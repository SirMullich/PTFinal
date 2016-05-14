using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Please enter full directory path: ");
            string path = Console.ReadLine();
            DirectoryInfo dir = new DirectoryInfo(path);

            //Все файлы из dir запоминаем в list
            List<FileInfo> files = new List<FileInfo>();
            files.AddRange(dir.GetFiles());

            Console.WriteLine("The following files have exactly one \"hello world\" in them: " + Environment.NewLine);

            // Read each file
            foreach (var file in files)
            {
                StreamReader sr = new StreamReader(file.FullName);
                string text = sr.ReadToEnd();
                sr.Close();

                // Loop through all instances of "hello world" in text
                int i = 0;
                int count = 0;
                while ((i = text.IndexOf("hello world", i)) != -1)
                {
                    // Print out the substring.
                    count++;
                    // Increment the index.
                    i++;
                }

                // Console.WriteLine("{0} has {1} \"HW\" in it", file.FullName, count);

                // Print out only files with one occurence of "hello world"
                if (count == 1)
                {
                    Console.WriteLine(file.Name);
                }

            }
        }
    }
}
