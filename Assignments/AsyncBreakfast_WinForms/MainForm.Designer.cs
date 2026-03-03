namespace AsyncBreakfast_WinForms
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
            lblCoffeStatus = new Label();
            lblEggsStatus = new Label();
            lblBaconStatus = new Label();
            lblToastStatus = new Label();
            lblJuiceStatus = new Label();
            btnStart = new Button();
            SuspendLayout();
            // 
            // lblCoffeStatus
            // 
            lblCoffeStatus.AutoSize = true;
            lblCoffeStatus.Location = new Point(12, 9);
            lblCoffeStatus.Name = "lblCoffeStatus";
            lblCoffeStatus.Size = new Size(45, 20);
            lblCoffeStatus.TabIndex = 0;
            lblCoffeStatus.Text = "Кава:";
            // 
            // lblEggsStatus
            // 
            lblEggsStatus.AutoSize = true;
            lblEggsStatus.Location = new Point(12, 29);
            lblEggsStatus.Name = "lblEggsStatus";
            lblEggsStatus.Size = new Size(47, 20);
            lblEggsStatus.TabIndex = 1;
            lblEggsStatus.Text = "Яйця:";
            // 
            // lblBaconStatus
            // 
            lblBaconStatus.AutoSize = true;
            lblBaconStatus.Location = new Point(12, 49);
            lblBaconStatus.Name = "lblBaconStatus";
            lblBaconStatus.Size = new Size(54, 20);
            lblBaconStatus.TabIndex = 2;
            lblBaconStatus.Text = "Бекон:";
            // 
            // lblToastStatus
            // 
            lblToastStatus.AutoSize = true;
            lblToastStatus.Location = new Point(12, 69);
            lblToastStatus.Name = "lblToastStatus";
            lblToastStatus.Size = new Size(46, 20);
            lblToastStatus.TabIndex = 3;
            lblToastStatus.Text = "Тост: ";
            // 
            // lblJuiceStatus
            // 
            lblJuiceStatus.AutoSize = true;
            lblJuiceStatus.Location = new Point(12, 89);
            lblJuiceStatus.Name = "lblJuiceStatus";
            lblJuiceStatus.Size = new Size(32, 20);
            lblJuiceStatus.TabIndex = 4;
            lblJuiceStatus.Text = "Сік:";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 122);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(349, 76);
            btnStart.TabIndex = 5;
            btnStart.Text = "Розпочати приготування сніданку";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 210);
            Controls.Add(btnStart);
            Controls.Add(lblJuiceStatus);
            Controls.Add(lblToastStatus);
            Controls.Add(lblBaconStatus);
            Controls.Add(lblEggsStatus);
            Controls.Add(lblCoffeStatus);
            Name = "MainForm";
            Text = "Сніданок";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCoffeStatus;
        private Label lblEggsStatus;
        private Label lblBaconStatus;
        private Label lblToastStatus;
        private Label lblJuiceStatus;
        private Button btnStart;
    }
}
