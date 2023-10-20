namespace ProgressWindows_WinForm
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
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.progressTitle = new System.Windows.Forms.Label();
			this.progressValue = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.parameterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.isCheckedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ItemTableGridView = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tableItemBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemTableGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerReportsProgress = true;
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
			this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
			// 
			// buttonStart
			// 
			this.buttonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonStart.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.buttonStart.Location = new System.Drawing.Point(615, 3);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(120, 40);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "START";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Enabled = false;
			this.buttonCancel.Location = new System.Drawing.Point(741, 3);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(120, 40);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "CANCEL";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// progressTitle
			// 
			this.progressTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressTitle.AutoSize = true;
			this.progressTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.progressTitle.Location = new System.Drawing.Point(3, 17);
			this.progressTitle.Name = "progressTitle";
			this.progressTitle.Padding = new System.Windows.Forms.Padding(8);
			this.progressTitle.Size = new System.Drawing.Size(114, 37);
			this.progressTitle.TabIndex = 2;
			this.progressTitle.Text = "PROGRESS";
			this.progressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// progressValue
			// 
			this.progressValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressValue.AutoSize = true;
			this.progressValue.BackColor = System.Drawing.Color.White;
			this.progressValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.progressValue.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.progressValue.Location = new System.Drawing.Point(128, 8);
			this.progressValue.Margin = new System.Windows.Forms.Padding(8);
			this.progressValue.MaximumSize = new System.Drawing.Size(136, 56);
			this.progressValue.MinimumSize = new System.Drawing.Size(136, 56);
			this.progressValue.Name = "progressValue";
			this.progressValue.Padding = new System.Windows.Forms.Padding(16);
			this.progressValue.Size = new System.Drawing.Size(136, 56);
			this.progressValue.TabIndex = 3;
			this.progressValue.Text = "0";
			this.progressValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(12, 12);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.ItemTableGridView);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.buttonStart);
			this.splitContainer1.Panel2.Controls.Add(this.progressTitle);
			this.splitContainer1.Panel2.Controls.Add(this.progressValue);
			this.splitContainer1.Panel2.Controls.Add(this.buttonCancel);
			this.splitContainer1.Size = new System.Drawing.Size(864, 504);
			this.splitContainer1.SplitterDistance = 252;
			this.splitContainer1.TabIndex = 4;
			// 
			// tableItemBindingSource
			// 
			this.tableItemBindingSource.DataSource = typeof(ProgressWindows_WinForm.TableItem);
			// 
			// nameDataGridViewTextBoxColumn
			// 
			this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
			this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
			this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
			// 
			// parameterDataGridViewTextBoxColumn
			// 
			this.parameterDataGridViewTextBoxColumn.DataPropertyName = "Parameter";
			this.parameterDataGridViewTextBoxColumn.HeaderText = "Parameter";
			this.parameterDataGridViewTextBoxColumn.Name = "parameterDataGridViewTextBoxColumn";
			// 
			// isCheckedDataGridViewCheckBoxColumn
			// 
			this.isCheckedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.isCheckedDataGridViewCheckBoxColumn.DataPropertyName = "IsChecked";
			this.isCheckedDataGridViewCheckBoxColumn.HeaderText = "IsChecked";
			this.isCheckedDataGridViewCheckBoxColumn.Name = "isCheckedDataGridViewCheckBoxColumn";
			// 
			// ItemTableGridView
			// 
			this.ItemTableGridView.AllowUserToAddRows = false;
			this.ItemTableGridView.AllowUserToDeleteRows = false;
			this.ItemTableGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ItemTableGridView.AutoGenerateColumns = false;
			this.ItemTableGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.ItemTableGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.ItemTableGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.ItemTableGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isCheckedDataGridViewCheckBoxColumn,
            this.parameterDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
			this.ItemTableGridView.DataSource = this.tableItemBindingSource;
			this.ItemTableGridView.Location = new System.Drawing.Point(3, 3);
			this.ItemTableGridView.Name = "ItemTableGridView";
			this.ItemTableGridView.RowTemplate.Height = 21;
			this.ItemTableGridView.Size = new System.Drawing.Size(858, 246);
			this.ItemTableGridView.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(888, 528);
			this.Controls.Add(this.splitContainer1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "ProgressWindows";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.tableItemBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ItemTableGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label progressTitle;
		private System.Windows.Forms.Label progressValue;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.BindingSource tableItemBindingSource;
		private System.Windows.Forms.DataGridView ItemTableGridView;
		private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckedDataGridViewCheckBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn parameterDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
	}
}

