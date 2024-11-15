using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectShowLib;
using System.Runtime.InteropServices;

namespace FRB_LiveView_Component
{

    public partial class Live_View_Control: UserControl
    {

        private IFilterGraph2 filterGraph;
        private IVideoWindow videoWindow;
        private IMediaControl mediaControl;
        private IAMStreamConfig streamConfig;
        private IAMCameraControl cameraControl;
        public Live_View_Control()
        {
            InitializeComponent();
        }
        
        public struct Camera
        {
            public string Name;
            public string Path;
            public FormatDetails[] Formats;
        }

        public struct FormatDetails
        {
            public string FormatType;
            public ResolutionFPS[] ResolutionsFPS;
        }

        public struct ResolutionFPS
        {
            public int Width;
            public int Height;
            public int FPS;
        }

        private Camera[] cameras;
        public Camera[] Cameras
        {
            get 
            {
                Get_Cameras(); // Starts Here.
                return cameras; 
            }
            set
            {
                cameras = value;
            }
        }
        private void Get_Cameras()
        {
            try
            {
                DsDevice[] devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
                cameras = new Camera[devices.Length];
                for (int i = 0; i < devices.Length; i++)
                {
                    cameras[i].Path = devices[i].DevicePath;
                    cameras[i].Name = devices[i].Name;
                    cameras[i].Formats = GetSupportedFormats(devices[i]);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Can't Get Camera Names");
            }
        }

        private FormatDetails[] GetSupportedFormats(DsDevice device)
        {
            IFilterGraph2 filterGraph = (IFilterGraph2)new FilterGraph();
            IBaseFilter cameraFilter = CreateFilterFromDevice(device);
            filterGraph.AddFilter(cameraFilter, "Video Capture");



            IPin capturePin = DsFindPin.ByCategory(cameraFilter, PinCategory.Capture, 0);
            IAMStreamConfig streamConfig = capturePin as IAMStreamConfig;

            if (streamConfig == null)
            {
                MessageBox.Show("Failed to get IAMStreamConfig.");
                return null;
            }

            int count, size;
            streamConfig.GetNumberOfCapabilities(out count, out size);
            IntPtr taskMem = Marshal.AllocCoTaskMem(size);

            var formatsList = new System.Collections.Generic.List<FormatDetails>();

            for (int i = 0; i < count; i++)
            {
                AMMediaType mediaType;
                streamConfig.GetStreamCaps(i, out mediaType, taskMem);

                string formatType = mediaType.subType == MediaSubType.MJPG ? "MJPG" :
                                    mediaType.subType == MediaSubType.YUY2 ? "YUY2" : "Other";

                VideoInfoHeader videoInfo = (VideoInfoHeader)Marshal.PtrToStructure(
                    mediaType.formatPtr, typeof(VideoInfoHeader));

                int width = videoInfo.BmiHeader.Width;
                int height = videoInfo.BmiHeader.Height;
                int fps = (int)(10000000 / videoInfo.AvgTimePerFrame);

                // Find or add the format type in formatsList
                int formatIndex = formatsList.FindIndex(f => f.FormatType == formatType);
                if (formatIndex == -1)
                {
                    // Add new format if it doesn't exist
                    formatsList.Add(new FormatDetails
                    {
                        FormatType = formatType,
                        ResolutionsFPS = new ResolutionFPS[0] // Initialize as empty array
                    });
                    formatIndex = formatsList.Count - 1;
                }
                // Get the current FormatDetails and update it
                var format = formatsList[formatIndex];

                // Convert the existing ResolutionsFPS array to a list, add the new resolution, and convert back to array
                var tempList = formatsList[formatIndex].ResolutionsFPS.ToList();
                if (width > 300 && height > 200)
                {
                    tempList.Add(new ResolutionFPS { Width = width, Height = height, FPS = fps });
                }

                // Update the ResolutionsFPS array in the format struct
                format.ResolutionsFPS = tempList.ToArray();

                // Reassign the modified format back to formatsList
                formatsList[formatIndex] = format;

                DsUtils.FreeAMMediaType(mediaType);
            }

            Marshal.FreeCoTaskMem(taskMem);
            return formatsList.ToArray();
        }
        public void StartLiveFeed(Camera camera, string formatType, int width, int height, int fps, Panel displayPanel)
        {
            try
            {
                
                StopLiveFeed(); // Stop any existing video feed
                filterGraph = (IFilterGraph2)new FilterGraph();

                // Create the filter for the camera device
                DsDevice selectedDevice = FindDeviceByPath(camera.Path);
                IBaseFilter cameraFilter = CreateFilterFromDevice(selectedDevice);
                filterGraph.AddFilter(cameraFilter, "Video Capture");


                // Initialize IAMCameraControl interface for focus and exposure
                cameraControl = cameraFilter as IAMCameraControl;
                if (cameraControl == null)
                {
                    MessageBox.Show("IAMCameraControl interface not supported by this device.");
                }

                // Get the capture pin and IAMStreamConfig interface to set the format
                IPin capturePin = DsFindPin.ByCategory(cameraFilter, PinCategory.Capture, 0);
                streamConfig = capturePin as IAMStreamConfig;

                if (streamConfig == null)
                {
                    MessageBox.Show("Failed to get IAMStreamConfig.");
                    return;
                }

                // Set the format, resolution, and FPS
                ConfigureStreamFormat(formatType, width, height, fps);

                // Render the video stream to the external display panel
                filterGraph.Render(capturePin);

                // Use Invoke to ensure UI updates run on the UI thread
                displayPanel.Invoke((MethodInvoker)delegate
                {
                    // Configure the video window to show in the specified display panel
                    videoWindow = filterGraph as IVideoWindow;
                    videoWindow.put_Owner(displayPanel.Handle);
                    videoWindow.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipSiblings);
                    // Set up size synchronization by handling displayPanel's SizeChanged event
                    displayPanel.SizeChanged += (sender, e) =>
                    {
                        videoWindow.SetWindowPosition(0, 0, displayPanel.Width, displayPanel.Height);
                        videoWindow.put_Visible(OABool.True);
                    };
                    // Start the graph to begin video feed
                    mediaControl = filterGraph as IMediaControl;
                    mediaControl.Run();
                });


            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start live video: " + ex.Message);
            }
        }

