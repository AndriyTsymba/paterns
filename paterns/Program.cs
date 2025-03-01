using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns
{
    public interface ICar
    {
        void Display(string color);
    }
    public class Car : ICar
    {
        private string model;
        public Car(string model)
        {
            this.model = model;
        }
        public void Display(string color)
        {
            Console.WriteLine($"Car model: {model}, Color: {color}");
        }
    }
    public class CarFactory
    {
        private Dictionary<string, ICar> cars = new Dictionary<string, ICar>();
        public ICar GetCar(string model)
        {
            if (!cars.ContainsKey(model))
            {
                cars[model] = new Car(model);
                Console.WriteLine($"Creating car model: {model}");
            }
            return cars[model];
        }
    }
    class Program
    {
        static void Main()
        {
            CarFactory carFactory = new CarFactory();
            ICar car1 = carFactory.GetCar("BMW");
            car1.Display("Red");

            ICar car2 = carFactory.GetCar("BMW");
            car2.Display("Blue");

            ICar car3 = carFactory.GetCar("Audi");
            car3.Display("Black");

            ICar car4 = carFactory.GetCar("BMW");
            car4.Display("Green");
        }
    }
}