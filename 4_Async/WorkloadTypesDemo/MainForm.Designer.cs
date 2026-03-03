namespace WorkloadTypesDemo
{
    partial class MainForm
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
            btnCpuBound = new Button();
            btnIoBound = new Button();
            lblStatus = new Label();
            prgDemo = new ProgressBar();
            SuspendLayout();
            // 
            // btnCpuBound
            // 
            btnCpuBound.Location = new Point(39, 93);
            btnCpuBound.Name = "btnCpuBound";
            btnCpuBound.Size = new Size(300, 75);
            btnCpuBound.TabIndex = 0;
            btnCpuBound.Text = "Start CPU-bound task";
            btnCpuBound.UseVisualStyleBackColor = true;
            btnCpuBound.Click += btnCpuBound_Click;
            // 
            // btnIoBound
            // 
            btnIoBound.Location = new Point(39, 174);
            btnIoBound.Name = "btnIoBound";
            btnIoBound.Size = new Size(300, 75);
            btnIoBound.TabIndex = 1;
            btnIoBound.Text = "Start I/O-bound task";
            btnIoBound.UseVisualStyleBackColor = true;
            btnIoBound.Click += btnIoBound_ClickAsync;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(39, 9);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(55, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Статус:";
            // 
            // prgDemo
            // 
            prgDemo.Location = new Point(39, 47);
            prgDemo.Name = "prgDemo";
            prgDemo.Size = new Size(300, 29);
            prgDemo.Style = ProgressBarStyle.Marquee;
            prgDemo.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 265);
            Controls.Add(prgDemo);
            Controls.Add(lblStatus);
            Controls.Add(btnIoBound);
            Controls.Add(btnCpuBound);
            Name = "MainForm";
            Text = "CPU-bound vs. I/O-bound";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCpuBound;
        private Button btnIoBound;
        private Label lblStatus;
        private ProgressBar prgDemo;
    }
}
