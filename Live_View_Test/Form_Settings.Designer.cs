namespace Live_View_Test
{
    partial class Form_Settings
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
            this.button_Ok = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_Focus = new System.Windows.Forms.Label();
            this.label_Exposure = new System.Windows.Forms.Label();
            this.trackBar_Focus = new System.Windows.Forms.TrackBar();
            this.trackBar_Exposure = new System.Windows.Forms.TrackBar();
            this.checkBox_Auto_Focus = new System.Windows.Forms.CheckBox();
            this.checkBox_Auto_Exposure = new System.Windows.Forms.CheckBox();
            this.textBox_Focus_Value = new System.Windows.Forms.TextBox();
            this.textBox_Exposure_Value = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Focus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Exposure)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Ok
            // 
            this.button_Ok.Location = new System.Drawing.Point(12, 268);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(75, 23);
            this.button_Ok.TabIndex = 0;
            this.button_Ok.Text = "OK";
            this.button_Ok.UseVisualStyleBackColor = true;
            this.button_Ok.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(292, 268);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // label_Focus
            // 
            this.label_Focus.AutoSize = true;
            this.label_Focus.Location = new System.Drawing.Point(9, 20);
            this.label_Focus.Name = "label_Focus";
            this.label_Focus.Size = new System.Drawing.Size(36, 13);
            this.label_Focus.TabIndex = 2;
            this.label_Focus.Text = "Focus";
            this.label_Focus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Exposure
            // 
            this.label_Exposure.AutoSize = true;
            this.label_Exposure.Location = new System.Drawing.Point(9, 76);
            this.label_Exposure.Name = "label_Exposure";
            this.label_Exposure.Size = new System.Drawing.Size(51, 13);
            this.label_Exposure.TabIndex = 3;
            this.label_Exposure.Text = "Exposure";
            // 
            // trackBar_Focus
            // 
            this.trackBar_Focus.AutoSize = false;
            this.trackBar_Focus.Enabled = false;
            this.trackBar_Focus.Location = new System.Drawing.Point(83, 16);
            this.trackBar_Focus.Name = "trackBar_Focus";
            this.trackBar_Focus.Size = new System.Drawing.Size(141, 34);
            this.trackBar_Focus.TabIndex = 4;
            this.trackBar_Focus.Scroll += new System.EventHandler(this.focusTrackBar_Scroll);
            // 
            // trackBar_Exposure
            // 
            this.trackBar_Exposure.AutoSize = false;
            this.trackBar_Exposure.Enabled = false;
            this.trackBar_Exposure.Location = new System.Drawing.Point(83, 73);
            this.trackBar_Exposure.Name = "trackBar_Exposure";
            this.trackBar_Exposure.Size = new System.Drawing.Size(141, 36);
            this.trackBar_Exposure.TabIndex = 5;
            this.trackBar_Exposure.Scroll += new System.EventHandler(this.exposureTrackBar_Scroll);
            // 
            // checkBox_Auto_Focus
            // 
            this.checkBox_Auto_Focus.AutoSize = true;
            this.checkBox_Auto_Focus.Checked = true;
            this.checkBox_Auto_Focus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Auto_Focus.Location = new System.Drawing.Point(319, 18);
            this.checkBox_Auto_Focus.Name = "checkBox_Auto_Focus";
            this.checkBox_Auto_Focus.Size = new System.Drawing.Size(48, 17);
            this.checkBox_Auto_Focus.TabIndex = 6;
            this.checkBox_Auto_Focus.Text = "Auto";
            this.checkBox_Auto_Focus.UseVisualStyleBackColor = true;
            this.checkBox_Auto_Focus.CheckedChanged += new System.EventHandler(this.checkBox_Auto_Focus_CheckedChanged);
            // 
            // checkBox_Auto_Exposure
            // 
            this.checkBox_Auto_Exposure.AutoSize = true;
            this.checkBox_Auto_Exposure.Checked = true;
            this.checkBox_Auto_Exposure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Auto_Exposure.Location = new System.Drawing.Point(319, 78);
            this.checkBox_Auto_Exposure.Name = "checkBox_Auto_Exposure";
            this.checkBox_Auto_Exposure.Size = new System.Drawing.Size(48, 17);
            this.checkBox_Auto_Exposure.TabIndex = 7;
            this.checkBox_Auto_Exposure.Text = "Auto";
            this.checkBox_Auto_Exposure.UseVisualStyleBackColor = true;
            this.checkBox_Auto_Exposure.CheckedChanged += new System.EventHandler(this.checkBox_Auto_Exposure_CheckedChanged);
            // 
            // textBox_Focus_Value
            // 
            this.textBox_Focus_Value.Location = new System.Drawing.Point(242, 16);
            this.textBox_Focus_Value.MaxLength = 5;
            this.textBox_Focus_Value.Name = "textBox_Focus_Value";
            this.textBox_Focus_Value.ReadOnly = true;
            this.textBox_Focus_Value.Size = new System.Drawing.Size(49, 20);
            this.textBox_Focus_Value.TabIndex = 8;
            this.textBox_Focus_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Exposure_Value
            // 
            this.textBox_Exposure_Value.Location = new System.Drawing.Point(242, 75);
            this.textBox_Exposure_Value.MaxLength = 5;
            this.textBox_Exposure_Value.Name = "textBox_Exposure_Value";
            this.textBox_Exposure_Value.ReadOnly = true;
            this.textBox_Exposure_Value.Size = new System.Drawing.Size(49, 20);
            this.textBox_Exposure_Value.TabIndex = 9;
            this.textBox_Exposure_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 303);
            this.Controls.Add(this.textBox_Exposure_Value);
            this.Controls.Add(this.textBox_Focus_Value);
            this.Controls.Add(this.checkBox_Auto_Exposure);
            this.Controls.Add(this.checkBox_Auto_Focus);
            this.Controls.Add(this.trackBar_Exposure);
            this.Controls.Add(this.trackBar_Focus);
            this.Controls.Add(this.label_Exposure);
            this.Controls.Add(this.label_Focus);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Form_Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Focus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Exposure)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_Focus;
        private System.Windows.Forms.Label label_Exposure;
        private System.Windows.Forms.TrackBar trackBar_Focus;
        private System.Windows.Forms.TrackBar trackBar_Exposure;
        private System.Windows.Forms.CheckBox checkBox_Auto_Focus;
        private System.Windows.Forms.CheckBox checkBox_Auto_Exposure;
        private System.Windows.Forms.TextBox textBox_Focus_Value;
        private System.Windows.Forms.TextBox textBox_Exposure_Value;
    }
}