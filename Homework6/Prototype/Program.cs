using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Figure triangle = new Triangle("triagle0", 10, 15, 11);
            Figure triangleClone = triangle.Clone();
            triangle.GetInfo();
            triangleClone.GetInfo();
        }
    }
    abstract class Figure
    {
        public string name { get; private set; }
        public Figure(string name)
        {
            this.name = name;
        }
        public abstract Figure Clone();
        public abstract void GetInfo();
    }

    class Triangle : Figure
    {
        double sideA;
        double sideB;
        double sideC;
        
        public Triangle(string name, double a, double b, double c)
        : base(name)
        {
            sideA = a;
            sideB = b;
            sideC = c;
        }
        public override Figure Clone()
        {
            return new Triangle(name, sideA, sideB, sideC);
        }

        public override void GetInfo()
        {
            Console.WriteLine("{0} with sides lengths: {1}; {2}; {3}", name, sideA, sideB, sideC);
        }
    }
}
