namespace DFM_Analyzer
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFileSelect1 = new System.Windows.Forms.Button();
            this.txtFilePath1 = new System.Windows.Forms.TextBox();
            this.txtFilePath2 = new System.Windows.Forms.TextBox();
            this.btnFileSelect2 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPropertyName = new System.Windows.Forms.TextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.tv1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.tv2 = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnOutput = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFileSelect1
            // 
            this.btnFileSelect1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileSelect1.Location = new System.Drawing.Point(1097, 8);
            this.btnFileSelect1.Name = "btnFileSelect1";
            this.btnFileSelect1.Size = new System.Drawing.Size(75, 23);
            this.btnFileSelect1.TabIndex = 0;
            this.btnFileSelect1.Text = "選択1";
            this.btnFileSelect1.UseVisualStyleBackColor = true;
            this.btnFileSelect1.Click += new System.EventHandler(this.btnFileSelect1_Click);
            // 
            // txtFilePath1
            // 
            this.txtFilePath1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath1.Location = new System.Drawing.Point(12, 12);
            this.txtFilePath1.Name = "txtFilePath1";
            this.txtFilePath1.ReadOnly = true;
            this.txtFilePath1.Size = new System.Drawing.Size(1079, 19);
            this.txtFilePath1.TabIndex = 1;
            // 
            // txtFilePath2
            // 
            this.txtFilePath2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath2.Location = new System.Drawing.Point(12, 37);
            this.txtFilePath2.Name = "txtFilePath2";
            this.txtFilePath2.ReadOnly = true;
            this.txtFilePath2.Size = new System.Drawing.Size(1079, 19);
            this.txtFilePath2.TabIndex = 3;
            // 
            // btnFileSelect2
            // 
            this.btnFileSelect2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileSelect2.Location = new System.Drawing.Point(1097, 33);
            this.btnFileSelect2.Name = "btnFileSelect2";
            this.btnFileSelect2.Size = new System.Drawing.Size(75, 23);
            this.btnFileSelect2.TabIndex = 2;
            this.btnFileSelect2.Text = "選択2";
            this.btnFileSelect2.UseVisualStyleBackColor = true;
            this.btnFileSelect2.Click += new System.EventHandler(this.btnFileSelect2_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "DFM (*.dfm)|*.dfm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "対象プロパティ";
            // 
            // txtPropertyName
            // 
            this.txtPropertyName.Location = new System.Drawing.Point(89, 70);
            this.txtPropertyName.Name = "txtPropertyName";
            this.txtPropertyName.Size = new System.Drawing.Size(273, 19);
            this.txtPropertyName.TabIndex = 5;
            this.txtPropertyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPropertyName_KeyDown);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(368, 68);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyze.TabIndex = 6;
            this.btnAnalyze.Text = "解析";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // tv1
            // 
            this.tv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tv1.Location = new System.Drawing.Point(12, 129);
            this.tv1.Name = "tv1";
            this.tv1.Size = new System.Drawing.Size(300, 621);
            this.tv1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "ファイル1";
            // 
            // tv2
            // 
            this.tv2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv2.Location = new System.Drawing.Point(872, 129);
            this.tv2.Name = "tv2";
            this.tv2.Size = new System.Drawing.Size(300, 621);
            this.tv2.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(870, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "ファイル2";
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(318, 129);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 21;
            this.dgv.Size = new System.Drawing.Size(548, 621);
            this.dgv.TabIndex = 11;
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(449, 68);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 12;
            this.btnOutput.Text = "出力";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "txt|*.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tv2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tv1);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.txtPropertyName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFilePath2);
            this.Controls.Add(this.btnFileSelect2);
            this.Controls.Add(this.txtFilePath1);
            this.Controls.Add(this.btnFileSelect1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFileSelect1;
        private System.Windows.Forms.TextBox txtFilePath1;
        private System.Windows.Forms.TextBox txtFilePath2;
        private System.Windows.Forms.Button btnFileSelect2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPropertyName;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.TreeView tv1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView tv2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

