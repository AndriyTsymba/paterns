using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns
{

    public interface Chair
    {
        string GetDescription();
        void SitOn();
    }

    public interface Sofa
    {
        string GetDescription();
        void LieOn();
    }

    public interface CoffeeTable
    {
        string GetDescription();
        void PlaceItem(string item);
    }
    public interface FurnitureFactory
    {
        Chair CreateChair();
        Sofa CreateSofa();
        CoffeeTable CreateCoffeeTable();
        string GetStyleName();
    }
    public class ModernChair : Chair
    {
        public string GetDescription()
        {
            return "Modern Chair: Minimalist design with metal frame and clean lines";
        }

        public void SitOn()
        {
            Console.WriteLine("Sitting on a sleek and comfortable modern chair");
        }
    }
    public class ModernSofa : Sofa
    {
        public string GetDescription()
        {
            return "Modern Sofa: Low-profile with straight lines and neutral colors";
        }

        public void LieOn()
        {
            Console.WriteLine("Lounging on a spacious modern sofa");
        }
    }
    public class ModernCoffeeTable : CoffeeTable
    {
        public string GetDescription()
        {
            return "Modern Coffee Table: Glass top with geometric metal base";
        }

        public void PlaceItem(string item)
        {
            Console.WriteLine($"Placing {item} on the glass modern coffee table");
        }
    }
    public class VictorianChair : Chair
    {
        public string GetDescription()
        {
            return "Victorian Chair: Ornate wooden frame with tufted velvet upholstery";
        }

        public void SitOn()
        {
            Console.WriteLine("Sitting on an elegant Victorian chair with proper posture");
        }
    }

    public class VictorianSofa : Sofa
    {
        public string GetDescription()
        {
            return "Victorian Sofa: Carved wood details with plush floral fabric";
        }

        public void LieOn()
        {
            Console.WriteLine("Gracefully reclining on a Victorian sofa");
        }
    }

    public class VictorianCoffeeTable : CoffeeTable
    {
        public string GetDescription()
        {
            return "Victorian Coffee Table: Dark mahogany with intricate carved details";
        }

        public void PlaceItem(string item)
        {
            Console.WriteLine($"Carefully placing {item} on the polished Victorian coffee table");
        }
    }
    public class ModernFactory : FurnitureFactory
    {
        public Chair CreateChair()
        {
            return new ModernChair();
        }

        public Sofa CreateSofa()
        {
            return new ModernSofa();
        }

        public CoffeeTable CreateCoffeeTable()
        {
            return new ModernCoffeeTable();
        }

        public string GetStyleName()
        {
            return "Modern";
        }
    }
    public class VictorianFurnitureFactory : FurnitureFactory
    {
        public Chair CreateChair()
        {
            return new VictorianChair();
        }

        public Sofa CreateSofa()
        {
            return new VictorianSofa();
        }

        public CoffeeTable CreateCoffeeTable()
        {
            return new VictorianCoffeeTable();
        }

        public string GetStyleName()
        {
            return "Victorian";
        }
    }
    public class FurnitureShop
    {
        private readonly FurnitureFactory _factory;

        public FurnitureShop(FurnitureFactory factory)
        {
            _factory = factory;
        }
        public void DisplayFurnitureSet()
        {
            Console.WriteLine($"\n=== {_factory.GetStyleName()} Furniture Set ===");

            Chair chair = _factory.CreateChair();
            Sofa sofa = _factory.CreateSofa();
            CoffeeTable coffeeTable = _factory.CreateCoffeeTable();

            Console.WriteLine(chair.GetDescription());
            Console.WriteLine(sofa.GetDescription());
            Console.WriteLine(coffeeTable.GetDescription());
        }
        public void DemonstrateUsage()
        {
            Console.WriteLine($"\n=== Using {_factory.GetStyleName()} Furniture ===");

            Chair chair = _factory.CreateChair();
            Sofa sofa = _factory.CreateSofa();
            CoffeeTable coffeeTable = _factory.CreateCoffeeTable();

            chair.SitOn();
            sofa.LieOn();
            coffeeTable.PlaceItem("coffee cup");
        }
        public Dictionary<string, object> OrderFurnitureSet(int quantity = 1)
        {
            var order = new Dictionary<string, object>();

            for (int i = 0; i < quantity; i++)
            {
                order[$"Chair_{i}"] = _factory.CreateChair();
                order[$"Sofa_{i}"] = _factory.CreateSofa();
                order[$"CoffeeTable_{i}"] = _factory.CreateCoffeeTable();
            }

            Console.WriteLine($"Ordered {quantity} sets of {_factory.GetStyleName()} furniture");
            return order;
        }
    }
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("=== Furniture Shop Abstract Factory Demo ===");
            FurnitureFactory modernFactory = new ModernFactory();
            FurnitureShop modernShop = new FurnitureShop(modernFactory);
            modernShop.DisplayFurnitureSet();
            modernShop.DemonstrateUsage();
            modernShop.OrderFurnitureSet(2);
            FurnitureFactory victorianFactory = new VictorianFurnitureFactory();
            FurnitureShop victorianShop = new FurnitureShop(victorianFactory);
            victorianShop.DisplayFurnitureSet();
            victorianShop.DemonstrateUsage();
            victorianShop.OrderFurnitureSet();
            Console.WriteLine("\n=== How to extend with a new style ===");
            Console.WriteLine("1. Create concrete implementations of IChair, ISofa, ICoffeeTable for the new style");
            Console.WriteLine("2. Implement a new factory class that implements IFurnitureFactory");
            Console.WriteLine("3. Create a shop instance with the new factory");
            Console.WriteLine("Example: FurnitureShop scandinavianShop = new FurnitureShop(new ScandinavianFurnitureFactory());");
        }
    }
}