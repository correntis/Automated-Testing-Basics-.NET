using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first
{
    // Класс "Двигатель"
    public class Engine
    {
        public int Power { get; set; }
        public int Volume { get; set; }
        public string Type { get; set; }
        public string SerialNumber { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Мощность: {Power} л.с.");
            Console.WriteLine($"Объем: {Volume} л");
            Console.WriteLine($"Тип: {Type}");
            Console.WriteLine($"Серийный номер: {SerialNumber}");
        }
    }

    // Класс "Шасси"
    public class Chassis
    {
        public int NumberOfWheels { get; set; }
        public string Number { get; set; }
        public int LoadCapacity { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Количество колес: {NumberOfWheels}");
            Console.WriteLine($"Номер: {Number}");
            Console.WriteLine($"Допустимая нагрузка: {LoadCapacity} кг");
        }
    }

    // Класс "Трансмиссия"
    public class Transmission
    {
        public string Type { get; set; }
        public int NumberOfGears { get; set; }
        public string Manufacturer { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"Тип: {Type}");
            Console.WriteLine($"Количество передач: {NumberOfGears}");
            Console.WriteLine($"Производитель: {Manufacturer}");
        }
    }

    // Класс "Легковой автомобиль"
    public class Car
    {
        public Engine Engine { get; set; }
        public Chassis Chassis { get; set; }
        public Transmission Transmission { get; set; }
        public string Model { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine("Информация о легковом автомобиле:");
            Console.WriteLine($"Модель: {Model}");
            Engine.PrintInfo();
            Chassis.PrintInfo();
            Transmission.PrintInfo();
            Console.WriteLine();
        }
    }

    // Класс "Грузовик"
    public class Truck
    {
        public Engine Engine { get; set; }
        public Chassis Chassis { get; set; }
        public Transmission Transmission { get; set; }
        public int CargoCapacity { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine("Информация о грузовике:");
            Console.WriteLine($"Грузоподъемность: {CargoCapacity} кг");
            Engine.PrintInfo();
            Chassis.PrintInfo();
            Transmission.PrintInfo();
            Console.WriteLine();
        }
    }

    // Класс "Автобус"
    public class Bus
    {
        public Engine Engine { get; set; }
        public Chassis Chassis { get; set; }
        public Transmission Transmission { get; set; }
        public int PassengerCapacity { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine("Информация об автобусе:");
            Console.WriteLine($"Вместимость пассажиров: {PassengerCapacity}");
            Engine.PrintInfo();
            Chassis.PrintInfo();
            Transmission.PrintInfo();
            Console.WriteLine();
        }
    }

    // Класс "Скутер"
    public class Scooter
    {
        public Engine Engine { get; set; }
        public Chassis Chassis { get; set; }
        public Transmission Transmission { get; set; }
        public string Color { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine("Информация о скутере:");
            Console.WriteLine($"Цвет: {Color}");
            Engine.PrintInfo();
            Chassis.PrintInfo();
            Transmission.PrintInfo();
            Console.WriteLine();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Создание объектов и вывод информации
            var car = new Car
            {
                Model = "Toyota Camry",
                Engine = new Engine { Power = 180, Volume = 2, Type = "Бензин", SerialNumber = "123456" },
                Chassis = new Chassis { NumberOfWheels = 4, Number = "A123BC", LoadCapacity = 400 },
                Transmission = new Transmission { Type = "Автоматическая", NumberOfGears = 6, Manufacturer = "Toyota" }
            };
            car.PrintInfo();

            var truck = new Truck
            {
                CargoCapacity = 5000,
                Engine = new Engine { Power = 300, Volume = 5, Type = "Дизель", SerialNumber = "654321" },
                Chassis = new Chassis { NumberOfWheels = 6, Number = "B456CD", LoadCapacity = 10000 },
                Transmission = new Transmission { Type = "Механическая", NumberOfGears = 8, Manufacturer = "Volvo" }
            };
            truck.PrintInfo();

            var bus = new Bus
            {
                PassengerCapacity = 40,
                Engine = new Engine { Power = 200, Volume = 3, Type = "Дизель", SerialNumber = "987654" },
                Chassis = new Chassis { NumberOfWheels = 6, Number = "C789DE", LoadCapacity = 5000 },
                Transmission = new Transmission { Type = "Автоматическая", NumberOfGears = 6, Manufacturer = "Mercedes-Benz" }
            };
            bus.PrintInfo();

            var scooter = new Scooter
            {
                Color = "Синий",
                Engine = new Engine { Power = 10, Volume = 1, Type = "Бензин", SerialNumber = "567890" },
                Chassis = new Chassis { NumberOfWheels = 2, Number = "D012EF", LoadCapacity = 150 },
                Transmission = new Transmission { Type = "Вариатор", NumberOfGears = 0, Manufacturer = "Honda" }
            };
            scooter.PrintInfo();

            Console.ReadLine();
        }
    }
}
