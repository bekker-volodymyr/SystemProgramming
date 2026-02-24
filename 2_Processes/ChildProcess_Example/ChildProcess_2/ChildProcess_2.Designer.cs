namespace ChildProcess_2
{
    partial class ChildProcess_2
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
            processLbl = new Label();
            SuspendLayout();
            // 
            // processLbl
            // 
            processLbl.AutoSize = true;
            processLbl.Location = new Point(12, 9);
            processLbl.Name = "processLbl";
            processLbl.Size = new Size(56, 15);
            processLbl.TabIndex = 0;
            processLbl.Text = "Process 2";
            // 
            // ChildProcess_2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(493, 164);
            Controls.Add(processLbl);
            Name = "ChildProcess_2";
            Text = "Child Process #2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label processLbl;
    }
}
