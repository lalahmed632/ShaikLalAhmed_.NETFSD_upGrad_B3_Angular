using System;
using System.IO;
using System.Text;

namespace ConsoleApp2
{
     class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter folder path: ");
            string path = Console.ReadLine();

            try
            {
                if (!Directory.Exists(path))
                {
                    Console.WriteLine("Invalid directory path!");
                    return;
                }

                string[] files = Directory.GetFiles(path);

                Console.WriteLine("\nFiles Details:\n");

                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);

                    Console.WriteLine($"Name: {info.Name}");
                    Console.WriteLine($"Size: {info.Length} bytes");
                    Console.WriteLine($"Created: {info.CreationTime}");
                    Console.WriteLine("----------------------");
                }

                Console.WriteLine($"Total Files: {files.Length}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

