using System.Collections.Generic;
using Unity;

namespace RihnoMockDemo
{
    public class MainClassForTest
    {
        private readonly CreatePlugIns _createPlugIns;
        public MainClassForTest()
        {
            var serviceLocator = new ServiceLocator();
            _createPlugIns = serviceLocator.GetServiceLocator().Resolve<CreatePlugIns>();
        }

        public IEnumerable<IPlugInType> TestPlugIns()
        {
            return _createPlugIns.GetAllPlugIns();
        }
    }
}