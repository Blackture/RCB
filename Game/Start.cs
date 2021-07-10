using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCB.Game
{
    class Start
    {
        public static void AbilitySelection(string Element, int PlayerID)
        {
            if (Element == "Water")
            {
                string AbilityString;
                do {
                    Console.Clear();
                    AbilityString = "";
                    Console.Clear();
                    Console.WriteLine($"{Program.Players[PlayerID].Name} choose your abilities from the list below:");
                    Console.WriteLine("[1] Smash\t\t[2] Coin Toss\t\t[3] Stunning Blow\t\t[4] Adrenaline Rush");
                    Console.WriteLine("[5] Kick\t\t[6] Soapbubble\t\t[7] Potion Brewer\t\t[8] Change Aggregate State");
                    for (int i = 0; i < 4; i++)
                    {
                        Console.SetCursorPosition(0, 4);
                        Console.WriteLine($"You already selected:\t{ AbilityString.Replace(';', '\t')}");
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                AbilityString += "Smash;";
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                AbilityString += "Coin Toss;";
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                AbilityString += "Stunning Blow;";
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                AbilityString += "Adrenaline Rush;";
                                break;
                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                AbilityString += "Kick;";
                                break;
                            case ConsoleKey.D6:
                            case ConsoleKey.NumPad6:
                                AbilityString += "Soapbubble;";
                                break;
                            case ConsoleKey.D7:
                            case ConsoleKey.NumPad7:
                                AbilityString += "Potion Brewer;";
                                break;
                            case ConsoleKey.D8:
                            case ConsoleKey.NumPad8:
                                AbilityString += "Change Aggregate State;";
                                break;
                        }
                    }
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine($"Your selection: { AbilityString.Replace(";", ", ")}is it? | [N]o, I want to change something! | Push another button to continue.");
                } while (Console.ReadKey(true).Key == ConsoleKey.N);
                Program.Players[PlayerID].Abilities = AbilityString.Split(';');
            }
            if (Element == "Fire")
            {
                string AbilityString;
                do
                {
                    Console.Clear();
                    AbilityString = "";
                    Console.Clear();
                    Console.WriteLine($"{Program.Players[PlayerID].Name} choose your abilities from the list below:");
                    Console.WriteLine("[1] Smash\t\t[2] Coin Toss\t\t[3] Stunning Blow\t\t[4] Adrenaline Rush");
                    Console.WriteLine("[5] Kick\t\t[6] Soapbubble\t\t[7] Potion Brewer\t\t[8] Flamethrower");
                    for (int i = 0; i < 4; i++)
                    {
                        Console.SetCursorPosition(0, 4);
                        Console.WriteLine($"You already selected:\t{ AbilityString.Replace(';', '\t')}");
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                AbilityString += "Smash;";
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                AbilityString += "Coin Toss;";
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                AbilityString += "Stunning Blow;";
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                AbilityString += "Adrenaline Rush;";
                                break;
                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                AbilityString += "Kick;";
                                break;
                            case ConsoleKey.D6:
                            case ConsoleKey.NumPad6:
                                AbilityString += "Soapbubble;";
                                break;
                            case ConsoleKey.D7:
                            case ConsoleKey.NumPad7:
                                AbilityString += "Potion Brewer;";
                                break;
                            case ConsoleKey.D8:
                            case ConsoleKey.NumPad8:
                                AbilityString += "Flamethrower;";
                                break;
                        }
                    }
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine($"Your selection: { AbilityString.Replace(";", ", ")}is it? | [N]o, I want to change something! | Push another button to continue.");
                } while (Console.ReadKey(true).Key == ConsoleKey.N);
                Program.Players[PlayerID].Abilities = AbilityString.Split(';');
            }
            if (Element == "Earth")
            {
                string AbilityString;
                do
                {
                    Console.Clear();
                    AbilityString = "";
                    Console.Clear();
                    Console.WriteLine($"{Program.Players[PlayerID].Name} choose your abilities from the list below:");
                    Console.WriteLine("[1] Smash\t\t[2] Coin Toss\t\t[3] Stunning Blow\t\t[4] Adrenaline Rush");
                    Console.WriteLine("[5] Kick\t\t[6] Soapbubble\t\t[7] Potion Brewer\t\t[8] Mossy Mountains");
                    for (int i = 0; i < 4; i++)
                    {
                        Console.SetCursorPosition(0, 4);
                        Console.WriteLine($"You already selected:\t{ AbilityString.Replace(';', '\t')}");
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                AbilityString += "Smash;";
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                AbilityString += "Coin Toss;";
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                AbilityString += "Stunning Blow;";
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                AbilityString += "Adrenaline Rush;";
                                break;
                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                AbilityString += "Kick;";
                                break;
                            case ConsoleKey.D6:
                            case ConsoleKey.NumPad6:
                                AbilityString += "Soapbubble;";
                                break;
                            case ConsoleKey.D7:
                            case ConsoleKey.NumPad7:
                                AbilityString += "Potion Brewer;";
                                break;
                            case ConsoleKey.D8:
                            case ConsoleKey.NumPad8:
                                AbilityString += "Mossy Mountains;";
                                break;
                        }
                    }
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine($"Your selection: { AbilityString.Replace(";", ", ")}is it? | [N]o, I want to change something! | Push another button to continue.");
                } while (Console.ReadKey(true).Key == ConsoleKey.N);
                Program.Players[PlayerID].Abilities = AbilityString.Split(';');
            }
            if (Element == "Air")
            {
                string AbilityString;
                do
                {
                    Console.Clear();
                    AbilityString = "";
                    Console.Clear();
                    Console.WriteLine($"{Program.Players[PlayerID].Name} choose your abilities from the list below:");
                    Console.WriteLine("[1] Smash\t\t[2] Coin Toss\t\t[3] Stunning Blow\t\t[4] Adrenaline Rush");
                    Console.WriteLine("[5] Kick\t\t[6] Soapbubble\t\t[7] Potion Brewer\t\t[8] Tornado");
                    for (int i = 0; i < 4; i++)
                    {
                        Console.SetCursorPosition(0, 4);
                        Console.WriteLine($"You already selected:\t{ AbilityString.Replace(';', '\t')}");
                        switch (Console.ReadKey(true).Key)
                        {
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                AbilityString += "Smash;";
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                AbilityString += "Coin Toss;";
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                AbilityString += "Stunning Blow;";
                                break;
                            case ConsoleKey.D4:
                            case ConsoleKey.NumPad4:
                                AbilityString += "Adrenaline Rush;";
                                break;
                            case ConsoleKey.D5:
                            case ConsoleKey.NumPad5:
                                AbilityString += "Kick;";
                                break;
                            case ConsoleKey.D6:
                            case ConsoleKey.NumPad6:
                                AbilityString += "Soapbubble;";
                                break;
                            case ConsoleKey.D7:
                            case ConsoleKey.NumPad7:
                                AbilityString += "Potion Brewer;";
                                break;
                            case ConsoleKey.D8:
                            case ConsoleKey.NumPad8:
                                AbilityString += "Tornado;";
                                break;
                        }
                    }
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine($"Your selection: { AbilityString.Replace(";", ", ")}is it? | [N]o, I want to change something! | Push another button to continue.");
                } while (Console.ReadKey(true).Key == ConsoleKey.N);
                Program.Players[PlayerID].Abilities = AbilityString.Split(';');
            }
        }
    }
}
