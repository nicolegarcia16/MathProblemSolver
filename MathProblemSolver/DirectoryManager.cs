using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MathProblemSolver
{
    public class DirectoryManager
    {
        DriveInfo thisDriveInfo;
        string currentFolderPath;
        
        public DriveInfo[] getAvailableDrives()
        {
            return DriveInfo.GetDrives();
        }

        public string[] getAvailableDriveNames()
        {
            DriveInfo[] drives = getAvailableDrives();
            List<string> driveNames = new List<string>();
            foreach(DriveInfo drive in drives)
            {
                driveNames.Add(drive.Name);   
            }
            return driveNames.ToArray();
        }

        public DriveInfo setDrive(string drive)
        {
            this.thisDriveInfo = new DriveInfo(drive);
            return thisDriveInfo;
        }

        public DirectoryInfo[] getFoldersInDrive()
        {
            DirectoryInfo thisDirectory = thisDriveInfo.RootDirectory;
            IEnumerable<DirectoryInfo> folders = thisDirectory.EnumerateDirectories();
            return folders.ToArray();
        }

        public DirectoryInfo selectFolder(string folderName, bool firstSelection)
        {
            DirectoryInfo thisDirectory;
            string path;
            if (firstSelection)
            {
                thisDirectory = thisDriveInfo.RootDirectory;
                path = thisDirectory.FullName;
            }

            else
            {
                thisDirectory = new DirectoryInfo(currentFolderPath);
                path = thisDirectory.FullName + "\\" +folderName;
            }
            DirectoryInfo newDirectory = new DirectoryInfo(path);
            currentFolderPath = newDirectory.FullName;
            return newDirectory;
        }

        public FileInfo selectFile(string fileName)
        {
            string path = currentFolderPath + "\\" + fileName;
            FileInfo file = new FileInfo(path);
            return file;
        }

    }
}
