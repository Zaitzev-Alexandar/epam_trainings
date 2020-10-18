using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FiguresLib
{
    public class Circle : Figure
    {
        private double radius;
        /// <summary>
        /// Конструктор круга
        /// </summary>
        /// <param name="radius">Радиус</param>
        /// <param name="name">Название</param>
        public Circle(double radius, string name)
        {
            this.Name = name;
            this.radius = Math.Abs(radius);
        }
        /// <summary>
        /// Периметр круга
        /// </summary>
        public override double GetPerimeter
        {
            get { return Math.PI * 2 * radius; }
        }
        /// <summary>
        /// Площадь круга
        /// </summary>
        public override double GetSquare
        {
            get { return Math.PI * radius * radius; }
        }
        /// <summary>
        /// Вывод информации о круге
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Circle: {Name};radius: {radius};perimeter: {GetPerimeter};square: {GetSquare};\n";
        }
    }
}
