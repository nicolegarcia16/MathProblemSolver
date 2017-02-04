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
            string path = "C:/Users/nicol/Documents/Graduate Classes/SSE 554/testRead.txt";
            MathProblemSolver.FileEditor myEditor = new FileEditor(path);
            List<string> lines = myEditor.readEntireFile();
            Assert.AreEqual(lines[0], "This is a test.");
        }

        [TestMethod]
        public void TestWriteLineToFile()
        {
            string path = "C:/Users/nicol/Documents/Graduate Classes/SSE 554/test.txt";
            FileEditor myEditor = new FileEditor(path);
            string testSentence = "Test sentence.";
            myEditor.writeLineToFile(testSentence);
            List<string> lines = myEditor.readEntireFile();
            Assert.AreEqual(lines[lines.Count - 1], "Test sentence.");
        }

        [TestMethod]
        public void TestWriteMultipleLinesToFile()
        {
            string path = "C:/Users/nicol/Documents/Graduate Classes/SSE 554/test.txt";
            FileEditor myEditor = new FileEditor(path);
            List<string> testSentences = new List<string>();
            testSentences.Add("Bow ties are cool.");
            testSentences.Add("Yer a wizard, Harry!");
            testSentences.Add("That's no moon...");
            testSentences.Add("It is a truth universally acknowledged");
            myEditor.writeMultipleLinesToFile(testSentences.ToArray());
            List<string> lines = myEditor.readEntireFile();
            Assert.AreEqual(lines.[lines.Count - 1], "It is a truth universally acknowledged");
        }
    }
}
