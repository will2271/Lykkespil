using System;

namespace Lykkespil
{
    class Program
    {
        static void Main(string[] args)
        {
            spil();
        }
        static void scoretavle(int antal_deltagere, string[] deltager, int[] skattekiste)
        {
            Console.WriteLine("Indhold i skattekister:");
            for (int i = 0; antal_deltagere > i; i++)
            {
                Console.WriteLine($"{deltager[i]}: {skattekiste[i]}");
                Console.WriteLine("");
            }
        }
        static void spil()
        {
            Console.Write("Indtast antal deltagere i dette spil: ");
            int antal_deltagere = int.Parse(Console.ReadLine());
            string[] deltager = new string[antal_deltagere];
            int[] skattekiste = new int[antal_deltagere];
            bool vinder = false;
            bool runde = true;
            Random rnd = new Random();
            for (int i = 0; i != antal_deltagere; i++)
            {
                Console.Write($"Indtast deltager {i + 1}: ");
                deltager[i] = Console.ReadLine();
            }
            Console.WriteLine("Tryk \"Spacebar\" for at kaste terningen:");
            while (vinder == false)
            {
                for (int i = 0; i != antal_deltagere; i++)
                {
                    int[] kast = new int[20];
                    int sum = 0;
                    runde = true;
                    Console.WriteLine("");
                    Console.WriteLine($"Det er nu {deltager[i]}s tur:");
                    Console.WriteLine("");
                    if (Console.ReadKey(true).Key == ConsoleKey.S)
                        do
                        {
                            scoretavle(antal_deltagere, deltager, skattekiste);
                            Console.WriteLine($"Det er nu {deltager[i]}s tur. Tryk \"Spacebar\" for at kaste terningen: ");
                            Console.WriteLine("");
                        } while (Console.ReadKey(true).Key == ConsoleKey.S);

                    for (int kast_index = 0; runde == true; kast_index++) //runde start
                    {

                        kast[kast_index] = rnd.Next(1, 7);
                        if (kast[kast_index] == 1)
                        {
                            Console.Write($"{deltager[i]} slår: 1 ");
                            runde = false;
                        }
                        else
                        {
                            Console.Write($"{deltager[i]} slår:");
                            foreach (int nummer in kast)
                                if (nummer > 0)
                                    Console.Write($" {nummer},");
                            Console.WriteLine(" Læg samlede kast i kisten? (tryk \"Enter\")");
                            var userinput = Console.ReadKey(true).Key;
                            if (userinput == ConsoleKey.Enter)
                            {
                                Console.WriteLine("");
                                Console.Write($"{deltager[i]} vælger at stoppe, ");
                                for (int i3 = 0; i3 != kast_index + 1; i3++)
                                    sum = sum + kast[i3];
                                Console.Write("der bliver lagt ");
                                for (int i2 = 0; i2 <= kast_index; i2++)
                                {
                                    if (i2 != kast_index)
                                        Console.Write($" {kast[i2]} + ");
                                    else
                                        Console.Write($" {kast[i2]} ");
                                }
                                skattekiste[i] = sum + skattekiste[i];
                                if (skattekiste[i] >= 100)
                                    vinder = true;
                                Console.WriteLine($"= {sum} i skattekisten. Tryk \"S\" for at se scoretavlen.");
                                Console.WriteLine("");
                                userinput = ConsoleKey.Spacebar;
                                runde = false;
                            }
                            else if (userinput != ConsoleKey.Spacebar)
                                while (userinput != ConsoleKey.Spacebar)
                                {
                                    Console.WriteLine("Tryk \"Spacebar\" for at kaste igen");
                                    userinput = Console.ReadKey(true).Key;
                                }
                            else
                                runde = true;
                        }

                    }
                    if (vinder == true)
                    {
                        scoretavle(antal_deltagere, deltager, skattekiste);
                        Console.WriteLine($"{deltager[i]} har vundet!");
                    }
                }
            }
            Console.WriteLine("Spillet er slut.");
        }
    }
}
