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
            ExampleFilesCreator fileCreator = new ExampleFilesCreator();

            string path = System.Environment.CurrentDirectory;
            path = Directory.GetParent(Directory.GetParent(path).ToString()).ToString();
            path = path + "\\Endings";

            fileCreator.CreateCRLFEndingsFiles(path, "subfolder1", 3);
            fileCreator.CreateLFEndingsFiles(path, "subfolder1", 2);
            fileCreator.CreateLFEndingsFiles(path, "", 1);
            fileCreator.CreateMixedEndingsFiles(path, "subfolder2", 4);

            ds.CountAndDisplay(path);
        }

    }
}

