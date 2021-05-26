using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAndDelegates1
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> stringProcessingDelegate = Method1;
            stringProcessingDelegate += Method2;
            stringProcessingDelegate -= Method1;

            Console.WriteLine("Invoking the delegate with one as parameter");
            stringProcessingDelegate.Invoke("one");
            Console.WriteLine();

            stringProcessingDelegate += Method1;
            Console.WriteLine("Invoking the delegate with two as parameter");
            stringProcessingDelegate.Invoke("two");
        }

        private static void Method1(string a)
        {
            Console.WriteLine("Method1 " + a);
        }

        private static void Method2(string a)
        {
            Console.WriteLine("Method2 " + a);
        }

    }

}
