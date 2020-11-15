using System;
namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            Developer dev = new CircleDeveloper("Розробник колоподібних деталь");
            Detail circleDetail = dev.Create();

            dev = new RectangleDeveloper("Розробник прямокутних деталь");
            Detail rectangleDetail = dev.Create();

            Console.ReadLine();
        }
    }
    // абстрактний клас компанії розробника
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string n)
        {
            Name = n;
        }
        // фабричный метод
        abstract public Detail Create();
    }
    // розробляє деталі колоподібної форми
    class CircleDeveloper : Developer
    {
        public CircleDeveloper(string n) : base(n)
        { }

        public override Detail Create()
        {
            return new CircleDetail();
        }
    }
    // розробляє деталі прямокутної форми
    class RectangleDeveloper : Developer
    {
        public RectangleDeveloper(string n) : base(n)
        { }

        public override Detail Create()
        {
            return new RectangleDetail();
        }
    }

    abstract class Detail
    { }

    class CircleDetail : Detail
    {
        public CircleDetail()
        {
            Console.WriteLine("Виготовлено деталь колоподібної форми");
        }
    }
    class RectangleDetail : Detail
    {
        public RectangleDetail()
        {
            Console.WriteLine("Виготовлено деталь прямокутної форми");
        }
    }
}