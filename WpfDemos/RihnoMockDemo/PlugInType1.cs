using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RihnoMockDemo
{

    public class PlugInType1 : IPlugInType
    {
        public string GetPlugInName()
        {
            return "This is First PlugInType1";
        }

        public int Id { get { return 1; } set { } }
    }


}
