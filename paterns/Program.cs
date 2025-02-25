using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns
{
    public interface ICar
    {
        ICar Clone();
        void ShowDetails();
    }

    public class Car : ICar
    {
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Color { get; set; }
        public Car(string model, string engine, string color)
        {
            Model = model;
            Engine = engine;
            Color = color;
        }
        public ICar Clone()
        {
            return new Car(Model, Engine, Color);
        }
        public void ShowDetails()
        {
            Console.WriteLine($"Model: {Model}, Engine: {Engine}, Color: {Color}");
        }

    }
    public class CarFactory
    {
        private Dictionary<string, ICar> _carPrototypes = new Dictionary<string, ICar>();

        public void RegisterCar(string key, ICar car)
        {
            _carPrototypes[key] = car;
        }

        public ICar CreateCar(string key)
        {
            return _carPrototypes.ContainsKey(key) ? _carPrototypes[key].Clone() : null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CarFactory factory = new CarFactory();
            factory.RegisterCar("Sedan", new Car("Sedan", "V6", "Red"));
            factory.RegisterCar("SUV", new Car("SUV", "V8", "Blue"));
            ICar sedan = factory.CreateCar("Sedan");
            ICar suv = factory.CreateCar("SUV");
            sedan.ShowDetails();
            suv.ShowDetails();
            ICar clonedSedan = factory.CreateCar("Sedan");
            ICar clonedSUV = factory.CreateCar("SUV");
            clonedSedan.ShowDetails();
            clonedSUV.ShowDetails();
        }
    }
}
