using System;
using System.IO;
using System.Collections.Generic;

namespace FiguresLib
{
    /// <summary>
    /// Абстрактный класс фигуры.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Название фигуры.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Метод вычисления площади фигуры.
        /// </summary>
        public abstract double GetSquare { get; }

        /// <summary>
        /// Метод вычисления периметра фигуры.
        /// </summary>
        public abstract double GetPerimeter { get; }

        /// <summary>
        /// Средний периметр среди фигур
        /// </summary>
        /// <param name="figures">Фигуры</param>
        /// <returns></returns>
        public static double AveragePerimeter(params Figure[] figures)
        {
            double result = 0;
            foreach(Figure figure in figures)
            {
                result += figure.GetPerimeter;
            }
            result /= figures.Length;
            return result;
        }
        /// <summary>
        /// Суммарная площадь всех фигур
        /// </summary>
        /// <param name="figures">Фигуры</param>
        /// <returns></returns>
        public static double FiguresSquare(params Figure[] figures)
        {
            double result = 0;
            foreach (Figure figure in figures)
            {
                result += figure.GetSquare;
            }
            return result;
        }
        /// <summary>
        /// Поиск фигуры с наибольшей площадью
        /// </summary>
        /// <param name="figures">Фигуры</param>
        /// <returns></returns>
        public static Figure MaxSquare(params Figure[] figures)
        {
            double square = figures[0].GetSquare;
            Figure result = figures[0];
            foreach (Figure figure in figures)
            {
                if(figure.GetSquare >= square) { square = figure.GetSquare; result = figure; }
            }
            return result;
        }
        /// <summary>
        /// Тип фигуры с наибольшим значением среднего периметра среди остальных фигур
        /// </summary>
        /// <param name="figures">Фигуры</param>
        /// <returns></returns>
        public static string MaxAvgPerimeterInType(params Figure[] figures)
        {
            List<string> types = new List<string>();
            foreach(Figure figure in figures)
            {
                if(types.Count == 0) { types.Add(figure.GetType().Name); }
                else
                {
                    bool flag = true;
                    foreach(string type in types)
                    {
                        if(typeof(Figure).Name == type) { flag = false; }
                    }
                    if(flag == true)
                    {
                        types.Add(figure.GetType().Name);
                    }
                }
            }
            List<double> avgPerimeters = new List<double>();
            foreach(string type in types)
            {
                List<Figure> tempFigures = new List<Figure>();
                foreach(Figure figure in figures)
                {
                    if(type == figure.GetType().Name) { tempFigures.Add(figure); }
                }
                avgPerimeters.Add(AveragePerimeter(tempFigures.ToArray()));
            }
            double maxAvgPerimeter = avgPerimeters[0];
            int maxAvgPerimeterId = 0;
            for(int i = 0; i < avgPerimeters.Count; i++)
            {
                if(avgPerimeters[i] >= maxAvgPerimeter)
                {
                    maxAvgPerimeter = avgPerimeters[i];
                    maxAvgPerimeterId = i;
                }
            }
            string result = types[maxAvgPerimeterId];
            return result;
        }
        /// <summary>
        /// Считывание фигур из файла
        /// </summary>
        /// <param name="filePath">Полный путь к файлус фигурами</param>
        /// <returns></returns>
        public static List<Figure> ReadFromFile(string filePath)
        {
            List<Figure> figures = new List<Figure>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] vs = line.Split(' ');
                    string type = vs[0];
                    string name = vs[1];

                    switch (type)
                    {
                        case "Circle":
                            int radius;
                            if (!int.TryParse(vs[2], out radius))
                                throw new Exception("Incorrect format of data.");

                            figures.Add(new Circle(radius, name));
                            break;
                        case "Rectangle":
                            int length;
                            if (!int.TryParse(vs[2], out length))
                                throw new Exception("Incorrect format of data.");

                            int width;
                            if (!int.TryParse(vs[3], out width))
                                throw new Exception("Incorrect format of data.");

                            figures.Add(new Rectangle(length, width, name));
                            break;
                        case "Square":
                            int side;
                            if (!int.TryParse(vs[2], out side))
                                throw new Exception("Incorrect format of data.");

                            figures.Add(new Square(side, name));
                            break;
                        default:
                            throw new Exception("Incorrect format of data.");
                    }
                }
            }

            return figures;
        }
    }
}
