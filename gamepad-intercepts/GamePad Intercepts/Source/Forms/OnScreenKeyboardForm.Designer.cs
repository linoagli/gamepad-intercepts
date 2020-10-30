namespace GamePad_Intercepts.Forms
{
    partial class OnScreenKeyboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.keyboard = new GamePad_Intercepts_Keyboard.WinForms.Keyboard();
            this.SuspendLayout();
            // 
            // keyboard
            // 
            this.keyboard.BackColor = System.Drawing.Color.Black;
            this.keyboard.Location = new System.Drawing.Point(1, 1);
            this.keyboard.Margin = new System.Windows.Forms.Padding(0);
            this.keyboard.MaximumSize = new System.Drawing.Size(705, 355);
            this.keyboard.MinimumSize = new System.Drawing.Size(705, 355);
            this.keyboard.Name = "keyboard";
            this.keyboard.Padding = new System.Windows.Forms.Padding(5);
            this.keyboard.Size = new System.Drawing.Size(705, 355);
            this.keyboard.TabIndex = 2;
            // 
            // OnScreenKeyboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(707, 357);
            this.Controls.Add(this.keyboard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OnScreenKeyboardForm";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Text = "OnScreenKeyboardForm";
            this.TransparencyKey = System.Drawing.Color.Blue;
            this.ResumeLayout(false);

        }

        #endregion

        private GamePad_Intercepts_Keyboard.WinForms.Keyboard keyboard;
    }
}