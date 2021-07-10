using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RCB
{
    class Program
    {
        public static List<Player.IPlayerStats> Players = new List<Player.IPlayerStats>();
        static void menue()
        {
            Console.Clear();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~  Welcome to RCB  ~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("[1] Create characters");
            Console.WriteLine("[2] Play!");
            Console.WriteLine("[9] Quit");
            Console.Write("Your choice:\t");
        }
        public static bool createdCharacters = false;
        static void Main(string[] args)
        {
            Console.Title = "Random Characteristics Battle";
            int auswahl;
            int[] Player1 = new int[5];
            //Ein Spieler wird definiert über fünf Eigenschaften.
            //Gesundheit, Geschicklichkeit, Stärke, Ausdauer, Lernfähigkeit
            //Jede Eigenschaft muss bei der Erstellung mindestens 5 Punkte erhalten.
            int[] RandomPlayer = new int[5];
            do
            {
                menue();
                int.TryParse(Console.ReadLine(), out auswahl);
                switch(auswahl)
                {
                    case 1:
                        if (!createdCharacters)
                            Player.Stats.Create(ref RandomPlayer, ref Player1);
                        else
                            Console.WriteLine("You already created your characters!");
                        break;                        
                    case 2:
                        if (createdCharacters == true)
                        {
                            Console.Clear();
                            Game.Start.AbilitySelection(Players[0].Element, 0);
                            Console.Clear();
                            Game.Start.AbilitySelection(Players[1].Element, 1);
                            Console.Clear();
                            Game.Main.InGame(Players, out Player.IPlayerStats Winner);
                            Console.Clear();
                            do
                            {
                                Console.WriteLine($"\n\tCongratulations @{Winner.Name}, you are the winner!");
                                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                                Console.WriteLine($"\t_..---Press [ESC] to continue---.._");
                            } while (!(Console.ReadKey(true).Key != ConsoleKey.Escape));
                        }
                        else
                        {
                            Console.WriteLine("You have to create the characters first.");
                        }
                        break;
                    case 9:
                        Console.Clear();
                        
                        break;
                    default:
                        Console.Write("\n\t\tInvalid input!");
                        break;
                }
                Console.ReadLine();
            } while (auswahl != 9);
        }
    }
}
