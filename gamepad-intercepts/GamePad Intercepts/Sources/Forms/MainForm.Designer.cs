namespace GamePad_Intercepts.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroPanel_controlsContainer = new MetroFramework.Controls.MetroPanel();
            this.metroLabel_breadcrumb = new MetroFramework.Controls.MetroLabel();
            this.metroLink_back = new MetroFramework.Controls.MetroLink();
            this.metroLink_close = new MetroFramework.Controls.MetroLink();
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
            this.metroPanel_controlsContainer.Location = new System.Drawing.Point(23, 71);
            this.metroPanel_controlsContainer.Name = "metroPanel_controlsContainer";
            this.metroPanel_controlsContainer.Size = new System.Drawing.Size(1154, 506);
            this.metroPanel_controlsContainer.TabIndex = 0;
            this.metroPanel_controlsContainer.VerticalScrollbarBarColor = true;
            this.metroPanel_controlsContainer.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel_controlsContainer.VerticalScrollbarSize = 10;
            // 
            // metroLabel_breadcrumb
            // 
            this.metroLabel_breadcrumb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel_breadcrumb.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel_breadcrumb.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel_breadcrumb.Location = new System.Drawing.Point(23, 33);
            this.metroLabel_breadcrumb.Name = "metroLabel_breadcrumb";
            this.metroLabel_breadcrumb.Size = new System.Drawing.Size(1078, 32);
            this.metroLabel_breadcrumb.TabIndex = 1;
            this.metroLabel_breadcrumb.Text = "GamePad Intercepts";
            this.metroLabel_breadcrumb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroLink_back
            // 
            this.metroLink_back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLink_back.Image = global::GamePad_Intercepts.Properties.Resources.ic_back;
            this.metroLink_back.ImageSize = 32;
            this.metroLink_back.Location = new System.Drawing.Point(1107, 33);
            this.metroLink_back.Name = "metroLink_back";
            this.metroLink_back.Size = new System.Drawing.Size(32, 32);
            this.metroLink_back.TabIndex = 3;
            this.metroLink_back.UseSelectable = true;
            this.metroLink_back.Click += new System.EventHandler(this.metroLink_back_Click);
            // 
            // metroLink_close
            // 
            this.metroLink_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLink_close.Image = global::GamePad_Intercepts.Properties.Resources.if_close_black;
            this.metroLink_close.ImageSize = 32;
            this.metroLink_close.Location = new System.Drawing.Point(1145, 33);
            this.metroLink_close.Name = "metroLink_close";
            this.metroLink_close.Size = new System.Drawing.Size(32, 32);
            this.metroLink_close.TabIndex = 2;
            this.metroLink_close.UseSelectable = true;
            this.metroLink_close.Click += new System.EventHandler(this.metroLink_close_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.ControlBox = false;
            this.Controls.Add(this.metroLink_back);
            this.Controls.Add(this.metroLink_close);
            this.Controls.Add(this.metroLabel_breadcrumb);
            this.Controls.Add(this.metroPanel_controlsContainer);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Style = MetroFramework.MetroColorStyle.Silver;
            this.Text = "GPI | Gamepad Intercepts";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel_controlsContainer;
        private MetroFramework.Controls.MetroLabel metroLabel_breadcrumb;
        private MetroFramework.Controls.MetroLink metroLink_close;
        private MetroFramework.Controls.MetroLink metroLink_back;
    }
}