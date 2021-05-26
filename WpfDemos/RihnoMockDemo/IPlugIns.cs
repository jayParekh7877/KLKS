using System.Collections.Generic;

namespace RihnoMockDemo
{
    public interface IPlugIns
    {
        List<IPlugInType> GetPlugIns();
    }
}