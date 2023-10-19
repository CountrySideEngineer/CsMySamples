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
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.buttonStart = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.progressTitle = new System.Windows.Forms.Label();
			this.progressValue = new System.Windows.Forms.Label();
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
			this.buttonStart.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.buttonStart.Location = new System.Drawing.Point(20, 87);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(120, 40);
			this.buttonStart.TabIndex = 0;
			this.buttonStart.Text = "START";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.button1_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Enabled = false;
			this.buttonCancel.Location = new System.Drawing.Point(165, 87);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(120, 40);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "CANCEL";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// progressTitle
			// 
			this.progressTitle.AutoSize = true;
			this.progressTitle.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.progressTitle.Location = new System.Drawing.Point(16, 27);
			this.progressTitle.Name = "progressTitle";
			this.progressTitle.Padding = new System.Windows.Forms.Padding(8);
			this.progressTitle.Size = new System.Drawing.Size(114, 37);
			this.progressTitle.TabIndex = 2;
			this.progressTitle.Text = "PROGRESS";
			this.progressTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// progressValue
			// 
			this.progressValue.AutoSize = true;
			this.progressValue.BackColor = System.Drawing.Color.White;
			this.progressValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.progressValue.Font = new System.Drawing.Font("ＭＳ ゴシック", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.progressValue.Location = new System.Drawing.Point(149, 17);
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
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(305, 147);
			this.Controls.Add(this.progressValue);
			this.Controls.Add(this.progressTitle);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonStart);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.Text = "ProgressWindows";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label progressTitle;
		private System.Windows.Forms.Label progressValue;
	}
}

