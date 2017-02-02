using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathProblemSolver;
using System.Collections.Generic;

namespace MathProblemSolverTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestReadFile()
        {
            string path = "C:/Users/nicol/Documents/Graduate Classes/SSE 554/test.txt";
            MathProblemSolver.FileEditor myEditor = new FileEditor(path);
            string[] lines = myEditor.readEntireFile();
            Assert.AreEqual(lines[0], "This is a test.");
            myEditor.dispose();
        }

        [TestMethod]
        public void TestWriteLineToFile()
        {
            string path = "C:/Users/nicol/Documents/Graduate Classes/SSE 554/test.txt";
            FileEditor myEditor = new FileEditor(path);
            string testSentence = "Test sentence";
            myEditor.writeLineToFile(testSentence);
            string[] lines = myEditor.readEntireFile();
            Assert.AreEqual(lines[lines.GetLength(0)-1], "Test sentence.");
            myEditor.dispose();
        }

        [TestMethod]
        public void TestWriteMultipleLinesToFile()
        {
            string path = "C:/Users/nicol/Documents/Graduate Classes/SSE 554/test.txt";
            FileEditor myEditor = new FileEditor(path);
            List<string> testSentences = new List<string>();
            testSentences.Add("Bow ties are cool.");
            testSentences.Add("Yer a wizard, Harry!");
            testSentences.Add("It is a truth universally acknowledged");
            myEditor.writeMultipleLinesToFile(testSentences.ToArray());
            string[] lines = myEditor.readEntireFile();
            myEditor.dispose();
            Assert.AreEqual(lines[lines.GetLength(0)-1], "It is a truth universally acknowledged.");
            
        }

        [TestMethod]
        public void TestReadLineFromFile()
        {

        }


    }
}
