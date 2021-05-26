using System.Collections.Generic;

namespace RihnoMockDemo
{
    public class PlugIns : IPlugIns
    {
        public List<IPlugInType> GetPlugIns()
        {
            return new List<IPlugInType>() { new PlugInType1(), new PlugInType2() };
        }
    }
}