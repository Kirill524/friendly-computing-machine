//Задание 1
// Запрограммируйте класс Money (объект класса опе
//рирует одной валютой) для работы с деньгами.
// В классе должны быть предусмотрены поле для хране
//ния целой части денег (доллары, евро, гривны и т.д.) и поле 
//для хранения копеек (центы, евроценты, копейки и т.д.).
// Реализовать методы для вывода суммы на экран, за
//дания значений для частей. 
//На базе класса Money создать класс Product для работы 
//с продуктом или товаром. Реализовать метод, позволяю
//щий уменьшить цену на заданное число.
// Для каждого из классов реализовать необходимые 
//методы и поля.

using System;

namespace MoneyProductApp
{
    public class Money
    {
        private int whole;
        private int cents;

        public int Whole
        {
            get => whole;
            set => whole = value >= 0 ? value : 0;
        }

        public int Cents
        {
            get => cents;
            set
            {
                if (value >= 0)
                {
                    whole += value / 100;
                    cents = value % 100;
                }
            }
        }

        public Money(int whole, int cents)
        {
            Whole = whole;
            Cents = cents;
        }

        public void SetMoney(int w, int c)
        {
            Whole = w;
            Cents = c;
        }

        public void Show()
        {
            Console.WriteLine($"{Whole}.{Cents:00}");
        }

        public void Subtract(decimal amount)
        {
            int totalCents = Whole * 100 + Cents - (int)(amount * 100);

            if (totalCents < 0)
                totalCents = 0;

            Whole = totalCents / 100;
            Cents = totalCents % 100;
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public Money Price { get; set; }

        public Product(string name, Money price)
        {
            Name = name;
            Price = price;
        }

        public void DecreasePrice(decimal amount)
        {
            Price.Subtract(amount);
        }

        public void Show()
        {
            Console.Write($"{Name}: ");
            Price.Show();
        }
    }

    class Program
    {
        static void Main()
        {
            Money price = new Money(10, 50);
            Product product = new Product("Шоколад", price);

            Console.WriteLine("Цена товара:");
            product.Show();

            Console.WriteLine("\nУменьшаем цену на 2.30");
            product.DecreasePrice(2.30m);

            Console.WriteLine("\nНовая цена:");
            product.Show();

            Console.ReadLine();
        }
    }
}

// Задание 2
// Создать базовый класс «Устройство» и производные 
//классы «Чайник», «Микроволновка», «Автомобиль», «Па
//роход». С помощью конструктора установить имя каждого 
//устройства и его характеристики.
// Реализуйте для каждого из классов методы:
// ■ Sound — издает звук устройства (пишем текстом в 
//консоль);
// ■ Show — отображает название устройства;
// ■ Desc — отображает описание устройства.

using System;

namespace DevicesApp
{
    class Device
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Device(string name, string desc) { Name = name; Description = desc; }
        public virtual void Sound() => Console.WriteLine("Устройство издает звук");
        public virtual void Show() => Console.WriteLine($"Название: {Name}");
        public virtual void Desc() => Console.WriteLine($"Описание: {Description}");
    }

    class Kettle : Device
    {
        public Kettle(string name, string desc) : base(name, desc) { }
        public override void Sound() => Console.WriteLine("Ш-ш-ш");
    }

    class Microwave : Device
    {
        public Microwave(string name, string desc) : base(name, desc) { }
        public override void Sound() => Console.WriteLine("Бип-бип");
    }

    class Car : Device
    {
        public Car(string name, string desc) : base(name, desc) { }
        public override void Sound() => Console.WriteLine("Брррр-брум");
    }

    class Steamboat : Device
    {
        public Steamboat(string name, string desc) : base(name, desc) { }
        public override void Sound() => Console.WriteLine("Пых-пых");
    }

    class Program
    {
        static void Main()
        {
            Device[] devices = {
                new Kettle("Электрочайник", "Нагревает воду"),
                new Microwave("Микроволновка", "Греет еду"),
                new Car("Автомобиль", "Перевозка людей"),
                new Steamboat("Пароход", "Путешествия по реке")
            };

            foreach (var d in devices)
            {
                d.Show();
                d.Desc();
                d.Sound();
                Console.WriteLine();
            }
        }
    }
}

// Задание 3
// Создать базовый класс «Музыкальный инструмент» 
//и производные классы «Скрипка», «Тромбон», « Укулеле»,
//«Виолончель». С помощью конструктора установить имя 
//каждого музыкального инструмента и его характеристики.
// Реализуйте для каждого из классов методы:
// ■ Sound — издает звук музыкального инструмента 
//(пишем текстом в консоль);
// ■ Show — отображает название музыкального инстру
//мента;
// ■ Desc — отображает описание музыкального инстру
//мента;
// ■ History — отображает историю создания музыкаль
//ного инструмента.