        // Configures the stream format based on selected resolution and FPS
        private void ConfigureStreamFormat(string formatType, int width, int height, int fps)
        {
            int count, size;
            streamConfig.GetNumberOfCapabilities(out count, out size);
            IntPtr taskMem = Marshal.AllocCoTaskMem(size);

            for (int i = 0; i < count; i++)
            {
                AMMediaType mediaType;
                streamConfig.GetStreamCaps(i, out mediaType, taskMem);

                string currentFormatType = mediaType.subType == MediaSubType.MJPG ? "MJPG" :
                                           mediaType.subType == MediaSubType.YUY2 ? "YUY2" : "Other";

                if (currentFormatType == formatType)
                {
                    VideoInfoHeader videoInfo = (VideoInfoHeader)Marshal.PtrToStructure(
                        mediaType.formatPtr, typeof(VideoInfoHeader));

                    if (videoInfo.BmiHeader.Width == width && videoInfo.BmiHeader.Height == height &&
                        (int)(10000000 / videoInfo.AvgTimePerFrame) == fps)
                    {
                        streamConfig.SetFormat(mediaType);
                        DsUtils.FreeAMMediaType(mediaType);
                        Marshal.FreeCoTaskMem(taskMem);
                        return;
                    }
                }
                DsUtils.FreeAMMediaType(mediaType);
            }

            Marshal.FreeCoTaskMem(taskMem);
            throw new Exception("Requested format, resolution, or FPS is not supported by this camera.");
        }

        private DsDevice FindDeviceByPath(string path)
        {
            var devices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            foreach (var device in devices)
            {
                if (device.DevicePath == path)
                {
                    return device;
                }
            }
            throw new Exception("Camera device not found.");
        }

        // Method to get range of focus or exposure control
        public (int min, int max, int step, int defaultValue) GetControlRange(CustomCameraControlProperty property)
        {
            CameraControlProperty controlProperty = ConvertToDirectShowProperties(property);
            CameraControlFlags flags;
            int min, max, step, defaultValue;
            if (cameraControl != null)
            {
                int hr = cameraControl.GetRange(controlProperty, out min, out max, out step, out defaultValue, out flags);
                if (hr == 0)
                {
                    return (min, max, step, defaultValue);
                }
                else
                {
                    throw new Exception("Failed to get control range.");
                }
            }
            throw new NotSupportedException("Camera control not supported.");
        }


        // This is the public method exposed by your component
        public void SetFocus(int focusValue, CustomCameraControlFlags mode)
        {
            // Convert to DirectShow CameraControlFlags internally
            CameraControlFlags directShowMode = ConvertToDirectShowFlags(mode);
            cameraControl.Set(CameraControlProperty.Focus, focusValue, directShowMode);
        }

        public void SetExposure(int exposureValue, CustomCameraControlFlags mode)
        {
            // Convert to DirectShow CameraControlFlags internally
            CameraControlFlags directShowMode = ConvertToDirectShowFlags(mode);
            cameraControl.Set(CameraControlProperty.Exposure, exposureValue, directShowMode);
        }


        private CameraControlFlags ConvertToDirectShowFlags(CustomCameraControlFlags customMode)
        {
            return customMode == CustomCameraControlFlags.Manual ? CameraControlFlags.Manual : CameraControlFlags.Auto;
        }        
        private CameraControlProperty ConvertToDirectShowProperties(CustomCameraControlProperty customMode)
        {
            return customMode == CustomCameraControlProperty.Focus ? CameraControlProperty.Focus : CameraControlProperty.Exposure;
        }

        // Method to stop the live video feed
        public void StopLiveFeed()
        {
            if (mediaControl != null)
            {
                mediaControl.Stop();
            }
            if (videoWindow != null)
            {
                videoWindow.put_Visible(OABool.False);
                videoWindow.put_Owner(IntPtr.Zero);
            }
            if (filterGraph != null)
            {
                Marshal.ReleaseComObject(filterGraph);
                filterGraph = null;
            }
        }

        private IBaseFilter CreateFilterFromDevice(DsDevice device)
        {
            device.Mon.BindToObject(null, null, typeof(IBaseFilter).GUID, out object source);
            return (IBaseFilter)source;
        }
    }

    public enum CustomCameraControlFlags
    {
        Auto,
        Manual
    }
    public enum CustomCameraControlProperty
    {
        Focus,
        Exposure
    }
    public class FocusChangedEventArgs : EventArgs
    {
        public int FocusValue { get; }
        public CustomCameraControlFlags Mode { get; }

        public FocusChangedEventArgs(int focusValue, CustomCameraControlFlags mode)
        {
            FocusValue = focusValue;
            Mode = mode;
        }
    }

    public class ExposureChangedEventArgs : EventArgs
    {
        public int ExposureValue { get; }
        public CustomCameraControlFlags Mode { get; }

        public ExposureChangedEventArgs(int exposureValue, CustomCameraControlFlags mode)
        {
            ExposureValue = exposureValue;
            Mode = mode;
        }
    }
}
