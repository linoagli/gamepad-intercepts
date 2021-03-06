﻿namespace GamePad_Intercepts.UserControls
{
    partial class HomeUserControl
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
            this.metroPanel_statusDisplayArea = new MetroFramework.Controls.MetroPanel();
            this.metroLabel_systemVolumeStatus = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_networkStatus = new MetroFramework.Controls.MetroLabel();
            this.metroLabel_powerStatus = new MetroFramework.Controls.MetroLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroPanel_mainOptions = new MetroFramework.Controls.MetroPanel();
            this.metroTile_powerOptions = new MetroFramework.Controls.MetroTile();
            this.metroTile_soundSettings = new MetroFramework.Controls.MetroTile();
            this.metroTile_launchGamePlatform = new MetroFramework.Controls.MetroTile();
            this.metroTile_wifiSettings = new MetroFramework.Controls.MetroTile();
            this.metroTile_webBrowser = new MetroFramework.Controls.MetroTile();
            this.metroPanel_controlsContainer.SuspendLayout();
            this.metroPanel_statusDisplayArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroPanel_mainOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel_controlsContainer
            // 
            this.metroPanel_controlsContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel_controlsContainer.Controls.Add(this.metroPanel_statusDisplayArea);
            this.metroPanel_controlsContainer.Controls.Add(this.metroPanel_mainOptions);
            this.metroPanel_controlsContainer.HorizontalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.HorizontalScrollbarSize = 10;
            this.metroPanel_controlsContainer.Location = new System.Drawing.Point(3, 3);
            this.metroPanel_controlsContainer.Name = "metroPanel_controlsContainer";
            this.metroPanel_controlsContainer.Size = new System.Drawing.Size(1274, 714);
            this.metroPanel_controlsContainer.TabIndex = 0;
            this.metroPanel_controlsContainer.VerticalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.VerticalScrollbarSize = 10;
            // 
            // metroPanel_statusDisplayArea
            // 
            this.metroPanel_statusDisplayArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel_statusDisplayArea.Controls.Add(this.metroLabel_systemVolumeStatus);
            this.metroPanel_statusDisplayArea.Controls.Add(this.metroLabel_networkStatus);
            this.metroPanel_statusDisplayArea.Controls.Add(this.metroLabel_powerStatus);
            this.metroPanel_statusDisplayArea.Controls.Add(this.pictureBox3);
            this.metroPanel_statusDisplayArea.Controls.Add(this.pictureBox2);
            this.metroPanel_statusDisplayArea.Controls.Add(this.pictureBox1);
            this.metroPanel_statusDisplayArea.HorizontalScrollbarBarColor = true;
            this.metroPanel_statusDisplayArea.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel_statusDisplayArea.HorizontalScrollbarSize = 10;
            this.metroPanel_statusDisplayArea.Location = new System.Drawing.Point(914, 3);
            this.metroPanel_statusDisplayArea.Name = "metroPanel_statusDisplayArea";
            this.metroPanel_statusDisplayArea.Size = new System.Drawing.Size(357, 116);
            this.metroPanel_statusDisplayArea.TabIndex = 0;
            this.metroPanel_statusDisplayArea.VerticalScrollbarBarColor = true;
            this.metroPanel_statusDisplayArea.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_statusDisplayArea.VerticalScrollbarSize = 10;
            // 
            // metroLabel_systemVolumeStatus
            // 
            this.metroLabel_systemVolumeStatus.Location = new System.Drawing.Point(41, 79);
            this.metroLabel_systemVolumeStatus.Name = "metroLabel_systemVolumeStatus";
            this.metroLabel_systemVolumeStatus.Size = new System.Drawing.Size(313, 32);
            this.metroLabel_systemVolumeStatus.TabIndex = 8;
            this.metroLabel_systemVolumeStatus.Text = "80%";
            this.metroLabel_systemVolumeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel_networkStatus
            // 
            this.metroLabel_networkStatus.Location = new System.Drawing.Point(41, 41);
            this.metroLabel_networkStatus.Name = "metroLabel_networkStatus";
            this.metroLabel_networkStatus.Size = new System.Drawing.Size(313, 32);
            this.metroLabel_networkStatus.TabIndex = 7;
            this.metroLabel_networkStatus.Text = "No Network Connection";
            this.metroLabel_networkStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLabel_powerStatus
            // 
            this.metroLabel_powerStatus.Location = new System.Drawing.Point(41, 3);
            this.metroLabel_powerStatus.Name = "metroLabel_powerStatus";
            this.metroLabel_powerStatus.Size = new System.Drawing.Size(313, 32);
            this.metroLabel_powerStatus.TabIndex = 6;
            this.metroLabel_powerStatus.Text = "99%";
            this.metroLabel_powerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox3.BackgroundImage = global::GamePad_Intercepts.Properties.Resources.ic_volume;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(3, 79);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox2.BackgroundImage = global::GamePad_Intercepts.Properties.Resources.ic_wifi_connected;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(3, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.BackgroundImage = global::GamePad_Intercepts.Properties.Resources.ic_battery;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // metroPanel_mainOptions
            // 
            this.metroPanel_mainOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel_mainOptions.Controls.Add(this.metroTile_powerOptions);
            this.metroPanel_mainOptions.Controls.Add(this.metroTile_soundSettings);
            this.metroPanel_mainOptions.Controls.Add(this.metroTile_launchGamePlatform);
            this.metroPanel_mainOptions.Controls.Add(this.metroTile_wifiSettings);
            this.metroPanel_mainOptions.Controls.Add(this.metroTile_webBrowser);
            this.metroPanel_mainOptions.HorizontalScrollbarBarColor = true;
            this.metroPanel_mainOptions.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel_mainOptions.HorizontalScrollbarSize = 10;
            this.metroPanel_mainOptions.Location = new System.Drawing.Point(50, 147);
            this.metroPanel_mainOptions.Name = "metroPanel_mainOptions";
            this.metroPanel_mainOptions.Size = new System.Drawing.Size(1173, 538);
            this.metroPanel_mainOptions.TabIndex = 0;
            this.metroPanel_mainOptions.VerticalScrollbarBarColor = true;
            this.metroPanel_mainOptions.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_mainOptions.VerticalScrollbarSize = 10;
            // 
            // metroTile_powerOptions
            // 
            this.metroTile_powerOptions.ActiveControl = null;
            this.metroTile_powerOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroTile_powerOptions.Location = new System.Drawing.Point(851, 280);
            this.metroTile_powerOptions.Name = "metroTile_powerOptions";
            this.metroTile_powerOptions.Size = new System.Drawing.Size(301, 224);
            this.metroTile_powerOptions.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTile_powerOptions.TabIndex = 5;
            this.metroTile_powerOptions.Text = "Power Options";
            this.metroTile_powerOptions.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile_powerOptions.TileImage = global::GamePad_Intercepts.Properties.Resources.ic_power_options;
            this.metroTile_powerOptions.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile_powerOptions.UseSelectable = true;
            this.metroTile_powerOptions.UseTileImage = true;
            this.metroTile_powerOptions.Click += new System.EventHandler(this.metroTile_powerOptions_Click);
            // 
            // metroTile_soundSettings
            // 
            this.metroTile_soundSettings.ActiveControl = null;
            this.metroTile_soundSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroTile_soundSettings.Location = new System.Drawing.Point(851, 35);
            this.metroTile_soundSettings.Name = "metroTile_soundSettings";
            this.metroTile_soundSettings.Size = new System.Drawing.Size(301, 224);
            this.metroTile_soundSettings.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTile_soundSettings.TabIndex = 2;
            this.metroTile_soundSettings.Text = "Sound Settings";
            this.metroTile_soundSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile_soundSettings.TileImage = global::GamePad_Intercepts.Properties.Resources.ic_sound_settings;
            this.metroTile_soundSettings.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile_soundSettings.UseSelectable = true;
            this.metroTile_soundSettings.UseTileImage = true;
            this.metroTile_soundSettings.Click += new System.EventHandler(this.metroTile_soundSettings_Click);
            // 
            // metroTile_launchGamePlatform
            // 
            this.metroTile_launchGamePlatform.ActiveControl = null;
            this.metroTile_launchGamePlatform.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroTile_launchGamePlatform.Location = new System.Drawing.Point(39, 35);
            this.metroTile_launchGamePlatform.Name = "metroTile_launchGamePlatform";
            this.metroTile_launchGamePlatform.Size = new System.Drawing.Size(469, 469);
            this.metroTile_launchGamePlatform.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTile_launchGamePlatform.TabIndex = 0;
            this.metroTile_launchGamePlatform.Text = "Game Platform Launcher";
            this.metroTile_launchGamePlatform.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile_launchGamePlatform.TileImage = global::GamePad_Intercepts.Properties.Resources.ic_steam;
            this.metroTile_launchGamePlatform.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile_launchGamePlatform.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile_launchGamePlatform.UseSelectable = true;
            this.metroTile_launchGamePlatform.UseTileImage = true;
            this.metroTile_launchGamePlatform.Click += new System.EventHandler(this.metroTile_launchGamePlatform_Click);
            // 
            // metroTile_wifiSettings
            // 
            this.metroTile_wifiSettings.ActiveControl = null;
            this.metroTile_wifiSettings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroTile_wifiSettings.Location = new System.Drawing.Point(530, 280);
            this.metroTile_wifiSettings.Name = "metroTile_wifiSettings";
            this.metroTile_wifiSettings.Size = new System.Drawing.Size(301, 224);
            this.metroTile_wifiSettings.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTile_wifiSettings.TabIndex = 0;
            this.metroTile_wifiSettings.Text = "Wifi Settings";
            this.metroTile_wifiSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile_wifiSettings.TileImage = global::GamePad_Intercepts.Properties.Resources.ic_wifi;
            this.metroTile_wifiSettings.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile_wifiSettings.UseSelectable = true;
            this.metroTile_wifiSettings.UseTileImage = true;
            this.metroTile_wifiSettings.Click += new System.EventHandler(this.metroTile_wifiSettings_Click);
            // 
            // metroTile_webBrowser
            // 
            this.metroTile_webBrowser.ActiveControl = null;
            this.metroTile_webBrowser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroTile_webBrowser.Location = new System.Drawing.Point(530, 35);
            this.metroTile_webBrowser.Name = "metroTile_webBrowser";
            this.metroTile_webBrowser.Size = new System.Drawing.Size(301, 224);
            this.metroTile_webBrowser.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTile_webBrowser.TabIndex = 0;
            this.metroTile_webBrowser.Text = "Web Browser";
            this.metroTile_webBrowser.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile_webBrowser.TileImage = global::GamePad_Intercepts.Properties.Resources.ic_web_browser;
            this.metroTile_webBrowser.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile_webBrowser.UseSelectable = true;
            this.metroTile_webBrowser.UseTileImage = true;
            this.metroTile_webBrowser.Click += new System.EventHandler(this.metroTile_webBrowser_Click);
            // 
            // HomeUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroPanel_controlsContainer);
            this.Name = "HomeUserControl";
            this.Size = new System.Drawing.Size(1280, 720);
            this.metroPanel_controlsContainer.ResumeLayout(false);
            this.metroPanel_statusDisplayArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroPanel_mainOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel_controlsContainer;
        private MetroFramework.Controls.MetroPanel metroPanel_statusDisplayArea;
        private MetroFramework.Controls.MetroPanel metroPanel_mainOptions;
        private MetroFramework.Controls.MetroTile metroTile_launchGamePlatform;
        private MetroFramework.Controls.MetroTile metroTile_wifiSettings;
        private MetroFramework.Controls.MetroTile metroTile_webBrowser;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroLabel metroLabel_systemVolumeStatus;
        private MetroFramework.Controls.MetroLabel metroLabel_networkStatus;
        private MetroFramework.Controls.MetroLabel metroLabel_powerStatus;
        private MetroFramework.Controls.MetroTile metroTile_soundSettings;
        private MetroFramework.Controls.MetroTile metroTile_powerOptions;
    }
}
