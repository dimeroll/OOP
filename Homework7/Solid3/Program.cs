using System;

//квадрат наслідується від прямокутника!!!

//порушення принципу підстановки Лісков
//поведінка класу Square відрізняється від поведінки класу Rectangle
//таким чином клас Square не може бути замінений базовим
// тому створюємо інтерфейс IFigure


interface IFigure
{
    int GetArea();
}
class Rectangle : IFigure
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
    public int GetArea()
    {
        return Width * Height;
    }
}

class Square : IFigure
{
    public int Side { get; set; }

    public int GetArea()
    {
        return Side * Side;
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();
            rect.Width = 5;
            rect.Height = 10;

            Console.WriteLine(rect.GetArea());
            Console.ReadKey();
        }
    }
