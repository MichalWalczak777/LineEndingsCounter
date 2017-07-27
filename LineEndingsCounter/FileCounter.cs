using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace LineEndingsCounter
{
    class FileCounter
    {
        int CRLFEndingsFilesCounter = 0;
        int LFEndingsFilesCounter = 0;
        int MixedEndingsFilesCounter = 0;

        List<string> LFEndingsFilesList = new List<string>();
        List<string> MixedEndingsFilesList = new List<string>();



        public void CountAndDisplay(string sDir)
        {
            CountFiles(sDir);
            DisplayResults();
        }



        public void CountFiles(string sDir)
        {

            string text = "";


                foreach (string filePath in Directory.GetFiles(sDir, "*cs"))
                {
                    text = (File.ReadAllText(filePath));

                switch ((CheckLineEndings(text)))
                {
                    case EndingsType.LF:
                        LFEndingsFilesCounter++;
                        LFEndingsFilesList.Add(filePath);
                        break;
                    case EndingsType.MIXED:
                        MixedEndingsFilesCounter++;
                        MixedEndingsFilesList.Add(filePath);
                        break;
                    case EndingsType.CRLF:
                        CRLFEndingsFilesCounter++;
                        break;

                }

                }
                foreach (string filePath in Directory.GetDirectories(sDir))
                {
                    CountFiles(filePath);
                }


        }

        private EndingsType CheckLineEndings(string text)
        {
            int CRCtr = 0;
            int LFCtr = 0;

            EndingsType lastEnding = EndingsType.UNKNOWN;
            bool canBeCRLF = true;

            foreach (char c in text)
            {
                switch (c)
                {
                    case '\n':
                        LFCtr++;

                        if(lastEnding == EndingsType.LF)
                        {
                            canBeCRLF = false;
                        }

                        lastEnding = EndingsType.LF;
                        break;

                    case '\r':
                        CRCtr++;

                        if (lastEnding == EndingsType.CR)
                        {
                            canBeCRLF = false;
                        }

                        lastEnding = EndingsType.CR;
                        break;
                }
            }


            if (CRCtr == LFCtr && CRCtr != 0 && canBeCRLF)
            { 
                return EndingsType.CRLF;
            }
            else if (CRCtr == 0 && LFCtr != 0)
            {
                return EndingsType.LF;
            }

            else if (CRCtr != 0 && LFCtr != 0)
            {
                return EndingsType.MIXED;
            }
            else
            {
                return EndingsType.UNKNOWN;
            }
        }



        private void DisplayResults()
        {
            Console.WriteLine("liczba plikow z CRLF: " + CRLFEndingsFilesCounter);
            Console.WriteLine(" ");

            Console.WriteLine("liczba plikow z LF: " + LFEndingsFilesCounter);
            Console.WriteLine("Lista plikow z LF: ");

            foreach (string filePath in LFEndingsFilesList)
            {
                Console.WriteLine(filePath);
            }

            Console.WriteLine(" ");
            Console.WriteLine("Liczba plikow z mieszanymi zakonczeniami: " + MixedEndingsFilesCounter);
            Console.WriteLine("Lista plikow z mieszanymi zakonczeniami: ");

            foreach (string filePath in MixedEndingsFilesList)
            {
                Console.WriteLine(filePath);
            }

            Thread.Sleep(40000);
        }


    }
}
