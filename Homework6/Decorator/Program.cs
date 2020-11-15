using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ChristmasTree tree = new ChristmasTree();
            NonLightDecorationsDecorator d1 = new NonLightDecorationsDecorator();
            GarlandsDecorator d2 = new GarlandsDecorator();

            // Link decorators
            d1.SetTree(tree);
            d2.SetTree(tree);

            d1.SetAllDecorations(10);
            d2.SetAllDecorations(2);

            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class AbstractChristmasTree
    {
        public abstract void SetAllDecorations(int n);
    }

    // "ConcreteComponent"
    class ChristmasTree : AbstractChristmasTree
    {
        public int nonLightDecorations = 0;
        public int garlands = 0;
        public override void SetAllDecorations(int n)
        {
            Console.WriteLine("nonLightDecorations - {0}; garlands - {1};\n", nonLightDecorations, garlands);
        }
        public void Glow()
        {
            Console.WriteLine("{0} garlands are glowing;\n", garlands);
        }
    }
    // "Decorator"
    abstract class Decorator : AbstractChristmasTree
    {
        protected ChristmasTree tree;

        public void SetTree(ChristmasTree tree)
        {
            this.tree = tree;
        }
    }

    // "ConcreteDecoratorA"
    class NonLightDecorationsDecorator : Decorator
    {
        public override void SetAllDecorations(int n)
        {
            tree.nonLightDecorations += n;
            tree.SetAllDecorations(n);
        }
    }

    // "ConcreteDecoratorB" 
    class GarlandsDecorator : Decorator
    {
        public override void SetAllDecorations(int n)
        {
            tree.garlands += n;
            tree.SetAllDecorations(n);
            tree.Glow();
        }
    }
}
