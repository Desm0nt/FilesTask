using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string[] fileArray = Directory.GetFiles(path);
            Console.WriteLine("--- Files: ---");
            int i = 0;
            foreach (string name in fileArray)
            {
                Console.WriteLine((i+1) + ". " + name);
                i++;
            }
            Console.WriteLine("Select the file");
            int filenum = 0;
            do
            {
                var fileNumber = Console.ReadLine();
                if (int.TryParse(fileNumber, out filenum))
                {
                    if (filenum < 1 || filenum > fileArray.Length)
                        Console.WriteLine("File not exist. Number must be between 1 and " + fileArray.Length + ".");
                }
                else
                    Console.WriteLine("Number must be int32. Please try again.");
            } while (filenum < 1 || filenum > fileArray.Length);
            using (FileStream fileStream = File.OpenRead(fileArray[filenum-1]))
            {
                byte[] data = new byte[fileStream.Length];
                for (int index = 0; index < fileStream.Length; index++)
                {
                    data[index] = (byte)fileStream.ReadByte();
                }
                Console.WriteLine(Encoding.UTF8.GetString(data)); // Displays: MyValue 
            }
            Console.WriteLine("\n\nPress any key to exit");
            Console.ReadLine();
        }
    }
}
