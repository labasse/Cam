using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AForge.Video.DirectShow;

namespace Cam
{
    public partial class MainFrm : Form
    {
        private FilterInfoCollection devices;
        private int current = -1;
        private List<VideoCaptureDevice> captureDevices = new List<VideoCaptureDevice>();
        public MainFrm()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            foreach(VideoCaptureDevice device in captureDevices)
            {
                device.SignalToStop();
            }
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            Change();
        }

        private void Change()
        {
            videoSource.VideoSource?.Stop();
            videoSource.VideoSource?.WaitForStop();
            if (devices.Count > 1)
            {
                current = (current + 1) % devices.Count;
                if(captureDevices.Count <= current)
                {
                    captureDevices.Add(new VideoCaptureDevice(devices[current].MonikerString));
                }
                videoSource.VideoSource = captureDevices[current];
                videoSource.VideoSource.Start();
            }
        }

        private void videoSource_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button.HasFlag(MouseButtons.Right))
            {
                Change();
            }
            else if(e.Button.HasFlag(MouseButtons.Left))
            {
                if(captureDevices[current].IsRunning)
                {
                    videoSource.VideoSource.Stop();
                }
                else
                {
                    videoSource.VideoSource.Start();
                }
            }
            else if(e.Button.HasFlag(MouseButtons.Middle) && captureDevices[current].CheckIfCrossbarAvailable())
            {
                captureDevices[current].DisplayCrossbarPropertyPage(Handle);                
            }
            UpdateText();
        }

        private void UpdateText()
        {
            Text = $"Cam ({devices[current].Name})" + (captureDevices[current].IsRunning ? " ⦿" : "");
        }
    }
}
