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

        public FileEditor(string filePath)
        {
            stream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
        }

        public void dispose()
        {
            writer.Close();
            writer.Dispose();
        }

        public string[] readEntireFile()
        {
           
            List<string> lines = new List<string>();
            while (!reader.EndOfStream)
            {
                lines.Add(reader.ReadLine());
            }
            return lines.ToArray();
        }

        public void writeLineToFile(string lineToWrite)
        {
            writer.WriteLine(lineToWrite);
            writer.Flush();
        }

        public void writeMultipleLinesToFile(string[] linesToWrite)
        {
            foreach(string line in linesToWrite)
            {
                writer.WriteLine(line);
            }
        }

    }
}
