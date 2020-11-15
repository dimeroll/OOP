using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade.Examples
{
    // Mainapp test application 
    class Client
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            Worker1 w1 = new Worker1();
            Worker2 w2 = new Worker2();
            Worker3 w3 = new Worker3();
            Manager manager = new Manager(w1, w2, w3);

            manager.Start();
            manager.Finish();

            // Wait for user 
            Console.Read();
        }
    }


    // "Subsystem one" 
    class Worker1
    {
        public void PlanCreation()
        {
            Console.WriteLine("Розробка плану роботи");
        }
    }

    // Subsystem two" 
    class Worker2
    {
        public void Realization()
        {
            Console.WriteLine("Реалізація плану роботи");
        }
    }


    // Subsystem three" 
    class Worker3
    {
        public void FinalPart()
        {
            Console.WriteLine("Завершення виконання завдання");
        }

        public void BackToClient()
        {
            Console.WriteLine("Готовий проект передано клієнту");
        }

    }
  
    // "Facade" 
    class Manager
    {
        Worker1 worker1;
        Worker2 worker2;
        Worker3 worker3;
        public Manager(Worker1 w1, Worker2 w2, Worker3 w3)
        {
            worker1 = w1;
            worker2 = w2;
            worker3 = w3;
        }

        public void Start()
        {
            worker1.PlanCreation();
            worker2.Realization();
        }

        public void Finish()
        {
            worker3.BackToClient();
        }
    }
}