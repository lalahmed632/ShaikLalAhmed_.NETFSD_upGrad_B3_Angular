using System;
using System.IO;
using System.Text;

namespace ConsoleApp2
{
     class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\File\\file.txt";

            try
            {
                Console.Write("Enter message: ");
                string message = Console.ReadLine();

                // Convert string to byte array
                byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

                // Open file in Append mode
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    fs.Write(data, 0, data.Length);
                }

                Console.WriteLine("Message written successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

