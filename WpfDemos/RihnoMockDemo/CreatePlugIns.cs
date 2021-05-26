using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RihnoMockDemo
{
    public class CreatePlugIns
    {
        private readonly IPlugIns _plugIns;
        private readonly IPlugIns _plugInsWithRihnoMock;

        public CreatePlugIns(IPlugIns plugIns,IPlugIns plugInsWithRihnoMock)
        {
            _plugIns = plugIns;
            _plugInsWithRihnoMock = plugInsWithRihnoMock;
        }

        public IEnumerable<IPlugInType> GetAllPlugIns()
        {
            return _plugIns.GetPlugIns();
        }

        public IEnumerable<IPlugInType> GetAllPlugInsRhinoMock()
        {
            return _plugInsWithRihnoMock.GetPlugIns();
        }
    }
}
