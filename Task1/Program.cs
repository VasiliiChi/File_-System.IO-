using System;
using System.IO;

namespace Task1

// Напишите программу, которая чистит нужную нам папку от файлов  и папок, которые не использовались более 30 минут

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки:");
            string path = Console.ReadLine();

            var directories = new DirectoryInfo(path);
            string search = "";

            Console.WriteLine("По указанному пути находятся: \nпапки:");


            if (directories.Exists)
            {
                DirectoryInfo[] dirs = directories.GetDirectories(search, SearchOption.AllDirectories);
                foreach (DirectoryInfo dir in dirs)
                {
                    Console.WriteLine("\t" + dir);
                }


                Console.WriteLine("\nфайлы:");
                FileInfo[] files = directories.GetFiles(search, SearchOption.AllDirectories);
                foreach (FileInfo file in files)
                {
                    Console.WriteLine("\t" + file);

                    if (DateTime.Now - file.LastWriteTime >= TimeSpan.FromMinutes(30))
                    {
                        file.Delete();
                    }
                }


                int ndirs = directories.GetDirectories(search, SearchOption.AllDirectories).Length;
                for (int i = ndirs - 1; i >= 0; i--)
                {
                    DirectoryInfo[] dirs1 = directories.GetDirectories(search, SearchOption.AllDirectories);
                    foreach (DirectoryInfo delDir in dirs1)
                    {
                        if (delDir.GetDirectories().Length == 0 && delDir.GetFiles().Length == 0)
                        {
                            delDir.Delete();
                        }

                    }
                }

            }

            Console.WriteLine("\nУдалены пустые папки и файлы измененные более, чем 30 минут назад.");
            Console.ReadKey();


        }
    }
}
