namespace GamePad_Intercepts.UserControls.WifiSetup
{
    partial class WifiSetupProgressUserControl
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
            this.metroLabel_message = new MetroFramework.Controls.MetroLabel();
            this.metroButton_done = new MetroFramework.Controls.MetroButton();
            this.metroPanel_controlsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel_controlsContainer
            // 
            this.metroPanel_controlsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel_controlsContainer.Controls.Add(this.metroLabel_message);
            this.metroPanel_controlsContainer.Controls.Add(this.metroButton_done);
            this.metroPanel_controlsContainer.HorizontalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.HorizontalScrollbarSize = 10;
            this.metroPanel_controlsContainer.Location = new System.Drawing.Point(100, 150);
            this.metroPanel_controlsContainer.Name = "metroPanel_controlsContainer";
            this.metroPanel_controlsContainer.Size = new System.Drawing.Size(600, 100);
            this.metroPanel_controlsContainer.TabIndex = 6;
            this.metroPanel_controlsContainer.VerticalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.VerticalScrollbarSize = 10;
            // 
            // metroLabel_message
            // 
            this.metroLabel_message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel_message.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel_message.Location = new System.Drawing.Point(3, 9);
            this.metroLabel_message.Name = "metroLabel_message";
            this.metroLabel_message.Size = new System.Drawing.Size(594, 32);
            this.metroLabel_message.TabIndex = 3;
            this.metroLabel_message.Text = "No message";
            this.metroLabel_message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroButton_done
            // 
            this.metroButton_done.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton_done.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_done.Location = new System.Drawing.Point(3, 61);
            this.metroButton_done.Name = "metroButton_done";
            this.metroButton_done.Size = new System.Drawing.Size(594, 36);
            this.metroButton_done.TabIndex = 1;
            this.metroButton_done.Text = "Done";
            this.metroButton_done.UseSelectable = true;
            this.metroButton_done.Click += new System.EventHandler(this.metroButton_done_Click);
            // 
            // WifiSetupProgressUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel_controlsContainer);
            this.Name = "WifiSetupProgressUserControl";
            this.Size = new System.Drawing.Size(795, 435);
            this.metroPanel_controlsContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel_controlsContainer;
        private MetroFramework.Controls.MetroLabel metroLabel_message;
        private MetroFramework.Controls.MetroButton metroButton_done;
    }
}
