using System;
using System.IO;
using System.Text;

namespace ConsoleApp2
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter root directory path: ");
            string path = Console.ReadLine();

            try
            {
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Invalid path!");
                    return;
                }

                DirectoryInfo dir = new DirectoryInfo(path);
                DirectoryInfo[] subDirs = dir.GetDirectories();

                foreach (DirectoryInfo sub in subDirs)
                {
                    int fileCount = sub.GetFiles().Length;

                    Console.WriteLine($"Folder: {sub.Name}");
                    Console.WriteLine($"Files Count: {fileCount}");
                    Console.WriteLine("----------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
    }
}

