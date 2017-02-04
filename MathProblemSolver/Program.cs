using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.IO.Compression;


namespace MathProblemSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryManager thisManager = new DirectoryManager();
            Console.WriteLine("Press enter to see a list of available drives.");
            Console.ReadLine();
            string[] availableDrivesNames = thisManager.getAvailableDriveNames();
            Console.WriteLine("\nAvailable Drives:");
            foreach (string drive in availableDrivesNames)
            {
                Console.WriteLine(drive);
            }
            Console.WriteLine("To see more information about the available drives, enter 'M'");
            Console.WriteLine("To select a drive, enter 'S'");
            string selection = Console.ReadLine();
            while (!selection.Equals("M") && !selection.Equals("m") && !selection.Equals("S") && !selection.Equals("s"))
            {
                Console.WriteLine("Invalid selection. Please try again.");
                selection = Console.ReadLine();
            }
            if (selection.Equals("M") || selection.Equals("m"))
            {
                DriveInfo[] availableDrivesInfo = thisManager.getAvailableDrives();
                foreach (DriveInfo drive in availableDrivesInfo)
                {
                    if (drive.IsReady)
                    {
                        Console.WriteLine("Name:                 " + drive.Name);
                        Console.WriteLine("Type:                 " + drive.DriveType);
                        Console.WriteLine("Format:               " + drive.DriveFormat);
                        Console.WriteLine("Available Free Space: " + drive.AvailableFreeSpace);
                        Console.WriteLine("Root Directory:       " + drive.RootDirectory);
                        Console.WriteLine("Total Size:           " + drive.TotalSize);
                        Console.WriteLine("Total Free Space:     " + drive.TotalFreeSpace);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Press enter to select a file.");
                Console.ReadLine();
            }
            Console.WriteLine("Which drive would you like to select?");
            Console.WriteLine("Please enter the letter name (no colon or slash) of the drive that you would like to select.");
            string driveToSelect = Console.ReadLine();
            driveToSelect = driveToSelect + ":\\";
            DriveInfo selectedDrive;
            DirectoryInfo selectedFolder;
            selectedDrive = thisManager.setDrive(driveToSelect);

            selectedFolder = thisManager.selectFolder(driveToSelect, true);
            Console.WriteLine("Available Subfolders: ");
            IEnumerable<DirectoryInfo> subfolders = selectedFolder.EnumerateDirectories();
            foreach (DirectoryInfo subfolder in subfolders)
            {
                Console.WriteLine(subfolder.Name);
            }
            IEnumerable<FileInfo> files = selectedFolder.EnumerateFiles();
            if (files.Count() > 0)
            {
                Console.WriteLine("\n\nAvailable Files: ");
                foreach (FileInfo file in files)
                {
                    if (!file.IsReadOnly)
                        Console.WriteLine(file.Name);

                }
            }
            Console.WriteLine("To select a file, enter 'F'. \nOtherwise, enter the name of the folder that you would like to see.");
            string choice = Console.ReadLine();
            while (!choice.Equals("F"))
            {
                while (!subfolders.Select(x => x.Name).Contains(choice))
                {
                    Console.WriteLine("That is not a valid folder. Try again.");
                    choice = Console.ReadLine();
                }
                selectedFolder = thisManager.selectFolder(choice, false);
                Console.WriteLine("Available Subfolders: ");
                subfolders = selectedFolder.EnumerateDirectories();
                foreach (DirectoryInfo subfolder in subfolders)
                {
                    Console.WriteLine(subfolder.Name);
                }
                files = selectedFolder.EnumerateFiles();
                if (files.Count() > 0)
                {
                    Console.WriteLine("\n\nAvailable Files: ");
                    foreach (FileInfo file in files)
                    {
                        if (!file.IsReadOnly)
                            Console.WriteLine(file.Name);
                    }
                }
                choice = Console.ReadLine();
            }
            Console.WriteLine("Which file would you like to view/edit?");
            string fileToView = Console.ReadLine();
            while (!files.Select(x => x.Name).Contains(fileToView))
            {
                Console.WriteLine("That is not a valid file. Try again.");
                fileToView = Console.ReadLine();
            }
            FileInfo selectedFile = thisManager.selectFile(fileToView);
            FileEditor thisEditor = new FileEditor(selectedFile.FullName);
            Console.WriteLine("Current File Contents");
            Console.WriteLine("---------------------");
            Console.WriteLine();
            List<string> lines = thisEditor.readEntireFile();
            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("Would you like to append new text to the end of this file (A)," 
                            + "or would you like to write over the current file contents (R)?");
            selection = Console.ReadLine();
            while (!selection.Equals("A") && !selection.Equals("a") && !selection.Equals("R") && !selection.Equals("r"))
            {
                Console.WriteLine("Invalid selection. Please try again.");
                selection = Console.ReadLine();
            }
            if(selection.Equals("R") || selection.Equals("r"))
            {
                lines.Clear();
            }
            Console.WriteLine("Please enter the text that you would like to write to the file.");
            string textToAdd = Console.ReadLine();
            lines.Add(textToAdd);
            thisEditor.writeMultipleLinesToFile(lines.ToArray());
            Console.WriteLine("Text written to the file.");
        }
    }
}
