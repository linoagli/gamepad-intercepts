namespace GamePad_Intercepts.Forms.UserControls
{
    partial class WifiSetupUserControl
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
            this.SuspendLayout();
            // 
            // metroPanel_controlsContainer
            // 
            this.metroPanel_controlsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel_controlsContainer.HorizontalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.HorizontalScrollbarSize = 10;
            this.metroPanel_controlsContainer.Location = new System.Drawing.Point(3, 3);
            this.metroPanel_controlsContainer.Name = "metroPanel_controlsContainer";
            this.metroPanel_controlsContainer.Size = new System.Drawing.Size(1095, 604);
            this.metroPanel_controlsContainer.TabIndex = 0;
            this.metroPanel_controlsContainer.VerticalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.VerticalScrollbarSize = 10;
            // 
            // WifiSetupUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel_controlsContainer);
            this.Name = "WifiSetupUserControl";
            this.Size = new System.Drawing.Size(1101, 610);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel_controlsContainer;
    }
}
