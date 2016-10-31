using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;


namespace AutoUSBBackup
{
    public partial class MainForm : Form
    {
        UInt32 WM_DEVICECHANGE = 0x0219;
        UInt32 DBT_DEVTUP_VOLUME = 0x02;
        UInt32 DBT_DEVICEARRIVAL = 0x8000;
        UInt32 DBT_DEVICEREMOVECOMPLETE = 0x8004;

        private DriveInfoManager driveInfoManager = new DriveInfoManager();
        private ConcurrentDictionary<String, FileManager> fileManager = new ConcurrentDictionary<string, FileManager>();
        private TaskPool taskPool = new TaskPool();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        protected override void WndProc(ref Message m)
        {
            // USB device attach event
            if ((m.Msg == WM_DEVICECHANGE) && (m.WParam.ToInt32() == DBT_DEVICEARRIVAL))
            {
                driveInfoManager.updateDeviceInfo();
#if DEBUG
                Console.WriteLine("Drive is attached");
#endif

                driveInfoManager.refreshDrives();
                DriveInfo[] drives = driveInfoManager.getDrivesInfo();

                foreach (DriveInfo dinfo in drives)
                {
                    try
                    {
                        fileManager[dinfo.Name].fileRefresh();
                        taskPool.RunTask(dinfo.Name);
                    }
                    catch (KeyNotFoundException excpt)
                    {
                        String dname = dinfo.Name.Replace(":\\", "");

                        FileManager fm = new FileManager("c:\\", "test\\" + dname + "\\");
                        fm.fileRefresh();

                        Action action = () => { fm.FileInput(dinfo.RootDirectory.GetFiles(), dinfo.RootDirectory.GetDirectories(), "\\"); };

                        taskPool.AddTask(dinfo.Name, action);
                        taskPool.RunTask(dinfo.Name);

                        fileManager.TryAdd(dinfo.Name, fm);
                    }
                }
            }

            // USB device detach event
            if ((m.Msg == WM_DEVICECHANGE) && (m.WParam.ToInt32() == DBT_DEVICEREMOVECOMPLETE))
            {
                driveInfoManager.updateDeviceInfo();

#if DEBUG
                Console.WriteLine("Drive is detached");
#endif
            }
            

            base.WndProc(ref m);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
