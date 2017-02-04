using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace MathProblemSolver
{
    public class FileEditor
    {
        FileStream stream;
        StreamReader reader;
        StreamWriter writer;
        string FilePath;

        public FileEditor(string filePath)
        {
            FilePath = filePath;
        }

        public List<string> readEntireFile()
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(FilePath))
            {
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
            }
            return lines;
        }

        public void writeLineToFile(string lineToWrite)
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                writer.WriteLine(lineToWrite);
            }
        }

        public void writeMultipleLinesToFile(string[] linesToWrite)
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (string line in linesToWrite)
                {
                    writer.WriteLine(line);
                }
            }
        }




    }
}
