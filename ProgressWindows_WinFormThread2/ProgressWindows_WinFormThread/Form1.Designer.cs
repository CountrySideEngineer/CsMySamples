namespace ProgressWindows_WinFormThread2
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
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.tableItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewProgressBarColumn1 = new ProgressWindows_WinForm.DataGridViewProgressBarColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCheckedDataGridColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nameDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressDataGridColumn = new ProgressWindows_WinForm.DataGridViewProgressBarColumn();
            this.resultDataGridColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isCheckedDataGridColumn,
            this.nameDataGridColumn,
            this.progressDataGridColumn,
            this.resultDataGridColumn});
            this.dataView.DataSource = this.tableItemBindingSource;
            this.dataView.Location = new System.Drawing.Point(12, 12);
            this.dataView.Name = "dataView";
            this.dataView.RowTemplate.Height = 21;
            this.dataView.Size = new System.Drawing.Size(776, 317);
            this.dataView.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(713, 335);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "IsChecked";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 59;
            // 
            // dataGridViewProgressBarColumn1
            // 
            this.dataGridViewProgressBarColumn1.HeaderText = "Progress";
            this.dataGridViewProgressBarColumn1.Maximum = 100;
            this.dataGridViewProgressBarColumn1.Mimimum = 0;
            this.dataGridViewProgressBarColumn1.Name = "dataGridViewProgressBarColumn1";
            this.dataGridViewProgressBarColumn1.ReadOnly = true;
            this.dataGridViewProgressBarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProgressBarColumn1.Width = 511;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Result";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 63;
            // 
            // isCheckedDataGridColumn
            // 
            this.isCheckedDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.isCheckedDataGridColumn.DataPropertyName = "IsChecked";
            this.isCheckedDataGridColumn.HeaderText = "IsChecked";
            this.isCheckedDataGridColumn.Name = "isCheckedDataGridColumn";
            this.isCheckedDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.isCheckedDataGridColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isCheckedDataGridColumn.Width = 83;
            // 
            // nameDataGridColumn
            // 
            this.nameDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridColumn.DataPropertyName = "Name";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.nameDataGridColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.nameDataGridColumn.HeaderText = "Name";
            this.nameDataGridColumn.Name = "nameDataGridColumn";
            this.nameDataGridColumn.ReadOnly = true;
            // 
            // progressDataGridColumn
            // 
            this.progressDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.progressDataGridColumn.DataPropertyName = "Progress";
            this.progressDataGridColumn.HeaderText = "Progress";
            this.progressDataGridColumn.Maximum = 100;
            this.progressDataGridColumn.Mimimum = 0;
            this.progressDataGridColumn.Name = "progressDataGridColumn";
            this.progressDataGridColumn.ReadOnly = true;
            this.progressDataGridColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // resultDataGridColumn
            // 
            this.resultDataGridColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.resultDataGridColumn.DataPropertyName = "ResultCode";
            this.resultDataGridColumn.HeaderText = "Result";
            this.resultDataGridColumn.Name = "resultDataGridColumn";
            this.resultDataGridColumn.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 382);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableItemBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private ProgressWindows_WinForm.DataGridViewProgressBarColumn dataGridViewProgressBarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource tableItemBindingSource;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckedDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridColumn;
        private ProgressWindows_WinForm.DataGridViewProgressBarColumn progressDataGridColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultDataGridColumn;
    }
}

