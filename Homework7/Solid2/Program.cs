using System;

//Який принцип S.O.L.I.D. порушено? Виправте!

/*Зверніть увагу на клас EmailSender. Крім того, що за допомогою методу Send, він відправляє повідомлення, 
він ще і вирішує як буде вестися лог. В даному прикладі лог ведеться через консоль.
Якщо трапиться так, що нам доведеться міняти спосіб логування, то ми будемо змушені внести правки в клас EmailSender.
Хоча, здавалося б, ці правки не стосуються відправки повідомлень. Очевидно, EmailSender виконує кілька обов'язків і, 
щоб клас не прив'язаний тільки до одного способу вести лог, потрібно винести функціонал ведення логу з цього класу.*/

//порушено принцип відкритості/закритості
class Email
{
    public String Theme { get; set; }
    public String From { get; set; }
    public String To { get; set; }
}

class EmailSender
{
    public void Send(Email email, ILogType logType)
    {
        // ... sending...
        logType.Log(email);
    }
}

interface ILogType
{
    void Log(Email email);
}

class ConsoleLogType : ILogType
{
    public void Log(Email email)
    {
        Console.WriteLine("Email from '" + email.From + "' to '" + email.To + "' was send");
    }
}
class Program
{
    static void Main(string[] args)
    {
        ILogType consolelogType = new ConsoleLogType();

        Email e1 = new Email() { From = "Me", To = "Vasya", Theme = "Who are you?" };
        Email e2 = new Email() { From = "Vasya", To = "Me", Theme = "vacuum cleaners!" };
        Email e3 = new Email() { From = "Kolya", To = "Vasya", Theme = "No! Thanks!" };
        Email e4 = new Email() { From = "Vasya", To = "Me", Theme = "washing machines!" };
        Email e5 = new Email() { From = "Me", To = "Vasya", Theme = "Yes" };
        Email e6 = new Email() { From = "Vasya", To = "Petya", Theme = "+2" };

        EmailSender es = new EmailSender();
        es.Send(e1, consolelogType);
        es.Send(e2, consolelogType);
        es.Send(e3, consolelogType);
        es.Send(e4, consolelogType);
        es.Send(e5, consolelogType);
        es.Send(e6, consolelogType);

        Console.ReadKey();
    }
}