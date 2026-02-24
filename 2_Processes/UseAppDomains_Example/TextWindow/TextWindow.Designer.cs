namespace TextWindow
{
    partial class TextWindow
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
            txtField = new TextBox();
            SuspendLayout();
            // 
            // txtField
            // 
            txtField.Location = new Point(12, 12);
            txtField.Name = "txtField";
            txtField.Size = new Size(450, 23);
            txtField.TabIndex = 0;
            txtField.TextChanged += txtField_TextChanged;
            // 
            // TextWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 47);
            Controls.Add(txtField);
            Name = "TextWindow";
            Text = "TextWindow";
            LocationChanged += TextWindow_LocationChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtField;
    }
}
