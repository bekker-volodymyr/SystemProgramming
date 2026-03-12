namespace MagicOracleWF
{
    partial class MagicOracle
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
            txtQuestion = new TextBox();
            txtAnswer = new TextBox();
            btnAsk = new Button();
            SuspendLayout();
            // 
            // txtQuestion
            // 
            txtQuestion.Location = new Point(12, 12);
            txtQuestion.Name = "txtQuestion";
            txtQuestion.Size = new Size(776, 23);
            txtQuestion.TabIndex = 0;
            // 
            // txtAnswer
            // 
            txtAnswer.Enabled = false;
            txtAnswer.Location = new Point(12, 41);
            txtAnswer.Name = "txtAnswer";
            txtAnswer.Size = new Size(776, 23);
            txtAnswer.TabIndex = 1;
            // 
            // btnAsk
            // 
            btnAsk.Location = new Point(12, 70);
            btnAsk.Name = "btnAsk";
            btnAsk.Size = new Size(776, 23);
            btnAsk.TabIndex = 2;
            btnAsk.Text = "Запитати!";
            btnAsk.UseVisualStyleBackColor = true;
            btnAsk.Click += btnAsk_Click;
            // 
            // MagicOracle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 116);
            Controls.Add(btnAsk);
            Controls.Add(txtAnswer);
            Controls.Add(txtQuestion);
            Name = "MagicOracle";
            Text = "Magic Oracle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtQuestion;
        private TextBox txtAnswer;
        private Button btnAsk;
    }
}
