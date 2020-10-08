using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task4
{
    class Triangle
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
        public double CountPerimeter()
        {
            return this.SideA + this.SideB + this.SideC;
        }
        public double CountAngleA()
        {
            return Math.Acos((SideB*SideB + SideC*SideC - SideA*SideA)/(2*SideB*SideC));
        }
        public double CountAngleB()
        {
            return Math.Acos((SideA * SideA + SideC * SideC - SideB * SideB) / (2 * SideA * SideC));
        }
        public double CountAngleC()
        {
            return Math.Acos((SideB * SideB + SideA * SideA - SideC * SideC) / (2 * SideB * SideA));
        }

    }
    class EquilateralTriangle : Triangle
    {
        private double _square;
        public double CountSquare()
        {
            _square = Math.Pow(SideA, 2) * Math.Sqrt(3) / 4;
            return _square;
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
