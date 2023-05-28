using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace first
{
    // Базовый класс "Транспортное средство"
    public abstract class Vehicle
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Chassis Chassis { get; set; }
        public Transmission Transmission { get; set; }
    }

    // Класс "Двигатель"
    public class Engine
    {
        public double Power { get; set; }
        public double Volume { get; set; }
        public string Type { get; set; }
        public string SerialNumber { get; set; }
    }

    // Класс "Шасси"
    public class Chassis
    {
        public int WheelCount { get; set; }
        public string Number { get; set; }
        public double LoadCapacity { get; set; }
    }

    // Класс "Трансмиссия"
    public class Transmission
    {
        public string Type { get; set; }
        public int GearCount { get; set; }
        public string Manufacturer { get; set; }
    }

    // Класс "Грузовик"
    public class Truck : Vehicle
    {
        public double CargoCapacity { get; set; }
    }

    // Класс "Легковой автомобиль"
    public class Car : Vehicle
    {
        public int PassengerCapacity { get; set; }
    }

    // Класс "Автобус"
    public class Bus : Vehicle
    {
        public int PassengerCapacity { get; set; }
    }

    // Класс "Скутер"
    public class Scooter : Vehicle
    {
        public bool HasStorage { get; set; }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Создание коллекции и добавление объектов
            List<Vehicle> vehicles = new List<Vehicle>();

            // Добавление грузовика
            var truck = new Truck
            {
                Manufacturer = "Volvo",
                Model = "FH16",
                Engine = new Engine
                {
                    Power = 500,
                    Volume = 16,
                    Type = "Diesel",
                    SerialNumber = "ABC123"
                },
                Chassis = new Chassis
                {
                    WheelCount = 6,
                    Number = "TRK001",
                    LoadCapacity = 20000
                },
                Transmission = new Transmission
                {
                    Type = "Manual",
                    GearCount = 12,
                    Manufacturer = "Eaton"
                },
                CargoCapacity = 30000
            };
            vehicles.Add(truck);

            // Добавление легкового автомобиля
            var car = new Car
            {
                Manufacturer = "Toyota",
                Model = "Camry",
                Engine = new Engine
                {
                    Power = 180,
                    Volume = 2.5,
                    Type = "Gasoline",
                    SerialNumber = "XYZ456"
                },
                Chassis = new Chassis
                {
                    WheelCount = 4,
                    Number = "CAR001",
                    LoadCapacity = 500
                },
                Transmission = new Transmission
                {
                    Type = "Automatic",
                    GearCount = 6,
                    Manufacturer = "Aisin"
                },
                PassengerCapacity = 5
            };
            vehicles.Add(car);

            // Добавление автобуса
            var bus = new Bus
            {
                Manufacturer = "Mercedes-Benz",
                Model = "Citaro",
                Engine = new Engine
                {
                    Power = 350,
                    Volume = 7.7,
                    Type = "Diesel",
                    SerialNumber = "DEF789"
                },
                Chassis = new Chassis
                {
                    WheelCount = 6,
                    Number = "BUS001",
                    LoadCapacity = 1000
                },
                Transmission = new Transmission
                {
                    Type = "Automatic",
                    GearCount = 8,
                    Manufacturer = "Voith"
                },
                PassengerCapacity = 50
            };
            vehicles.Add(bus);

            // Добавление скутера
            var scooter = new Scooter
            {
                Manufacturer = "Honda",
                Model = "PCX",
                Engine = new Engine
                {
                    Power = 12,
                    Volume = 0.15,
                    Type = "Gasoline",
                    SerialNumber = "PQR789"
                },
                Chassis = new Chassis
                {
                    WheelCount = 2,
                    Number = "SCOOT001",
                    LoadCapacity = 50
                },
                Transmission = new Transmission
                {
                    Type = "Automatic",
                    GearCount = 1,
                    Manufacturer = "Honda"
                },
                HasStorage = true
            };
            vehicles.Add(scooter);

            // Запись информации в XML файлы
            WriteVehiclesWithLargeEngineVolume(vehicles, "vehicles_large_engine_volume.xml");
            WriteBusAndTruckEngineInfo(vehicles, "bus_truck_engine_info.xml");
            WriteVehiclesGroupedByTransmission(vehicles, "vehicles_grouped_by_transmission.xml");

            Console.WriteLine("Информация записана в XML файлы.");
            Console.ReadLine();
        }

        // Запись полной информации о транспортных средствах, обьем двигателя которых больше чем 1.5 литров
        private static void WriteVehiclesWithLargeEngineVolume(List<Vehicle> vehicles, string fileName)
        {
            var query = from vehicle in vehicles
                        where vehicle.Engine.Volume > 1.5
                        select vehicle;

            XElement xmlElements = new XElement("Vehicles",
                query.Select(v => new XElement("Vehicle",
                    new XElement("Manufacturer", v.Manufacturer),
                    new XElement("Model", v.Model),
                    new XElement("Engine",
                        new XElement("Power", v.Engine.Power),
                        new XElement("Volume", v.Engine.Volume),
                        new XElement("Type", v.Engine.Type),
                        new XElement("SerialNumber", v.Engine.SerialNumber)
                    ),
                    new XElement("Chassis",
                        new XElement("WheelCount", v.Chassis.WheelCount),
                        new XElement("Number", v.Chassis.Number),
                        new XElement("LoadCapacity", v.Chassis.LoadCapacity)
                    ),
                    new XElement("Transmission",
                        new XElement("Type", v.Transmission.Type),
                        new XElement("GearCount", v.Transmission.GearCount),
                        new XElement("Manufacturer", v.Transmission.Manufacturer)
                    )
                ))
            );

            xmlElements.Save(fileName);
        }

        // Запись типа двигателя, серийного номера и мощности для всех автобусов и грузовиков
        private static void WriteBusAndTruckEngineInfo(List<Vehicle> vehicles, string fileName)
        {
            var query = from vehicle in vehicles
                        where vehicle is Bus || vehicle is Truck
                        select vehicle;

            XElement xmlElements = new XElement("Vehicles",
                query.Select(v => new XElement("Vehicle",
                    new XElement("Manufacturer", v.Manufacturer),
                    new XElement("Model", v.Model),
                    new XElement("Engine",
                        new XElement("Type", v.Engine.Type),
                        new XElement("SerialNumber", v.Engine.SerialNumber),
                        new XElement("Power", v.Engine.Power)
                    )
                ))
            );

            xmlElements.Save(fileName);
        }

        // Запись полной информации о всех транспортных средствах, сгруппированной по типу трансмиссии
        private static void WriteVehiclesGroupedByTransmission(List<Vehicle> vehicles, string fileName)
        {
            var query = from vehicle in vehicles
                        group vehicle by vehicle.Transmission.Type into transmissionGroup
                        select new
                        {
                            TransmissionType = transmissionGroup.Key,
                            Vehicles = transmissionGroup.ToList()
                        };

            XElement xmlElements = new XElement("Vehicles",
                query.Select(g => new XElement("TransmissionGroup",
                    new XElement("TransmissionType", g.TransmissionType),
                    g.Vehicles.Select(v => new XElement("Vehicle",
                        new XElement("Manufacturer", v.Manufacturer),
                        new XElement("Model", v.Model),
                        new XElement("Engine",
                            new XElement("Power", v.Engine.Power),
                            new XElement("Volume", v.Engine.Volume),
                            new XElement("Type", v.Engine.Type),
                            new XElement("SerialNumber", v.Engine.SerialNumber)
                        ),
                        new XElement("Chassis",
                            new XElement("WheelCount", v.Chassis.WheelCount),
                            new XElement("Number", v.Chassis.Number),
                            new XElement("LoadCapacity", v.Chassis.LoadCapacity)
                        ),
                        new XElement("Transmission",
                            new XElement("Type", v.Transmission.Type),
                            new XElement("GearCount", v.Transmission.GearCount),
                            new XElement("Manufacturer", v.Transmission.Manufacturer)
                        )
                    ))
                ))
            );

            xmlElements.Save(fileName);
        }
    }
}