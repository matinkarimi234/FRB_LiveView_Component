using FRB_LiveView_Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Live_View_Test
{
    public partial class Form_Settings : Form
    {
        public event EventHandler<FocusChangedEventArgs> FocusChanged;
        public event EventHandler<ExposureChangedEventArgs> ExposureChanged;
        public Form_Settings()
        {
            InitializeComponent();
        }

        private void Form_Settings_Load(object sender, EventArgs e)
        {
            var mode = CustomCameraControlFlags.Auto;

            OnFocusChanged(trackBar_Focus.Value, mode);
            OnExposureChanged(trackBar_Exposure.Value, mode);
        }

        public void SetControlRanges((int min, int max, int step, int defaultValue) focusRange,
                             (int min, int max, int step, int defaultValue) exposureRange)
        {
            trackBar_Focus.Minimum = focusRange.min;
            trackBar_Focus.Maximum = focusRange.max;
            trackBar_Focus.TickFrequency = focusRange.step;
            trackBar_Focus.Value = focusRange.defaultValue;
            textBox_Focus_Value.Text = focusRange.defaultValue.ToString();


            trackBar_Exposure.Minimum = exposureRange.min;
            trackBar_Exposure.Maximum = exposureRange.max;
            trackBar_Exposure.TickFrequency = exposureRange.step;
            trackBar_Exposure.Value = exposureRange.defaultValue;
            textBox_Exposure_Value.Text = exposureRange.defaultValue.ToString();
        }

        protected virtual void OnFocusChanged(int value, CustomCameraControlFlags mode)
        {
            FocusChanged?.Invoke(this, new FocusChangedEventArgs(value, mode));
        }

        protected virtual void OnExposureChanged(int value, CustomCameraControlFlags mode)
        {
            ExposureChanged?.Invoke(this, new ExposureChangedEventArgs(value, mode));
        }

        private void focusTrackBar_Scroll(object sender, EventArgs e)
        {
            var mode = CustomCameraControlFlags.Manual;
            textBox_Focus_Value.Text = trackBar_Focus.Value.ToString();
            OnFocusChanged(trackBar_Focus.Value, mode);
        }

        private void exposureTrackBar_Scroll(object sender, EventArgs e)
        {
            var mode = CustomCameraControlFlags.Manual;
            textBox_Exposure_Value.Text = trackBar_Exposure.Value.ToString();
            OnExposureChanged(trackBar_Exposure.Value, mode);
        }

        private void checkBox_Auto_Focus_CheckedChanged(object sender, EventArgs e)
        {
            var mode = CustomCameraControlFlags.Auto;
            if (checkBox_Auto_Focus.Checked)
            {
                mode = CustomCameraControlFlags.Auto;
                trackBar_Focus.Enabled = false;
            }
            else
            {
                mode = CustomCameraControlFlags.Manual;
                trackBar_Focus.Enabled = true;
            }
            OnFocusChanged(trackBar_Focus.Value, mode);
        }

        private void checkBox_Auto_Exposure_CheckedChanged(object sender, EventArgs e)
        {
            var mode = CustomCameraControlFlags.Auto;
            if (checkBox_Auto_Exposure.Checked)
            {
                mode = CustomCameraControlFlags.Auto;
                trackBar_Exposure.Enabled = false;
            }
            else
            {
                mode = CustomCameraControlFlags.Manual;
                trackBar_Exposure.Enabled = true;
            }
            OnExposureChanged(trackBar_Exposure.Value, mode);
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
