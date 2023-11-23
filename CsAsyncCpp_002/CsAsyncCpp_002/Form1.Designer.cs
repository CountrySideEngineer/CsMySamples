namespace CsAsyncCpp_002
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
            this.startTimerButton1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressTimer1 = new System.Windows.Forms.Timer(this.components);
            this.startTimerButton2 = new System.Windows.Forms.Button();
            this.progressTimer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // startTimerButton1
            // 
            this.startTimerButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startTimerButton1.Location = new System.Drawing.Point(12, 41);
            this.startTimerButton1.Name = "startTimerButton1";
            this.startTimerButton1.Size = new System.Drawing.Size(387, 61);
            this.startTimerButton1.TabIndex = 0;
            this.startTimerButton1.Text = "START TIMER1";
            this.startTimerButton1.UseVisualStyleBackColor = true;
            this.startTimerButton1.Click += new System.EventHandler(this.startTimerButton1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(776, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // progressTimer1
            // 
            this.progressTimer1.Enabled = true;
            this.progressTimer1.Interval = 200;
            // 
            // startTimerButton2
            // 
            this.startTimerButton2.Location = new System.Drawing.Point(405, 41);
            this.startTimerButton2.Name = "startTimerButton2";
            this.startTimerButton2.Size = new System.Drawing.Size(383, 61);
            this.startTimerButton2.TabIndex = 2;
            this.startTimerButton2.Text = "START TIMER2";
            this.startTimerButton2.UseVisualStyleBackColor = true;
            this.startTimerButton2.Click += new System.EventHandler(this.startTimerButton2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 119);
            this.Controls.Add(this.startTimerButton2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.startTimerButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startTimerButton1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer progressTimer1;
        private System.Windows.Forms.Button startTimerButton2;
        private System.Windows.Forms.Timer progressTimer2;
    }
}

