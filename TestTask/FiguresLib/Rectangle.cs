using System;
using System.Collections.Generic;
using System.Text;

namespace FiguresLib
{
    public class Rectangle : Figure
    {
        // Длина 
        private double length;
        // Ширина
        private double width;
        /// <summary>
        /// Конструктор прямоугольника
        /// </summary>
        /// <param name="length">Длина</param>
        /// <param name="width">Ширина</param>
        /// <param name="name">Название</param>
        public Rectangle(double length, double width, string name)
        {
            this.Name = name;
            this.width = Math.Abs(width);
            this.length = Math.Abs(length);
        }
        /// <summary>
        /// Площадь прямоугольника
        /// </summary>
        public override double GetSquare
        {
            get { return width * length; }
        }
        /// <summary>
        /// Периметр прямоугольника
        /// </summary>
        public override double GetPerimeter
        {
            get { return 2 * (width + length); }
        }
        /// <summary>
        /// Вывод информации о прямоугольнике
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Rectangle: {Name};length: {length};width: {width};perimeter: {GetPerimeter};square: {GetSquare};\n";
        }
    }
}
