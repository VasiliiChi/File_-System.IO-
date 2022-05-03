using System;
using System.IO;

namespace Task3

/*Доработайте программу из задания 1, используя ваш метод из задания 2.

При запуске программа должна:

                         1.Показать, сколько весит папка до очистки.Использовать метод из задания 2. 
                         2.Выполнить очистку.
                         3.Показать сколько файлов удалено и сколько места освобождено.
                         4.Показать, сколько папка весит после очистки.*/

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки:");
            string path = Console.ReadLine();

            var directories = new DirectoryInfo(path);
            string search = "";
            float sizeBefore = 0.0f;
            float sizeAfter = 0.0f;

            Console.WriteLine("По указанному пути находятся: \nпапки:");


            if (directories.Exists)
            {
                DirectoryInfo[] dirs = directories.GetDirectories(search, SearchOption.AllDirectories);
                foreach (DirectoryInfo dir in dirs)
                {
                    Console.WriteLine("\t" + dir);
                }


                Console.WriteLine("\nфайлы:");
                FileInfo[] filesBefore = directories.GetFiles(search, SearchOption.AllDirectories);

                foreach (FileInfo fileSizeBefore in filesBefore)
                {
                    sizeBefore += fileSizeBefore.Length;
                    Console.WriteLine("\t" + fileSizeBefore);

                    if (DateTime.Now - fileSizeBefore.LastWriteTime >= TimeSpan.FromMinutes(30))
                    {
                        fileSizeBefore.Delete();
                    }

                }

                FileInfo[] filesAfter = directories.GetFiles(search, SearchOption.AllDirectories);
                foreach (FileInfo fileSizeAfter in filesAfter)
                {
                    sizeAfter += fileSizeAfter.Length;
                }

                Console.WriteLine($"\nРазмер папки до удаления файлов составляет: {sizeBefore} байт.");


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
            Console.WriteLine($"\nРазмер папки после удаления файлов составляет: {sizeAfter} байт.");
            Console.ReadKey();



            Console.ReadKey();
        }
    }
}
