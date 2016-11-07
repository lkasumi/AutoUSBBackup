using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUSBBackup
{
    class FileManager
    {
        //private String drivePath;
        //private String filePath;
        private String backupPath;

        private List<FileInfo> fileData = new List<FileInfo>();

        public FileManager(String path)
        {
            this.backupPath = path;
 
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            else
            {
                fileRefresh();
            }
        }

        public void fileRefresh()
        {
            fileData.Clear();
            clearFiles();
            getFiles(this.backupPath);
        }

        public void clearFiles()
        {
            this.fileData.Clear();
        }

        public void getFiles(String path)
        {
            String[] filenames = Directory.GetFiles(path);
            String[] directories = Directory.GetDirectories(path);

            foreach (String fn in filenames)
            {
                FileInfo fileinfo = new FileInfo(fn);

                if (fileinfo.Exists)
                    this.fileData.Add(fileinfo);
            }

            if(directories.Length > 0)
                foreach (String dn in directories)
                    getFiles(dn);
        }

        public void FileInput(FileInfo[] files, DirectoryInfo[] dirs, String destDir)
        {
            try
            {
                // if dir is not exist, make it
                if (Directory.Exists(this.backupPath + destDir) == false)
                    Directory.CreateDirectory(this.backupPath + destDir);

                // output files
                foreach (FileInfo file in files)
                {
                    int find_idx = fileData.FindIndex(x => (destDir + x.Name).Equals(destDir + file.Name));

                    //if (find_idx < 0)
                    // always overwrite file
                    {
                        file.CopyTo(this.backupPath + destDir + file.Name, true);
#if DEBUG
                        Console.WriteLine("file Add : " + file.DirectoryName + "\tfileName:" + file.FullName + "\tsize:" + file.Length);
#endif

#region nouse
                    }
                    //else
                    //{
                    // file add if length is modified
                    //if (file.Length.Equals(fileData[find_idx].Length) == false)
                    //{
                    //file.CopyTo(path + destDir + file.Name, true);
#if DEBUG
                    //Console.WriteLine("file Overwrite : " + file.DirectoryName + "\tfileName:" + file.FullName + "\tsize:" + file.Length);
#endif
                    //}
                    //}
#endregion
                }

                // mkdir subdirs and loop
                if (dirs.Length > 0)
                {
                    foreach (DirectoryInfo dir in dirs)
                    {
                        String d = dir.FullName.Replace(dir.Root.ToString(), "");

                        FileInput(dir.GetFiles(), dir.GetDirectories(), d + "\\");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception : " + e.Message);
            }
        }

    }
}