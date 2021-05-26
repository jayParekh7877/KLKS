using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            var validation = new Validation();
            var obj = new INvoice { Subtotal = 100000, Gst = 18, TaxRate = 15 };
            if (validation.IsGreaterThenZero(obj.Subtotal) && validation.IsGreaterThenZero(obj.TaxRate))
            {
                Console.Write("Show total Tax :=> ", obj.CalculateTax());
                Console.Write("Show total Bill :=> ", obj.CalculateTotal());
            }
            else
            {
                Console.Write("Subtotal & TaxRate must be greater then Zero");
            }
        }

    }
}



