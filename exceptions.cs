using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    public class InitializationException : Exception
    {
        public InitializationException(string message) : base(message)
        {
        }
    }

    public class AddException : Exception
    {
        public AddException(string message) : base(message)
        {
        }
    }

    public class GetAutoByParameterException : Exception
    {
        public GetAutoByParameterException(string message) : base(message)
        {
        }
    }

    public class UpdateAutoException : Exception
    {
        public UpdateAutoException(string message) : base(message)
        {
        }
    }

    public class RemoveAutoException : Exception
    {
        public RemoveAutoException(string message) : base(message)
        {
        }
    }

    public class AutoCollection
    {
        private List<Vehicle> vehicles;

        public event EventHandler<InitializationException> InitializationException;
        public event EventHandler<AddException> AddException;
        public event EventHandler<GetAutoByParameterException> GetAutoByParameterException;
        public event EventHandler<UpdateAutoException> UpdateAutoException;
        public event EventHandler<RemoveAutoException> RemoveAutoException;

        public AutoCollection()
        {
            vehicles = new List<Vehicle>();
        }

        public void AddAuto(Vehicle vehicle)
        {
            try
            {
                if (vehicle == null)
                {
                    throw new AddException("Vehicle cannot be null");
                }

                // Возможная логика добавления автомобиля в коллекцию

                vehicles.Add(vehicle);
            }
            catch (Exception ex)
            {
                AddException?.Invoke(this, new AddException(ex.Message));
            }
        }

        public Vehicle GetAutoByParameter(string parameter, string value)
        {
            try
            {
                // Возможная логика поиска автомобиля по заданному параметру

                throw new GetAutoByParameterException("Auto not found");
            }
            catch (Exception ex)
            {
                GetAutoByParameterException?.Invoke(this, new GetAutoByParameterException(ex.Message));
                return null;
            }
        }

        public void UpdateAuto(int id, Vehicle newVehicle)
        {
            try
            {
                if (newVehicle == null)
                {
                    throw new UpdateAutoException("New vehicle cannot be null");
                }

                // Возможная логика замены автомобиля

                throw new UpdateAutoException("Auto not found");
            }
            catch (Exception ex)
            {
                UpdateAutoException?.Invoke(this, new UpdateAutoException(ex.Message));
            }
        }

        public void RemoveAuto(int id)
        {
            try
            {
                // Возможная логика удаления автомобиля

                throw new RemoveAutoException("Auto not found");
            }
            catch (Exception ex)
            {
                RemoveAutoException?.Invoke(this, new RemoveAutoException(ex.Message));
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            AutoCollection autoCollection = new AutoCollection();

            autoCollection.InitializationException += (sender, e) =>
            {
                Console.WriteLine($"Initialization Exception: {e.Message}");
            };

            autoCollection.AddException += (sender, e) =>
            {
                Console.WriteLine($"Add Exception: {e.Message}");
            };

            autoCollection.GetAutoByParameterException += (sender, e) =>
            {
                Console.WriteLine($"GetAutoByParameter Exception: {e.Message}");
            };

            autoCollection.UpdateAutoException += (sender, e) =>
            {
                Console.WriteLine($"UpdateAuto Exception: {e.Message}");
            };

            autoCollection.RemoveAutoException += (sender, e) =>
            {
                Console.WriteLine($"RemoveAuto Exception: {e.Message}");
            };

            // Пример использования

            Vehicle car = new Car
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

            autoCollection.AddAuto(car);

            Vehicle foundAuto = autoCollection.GetAutoByParameter("Manufacturer", "Toyota");
            if (foundAuto != null)
            {
                Console.WriteLine($"Found Auto: {foundAuto.Manufacturer} {foundAuto.Model}");
            }

            Vehicle newCar = new Car
            {
                Manufacturer = "Nissan",
                Model = "Altima",
                Engine = new Engine
                {
                    Power = 200,
                    Volume = 2.0,
                    Type = "Gasoline",
                    SerialNumber = "ABC123"
                },
                Chassis = new Chassis
                {
                    WheelCount = 4,
                    Number = "CAR002",
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

            autoCollection.UpdateAuto(1, newCar);

            autoCollection.RemoveAuto(1);

            Console.ReadLine();
        }
    }
}