using System;

namespace MusicInstrumentsApp
{
    class Instrument
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string HistoryInfo { get; set; }

        public Instrument(string name, string desc, string hist)
        {
            Name = name; Description = desc; HistoryInfo = hist;
        }

        public virtual void Sound() => Console.WriteLine("Инструмент играет");
        public virtual void Show() => Console.WriteLine($"Название: {Name}");
        public virtual void Desc() => Console.WriteLine($"Описание: {Description}");
        public virtual void History() => Console.WriteLine($"История: {HistoryInfo}");
    }

    class Violin : Instrument
    {
        public Violin(string name, string desc, string hist) : base(name, desc, hist) { }
        public override void Sound() => Console.WriteLine("Виииин");
    }

    class Trombone : Instrument
    {
        public Trombone(string name, string desc, string hist) : base(name, desc, hist) { }
        public override void Sound() => Console.WriteLine("Труууум");
    }

    class Ukulele : Instrument
    {
        public Ukulele(string name, string desc, string hist) : base(name, desc, hist) { }
        public override void Sound() => Console.WriteLine("Стру-стру");
    }

    class Cello : Instrument
    {
        public Cello(string name, string desc, string hist) : base(name, desc, hist) { }
        public override void Sound() => Console.WriteLine("Вруум");
    }

    class Program
    {
        static void Main()
        {
            Instrument[] instruments = {
                new Violin("Скрипка","Струнный","Создана в XVI веке"),
                new Trombone("Тромбон","Духовой","Создан в XV веке"),
                new Ukulele("Укулеле","Струнный","Из Гавайев"),
                new Cello("Виолончель","Струнный","Создана в XVI веке")
            };

            foreach (var ins in instruments)
            {
                ins.Show();
                ins.Desc();
                ins.Sound();
                ins.History();
                Console.WriteLine();
            }
        }
    }
}

// Задание 4
// Создать абстрактный базовый класс Worker (работника) 
//с методом Print(). Создайте четыре производных класса: 
//President, Security, Manager, Engineer. Переопределите метод
// Print() для вывода информации, соответствующей 
//каждому типу работника.

using System;

namespace WorkerApp
{
    abstract class Worker
    {
        public abstract void Print();
    }

    class President : Worker
    {
        public override void Print() => Console.WriteLine("Президент: руководит компанией");
    }

    class Security : Worker
    {
        public override void Print() => Console.WriteLine("Охранник: обеспечивает безопасность");
    }

    class Manager : Worker
    {
        public override void Print() => Console.WriteLine("Менеджер: управляет проектами");
    }

    class Engineer : Worker
    {
        public override void Print() => Console.WriteLine("Инженер: разрабатывает решения");
    }

    class Program
    {
        static void Main()
        {
            Worker[] workers = { new President(), new Security(), new Manager(), new Engineer() };
            foreach (var w in workers) w.Print();
        }
    }
}

//Задание 1
// Создайте класс Human, который будет содержать 
//информацию о человеке.
// С помощью механизма наследования, реализуйте класс 
//Builder (содержит информацию о строителе), класс Sailor 
//(содержит информацию о моряке), класс Pilot (содержит 
//информацию о летчике).
// Каждый из классов должен содержать необходимые 
//для работы методы.

using System;

namespace HumanApp
{
    class Human
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Human(string name, int age) { Name = name; Age = age; }
        public virtual void ShowInfo() => Console.WriteLine($"{Name}, {Age} лет");
    }

    class Builder : Human
    {
        public string Specialization { get; set; }
        public Builder(string name, int age, string spec) : base(name, age) { Specialization = spec; }
        public override void ShowInfo() => Console.WriteLine($"{Name}, {Age} лет, строитель: {Specialization}");
    }

    class Sailor : Human
    {
        public int SailingExperience { get; set; }
        public Sailor(string name, int age, int exp) : base(name, age) { SailingExperience = exp; }
        public override void ShowInfo() => Console.WriteLine($"{Name}, {Age} лет, моряк: {SailingExperience} лет опыта");
    }

    class Pilot : Human
    {
        public string License { get; set; }
        public Pilot(string name, int age, string license) : base(name, age) { License = license; }
        public override void ShowInfo() => Console.WriteLine($"{Name}, {Age} лет, пилот: {License}");
    }

    class Program
    {
        static void Main()
        {
            Human[] humans = {
                new Builder("Иван",30,"Каменщик"),
                new Sailor("Петр",35,10),
                new Pilot("Анна",28,"A320")
            };
            foreach (var h in humans) h.ShowInfo();
        }
    }
}

