using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task5
{
    abstract class Figure
    {
        public virtual double GetSquare() { return 0; }
        public virtual double GetPerimeter() { return 0; }
    }

    class Triangle : Figure
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;
        public Triangle(double a, double b, double c)
        {
            if(a>0 && b>0 && c>0)
            {
                _sideA = a;
                _sideB = b;
                _sideC = c;
            }
            else { Console.WriteLine("set correct data"); }
        }
        public override double GetPerimeter()
        {
            return _sideA + _sideB + _sideC;
        }
        public override double GetSquare()
        {
            double p = GetPerimeter() / 2;
            return Math.Sqrt(p * (p - _sideA) * (p - _sideB) * (p - _sideC));
        }

    }
    class Circle : Figure
    {
        private double _radius;
        public Circle(double r)
        {
            if (r > 0) _radius = r;
            else 
            { 
                Console.WriteLine("set correct data"); 
            }
        }
        public override double GetPerimeter()
        {
            return Math.PI * 2 * _radius;
        }
        public override double GetSquare()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }

    }
    class Rectangle : Figure
    {
        private double _sideA;
        private double _sideB;
        public Rectangle(double a, double b)
        {
            if (a > 0 && b > 0)
            {
                _sideA = a;
                _sideB = b;
            }
            else { Console.WriteLine("set correct data"); }
        }
        public override double GetPerimeter()
        {
            return 2 * (_sideA + _sideB);
        }
        public override double GetSquare()
        {
            return _sideA * _sideB;
        }

    }
    class Quadrate : Figure
    {
        private double _side;
        public Quadrate(double a)
        {
            if (a > 0)
            {
                _side = a;
            }
            else { Console.WriteLine("set correct data"); }
        }
        public override double GetPerimeter()
        {
            return 4 * _side;
        }
        public override double GetSquare()
        {
            return Math.Pow(_side, 2);
        }

    }
    class Rhombus : Figure
    {
        private double _side;
        private double _angle;
        public Rhombus(double side, double angle)
        {
            if (side > 0 && angle > 0 && angle < 180)
            {
                _side = side;
                _angle = angle;
            }
            else { Console.WriteLine("set correct data"); }
        }
        public override double GetPerimeter()
        {
            return 4 * _side;
        }
        public override double GetSquare()
        {
            return Math.Pow(_side, 2) * Math.Sin(_angle * Math.PI / 180);
        }
    }

    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
