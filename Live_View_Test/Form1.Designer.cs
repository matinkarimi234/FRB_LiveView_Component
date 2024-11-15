namespace Live_View_Test
{
    partial class Form1
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
            this.panel_live = new System.Windows.Forms.Panel();
            this.live_View_Control = new FRB_LiveView_Component.Live_View_Control();
            this.menuStrip_Main = new System.Windows.Forms.MenuStrip();
            this.cameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.captureVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.capturePhotoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_live.SuspendLayout();
            this.menuStrip_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_live
            // 
            this.panel_live.AutoSize = true;
            this.panel_live.Controls.Add(this.live_View_Control);
            this.panel_live.Controls.Add(this.menuStrip_Main);
            this.panel_live.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_live.Location = new System.Drawing.Point(0, 0);
            this.panel_live.Name = "panel_live";
            this.panel_live.Size = new System.Drawing.Size(1103, 614);
            this.panel_live.TabIndex = 0;
            // 
            // live_View_Control
            // 
            this.live_View_Control.Location = new System.Drawing.Point(542, 42);
            this.live_View_Control.Name = "live_View_Control";
            this.live_View_Control.Size = new System.Drawing.Size(87, 43);
            this.live_View_Control.TabIndex = 0;
            // 
            // menuStrip_Main
            // 
            this.menuStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cameraToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.formatsToolStripMenuItem,
            this.resolutionToolStripMenuItem,
            this.capturingToolStripMenuItem});
            this.menuStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Main.Name = "menuStrip_Main";
            this.menuStrip_Main.Size = new System.Drawing.Size(1103, 24);
            this.menuStrip_Main.TabIndex = 0;
            this.menuStrip_Main.Text = "menuStrip1";
            // 
            // cameraToolStripMenuItem
            // 
            this.cameraToolStripMenuItem.Name = "cameraToolStripMenuItem";
            this.cameraToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.cameraToolStripMenuItem.Text = "Camera";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // formatsToolStripMenuItem
            // 
            this.formatsToolStripMenuItem.Name = "formatsToolStripMenuItem";
            this.formatsToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.formatsToolStripMenuItem.Text = "Formats";
            // 
            // resolutionToolStripMenuItem
            // 
            this.resolutionToolStripMenuItem.Name = "resolutionToolStripMenuItem";
            this.resolutionToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.resolutionToolStripMenuItem.Text = "Resolution";
            // 
            // capturingToolStripMenuItem
            // 
            this.capturingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.captureVideoToolStripMenuItem,
            this.capturePhotoToolStripMenuItem});
            this.capturingToolStripMenuItem.Name = "capturingToolStripMenuItem";
            this.capturingToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.capturingToolStripMenuItem.Text = "Capturing";
            // 
            // captureVideoToolStripMenuItem
            // 
            this.captureVideoToolStripMenuItem.Name = "captureVideoToolStripMenuItem";
            this.captureVideoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.captureVideoToolStripMenuItem.Text = "Capture Video";
            // 
            // capturePhotoToolStripMenuItem
            // 
            this.capturePhotoToolStripMenuItem.Name = "capturePhotoToolStripMenuItem";
            this.capturePhotoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.capturePhotoToolStripMenuItem.Text = "Capture Photo";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1103, 614);
            this.Controls.Add(this.panel_live);
            this.MainMenuStrip = this.menuStrip_Main;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_live.ResumeLayout(false);
            this.panel_live.PerformLayout();
            this.menuStrip_Main.ResumeLayout(false);
            this.menuStrip_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_live;
        private FRB_LiveView_Component.Live_View_Control live_View_Control;
        private System.Windows.Forms.MenuStrip menuStrip_Main;
        private System.Windows.Forms.ToolStripMenuItem cameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem captureVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturePhotoToolStripMenuItem;
    }
}