// Задание 2
// Создайте класс Passport (паспорт), который будет 
//содержать паспортную информацию о гражданине за
//данной страны.
// С помощью механизма наследования, реализуйте 
//класс ForeignPassport (загранпаспорт) производный от 
//Pass  port.
// Напомним, что заграничный паспорт содержит по
//мимо паспортных данных, также данные о визах, номер 
//заграничного паспорта.
// Каждый из классов должен содержать необходимые 
//методы.

using System;

namespace PassportApp
{
    class Passport
    {
        public string FullName { get; set; }
        public string Number { get; set; }
        public Passport(string name, string number) { FullName = name; Number = number; }
        public virtual void Show() => Console.WriteLine($"Паспорт: {FullName}, №{Number}");
    }

    class ForeignPassport : Passport
    {
        public string VisaInfo { get; set; }
        public string ForeignNumber { get; set; }
        public ForeignPassport(string name, string number, string fnum, string visa) : base(name, number)
        { ForeignNumber = fnum; VisaInfo = visa; }

        public override void Show() => Console.WriteLine($"Загранпаспорт: {FullName}, №{ForeignNumber}, визы: {VisaInfo}");
    }

    class Program
    {
        static void Main()
        {
            Passport p1 = new Passport("Иван Иванов", "123456");
            ForeignPassport fp1 = new ForeignPassport("Петр Петров", "654321", "AB123456", "Шенген, США");

            p1.Show();
            fp1.Show();
        }
    }
}

// Задание 3
// Создать базовый класс «Животное» и производные 
//классы «Тигр», «Крокодил», «Кенгуру». С помощью кон
//структора установить имя каждого животного и его ха
//рактеристики.
// Создайте для каждого класса необходимые методы 
//и поля.

using System;

namespace AnimalApp
{
    class Animal
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public Animal(string name, string species) { Name = name; Species = species; }
        public virtual void ShowInfo() => Console.WriteLine($"{Name}, вид: {Species}");
        public virtual void MakeSound() => Console.WriteLine("Звук животного");
    }

    class Tiger : Animal
    {
        public Tiger(string name) : base(name, "Тигр") { }
        public override void MakeSound() => Console.WriteLine("Рррр");
    }

    class Crocodile : Animal
    {
        public Crocodile(string name) : base(name, "Крокодил") { }
        public override void MakeSound() => Console.WriteLine("Ш-ш-ш");
    }

    class Kangaroo : Animal
    {
        public Kangaroo(string name) : base(name, "Кенгуру") { }
        public override void MakeSound() => Console.WriteLine("Топ-топ");
    }

    class Program
    {
        static void Main()
        {
            Animal[] animals = { new Tiger("Шерхан"), new Crocodile("Крок"), new Kangaroo("Скакун") };
            foreach (var a in animals) { a.ShowInfo(); a.MakeSound(); Console.WriteLine(); }
        }
    }
}

// Задание 4
// Создайте абстрактный базовый класс Фигура с аб
//страктным методом для подсчета площади. Создайте 
//производные классы: прямоугольник, круг, прямоугольный 
//треугольник, трапеция со своими реализациями метода 
//для подсчета площади. Для проверки определите массив 
//ссылок на абстрактный класс, которым присваиваются 
//адреса различных объектов классов-потомков.
using System;

namespace FiguresApp
{
    abstract class Figure
    {
        public abstract double Area();
    }

    class Rectangle : Figure
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double w, double h) { Width = w; Height = h; }
        public override double Area() => Width * Height;
    }

    class Circle : Figure
    {
        public double Radius { get; set; }
        public Circle(double r) { Radius = r; }
        public override double Area() => Math.PI * Radius * Radius;
    }

    class Triangle : Figure
    {
        public double Base { get; set; }
        public double Height { get; set; }
        public Triangle(double b, double h) { Base = b; Height = h; }
        public override double Area() => 0.5 * Base * Height;
    }

    class Trapezoid : Figure
    {
        public double Top { get; set; }
        public double Bottom { get; set; }
        public double Height { get; set; }
        public Trapezoid(double top, double bottom, double height) { Top = top; Bottom = bottom; Height = height; }
        public override double Area() => 0.5 * (Top + Bottom) * Height;
    }

    class Program
    {
        static void Main()
        {
            Figure[] figures = {
                new Rectangle(4,5),
                new Circle(3),
                new Triangle(4,6),
                new Trapezoid(3,5,4)
            };

            foreach (var f in figures) Console.WriteLine($"Площадь: {f.Area():F2}");
        }
    }
}