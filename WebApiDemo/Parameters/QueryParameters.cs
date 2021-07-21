using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Parameters
{
    public class QueryParameters
    {
        private const int MaxSiZe = 100;
        private int _size = 50;

        public int Page { get; set; }

        public int Size
        {
            get => _size;
            set => _size = Math.Min(MaxSiZe, value);
        }
    }
}
