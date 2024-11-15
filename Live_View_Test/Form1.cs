using FRB_LiveView_Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Live_View_Test
{
    public partial class Form1 : Form
    {
        Live_View_Control.Camera[] cameras;
        Live_View_Control.Camera current_Camera;
        Live_View_Control.FormatDetails current_Format;
        Live_View_Control.ResolutionFPS current_Resolution;

        private ToolStripMenuItem selectedCameraMenuItem; // Track the currently selected item
        private ToolStripMenuItem selectedFormatMenuItem; // Track the currently selected item
        private ToolStripMenuItem selectedResolutionMenuItem; // Track the currently selected item
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Get_Cameras_Name();
            
        }

        private void Get_Cameras_Name()
        {
            cameras = live_View_Control.Cameras;
            // Add video devices to the "Camera" menu
            foreach (Live_View_Control.Camera camera in cameras)
            {
                string path = camera.Path.Substring(0, camera.Path.IndexOf("{")); // Remove the unnecessary part of the camera's path
                var menuItem = new ToolStripMenuItem(path)
                {
                    Tag = camera // Store the device in the Tag for easy access
                };
                menuItem.Click += (sender, args) => SelectCamera(menuItem);
                cameraToolStripMenuItem.DropDownItems.Add(menuItem);
            }
             
            if (cameras.Length > 0)
            {
                // Check the first video device by default
                var firstCameraItem = cameraToolStripMenuItem.DropDownItems[0] as ToolStripMenuItem;
                SelectCamera(firstCameraItem);


            }
        }

        private void SelectCamera(ToolStripMenuItem menuItem)
        {
            // Uncheck the previously selected item, if any
            if (selectedCameraMenuItem != null)
            {
                selectedCameraMenuItem.Checked = false;
            }

            // Check the selected item
            selectedCameraMenuItem = menuItem;
            selectedCameraMenuItem.Checked = true;

            // Get the device from the Tag
            current_Camera = (Live_View_Control.Camera)menuItem.Tag;


            //-----------------------------//
            // get the formats of the camera
            formatsToolStripMenuItem.DropDownItems.Clear();
            foreach (var format in current_Camera.Formats)
            {
                
                string format_Type = format.FormatType;
                var formatItem = new ToolStripMenuItem(format_Type)
                {
                    Tag = format // Store the format in the Tag for easy access
                };
                formatItem.Click += (sender, args) => SelectFormat(formatItem);
                formatsToolStripMenuItem.DropDownItems.Add(formatItem);
            }
            //-------------------------------//

            // Check the first video format by default
            var firstFormatItem = formatsToolStripMenuItem.DropDownItems[0] as ToolStripMenuItem;
            SelectFormat(firstFormatItem);


        }

        private void SelectFormat(ToolStripMenuItem formatItem)
        {
            // Uncheck the previously selected item, if any
            if (selectedFormatMenuItem != null)
            {
                selectedFormatMenuItem.Checked = false;
            }

            // Check the selected item
            selectedFormatMenuItem = formatItem;
            selectedFormatMenuItem.Checked = true;

            // Get the format from the Tag
            current_Format = (Live_View_Control.FormatDetails)formatItem.Tag;


            //-----------------------------//
            resolutionToolStripMenuItem.DropDownItems.Clear();
            // Get the resolutions
            foreach (var resolutionFPS in current_Format.ResolutionsFPS)
            {
                int width = resolutionFPS.Width;
                int height = resolutionFPS.Height;
                int fps = resolutionFPS.FPS;
                var resolution_Item = new ToolStripMenuItem($"{width} x{height}, {fps}FPS")
                {
                    Tag = resolutionFPS // Store the resolution in the Tag for easy access
                };
                resolution_Item.Click += (sender, args) => SelectResolution(resolution_Item);
                resolutionToolStripMenuItem.DropDownItems.Add(resolution_Item);
            }
            //-----------------------------//

            // Check the first format's resolution by default
            var firstResolutionItem = resolutionToolStripMenuItem.DropDownItems[0] as ToolStripMenuItem;
            SelectResolution(firstResolutionItem);
        }

        private void SelectResolution(ToolStripMenuItem resolution_Item)
        {
            // Uncheck the previously selected item, if any
            if (selectedResolutionMenuItem != null)
            {
                selectedResolutionMenuItem.Checked = false;
            }

            // Check the selected item
            selectedResolutionMenuItem = resolution_Item;
            selectedResolutionMenuItem.Checked = true;

            // Get the format from the Tag
            current_Resolution = (Live_View_Control.ResolutionFPS)resolution_Item.Tag;

            string format = current_Format.FormatType;
            int width = current_Resolution.Width;
            int height = current_Resolution.Height;
            int fps = current_Resolution.FPS;

            live_View_Control.StartLiveFeed(current_Camera, format, width, height, fps, panel_live);
        }
    }
}
