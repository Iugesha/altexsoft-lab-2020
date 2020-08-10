using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;



namespace Module1
{
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
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                case "4":
                    Task4();
                    break;
                default:
                    Console.WriteLine("Вы нажали неверный символ");
                    break;
            }
        
        }


        static void Task1()
        {
            string curFile = @"less1.1.txt";
            if (File.Exists(curFile) == true)
            {
                string text = File.ReadAllText(@"less1.1.txt");

                File.WriteAllText("less1.2.txt", $"{text}");

                Console.WriteLine("Vvedite simvol/slovo: ");
                string input = Console.ReadLine();

                int indexOfinput = text.IndexOf(input);

                if (indexOfinput == -1)
                {
                    Console.WriteLine("Dannogo sochetania simvolov net v tekste");
                }
                else
                {
                    text = text.Replace($"{input}", "");
                    Console.WriteLine("Vash tekst: '{0}'\n", text);
                    File.WriteAllText(@"less1.1.txt", "{text}");
                }
            }
            else
            {
                Console.WriteLine("Файл для считывания не найден");
            }
        }

            static void Task2()
        {
            string curFile = @"less1.txt";
            if (File.Exists(curFile) == true)
            {
                string text = File.ReadAllText(@"less1.txt");
                
                    Regex regex = new Regex(@"\b\w+[-']*\w*\b");
                    MatchCollection matches = regex.Matches(text);
                    Console.WriteLine(matches.Count);

                    for (int i = 9; i < matches.Count; i += 10)
                    {

                        Console.Write(String.Join(",", matches[i].Value, " "));

                    }
                
            }
            else
            {
                Console.WriteLine("Файл для считывания не найден");
            }
        }


        static void Task3()
        {
            string curFile = @"less1.txt";
            if (File.Exists(curFile) == true)
            {
                string text = File.ReadAllText(@"less1.txt");
            Regex regex1 = new Regex(@"([А-ЯA-Z]((т.п.|т.д.|пр.)|[^?!.\(]|\([^\)]*\))*[.?!])");
            MatchCollection matches1 = regex1.Matches(text);
            Console.WriteLine(string.Concat(matches1[2].Value.Reverse()));
            }
            else
            {
                Console.WriteLine("Файл для считывания не найден");
            }

        }




        static void Task4()
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
                             
                                string[] files = Directory.GetFiles(mar);
                            if (files.Length > 1)
                            {
                                Console.WriteLine("Файлы:");
                                Array.Sort(files);
                                foreach (string f in files)
                                {
                                    Console.WriteLine(f);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Данная папка не содержит файлы");
                            }
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
}
    