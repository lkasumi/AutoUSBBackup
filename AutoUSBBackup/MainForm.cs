using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace AutoUSBBackup
{
    public partial class MainForm : Form
    {
        private IEnumerable<DriveInfo> _drives;
        UInt32 WM_DEVICECHANGE = 0x0219;
        UInt32 DBT_DEVTUP_VOLUME = 0x02;
        UInt32 DBT_DEVICEARRIVAL = 0x8000;
        UInt32 DBT_DEVICEREMOVECOMPLETE = 0x8004;

        public MainForm()
        {
            InitializeComponent();
            refreshDrives();
        }

        public void refreshDrives()
        {
            _drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);

            driveList.Items.Clear();
            
            foreach(DriveInfo info in _drives)
            {
                String name = info.Name;
                DirectoryInfo dir = info.RootDirectory;
                String size = info.TotalSize.ToString();

                driveList.Items.Add(name + "/" + dir.ToString() + "/" + size);
            }
        }
        
        protected override void WndProc(ref Message m)
        {
            // USB device attach event
            if ((m.Msg == WM_DEVICECHANGE) && (m.WParam.ToInt32() == DBT_DEVICEARRIVAL))
            {
                refreshDrives();
            }

            // USB device detach event
            if ((m.Msg == WM_DEVICECHANGE) && (m.WParam.ToInt32() == DBT_DEVICEARRIVAL))
            {
                refreshDrives();
            }

            base.WndProc(ref m);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
