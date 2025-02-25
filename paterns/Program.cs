using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns
{
    public class Pizza
    {
        public string Testo { get; set; }
        public string Sauce { get; set; }
        public List<string> Toppings { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"Пицца с {Testo} тістом и {Sauce} соусом.\nТоппинги: {string.Join(", ", Toppings)}";
        }
    }
    public abstract class PizzaBuilder
    {
        protected Pizza pizza;

        public PizzaBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            pizza = new Pizza();
        }

        public abstract PizzaBuilder BuildTesto();
        public abstract PizzaBuilder BuildSauce();
        public abstract PizzaBuilder BuildToppings();

        public Pizza GetPizza()
        {
            Pizza result = pizza;
            Reset();
            return result;
        }

        public class MargheritaPizza : PizzaBuilder
        {
            public override PizzaBuilder BuildTesto()
            {
                pizza.Testo = "тонким";
                return this;
            }

            public override PizzaBuilder BuildSauce()
            {
                pizza.Sauce = "томатний";
                return this;
            }

            public override PizzaBuilder BuildToppings()
            {
                pizza.Toppings.Add("моцарелла");
                pizza.Toppings.Add("базилик");
                pizza.Toppings.Add("оливкове масло");
                return this;
            }
        }
        public class PepperoniPizza : PizzaBuilder
        {
            public override PizzaBuilder BuildTesto()
            {
                pizza.Testo = "традиційним";
                return this;
            }

            public override PizzaBuilder BuildSauce()
            {
                pizza.Sauce = "томатним";
                return this;
            }

            public override PizzaBuilder BuildToppings()
            {
                pizza.Toppings.Add("моцарелла");
                pizza.Toppings.Add("пепперони");
                return this;
            }
        }
        public class QuattroFormaggiPizza : PizzaBuilder
        {
            public override PizzaBuilder BuildTesto()
            {
                pizza.Testo = "тонким";
                return this;
            }

            public override PizzaBuilder BuildSauce()
            {
                pizza.Sauce = "барбекю";
                return this;
            }

            public override PizzaBuilder BuildToppings()
            {
                pizza.Toppings.Add("моцарелла");
                pizza.Toppings.Add("пармезан");
                pizza.Toppings.Add("рикотта");
                pizza.Toppings.Add("чедер");
                return this;
            }
        }
        public class Pizzeria
        {
            private PizzaBuilder builder;

            public void SetBuilder(PizzaBuilder builder)
            {
                this.builder = builder;
            }

            public Pizza MakePizza()
            {
                return builder
                    .BuildTesto()
                    .BuildSauce()
                    .BuildToppings()
                    .GetPizza();
            }
        }

        public class Program
        {
            public static void Main()
            {
                Pizzeria pizzeria = new Pizzeria();
                PizzaBuilder margheritaBuilder = new MargheritaPizza();
                PizzaBuilder pepperoniBuilder = new PepperoniPizza();
                PizzaBuilder quattroFormaggiBuilder = new QuattroFormaggiPizza();
                pizzeria.SetBuilder(margheritaBuilder);
                Pizza margherita = pizzeria.MakePizza();
                Console.WriteLine("Заказ 1:");
                Console.WriteLine(margherita);
                Console.WriteLine();
                pizzeria.SetBuilder(pepperoniBuilder);
                Pizza pepperoni = pizzeria.MakePizza();
                Console.WriteLine("Заказ 2:");
                Console.WriteLine(pepperoni);
                Console.WriteLine();
                pizzeria.SetBuilder(quattroFormaggiBuilder);
                Pizza quattroFormaggi = pizzeria.MakePizza();
                Console.WriteLine("Заказ 3:");
                Console.WriteLine(quattroFormaggi);
                Console.WriteLine("\nПриклад індивідуального заказу:");
                Pizza customPizza = new PepperoniPizza()
                    .BuildTesto()
                    .BuildSauce()
                    .BuildToppings()
                    .GetPizza();
                Console.WriteLine(customPizza);
            }
        }
    }
}