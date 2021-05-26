using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace RihnoMockDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
           
            Console.ReadKey();
        }
    }

    public class ServiceLocator : UnityContainer
    {
        private readonly UnityContainer _container;
        public UnityContainer GetServiceLocator()
        {
            return _container;
        }

        public ServiceLocator()
        {
            _container = new UnityContainer();
            _container.RegisterType<IPlugIns, PlugIns>();
            _container.RegisterType<IPlugInType, PlugInType1>();
            //_container.RegisterType<IPlugInType, PlugInType2>();//If i Comment this line still it works, y ?
        }
    }
}
