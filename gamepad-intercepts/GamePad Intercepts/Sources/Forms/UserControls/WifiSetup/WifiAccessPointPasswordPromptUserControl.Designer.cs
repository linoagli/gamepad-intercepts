namespace GamePad_Intercepts.Forms.UserControls.WifiSetup
{
    partial class WifiAccessPointPasswordPromptUserControl
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
            this.metroTextBox_password = new MetroFramework.Controls.MetroTextBox();
            this.metroButton_connect = new MetroFramework.Controls.MetroButton();
            this.metroLabel_label = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_accessPointName = new MetroFramework.Controls.MetroLabel();
            this.metroPanel_controlsContainer = new MetroFramework.Controls.MetroPanel();
            this.metroPanel_controlsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTextBox_password
            // 
            this.metroTextBox_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.metroTextBox_password.CustomButton.Image = null;
            this.metroTextBox_password.CustomButton.Location = new System.Drawing.Point(560, 2);
            this.metroTextBox_password.CustomButton.Name = "";
            this.metroTextBox_password.CustomButton.Size = new System.Drawing.Size(31, 31);
            this.metroTextBox_password.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox_password.CustomButton.TabIndex = 1;
            this.metroTextBox_password.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox_password.CustomButton.UseSelectable = true;
            this.metroTextBox_password.CustomButton.Visible = false;
            this.metroTextBox_password.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.metroTextBox_password.Lines = new string[0];
            this.metroTextBox_password.Location = new System.Drawing.Point(3, 102);
            this.metroTextBox_password.MaxLength = 32767;
            this.metroTextBox_password.Name = "metroTextBox_password";
            this.metroTextBox_password.PasswordChar = '+';
            this.metroTextBox_password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox_password.SelectedText = "";
            this.metroTextBox_password.SelectionLength = 0;
            this.metroTextBox_password.SelectionStart = 0;
            this.metroTextBox_password.ShortcutsEnabled = true;
            this.metroTextBox_password.Size = new System.Drawing.Size(594, 36);
            this.metroTextBox_password.TabIndex = 0;
            this.metroTextBox_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.metroTextBox_password.UseSelectable = true;
            this.metroTextBox_password.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox_password.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton_connect
            // 
            this.metroButton_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton_connect.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_connect.Location = new System.Drawing.Point(3, 144);
            this.metroButton_connect.Name = "metroButton_connect";
            this.metroButton_connect.Size = new System.Drawing.Size(594, 36);
            this.metroButton_connect.TabIndex = 1;
            this.metroButton_connect.Text = "Connect";
            this.metroButton_connect.UseSelectable = true;
            this.metroButton_connect.Click += new System.EventHandler(this.metroButton_connect_Click);
            // 
            // metroLabel_label
            // 
            this.metroLabel_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel_label.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel_label.Location = new System.Drawing.Point(3, 52);
            this.metroLabel_label.Name = "metroLabel_label";
            this.metroLabel_label.Size = new System.Drawing.Size(594, 29);
            this.metroLabel_label.TabIndex = 2;
            this.metroLabel_label.Text = "Enter the network security key";
            this.metroLabel_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel_accessPointName
            // 
            this.metroLabel_accessPointName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel_accessPointName.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel_accessPointName.Location = new System.Drawing.Point(3, 20);
            this.metroLabel_accessPointName.Name = "metroLabel_accessPointName";
            this.metroLabel_accessPointName.Size = new System.Drawing.Size(594, 32);
            this.metroLabel_accessPointName.TabIndex = 3;
            this.metroLabel_accessPointName.Text = "Access Point Name";
            this.metroLabel_accessPointName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroPanel_controlsContainer
            // 
            this.metroPanel_controlsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel_controlsContainer.Controls.Add(this.metroLabel_label);
            this.metroPanel_controlsContainer.Controls.Add(this.metroLabel_accessPointName);
            this.metroPanel_controlsContainer.Controls.Add(this.metroButton_connect);
            this.metroPanel_controlsContainer.Controls.Add(this.metroTextBox_password);
            this.metroPanel_controlsContainer.HorizontalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.HorizontalScrollbarSize = 10;
            this.metroPanel_controlsContainer.Location = new System.Drawing.Point(100, 100);
            this.metroPanel_controlsContainer.Name = "metroPanel_controlsContainer";
            this.metroPanel_controlsContainer.Size = new System.Drawing.Size(600, 183);
            this.metroPanel_controlsContainer.TabIndex = 4;
            this.metroPanel_controlsContainer.VerticalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.VerticalScrollbarSize = 10;
            // 
            // WifiAccessPointPasswordPromptUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel_controlsContainer);
            this.Name = "WifiAccessPointPasswordPromptUserControl";
            this.Size = new System.Drawing.Size(800, 400);
            this.metroPanel_controlsContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox metroTextBox_password;
        private MetroFramework.Controls.MetroButton metroButton_connect;
        private MetroFramework.Controls.MetroLabel metroLabel_label;
        private MetroFramework.Controls.MetroLabel metroLabel_accessPointName;
        private MetroFramework.Controls.MetroPanel metroPanel_controlsContainer;
    }
}
