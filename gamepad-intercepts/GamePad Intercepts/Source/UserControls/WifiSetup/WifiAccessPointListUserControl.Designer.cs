namespace GamePad_Intercepts.UserControls.WifiSetup
{
    partial class WifiAccessPointListUserControl
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
            this.flowLayoutPanel_accessPointList = new System.Windows.Forms.FlowLayoutPanel();
            this.metroLabel_availableAccessPoints = new MetroFramework.Controls.MetroLabel();
            this.metroLink_refresh = new MetroFramework.Controls.MetroLink();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_accessPointList
            // 
            this.flowLayoutPanel_accessPointList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.flowLayoutPanel_accessPointList.AutoScroll = true;
            this.flowLayoutPanel_accessPointList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel_accessPointList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_accessPointList.Location = new System.Drawing.Point(50, 134);
            this.flowLayoutPanel_accessPointList.Name = "flowLayoutPanel_accessPointList";
            this.flowLayoutPanel_accessPointList.Size = new System.Drawing.Size(1000, 371);
            this.flowLayoutPanel_accessPointList.TabIndex = 1;
            this.flowLayoutPanel_accessPointList.WrapContents = false;
            this.flowLayoutPanel_accessPointList.Resize += new System.EventHandler(this.flowLayoutPanel_accessPointList_Resize);
            // 
            // metroLabel_availableAccessPoints
            // 
            this.metroLabel_availableAccessPoints.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroLabel_availableAccessPoints.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel_availableAccessPoints.Location = new System.Drawing.Point(88, 96);
            this.metroLabel_availableAccessPoints.Name = "metroLabel_availableAccessPoints";
            this.metroLabel_availableAccessPoints.Size = new System.Drawing.Size(924, 32);
            this.metroLabel_availableAccessPoints.TabIndex = 4;
            this.metroLabel_availableAccessPoints.Text = "Available Access Points";
            this.metroLabel_availableAccessPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLink_refresh
            // 
            this.metroLink_refresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroLink_refresh.Image = global::GamePad_Intercepts.Properties.Resources.ic_refresh;
            this.metroLink_refresh.ImageSize = 32;
            this.metroLink_refresh.Location = new System.Drawing.Point(1018, 92);
            this.metroLink_refresh.Name = "metroLink_refresh";
            this.metroLink_refresh.Size = new System.Drawing.Size(32, 36);
            this.metroLink_refresh.TabIndex = 5;
            this.metroLink_refresh.UseSelectable = true;
            this.metroLink_refresh.Click += new System.EventHandler(this.metroLink_refresh_Click);
            // 
            // WifiAccessPointListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.metroLink_refresh);
            this.Controls.Add(this.metroLabel_availableAccessPoints);
            this.Controls.Add(this.flowLayoutPanel_accessPointList);
            this.Name = "WifiAccessPointListUserControl";
            this.Size = new System.Drawing.Size(1100, 550);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_accessPointList;
        private MetroFramework.Controls.MetroLabel metroLabel_availableAccessPoints;
        private MetroFramework.Controls.MetroLink metroLink_refresh;
    }
}
