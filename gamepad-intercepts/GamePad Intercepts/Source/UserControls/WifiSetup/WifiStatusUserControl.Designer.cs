namespace GamePad_Intercepts.UserControls.WifiSetup
{
    partial class WifiStatusUserControl
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
            this.metroLabel_status = new MetroFramework.Controls.MetroLabel();
            this.metroButton_connect = new MetroFramework.Controls.MetroButton();
            this.metroButton_disconnect = new MetroFramework.Controls.MetroButton();
            this.metroPanel_controlsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel_controlsContainer
            // 
            this.metroPanel_controlsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel_controlsContainer.Controls.Add(this.metroButton_disconnect);
            this.metroPanel_controlsContainer.Controls.Add(this.metroLabel_status);
            this.metroPanel_controlsContainer.Controls.Add(this.metroButton_connect);
            this.metroPanel_controlsContainer.HorizontalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.HorizontalScrollbarSize = 10;
            this.metroPanel_controlsContainer.Location = new System.Drawing.Point(100, 100);
            this.metroPanel_controlsContainer.Name = "metroPanel_controlsContainer";
            this.metroPanel_controlsContainer.Size = new System.Drawing.Size(600, 183);
            this.metroPanel_controlsContainer.TabIndex = 5;
            this.metroPanel_controlsContainer.VerticalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.VerticalScrollbarSize = 10;
            // 
            // metroLabel_status
            // 
            this.metroLabel_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel_status.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel_status.Location = new System.Drawing.Point(3, 20);
            this.metroLabel_status.Name = "metroLabel_status";
            this.metroLabel_status.Size = new System.Drawing.Size(594, 32);
            this.metroLabel_status.TabIndex = 3;
            this.metroLabel_status.Text = "Not connected to the internet";
            this.metroLabel_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroButton_connect
            // 
            this.metroButton_connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton_connect.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_connect.Location = new System.Drawing.Point(3, 144);
            this.metroButton_connect.Name = "metroButton_connect";
            this.metroButton_connect.Size = new System.Drawing.Size(594, 36);
            this.metroButton_connect.TabIndex = 1;
            this.metroButton_connect.Text = "Connect to a Network";
            this.metroButton_connect.UseSelectable = true;
            this.metroButton_connect.Click += new System.EventHandler(this.metroButton_connect_Click);
            // 
            // metroButton_disconnect
            // 
            this.metroButton_disconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.metroButton_disconnect.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.metroButton_disconnect.Location = new System.Drawing.Point(3, 102);
            this.metroButton_disconnect.Name = "metroButton_disconnect";
            this.metroButton_disconnect.Size = new System.Drawing.Size(594, 36);
            this.metroButton_disconnect.TabIndex = 4;
            this.metroButton_disconnect.Text = "Disconnect from Network";
            this.metroButton_disconnect.UseSelectable = true;
            this.metroButton_disconnect.Click += new System.EventHandler(this.metroButton_disconnect_Click);
            // 
            // WifiStatusUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel_controlsContainer);
            this.Name = "WifiStatusUserControl";
            this.Size = new System.Drawing.Size(800, 400);
            this.metroPanel_controlsContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel_controlsContainer;
        private MetroFramework.Controls.MetroLabel metroLabel_status;
        private MetroFramework.Controls.MetroButton metroButton_connect;
        private MetroFramework.Controls.MetroButton metroButton_disconnect;
    }
}
