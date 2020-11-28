﻿using System;

/*Даний інтерфейс поганий тим, що він включає занадто багато методів.
 А що, якщо наш клас товарів не може мати знижок або промокодом, або для нього немає сенсу встановлювати матеріал з 
 якого зроблений (наприклад, для книг). Таким чином, щоб не реалізовувати в кожному класі невикористовувані в ньому методи, краще 
розбити інтерфейс на кілька дрібних і кожним конкретним класом реалізовувати потрібні інтерфейси.
Перепишіть, розбивши інтерфейс на декілька інтерфейсів, керуючись принципом розділення інтерфейсу. 
Опишіть класи книжки (розмір та колір не потрібні, але потрібна ціна та знижки) та верхній одяг (колір, розмір, ціна знижка),
які реалізують притаманні їм інтерфейси.*/

interface IItem
{
    void SetPrice(double price);
}

interface ISizeItem
{
    void SetSize(byte size);
}

interface IColorItem
{
    void SetColor(byte color);
}

interface IDiscountItem
{
    void ApplyDiscount(String discount);
}

interface IPromocodeItem
{
    void ApplyPromocode(String promocode);
}

class Book : IItem, IDiscountItem
{
    public void SetPrice(double price) { }

    public void ApplyDiscount(string discount) { }
}

class Outerwear : IItem, ISizeItem, IColorItem, IDiscountItem
{
    public void SetPrice(double price) { }
    public void SetSize(byte size) { }
    public void SetColor(byte color) { }
    public void ApplyDiscount(string discount) { }
}
class Program
{
    static void Main(string[] args)
    {
        Console.ReadKey();
    }
}