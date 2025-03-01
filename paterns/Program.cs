using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paterns
{
    public interface IRealSubject
    {
        void Request();
    }
    public class RealSubject : IRealSubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling request.");
        }
    }
    public class Proxy : IRealSubject
    {
        private RealSubject _realSubject;
        public void Request()
        {
            Console.WriteLine("Proxy: Checking access before forwarding the request.");
            if (_realSubject == null)
            {
                _realSubject = new RealSubject();
            }
            _realSubject.Request();
        }
    }
    class Program
    {
        static void Main()
        {
            IRealSubject proxy = new Proxy();
            proxy.Request();
        }
    }
}