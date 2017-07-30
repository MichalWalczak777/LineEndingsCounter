﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LineEndingsCounter
{
    class ExampleFilesCreator
    {

        public void CreateCRLFEndingsFiles(string path, string folderName, int numberOfFiles)
        {
            CreateFiles(path, folderName, numberOfFiles, EndingsType.CRLF);
        }

        public void CreateLFEndingsFiles(string path, string folderName, int numberOfFiles)
        {
            CreateFiles(path, folderName, numberOfFiles, EndingsType.LF);
        }

        public void CreateMixedEndingsFiles (string path, string folderName, int numberOfFiles)
        {
            CreateFiles(path, folderName, numberOfFiles, EndingsType.MIXED);
        }



        private void CreateFiles(string mainDirectory, string folderName, int numberOfFiles, EndingsType type)
        {
            string EndingsOfLine1 = "";
            string EndingsOfLine2 = "";


            Directory.CreateDirectory(mainDirectory + "\\" + folderName);


            for (int i = 0; i < numberOfFiles; i++)
            {

                string filePath = mainDirectory + "\\" + folderName + "\\" + type + "file" + (i+1) + ".cs";

                if (!File.Exists(filePath))
                {
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        switch (type)
                        {
                            case EndingsType.CRLF:
                                {
                                    EndingsOfLine1 = "\r\n";
                                    EndingsOfLine2 = "\r\n";
                                    break;
                                }
                            case EndingsType.LF:
                                {
                                    EndingsOfLine1 = "\n";
                                    EndingsOfLine2 = "\n";
                                    break;
                                }
                            case EndingsType.MIXED:
                                {
                                    EndingsOfLine1 = "\n";
                                    EndingsOfLine2 = "\r\n";
                                    break;
                                }
                        }
                        sw.Write("file generated by CreatedCRLFFiles function" + EndingsOfLine1);
                        sw.Write("line2" + EndingsOfLine2);
                    }
                }
            }
        }
    }
}
