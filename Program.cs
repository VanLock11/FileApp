using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FilleApp
{
    class Program
    {
        //We check whether there is already a classified element with this name
        public static bool ReadFile(string filePhat, string folder)
        {
            return File.Exists(folder + "\\" + Path.GetFileNameWithoutExtension(filePhat) + ".lip");
        }
        static void Main(string[] args)
        {
            string uzerName = Environment.UserName;
            Console.WriteLine("\n\tHi " + uzerName + "!!\n");
            //Path to the folder with the files
            string folderPath = Environment.ExpandEnvironmentVariables("%SystemDrive%\\Users\\" + uzerName + "\\Desktop\\YourFile");
            Console.WriteLine("Your secret-folder path : " + folderPath + "\n\n");
            DirectoryInfo FolderCreat = new DirectoryInfo(folderPath);

            //Check the existence of the folder
            if (!FolderCreat.Exists)
            {
                FolderCreat.Create();
                //Instruction
                Console.WriteLine("Move your files to this folder and the program will make their secret copy .");
            }
            else
            {
                //An array with names and path files
                string[] FileName = Directory.GetFiles(folderPath);
                //Check for array elements
                if (FileName.GetLength(0) != 0)
                {

                    foreach (string t in FileName)
                    {
                        //Check file privacy
                        if (Path.GetExtension(t) != ".lip")
                        {
                            //Check for a secret copy
                            if (!ReadFile(t, folderPath))
                            {
                                File.Copy(t, folderPath + "\\" + Path.GetFileNameWithoutExtension(t) + ".lip");
                                Console.WriteLine(Path.GetFileNameWithoutExtension(t));
                            }
                            else
                            {
                                Console.WriteLine("You have secret copy " + Path.GetFileNameWithoutExtension(t) + " file!");
                            }
                        }
                    }
                    Console.WriteLine("\n\tHappy End !");
                }
                else
                {
                    Console.WriteLine("I`m sory ,but You ende file.");
                }
            }

            Console.ReadKey();
        }
    }
}
