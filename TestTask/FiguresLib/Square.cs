using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresLib
{
    public class Square : Figure
    {
        private double side;
        /// <summary>
        /// Конструктор квадрата
        /// </summary>
        /// <param name="side">Длина стороны</param>
        /// <param name="name">Название</param>
        public Square(double side, string name)
        {
            this.Name = name;
            this.side = Math.Abs(side);
        }
        /// <summary>
        /// Периметр квадрата;
        /// </summary>
        /// <returns></returns>
        public override double GetPerimeter
        {
            get { return 4 * side; }
        }
        /// <summary>
        /// Площадь квадрата;
        /// </summary>
        /// <returns></returns>
        public override double GetSquare
        {
            get { return side * side; }
        }
        /// <summary>
        /// Вывод информации о фигуре;
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Square: {Name};side: {side};perimeter: {GetPerimeter};square: {GetSquare};\n";
        }
    }
}
