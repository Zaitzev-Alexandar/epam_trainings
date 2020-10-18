using Microsoft.VisualStudio.TestTools.UnitTesting;
using FiguresLib;
using System.Collections.Generic;
using System.IO;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class FiguresCollectionTest
    {
        [TestMethod]
        public void ReadFromFile()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\files\figures.txt";
            int exptected = File.ReadAllLines(filePath).Length;

            List<Figure> collection = new List<Figure>();
            collection = Figure.ReadFromFile(filePath);
            int actual = collection.Count;

            Assert.AreEqual(exptected, actual);
        }
        [TestMethod]
        public void GetAveragePerimeter()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\files\figures.txt";
            List<Figure> collection = new List<Figure>();
            collection = Figure.ReadFromFile(filePath);

            double expected = 0;
            for (int i = 0; i < collection.Count; i++)
                expected += collection[i].GetPerimeter;
            expected /= collection.Count;

            double actual = Figure.AveragePerimeter(collection.ToArray());

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetTotalSquare()
        {
            string filePath = Directory.GetCurrentDirectory() + @"\files\figures.txt";
            List<Figure> collection = new List<Figure>();
            collection = Figure.ReadFromFile(filePath);

            double expected = 0;
            for (int i = 0; i < collection.Count; i++)
                expected += collection[i].GetSquare;

            double actual = Figure.FiguresSquare(collection.ToArray());

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetMaxSquareFigure()
        {
            Figure expected = new Circle(5, "C3");

            string filePath = Directory.GetCurrentDirectory() + @"\files\figures.txt";
            List<Figure> collection = new List<Figure>();
            collection = Figure.ReadFromFile(filePath);

            Figure actual = Figure.MaxSquare(collection.ToArray());

            Assert.AreEqual(expected.GetSquare, actual.GetSquare);
        }

        [TestMethod]
        public void GetFigureTypeByMaxAveragePerimeter()
        {
            string expected = "Circle";

            string filePath = Directory.GetCurrentDirectory() + @"\files\figures.txt";
            List<Figure> collection = new List<Figure>();
            collection = Figure.ReadFromFile(filePath);

            string actual = Figure.MaxAvgPerimeterInType(collection.ToArray());

            Assert.AreEqual(expected, actual);
        }
    }
}
