namespace GamePad_Intercepts.Forms.UserControls.WifiSetup
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
            this.SuspendLayout();
            // 
            // flowLayoutPanel_accessPointList
            // 
            this.flowLayoutPanel_accessPointList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel_accessPointList.AutoScroll = true;
            this.flowLayoutPanel_accessPointList.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel_accessPointList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_accessPointList.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel_accessPointList.Name = "flowLayoutPanel_accessPointList";
            this.flowLayoutPanel_accessPointList.Size = new System.Drawing.Size(872, 462);
            this.flowLayoutPanel_accessPointList.TabIndex = 1;
            this.flowLayoutPanel_accessPointList.WrapContents = false;
            this.flowLayoutPanel_accessPointList.Resize += new System.EventHandler(this.flowLayoutPanel_accessPointList_Resize);
            // 
            // WifiAccessPointListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.flowLayoutPanel_accessPointList);
            this.Name = "WifiAccessPointListUserControl";
            this.Size = new System.Drawing.Size(878, 468);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_accessPointList;
    }
}
