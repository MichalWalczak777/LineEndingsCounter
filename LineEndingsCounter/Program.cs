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

            string path = System.Environment.CurrentDirectory;
            path = Directory.GetParent(Directory.GetParent(path).ToString()).ToString();
            path = path + "\\Endings";

            ds.CountAndDisplay(path);
        }

    }
}

