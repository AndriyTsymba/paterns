using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns
{
    using System;

    namespace SingletonPattern
    {
        public sealed class Singleton
        {
            private static Singleton instance;
            private static readonly object lockObject = new object();
            public int Count { get; private set; }
            private Singleton()
            {
                Count = 0;
                Console.WriteLine("Екземпляр Singleton створено");
            }
            public static Singleton GetInstance()
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }
                    }
                }

                return instance;
            }
            public void DoSomething()
            {
                Count++;
                Console.WriteLine($"Метод викликано {Count} разів");
            }
        }
        public sealed class ModernSingleton
        {
            private static readonly ModernSingleton instance = new ModernSingleton();
            public int Count { get; private set; }
            static ModernSingleton()
            {
            }
            private ModernSingleton()
            {
                Count = 0;
                Console.WriteLine("Екземпляр ModernSingleton створено");
            }
            public static ModernSingleton Instance
            {
                get
                {
                    return instance;
                }
            }
            public void DoSomething()
            {
                Count++;
                Console.WriteLine($"ModernSingleton: метод викликано {Count} разів");
            }
        }
        public sealed class LazySingleton
        {
            private static readonly Lazy<LazySingleton> lazy =
                new Lazy<LazySingleton>(() => new LazySingleton());
            public int Count { get; private set; }
            private LazySingleton()
            {
                Count = 0;
                Console.WriteLine("Екземпляр LazySingleton створено");
            }
            public static LazySingleton Instance
            {
                get
                {
                    return lazy.Value;
                }
            }
            public void DoSomething()
            {
                Count++;
                Console.WriteLine($"LazySingleton: метод викликано {Count} разів");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Демонстрація патерну Singleton:");
                Console.WriteLine("\n1. Класичний Singleton з подвійною перевіркою блокування:");
                Singleton s1 = Singleton.GetInstance();
                s1.DoSomething();
                Singleton s2 = Singleton.GetInstance();
                s2.DoSomething();
                Console.WriteLine($"s1 і s2 - це той самий об'єкт: {ReferenceEquals(s1, s2)}");
                Console.WriteLine("\n2. Сучасна реалізація з властивістю Instance:");
                ModernSingleton ms1 = ModernSingleton.Instance;
                ms1.DoSomething();
                ModernSingleton ms2 = ModernSingleton.Instance;
                ms2.DoSomething();
                Console.WriteLine($"ms1 і ms2 - це той самий об'єкт: {ReferenceEquals(ms1, ms2)}");
                Console.WriteLine("\n3. Реалізація з використанням Lazy<T>:");
                LazySingleton ls1 = LazySingleton.Instance;
                ls1.DoSomething();
                LazySingleton ls2 = LazySingleton.Instance;
                ls2.DoSomething();
                Console.WriteLine($"ls1 і ls2 - це той самий об'єкт: {ReferenceEquals(ls1, ls2)}");
                Console.ReadKey();
            }
        }
    }
}