using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns
{
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription() => "Простий кавовий напій";
        public double GetCost() => 10.0;
    }
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;

        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }
        public virtual string GetDescription() => _coffee.GetDescription();
        public virtual double GetCost() => _coffee.GetCost();
    }
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => _coffee.GetDescription() + ", з молоком";
        public override double GetCost() => _coffee.GetCost() + 5.0;
    }
    public class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => _coffee.GetDescription() + ", з цукром";
        public override double GetCost() => _coffee.GetCost() + 2.0;
    }
    class Program
    {
        static void Main()
        {
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost()} грн");
            coffee = new MilkDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost()} грн");
            coffee = new SugarDecorator(coffee);
            Console.WriteLine($"{coffee.GetDescription()} - {coffee.GetCost()} грн");
        }
    }
}
