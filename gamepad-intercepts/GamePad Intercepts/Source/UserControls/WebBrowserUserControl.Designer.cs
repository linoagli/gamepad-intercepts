namespace GamePad_Intercepts.UserControls
{
    partial class WebBrowserUserControl
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
            this.metroPanel_browserContainer = new MetroFramework.Controls.MetroPanel();
            this.metroLink_back = new MetroFramework.Controls.MetroLink();
            this.metroTextBox_url = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // metroPanel_browserContainer
            // 
            this.metroPanel_browserContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel_browserContainer.HorizontalScrollbarBarColor = true;
            this.metroPanel_browserContainer.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel_browserContainer.HorizontalScrollbarSize = 10;
            this.metroPanel_browserContainer.Location = new System.Drawing.Point(3, 3);
            this.metroPanel_browserContainer.Name = "metroPanel_browserContainer";
            this.metroPanel_browserContainer.Size = new System.Drawing.Size(1148, 573);
            this.metroPanel_browserContainer.TabIndex = 0;
            this.metroPanel_browserContainer.VerticalScrollbarBarColor = true;
            this.metroPanel_browserContainer.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_browserContainer.VerticalScrollbarSize = 10;
            // 
            // metroLink_back
            // 
            this.metroLink_back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.metroLink_back.Image = global::GamePad_Intercepts.Properties.Resources.ic_back_black;
            this.metroLink_back.ImageSize = 32;
            this.metroLink_back.Location = new System.Drawing.Point(3, 582);
            this.metroLink_back.Name = "metroLink_back";
            this.metroLink_back.Size = new System.Drawing.Size(32, 36);
            this.metroLink_back.TabIndex = 1;
            this.metroLink_back.UseSelectable = true;
            this.metroLink_back.Click += new System.EventHandler(this.metroLink_back_Click);
            // 
            // metroTextBox_url
            // 
            this.metroTextBox_url.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.metroTextBox_url.CustomButton.Image = null;
            this.metroTextBox_url.CustomButton.Location = new System.Drawing.Point(1076, 2);
            this.metroTextBox_url.CustomButton.Name = "";
            this.metroTextBox_url.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.metroTextBox_url.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_url.CustomButton.TabIndex = 1;
            this.metroTextBox_url.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_url.CustomButton.UseSelectable = true;
            this.metroTextBox_url.CustomButton.Visible = false;
            this.metroTextBox_url.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.metroTextBox_url.Lines = new string[0];
            this.metroTextBox_url.Location = new System.Drawing.Point(41, 582);
            this.metroTextBox_url.MaxLength = 32767;
            this.metroTextBox_url.Name = "metroTextBox_url";
            this.metroTextBox_url.PasswordChar = '\0';
            this.metroTextBox_url.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_url.SelectedText = "";
            this.metroTextBox_url.SelectionLength = 0;
            this.metroTextBox_url.SelectionStart = 0;
            this.metroTextBox_url.ShortcutsEnabled = true;
            this.metroTextBox_url.Size = new System.Drawing.Size(1110, 36);
            this.metroTextBox_url.TabIndex = 2;
            this.metroTextBox_url.UseSelectable = true;
            this.metroTextBox_url.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_url.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox_url.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metroTextBox_url_KeyUp);
            // 
            // WebBrowserUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTextBox_url);
            this.Controls.Add(this.metroLink_back);
            this.Controls.Add(this.metroPanel_browserContainer);
            this.Name = "WebBrowserUserControl";
            this.Size = new System.Drawing.Size(1154, 621);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel_browserContainer;
        private MetroFramework.Controls.MetroLink metroLink_back;
        private MetroFramework.Controls.MetroTextBox metroTextBox_url;
    }
}
