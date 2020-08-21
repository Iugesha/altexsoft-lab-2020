using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;



namespace Module1
{
    abstract class FileClass
    {
        public string text;
        public Dictionary<string, string> fileList;
        public void DisplayFile(string dirName)
        {
            string[] files = Directory.GetFiles(dirName);

            if (files.Length > 1)
            {
                this.fileList = new Dictionary<string, string>(files.Length);
                Console.WriteLine("Файлы:");
                Array.Sort(files);
                foreach (string s in files)
                {

                    this.fileList.Add(Convert.ToString(Array.IndexOf(files, s)), s);
                }
                foreach (KeyValuePair<string, string> keyValue in this.fileList)
                {
                    Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                }
            }
            else
            {
                Console.WriteLine("Данная папка не содержит файлы");
            }
        }

        public void SelectFile()
        {
            Console.WriteLine("Введите индекс файла:");
            string index = Console.ReadLine();
            string fileName;

            if (this.fileList.TryGetValue(index, out fileName))
            {
                Console.WriteLine(fileName);

                if (File.Exists(fileName) == true)
                {
                    this.text = File.ReadAllText(@fileName);
                }
                else
                {
                    Console.WriteLine("Файл для считывания не найден");
                }
            }
            else
            {
                Console.WriteLine("Вы ввели неверный индекс");
                this.SelectFile();
            }
        }
    }

    class Task1 : FileClass
    {
        public Task1()
        {
            this.DisplayFile("./");
            this.SelectFile();
            this.Run();
        }

        public void Run()
        {
            File.WriteAllText("less1.2.txt", this.text);

            Console.WriteLine("Vvedite simvol/slovo: ");

            string input = Console.ReadLine();

            int indexOfinput = text.IndexOf(input);

            if (indexOfinput == -1)
            {
                Console.WriteLine("Dannogo sochetania simvolov net v tekste");
            }
            else
            {
                string text = this.text.Replace(input, "");
                Console.WriteLine("Vash tekst: '{0}'\n", text);
                File.WriteAllText(@"less1.1.txt", text);
            }
        }
    }

    class Task2 : FileClass
    {
        public Task2()
        {
            this.DisplayFile("./");
            this.SelectFile();
            this.Run();
        }

        public void Run()
        {
            Regex regex = new Regex(@"\b\w+[-']*\w*\b");

            MatchCollection matches = regex.Matches(this.text);

            Console.WriteLine(matches.Count);


            string[] stringTen = new string[matches.Count / 10];

            for (int i = 1; i * 10 < matches.Count; i++)
            {
                stringTen[i - 1] = matches[i * 10 - 1].Value;
            };


            Console.WriteLine(String.Join(", ", stringTen));
        }
    }

    class Task3 : FileClass
    {
        public Task3()
        {
            this.DisplayFile("./");
            this.SelectFile();
            this.Run();
        }

        public void Run()
        {
            Regex regex1 = new Regex(@"([А-ЯA-Z]((т.п.|т.д.|пр.)|[^?!.\(]|\([^\)]*\))*[.?!])");
            MatchCollection matches1 = regex1.Matches(this.text);
            Console.WriteLine(string.Concat(matches1[2].Value.Reverse()));
        }
    }

    class Task4 : FileClass
    {
        public Task4()
        {
            this.Run();
        }

        public void Run()
        {
            Console.WriteLine("Введите путь (пример С:temp\\):");
            string dirName = Console.ReadLine();
            string[] dirn = Directory.GetDirectories(dirName);
            Dictionary<string, string> tabl = new Dictionary<string, string>(dirn.Length);
            try
            {

                if (Directory.Exists(dirName))
                {
                    if (dirn.Length > 0)
                    {
                        Console.WriteLine("Папки:");
                        Array.Sort(dirn);
                        foreach (string s in dirn)
                        {
                            tabl.Add(Convert.ToString(Array.IndexOf(dirn, s)), s);
                        }

                        foreach (KeyValuePair<string, string> keyValue in tabl)
                        {
                            Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
                        }

                        Console.WriteLine("Введите индекс интересующей папки:");

                        string fb = Console.ReadLine();
                        string mar;

                        if (tabl.TryGetValue(fb, out mar))
                        {
                            Console.WriteLine(mar);
                            this.DisplayFile(mar);
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели неверный индекс");
                        }


                    }

                    else
                    {
                        Console.WriteLine("Данная папка не содержит вложенные папки");
                    }
                }

            }

            catch
            {
                Console.WriteLine("Повезет в следующий раз. Но это не точно)))");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Считать файл и удалить символ/слово - введите 1. \n" +
                "Считать файл, вывести количество слов и каждое десятое слово через запятую - введите 2.\n" +
                "Вывести 3-е предложение так, чтобы буквы стояли в обратном порядке - введите 3.\n" +
                "Вывести Вывести имена папок по указанному пути в консоли - введите 4.\n" + "Сделайте свой выбор: ");
            string vibor = Console.ReadLine();
            switch (vibor)
            {
                case "1":
                    new Task1();
                    break;
                case "2":
                    new Task2();
                    break;
                case "3":
                    new Task3();
                    break;
                case "4":
                    new Task4();
                    break;
                default:
                    Console.WriteLine("Вы нажали неверный символ");
                    break;
            }

        }
    }
}
