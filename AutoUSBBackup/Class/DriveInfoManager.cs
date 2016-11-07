using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace AutoUSBBackup
{
    class DriveInfoManager
    {
        private IEnumerable<DriveInfo> _drives;

        public DriveInfoManager()
        {
            #if DEBUG
            Console.WriteLine("DriveInfoManager is initialized");
            #endif
            refreshDrives();
        }

        public List<DriveInfo> getDrivesInfo()
        {
            return _drives.ToList();
        }

        public DriveInfo getDriveInfo(ref int idx)
        {
            return _drives.ElementAt(idx);
        }

        public void refreshDrives()
        {
            _drives = DriveInfo.GetDrives().Where(drive => drive.IsReady && drive.DriveType == DriveType.Removable);
#if DEBUG
            Console.WriteLine("Refresh Drives Information");

            foreach(DriveInfo info in _drives)
            {
                Console.WriteLine("DriveFormat\t\t" + info.DriveFormat);
                Console.WriteLine("DriveType\t\t" + info.DriveType);
                Console.WriteLine("RootDirectory\t\t" + info.RootDirectory.ToString());
                Console.WriteLine("TotalFreeSpace\t\t" + info.TotalFreeSpace);
                Console.WriteLine("TotalSize\t\t" + info.TotalSize);
                Console.WriteLine("VolumeLabel\t\t" + info.VolumeLabel);
                Console.WriteLine("----------------------------------------");
            }
#endif
        }

        public void updateDeviceInfo()
        {
            refreshDrives();
        }
    }
}
