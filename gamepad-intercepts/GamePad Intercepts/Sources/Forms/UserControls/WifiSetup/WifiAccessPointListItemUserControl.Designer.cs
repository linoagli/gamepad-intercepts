namespace GamePad_Intercepts.Forms.UserControls.WifiSetup
{
    partial class WifiAccessPointListItemUserControl
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
            this.metroTile_accessPointButton = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // metroTile_accessPointButton
            // 
            this.metroTile_accessPointButton.ActiveControl = null;
            this.metroTile_accessPointButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTile_accessPointButton.Location = new System.Drawing.Point(3, 3);
            this.metroTile_accessPointButton.Name = "metroTile_accessPointButton";
            this.metroTile_accessPointButton.Size = new System.Drawing.Size(619, 92);
            this.metroTile_accessPointButton.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTile_accessPointButton.TabIndex = 0;
            this.metroTile_accessPointButton.Text = "Access Point Name\r\nSecured\r\nSignal Strength: 100%";
            this.metroTile_accessPointButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.metroTile_accessPointButton.UseSelectable = true;
            this.metroTile_accessPointButton.Click += new System.EventHandler(this.metroTile_accessPointButton_Click);
            // 
            // WifiAccessPointListItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTile_accessPointButton);
            this.Name = "WifiAccessPointListItemUserControl";
            this.Size = new System.Drawing.Size(625, 98);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile metroTile_accessPointButton;
    }
}
