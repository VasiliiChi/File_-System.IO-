using System;
using System.IO;

namespace Task2

// Напишите программу, которая считает размер папки на диске (вместе со всеми вложенными папками и файлами).
// На вход метод принимает URL директории, в ответ — размер в байтах.

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки:");
            string path = Console.ReadLine();

            var directories = new DirectoryInfo(path);
            string search = "";
            float size = 0.0f;


            if (directories.Exists)
            {
                FileInfo[] files = directories.GetFiles(search, SearchOption.AllDirectories);
                foreach (FileInfo file in files)
                {
                    size += file.Length;
                }
                Console.WriteLine($"Размер папки {size} байт.");
            }

            Console.ReadKey();
        }
    }
}
