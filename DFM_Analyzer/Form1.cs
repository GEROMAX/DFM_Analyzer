using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFM_Analyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnFileSelect1_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK.Equals(this.openFileDialog.ShowDialog()))
            {
                this.txtFilePath1.Text = this.openFileDialog.FileName;
            }
        }

        private void btnFileSelect2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK.Equals(this.openFileDialog.ShowDialog()))
            {
                this.txtFilePath2.Text = this.openFileDialog.FileName;
            }
        }

        private void txtPropertyName_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter.Equals(e.KeyCode))
            {
                this.btnAnalyze.PerformClick();
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFilePath1.Text) ||
                string.IsNullOrEmpty(this.txtFilePath2.Text) ||
                string.IsNullOrEmpty(this.txtPropertyName.Text))
            {
                return;
            }

            var analyzer1 = new DfmAnalyzer();
            var analyzer2 = new DfmAnalyzer();
            try
            {
                analyzer1.Analyze(this.txtFilePath1.Text);
                this.tv1.Nodes.Clear();
                this.AddTree(this.tv1.Nodes, analyzer1.DfmObject);
                this.tv1.ExpandAll();

                analyzer2.Analyze(this.txtFilePath2.Text);
                this.tv2.Nodes.Clear();
                this.AddTree(this.tv2.Nodes, analyzer2.DfmObject);
                this.tv2.ExpandAll();

                this.dgv.DataSource = analyzer1.CreatePropertyCompareData(this.txtPropertyName.Text, analyzer2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddTree(TreeNodeCollection nodes, DfmInfomation dfmInfo)
        {
            var nowNode = nodes.Add(dfmInfo.ObjectClass + "：" + dfmInfo.ObjectName);
            dfmInfo.ChildObjects.ForEach(info => this.AddTree(nowNode.Nodes, info));
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            if (null == this.dgv.DataSource)
            {
                return;
            }
            if (!DialogResult.OK.Equals(this.saveFileDialog.ShowDialog()))
            {
                return;
            }

            var data = (List<PropertyCompareData>)this.dgv.DataSource;
            var sb = new StringBuilder();
            sb.AppendLine("ファイル1：" + this.txtFilePath1.Text);
            sb.AppendLine("ファイル2：" + this.txtFilePath2.Text);
            sb.AppendLine("プロパティ：" + this.txtPropertyName.Text).AppendLine("");
            sb.AppendLine(string.Join(",", new string[] { "オブジェクト名", "ファイル1", "ファイル2", "比較結果" }));
            data.ForEach(item => sb.AppendLine(string.Join(",", new string[] { item.ObjectName, item.Value1, item.Value2, item.CompareResult })));
            File.WriteAllText(this.saveFileDialog.FileName, sb.ToString(), Encoding.GetEncoding("Shift_JIS"));
        }
    }

    public class DfmAnalyzer
    {
        public DfmInfomation DfmObject { get; private set; }

        public DfmAnalyzer()
        {
        }

        public void Analyze(string filePath)
        {
            this.DfmObject = new DfmInfomation(File.ReadAllText(filePath, Encoding.GetEncoding("Shift_JIS")));
        }

        public List<PropertyCompareData> CreatePropertyCompareData(string propertyName, DfmAnalyzer analyzer)
        {
            var list = new List<PropertyCompareData>();
            this.addPropertyCompareData(propertyName, this.DfmObject, analyzer.DfmObject, list);
            return list;
        }

        private void addPropertyCompareData(string propertyName, DfmInfomation dfmInfoA, DfmInfomation dfmInfoB, List<PropertyCompareData> list)
        {
            var compData = this.getPropertyCompareData(propertyName, dfmInfoA, dfmInfoB);
            if (!list.Exists(match => match.GetHashCode().Equals(compData.GetHashCode())))
            {
                list.Add(compData);
            }           

            if (null != dfmInfoA)
            {
                foreach (DfmInfomation dfmInfo in dfmInfoA.ChildObjects)
                {
                    var infoB = (dfmInfoB != null) ? dfmInfoB.ChildObjects.Find(match => dfmInfo.ObjectName.Equals(match.ObjectName)) : null;
                    this.addPropertyCompareData(propertyName, dfmInfo, infoB, list);
                }
            }
            if (null != dfmInfoB)
            {
                foreach (DfmInfomation dfmInfo in dfmInfoB.ChildObjects)
                {
                    var infoA = (dfmInfoA != null) ? dfmInfoA.ChildObjects.Find(match => dfmInfo.ObjectName.Equals(match.ObjectName)) : null;
                    this.addPropertyCompareData(propertyName, infoA, dfmInfo, list);
                }
            }
        }

        private PropertyCompareData getPropertyCompareData(string propertyName, DfmInfomation dfmInfoA, DfmInfomation dfmInfoB)
        {
            if (null == dfmInfoA)
            {
                return new PropertyCompareData(dfmInfoB.ObjectName, null, dfmInfoB[propertyName]);
            }
            else if (null == dfmInfoB)
            {
                return new PropertyCompareData(dfmInfoA.ObjectName, dfmInfoA[propertyName], null);
            }
            else
            {
                return new PropertyCompareData(dfmInfoA.ObjectName, dfmInfoA[propertyName], dfmInfoB[propertyName]);
            }
        }
    }

    public class PropertyCompareData
    {
        public string ObjectName { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string CompareResult
        {
            get
            {
                if (null == this.Value1 && null == this.Value2)
                {
                    return "No Property";
                }

                return string.Compare(this.Value1, this.Value2).Equals(0) ? "OK" : "NG";
            }
        }

        public PropertyCompareData(string name, string val1, string val2)
        {
            this.ObjectName = name;
            this.Value1 = val1;
            this.Value2 = val2;
        }

        public override int GetHashCode()
        {
            return this.ObjectName.GetHashCode();
        }
    }

    public class DfmInfomation : IComparable<DfmInfomation>
    {
        public const string PREFIX = "object ";
        public const string SUFIX = "end";
        public const string INDENT = "  ";
        public const string CRLF = "\r\n";

        public string ObjectName { get; set; }
        public string ObjectClass { get; set; }
        public string ObjectValue { get; set; }
        public string this[string propertyName]
        {
            get
            {
                return this.getPropertyValue(propertyName);
            }
        }
        public List<DfmInfomation> ChildObjects { get; set; }

        public DfmInfomation(string objValue)
        {
            if (!objValue.StartsWith(PREFIX))
            {
                throw new Exception("解析失敗");
            }

            var lines = objValue.Split(CRLF.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var objInfo = lines[0].Split(":".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            this.ObjectName = objInfo[0].TrimStart((PREFIX + " ").ToCharArray());
            this.ObjectClass = objInfo[1].TrimStart(" ".ToCharArray()).TrimEnd(CRLF.ToCharArray());

            var sb = new StringBuilder();
            foreach (string line in lines)
            {
                if (line.StartsWith(PREFIX) || line.Equals(SUFIX))
                {
                    continue;
                }
                sb.AppendLine(line.StartsWith(INDENT) ? line.Substring(2) : line);
            }
            this.ObjectValue = sb.ToString();
            
            var childFind = false;
            this.ChildObjects = new List<DfmInfomation>();
            var childLines = this.ObjectValue.Split(CRLF.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in childLines)
            {
                if (!childFind && line.StartsWith(PREFIX))
                {
                    childFind = true;
                    sb.Clear().AppendLine(line);                    
                }
                else if (childFind && line.Equals(SUFIX))
                {
                    childFind = false;
                    sb.AppendLine(line);
                    this.ChildObjects.Add(new DfmInfomation(sb.ToString()));
                    sb.Clear();
                }
                else if (childFind)
                {
                    sb.AppendLine(line);
                }
            }
            this.ChildObjects.Sort();
        }

        private string getPropertyValue(string propertyName)
        {
            var lines = this.ObjectValue.Split(CRLF.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();
            var find = false;
            foreach (string line in lines)
            {
                if (find && line.StartsWith(INDENT))
                {
                    sb.Append(line.TrimStart(INDENT.ToCharArray()).TrimEnd(CRLF.ToCharArray()));
                    continue;
                }
                else if (find)
                {
                    break;
                }

                if (!line.StartsWith(propertyName))
                {
                    continue;
                }
                else
                {
                    //見つけた
                    find = true;
                    //保持
                    sb.Append(line.TrimEnd(CRLF.ToCharArray()));
                    continue;
                }
            }
            if (sb.Length <= 0)
            {
                return null;
            }

            return sb.ToString().Split(" = ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1];
        }

        int IComparable<DfmInfomation>.CompareTo(DfmInfomation other)
        {
            var thisValue = this.ObjectClass + this.ObjectName;
            var otherValue = other.ObjectClass + other.ObjectName;
            return thisValue.CompareTo(otherValue);
        }
    }
}
