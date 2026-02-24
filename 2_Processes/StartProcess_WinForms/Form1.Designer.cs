namespace StartProcess_WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            startBtn = new Button();
            closeBtn = new Button();
            calcProcess = new System.Diagnostics.Process();
            SuspendLayout();
            // 
            // startBtn
            // 
            startBtn.Location = new Point(54, 31);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(94, 29);
            startBtn.TabIndex = 0;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // closeBtn
            // 
            closeBtn.Enabled = false;
            closeBtn.Location = new Point(54, 78);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(94, 29);
            closeBtn.TabIndex = 1;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // calcProcess
            // 
            calcProcess.StartInfo.CreateNewProcessGroup = false;
            calcProcess.StartInfo.Domain = "";
            calcProcess.StartInfo.LoadUserProfile = false;
            calcProcess.StartInfo.Password = null;
            calcProcess.StartInfo.StandardErrorEncoding = null;
            calcProcess.StartInfo.StandardInputEncoding = null;
            calcProcess.StartInfo.StandardOutputEncoding = null;
            calcProcess.StartInfo.UseCredentialsForNetworkingOnly = false;
            calcProcess.StartInfo.UserName = "";
            calcProcess.SynchronizingObject = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(205, 153);
            Controls.Add(closeBtn);
            Controls.Add(startBtn);
            Name = "Form1";
            Text = "Process Starter";
            ResumeLayout(false);
        }

        #endregion

        private Button startBtn;
        private Button closeBtn;
        private System.Diagnostics.Process calcProcess;
    }
}
