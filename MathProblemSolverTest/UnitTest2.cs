using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathProblemSolver;
using System.IO;

namespace MathProblemSolverTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestGetAvailableDrives()
        {
            DirectoryManager manager = new MathProblemSolver.DirectoryManager();
            DriveInfo[] drives = manager.getAvailableDrives();
            Assert.IsTrue(drives.Length > 0);
        }

        [TestMethod]
        public void TestGetDriveNames()
        {
            DirectoryManager manager = new MathProblemSolver.DirectoryManager();
            string[] driveNames = manager.getAvailableDriveNames();
            Assert.IsTrue(driveNames.Length > 0);
        }

        [TestMethod]
        public void TestSetDrive()
        {
            DirectoryManager manager = new MathProblemSolver.DirectoryManager();
            DriveInfo selectedDrive = manager.setDrive("c");
            Assert.AreEqual(selectedDrive.Name, "c:\\");
        }

        [TestMethod]
        public void TestGetFoldersInDrive()
        {
            DirectoryManager manager = new MathProblemSolver.DirectoryManager();
            DriveInfo selectedDrive = manager.setDrive("c");
            DirectoryInfo[] folders = manager.getFoldersInDrive();
            Assert.IsTrue(folders.Length > 0);
        }
         
        [TestMethod]
        public void TestSelectFolder()
        {
            DirectoryManager manager = new MathProblemSolver.DirectoryManager();
            DriveInfo selectedDrive = manager.setDrive("c");
            DirectoryInfo selectedFolder = manager.selectFolder("Users", true);
            Assert.AreEqual(selectedFolder.Name, "Users");
        }
    }
}
