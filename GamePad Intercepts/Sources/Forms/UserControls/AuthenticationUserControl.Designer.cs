namespace GamePad_Intercepts.Forms.UserControls
{
    partial class AuthenticationUserControl
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
            this.metroPanel_controlsContainer = new MetroFramework.Controls.MetroPanel();
            this.metroLabel_callToAction = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_greetingMessage = new MetroFramework.Controls.MetroLabel();
            this.metroButton_login = new MetroFramework.Controls.MetroButton();
            this.metroTextBox_password = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel_controlsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel_controlsContainer
            // 
            this.metroPanel_controlsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel_controlsContainer.Controls.Add(this.metroLabel_callToAction);
            this.metroPanel_controlsContainer.Controls.Add(this.metroLabel_greetingMessage);
            this.metroPanel_controlsContainer.Controls.Add(this.metroButton_login);
            this.metroPanel_controlsContainer.Controls.Add(this.metroTextBox_password);
            this.metroPanel_controlsContainer.HorizontalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.HorizontalScrollbarSize = 10;
            this.metroPanel_controlsContainer.Location = new System.Drawing.Point(200, 159);
            this.metroPanel_controlsContainer.Name = "metroPanel_controlsContainer";
            this.metroPanel_controlsContainer.Size = new System.Drawing.Size(600, 183);
            this.metroPanel_controlsContainer.TabIndex = 5;
            this.metroPanel_controlsContainer.VerticalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.VerticalScrollbarSize = 10;
            // 
            // metroLabel_callToAction
            // 
            this.metroLabel_callToAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel_callToAction.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel_callToAction.Location = new System.Drawing.Point(3, 52);
            this.metroLabel_callToAction.Name = "metroLabel_callToAction";
            this.metroLabel_callToAction.Size = new System.Drawing.Size(594, 29);
            this.metroLabel_callToAction.TabIndex = 2;
            this.metroLabel_callToAction.Text = "Enter your GamePad Intercept access code";
            this.metroLabel_callToAction.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel_greetingMessage
            // 
            this.metroLabel_greetingMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel_greetingMessage.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel_greetingMessage.Location = new System.Drawing.Point(3, 20);
            this.metroLabel_greetingMessage.Name = "metroLabel_greetingMessage";
            this.metroLabel_greetingMessage.Size = new System.Drawing.Size(594, 32);
            this.metroLabel_greetingMessage.TabIndex = 3;
            this.metroLabel_greetingMessage.Text = "Welcome back!";
            this.metroLabel_greetingMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroButton_login
            // 
            this.metroButton_login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton_login.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_login.Location = new System.Drawing.Point(3, 144);
            this.metroButton_login.Name = "metroButton_login";
            this.metroButton_login.Size = new System.Drawing.Size(594, 36);
            this.metroButton_login.TabIndex = 1;
            this.metroButton_login.Text = "Press Start";
            this.metroButton_login.UseSelectable = true;
            this.metroButton_login.Click += new System.EventHandler(this.metroButton_login_Click);
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
            this.metroTextBox_password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.metroTextBox_password_KeyUp);
            // 
            // AuthenticationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel_controlsContainer);
            this.Name = "AuthenticationUserControl";
            this.Size = new System.Drawing.Size(1000, 500);
            this.metroPanel_controlsContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel_controlsContainer;
        private MetroFramework.Controls.MetroLabel metroLabel_callToAction;
        private MetroFramework.Controls.MetroLabel metroLabel_greetingMessage;
        private MetroFramework.Controls.MetroButton metroButton_login;
        private MetroFramework.Controls.MetroTextBox metroTextBox_password;
    }
}
