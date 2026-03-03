namespace ParentProcess
{
    partial class ParentProcess
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
            startedLbx = new ListBox();
            availableLbx = new ListBox();
            startBtn = new Button();
            stopBtn = new Button();
            closeBtn = new Button();
            refreshBtn = new Button();
            runCalcBtn = new Button();
            SuspendLayout();
            // 
            // startedLbx
            // 
            startedLbx.FormattingEnabled = true;
            startedLbx.Location = new Point(12, 12);
            startedLbx.Name = "startedLbx";
            startedLbx.Size = new Size(120, 199);
            startedLbx.TabIndex = 0;
            startedLbx.SelectedIndexChanged += startedLbx_SelectedIndexChanged;
            // 
            // availableLbx
            // 
            availableLbx.FormattingEnabled = true;
            availableLbx.Location = new Point(285, 12);
            availableLbx.Name = "availableLbx";
            availableLbx.Size = new Size(120, 199);
            availableLbx.TabIndex = 1;
            availableLbx.SelectedIndexChanged += availableLbx_SelectedIndexChanged;
            // 
            // startBtn
            // 
            startBtn.Enabled = false;
            startBtn.Location = new Point(138, 12);
            startBtn.Name = "startBtn";
            startBtn.Size = new Size(141, 23);
            startBtn.TabIndex = 2;
            startBtn.Text = "Start";
            startBtn.UseVisualStyleBackColor = true;
            startBtn.Click += startBtn_Click;
            // 
            // stopBtn
            // 
            stopBtn.Enabled = false;
            stopBtn.Location = new Point(138, 41);
            stopBtn.Name = "stopBtn";
            stopBtn.Size = new Size(141, 23);
            stopBtn.TabIndex = 3;
            stopBtn.Text = "Stop";
            stopBtn.UseVisualStyleBackColor = true;
            stopBtn.Click += stopBtn_Click;
            // 
            // closeBtn
            // 
            closeBtn.Enabled = false;
            closeBtn.Location = new Point(138, 70);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(141, 23);
            closeBtn.TabIndex = 4;
            closeBtn.Text = "Close Window";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // refreshBtn
            // 
            refreshBtn.Enabled = false;
            refreshBtn.Location = new Point(138, 99);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(141, 23);
            refreshBtn.TabIndex = 5;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = true;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // runCalcBtn
            // 
            runCalcBtn.Location = new Point(138, 128);
            runCalcBtn.Name = "runCalcBtn";
            runCalcBtn.Size = new Size(141, 23);
            runCalcBtn.TabIndex = 6;
            runCalcBtn.Text = "Run Calc";
            runCalcBtn.UseVisualStyleBackColor = true;
            runCalcBtn.Click += runCalcBtn_Click;
            // 
            // ParentProcess
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(417, 252);
            Controls.Add(runCalcBtn);
            Controls.Add(refreshBtn);
            Controls.Add(closeBtn);
            Controls.Add(stopBtn);
            Controls.Add(startBtn);
            Controls.Add(availableLbx);
            Controls.Add(startedLbx);
            Name = "ParentProcess";
            Text = "Parent";
            FormClosing += ParentProcess_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private ListBox startedLbx;
        private ListBox availableLbx;
        private Button startBtn;
        private Button stopBtn;
        private Button closeBtn;
        private Button refreshBtn;
        private Button runCalcBtn;
    }
}
