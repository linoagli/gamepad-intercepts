namespace GamePad_Intercepts_Keyboard
{
    partial class Key
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_background = new System.Windows.Forms.Panel();
            this.panel_foreground = new System.Windows.Forms.Panel();
            this.panel_enabledIndicator = new System.Windows.Forms.Panel();
            this.label_character = new System.Windows.Forms.Label();
            this.panel_background.SuspendLayout();
            this.panel_foreground.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_background
            // 
            this.panel_background.BackColor = System.Drawing.Color.Black;
            this.panel_background.Controls.Add(this.panel_foreground);
            this.panel_background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_background.Location = new System.Drawing.Point(0, 0);
            this.panel_background.Name = "panel_background";
            this.panel_background.Size = new System.Drawing.Size(60, 60);
            this.panel_background.TabIndex = 0;
            // 
            // panel_foreground
            // 
            this.panel_foreground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_foreground.BackColor = System.Drawing.Color.White;
            this.panel_foreground.Controls.Add(this.panel_enabledIndicator);
            this.panel_foreground.Controls.Add(this.label_character);
            this.panel_foreground.Location = new System.Drawing.Point(5, 5);
            this.panel_foreground.Margin = new System.Windows.Forms.Padding(5);
            this.panel_foreground.Name = "panel_foreground";
            this.panel_foreground.Size = new System.Drawing.Size(50, 50);
            this.panel_foreground.TabIndex = 0;
            // 
            // panel_enabledIndicator
            // 
            this.panel_enabledIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_enabledIndicator.BackColor = System.Drawing.Color.Transparent;
            this.panel_enabledIndicator.Location = new System.Drawing.Point(5, 40);
            this.panel_enabledIndicator.Margin = new System.Windows.Forms.Padding(5);
            this.panel_enabledIndicator.Name = "panel_enabledIndicator";
            this.panel_enabledIndicator.Size = new System.Drawing.Size(40, 5);
            this.panel_enabledIndicator.TabIndex = 1;
            // 
            // label_character
            // 
            this.label_character.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_character.BackColor = System.Drawing.Color.Transparent;
            this.label_character.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_character.Location = new System.Drawing.Point(5, 5);
            this.label_character.Margin = new System.Windows.Forms.Padding(5, 5, 5, 0);
            this.label_character.Name = "label_character";
            this.label_character.Size = new System.Drawing.Size(40, 30);
            this.label_character.TabIndex = 0;
            this.label_character.Text = "*";
            this.label_character.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_character.UseMnemonic = false;
            // 
            // Key
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_background);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(60, 60);
            this.MinimumSize = new System.Drawing.Size(60, 60);
            this.Name = "Key";
            this.Size = new System.Drawing.Size(60, 60);
            this.panel_background.ResumeLayout(false);
            this.panel_foreground.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_background;
        protected System.Windows.Forms.Panel panel_foreground;
        protected System.Windows.Forms.Label label_character;
        protected System.Windows.Forms.Panel panel_enabledIndicator;
    }
}
