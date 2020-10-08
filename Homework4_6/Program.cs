using _task6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task6
{
    abstract class Triangle
    {
        protected double sideA;
        protected double sideB;
        protected double angle;
        public Triangle(double a, double b, double ang)
        {
            if (a > 0 && b > 0 && ang > 0 && ang < 180)
            {
                sideA = a;
                sideB = b;
                angle = ang * Math.PI / 180;
            }
            else { Console.WriteLine("set correct data"); }
        }
        public virtual double GetPerimeter()
        {
            return sideA + sideB + Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2) - 2 * sideA * sideB * Math.Cos(angle));
        }
        public virtual double GetArea()
        {
            return 0.5 * sideA * sideB * Math.Sin(angle);
        }


    }

    class RightTriangle : Triangle
    {
        public RightTriangle(double a, double b)
              : base(a, b, 90) { }
        public override double GetPerimeter()
        {
            return sideA + sideB + Math.Sqrt(Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
        }
        public override double GetArea()
        {
            return 0.5 * sideA * sideB;
        }


    }

    class IsoscelesTriangle : Triangle
    {
        public IsoscelesTriangle(double a, double angle)
              : base(a, a, angle) { }
        public override double GetPerimeter()
        {
            return sideA * (2 + Math.Sqrt(2 - 2 * Math.Cos(angle)));
        }
        public override double GetArea()
        {
            return 0.5 * sideA * sideA * Math.Sin(angle);
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
