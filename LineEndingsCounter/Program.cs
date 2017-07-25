using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace LineEndingsCounter
{
    class Program
    {

        static void Main(string[] args)
        {
            FileCounter ds = new FileCounter();
            ds.CountAndDisplay(@"C:\Users\Michał\Documents\Endings");
        }

    }
}

