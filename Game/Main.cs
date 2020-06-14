using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;

namespace Erstellung_Rollenspiel_Charakter.Game
{
    class Main
    {
        public static int[] PlayerAR = { 0, 0 };
        public static bool[] GetDMGpSec = { false, false };
        public static void InGame(List<Player.IPlayerStats> players2, out Player.IPlayerStats Winner)
        {
            Winner = null;
            Player.IPlayerStats Player1 = players2[0];
            Player.IPlayerStats Player2 = players2[1];
            Random rnd = new Random();
            //Choose starting player
            int turn = rnd.Next(1, 3);

            do //Game goes as long as nobody died
            {
                if (turn > 2)
                {
                    Player1.Agility -= 1;
                    Player2.Agility -= 1;
                    Random random = new Random();
                    int fallingBooks = random.Next(1, 25);
                    if (fallingBooks == 2)
                    {
                        Console.SetCursorPosition(0, 8);
                        Console.Write("Books are falling on top you!");
                        if (Player1.Educability >= 70)
                        {
                            Player1.Health -= 5.0;
                        }
                        if (Player2.Educability >= 70)
                        {
                            Player2.Health -= 5.0;
                        }
                        Thread.Sleep(5000);
                    }
                    turn = 1;
                }
                if (Player1.Agility <= 0)
                {
                    if (Player2.Agility == 0)
                    {
                        Winner = null;
                    }
                    else
                    {
                        Winner = Player2;
                    }
                }
                else if (Player2.Agility <= 0)
                {
                    if (Player1.Agility == 0)
                    {
                        Winner = null;
                    }
                    else
                    {
                        Winner = Player1;
                    }
                }
                #region 5 Stamina every round
                if (turn == 1)
                {
                    if (Player1.Stamina + 5 <= 90)
                    {
                        Player1.Stamina += 5;
                    }
                    else
                    {
                        Player1.Stamina = 90;
                    }
                }
                if (turn == 2)
                {
                    if (Player2.Stamina + 5 <= 90)
                    {
                        Player2.Stamina += 5;
                    }
                    else
                    {
                        Player2.Stamina = 90;
                    }
                }
                #endregion
                Console.Clear();
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                #region Setup ActionFrame
                Console.SetCursorPosition(1, Console.WindowHeight - 2);
                for (int i = 0; i < Console.WindowWidth - 2; i++)
                {
                    Console.Write("_");
                }
                Console.SetCursorPosition(1, Console.WindowHeight - 5);
                for (int i = 0; i < Console.WindowWidth - 2; i++)
                {
                    Console.Write("_");
                }
                Console.SetCursorPosition(1, Console.WindowHeight - 8);
                for (int i = 0; i < Console.WindowWidth - 2; i++)
                {
                    Console.Write("_");
                }
                for (int i = Console.WindowHeight - 7; i <= Console.WindowHeight - 2; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("|");
                }
                for (int i = Console.WindowHeight - 7; i <= Console.WindowHeight - 2; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth - 1, i);
                    Console.Write("|");
                }
                for (int i = Console.WindowHeight - 7; i <= Console.WindowHeight - 2; i++)
                {
                    Console.SetCursorPosition((Console.WindowWidth - 1) / 2, i);
                    Console.Write("|");
                }
                #endregion
                #region Display Player Stats Frame
                Console.SetCursorPosition(1, 0);
                for (int i = 0; i < Console.WindowWidth - 2; i++)
                {
                    Console.Write("_");
                }
                Console.SetCursorPosition(0, 6);
                for (int i = 0; i < Console.WindowWidth - 1; i++)
                {
                    Console.Write("_");
                }
                for (int i = 1; i <= 6; i++)
                {
                    Console.SetCursorPosition(59, i);
                    Console.Write("|");
                }
                for (int i = 1; i <= 6; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write("|");
                }
                for (int i = 1; i <= 6; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth - 1, i);
                    Console.Write("|");
                }
                #endregion
                Console.ForegroundColor = ConsoleColor.Yellow;
                #region Display Players
                if (turn == 1)
                {
                    Console.SetCursorPosition(2, 2);
                    Console.Write($"Stats of {Player1.Name}");
                    Console.SetCursorPosition(2, 3);
                    Console.Write($"Health:\t\t{Player1.Health,2}\tAgility:\t{Player1.Agility,2}");
                    Console.SetCursorPosition(2, 4);
                    Console.Write($"Stamina:\t\t{Player1.Stamina,2}\tStrength:\t{Player1.Strength,2}");
                    Console.SetCursorPosition(2, 5);
                    Console.Write($"(Educability:\t\t{Player1.Educability,2}");
                    if (Player1.Element != null)
                        Console.Write($"\tElement: {Player1.Element})");
                    //-------------------------------------------------------------------------------------------------
                    Console.SetCursorPosition(63, 2);
                    Console.Write($"Stats of {Player2.Name}");
                    Console.SetCursorPosition(63, 3);
                    Console.Write($"Health:\t\t\t{Player2.Health,2}\tAgility:\t{Player2.Agility,2}");
                    Console.SetCursorPosition(63, 4);
                    Console.Write($"Stamina:\t\t\t{Player2.Stamina,2}\tStrength:\t{Player2.Strength,2}");
                    Console.SetCursorPosition(63, 5);
                    Console.Write($"(Educability:\t\t{Player2.Educability,2}");
                    if (Player2.Element != null)
                        Console.Write($"\tElement: {Player2.Element})");
                }
                else
                {
                    Console.SetCursorPosition(63, 2);
                    Console.Write($"Stats of {Player1.Name}");
                    Console.SetCursorPosition(63, 3);
                    Console.Write($"Health:\t\t\t{Player1.Health,2}\tAgility:\t{Player1.Agility,2}");
                    Console.SetCursorPosition(63, 4);
                    Console.Write($"Stamina:\t\t\t{Player1.Stamina,2}\tStrength:\t{Player1.Strength,2}");
                    Console.SetCursorPosition(63, 5);
                    Console.Write($"(Educability:\t {Player1.Educability,2}");
                    if (Player1.Element != null)
                        Console.Write($"\tElement:\t{Player1.Element})");
                    //-------------------------------------------------------------------------------------------------
                    Console.SetCursorPosition(2, 2);
                    Console.Write($"Stats of {Player2.Name}");
                    Console.SetCursorPosition(2, 3);
                    Console.Write($"Health:\t\t\t{Player2.Health,2}\tAgility:\t{Player2.Agility,2}");
                    Console.SetCursorPosition(2, 4);
                    Console.Write($"Stamina:\t\t\t{Player2.Stamina,2}\tStrength:\t{Player2.Strength,2}");
                    Console.SetCursorPosition(2, 5);
                    Console.Write($"(Educability:\t {Player2.Educability,2}");
                    if (Player2.Element != null)
                        Console.Write($"\tElement:\t{Player2.Element})");
                }
                #endregion
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, Console.WindowHeight - 9);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($" It's your turn @{players2[turn - 1].Name} - Push the spacebar to skip your turn");
                Console.ForegroundColor = ConsoleColor.White;

                if (turn <= 1)
                {
                    PlayersTurn(ref Player1, ref Player2, ref turn, 0);
                }
                else if (turn >= 2)
                {
                    PlayersTurn(ref Player2, ref Player1, ref turn, 1);
                }

                if (Player1.Health <= 0.0)
                {
                    if (Player2.Health <= 0.0)
                    {
                        Winner = null;
                    }
                    else
                    {
                        Winner = Player2;
                    }
                }
                else if (Player2.Health <= 0.0)
                {
                    if (Player1.Health <= 0.0)
                    {
                        Winner = null;
                    }
                    else
                    {
                        Winner = Player1;
                    }
                }

            } while (Winner == null);
        }

        public static void PlayersTurn(ref Player.IPlayerStats player, ref Player.IPlayerStats player2, ref int turn, int pIndex)
        {
            if (player.Stunned > 0)
            {
                player.Stunned -= 1;
                turn += 1;
                return;
            }

            bool now = true;
            bool wdh;

            #region Display
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(1, Console.WindowHeight - 6);
            Console.Write($"   [1] {player.Abilities[0]} ");
            #region Check for Ability and needed Stamina
            if (player.Abilities[0] == "Smash" && player.Stamina >= 5)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(05 Stamina)");
            }
            else if (player.Abilities[0] == "Coin Toss" && player.Stamina >= 15)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(15 Stamina)");
            }
            else if (player.Abilities[0] == "Stunning Blow" && player.Stamina >= 15)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(15 Stamina)");
            }
            else if (player.Abilities[0] == "Adrenaline Rush" && player.Stamina >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(20 Stamina)");
            }
            else if (player.Abilities[0] == "Kick" && player.Stamina >= 10)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(10 Stamina)");
            }
            else if (player.Abilities[0] == "Soapbubble" && player.Stamina >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(20 Stamina)");
            }
            else if (player.Abilities[0] == "Potion Brewer" && player.Stamina >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(20 Stamina)");
            }
            else if (player.Abilities[0] == "Tornado" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else if (player.Abilities[0] == "Mossy Mountains" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else if (player.Abilities[0] == "Flamethrower" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else if (player.Abilities[0] == "Change Aggregate State" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(Not Enough Stamina)");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            #endregion
            Console.SetCursorPosition(((Console.WindowWidth - 1) / 2) + 1, Console.WindowHeight - 6);
            Console.Write($"   [2] {player.Abilities[1]} ");
            #region Check for Ability and needed Stamina
            if (player.Abilities[1] == "Smash" && player.Stamina >= 5)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(05 Stamina)");
            }
            else if (player.Abilities[1] == "Coin Toss" && player.Stamina >= 15)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(15 Stamina)");
            }
            else if (player.Abilities[1] == "Stunning Blow" && player.Stamina >= 15)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(15 Stamina)");
            }
            else if (player.Abilities[1] == "Adrenaline Rush" && player.Stamina >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(20 Stamina)");
            }
            else if (player.Abilities[1] == "Kick" && player.Stamina >= 10)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(10 Stamina)");
            }
            else if (player.Abilities[1] == "Soapbubble" && player.Stamina >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(20 Stamina)");
            }
            else if (player.Abilities[1] == "Potion Brewer" && player.Stamina >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(20 Stamina)");
            }
            else if (player.Abilities[1] == "Tornado" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else if (player.Abilities[1] == "Mossy Mountains" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else if (player.Abilities[1] == "Flamethrower" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else if (player.Abilities[1] == "Change Aggregate State" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(Not Enough Stamina)");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            #endregion
            Console.SetCursorPosition(1, Console.WindowHeight - 3);
            Console.Write($"   [3] {player.Abilities[2]} ");
            #region Check for Ability and needed Stamina
            if (player.Abilities[2] == "Smash" && player.Stamina >= 5)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(05 Stamina)");
            }
            else if (player.Abilities[2] == "Coin Toss" && player.Stamina >= 15)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(15 Stamina)");
            }
            else if (player.Abilities[2] == "Stunning Blow" && player.Stamina >= 15)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(15 Stamina)");
            }
            else if (player.Abilities[2] == "Adrenaline Rush" && player.Stamina >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(20 Stamina)");
            }
            else if (player.Abilities[2] == "Kick" && player.Stamina >= 10)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(10 Stamina)");
            }
            else if (player.Abilities[2] == "Soapbubble" && player.Stamina >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(20 Stamina)");
            }
            else if (player.Abilities[2] == "Potion Brewer" && player.Stamina >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(20 Stamina)");
            }
            else if (player.Abilities[2] == "Tornado" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else if (player.Abilities[2] == "Mossy Mountains" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else if (player.Abilities[2] == "Flamethrower" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else if (player.Abilities[2] == "Change Aggregate State" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(Not Enough Stamina)");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            #endregion
            Console.SetCursorPosition(((Console.WindowWidth - 1) / 2) + 1, Console.WindowHeight - 3);
            Console.Write($"   [4] {player.Abilities[3]} ");
            #region Check for Ability and needed Stamina
            if (player.Abilities[3] == "Smash" && player.Stamina >= 5)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(05 Stamina)");
            }
            else if (player.Abilities[3] == "Coin Toss" && player.Stamina >= 15)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(15 Stamina)");
            }
            else if (player.Abilities[3] == "Stunning Blow" && player.Stamina >= 15)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(15 Stamina)");
            }
            else if (player.Abilities[3] == "Adrenaline Rush" && player.Stamina >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(20 Stamina)");
            }
            else if (player.Abilities[3] == "Kick" && player.Stamina >= 10)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(10 Stamina)");
            }
            else if (player.Abilities[3] == "Soapbubble" && player.Stamina >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(20 Stamina)");
            }
            else if (player.Abilities[3] == "Potion Brewer" && player.Stamina >= 20)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(20 Stamina)");
            }
            else if (player.Abilities[3] == "Tornado" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else if (player.Abilities[3] == "Mossy Mountains" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else if (player.Abilities[3] == "Flamethrower" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else if (player.Abilities[3] == "Change Aggregate State" && player.Stamina >= 25)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(25 Stamina)");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("(Not Enough Stamina)");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            #endregion
            Console.ForegroundColor = ConsoleColor.White;
            #endregion

            do
            {
                wdh = false;
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        AbilityNStaminaCheck(0, ref now, ref player, ref player2, ref turn, pIndex, out wdh);
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        AbilityNStaminaCheck(1, ref now, ref player, ref player2, ref turn, pIndex, out wdh);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        AbilityNStaminaCheck(2, ref now, ref player, ref player2, ref turn, pIndex, out wdh);
                        break;
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        AbilityNStaminaCheck(3, ref now, ref player, ref player2, ref turn, pIndex, out wdh);
                        break;
                    case ConsoleKey.Spacebar:
                        Console.SetCursorPosition(0, 8);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Skipped your turn!");
                        Console.ForegroundColor = ConsoleColor.White;
                        turn += 1;
                        break;
                    default:
                        Console.SetCursorPosition(0, 8);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("Invalid Input!");
                        Console.ForegroundColor = ConsoleColor.White;
                        wdh = true;
                        break;
                }
            } while (wdh);
            if (PlayerAR[pIndex] > 0 && now)
            {
                PlayerAR[pIndex] -= 2;
                turn = pIndex + 1;
            }

        }

        public static void AbilityNStaminaCheck(int AbilityIndex, ref bool now, ref Player.IPlayerStats player, ref Player.IPlayerStats player2, ref int turn, int pIndex, out bool wdh)
        {
            wdh = false;
            if (player.Abilities[AbilityIndex] == "Smash" && player.Stamina >= 5)
            {
                player.Stamina -= 5;
                Random random = new Random();

                int GetCASAbility()
                {
                    double d = random.NextDouble();
                    if (d <= 0.95)
                        return 1;
                    else if (d > 0.95)
                        return 2;
                    return 0;
                }
                int CASAbility = GetCASAbility();
                if (CASAbility == 1)
                    player2.Health -= 3.0 * (1.0 + (player.Strength / 100));
                if (CASAbility == 2)
                    player.Health -= 1.5 * (1.0 + (player.Strength / 100));
                Console.SetCursorPosition(63, 8);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{player2.Name} was smashed by {player.Name}!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                turn += 1;
            }
            else if (player.Abilities[AbilityIndex] == "Coin Toss" && player.Stamina >= 15)
            {
                player.Stamina -= 15;
                Random random = new Random();

                int GetCASAbility()
                {
                    double d = random.NextDouble();
                    if (d < 0.20)
                        return 1;
                    else if (d >= 0.20 && d < 0.50)
                        return 2;
                    else if (d >= 0.50 && d < 0.75)
                        return 3;
                    else if (d >= 0.75 && d < 0.9375)
                        return 4;
                    else if (d > 0.9375)
                        return 5;
                    else
                        return 0;
                }
                int CASAbility = GetCASAbility();
                switch (CASAbility)
                {
                    case 2:
                        player2.Health -= 2.5 * (1.0 + (player.Strength / 100));
                        Console.SetCursorPosition(63, 8);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{player2.Name} was tossed off with a coin by {player.Name}!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 3:
                        player2.Health -= 5.0 * (1.0 + (player.Strength / 100));
                        Console.SetCursorPosition(63, 8);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{player2.Name} was tossed off with a coin by {player.Name}!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 4:
                        player2.Health -= 7.5 * (1.0 + (player.Strength / 100));
                        Console.SetCursorPosition(63, 8);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{player2.Name} was tossed off with a coin by {player.Name}!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    case 5:
                        player2.Health -= 10.0 * (1.0 + (player.Strength / 100));
                        Console.SetCursorPosition(63, 8);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{player2.Name} was tossed off with a coin by {player.Name}!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.SetCursorPosition(63, 8);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{player.Name} tossed a coin away!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Thread.Sleep(1000);
                turn += 1;
            }
            else if (player.Abilities[AbilityIndex] == "Stunning Blow" && player.Stamina >= 15)
            {
                player.Stamina -= 15;
                Random random = new Random();

                int GetCASAbility()
                {
                    double d = random.NextDouble();
                    if (d <= 0.66)
                        return 1;
                    else if (d > 0.66)
                        return 2;
                    return 0;
                }
                int CASAbility = GetCASAbility();

                if (CASAbility == 1)
                {
                    player2.Stunned += 1;
                    Console.SetCursorPosition(63, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player2.Name} was stunned by {player.Name}!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Thread.Sleep(1000);
                turn += 1;
            }
            else if (player.Abilities[AbilityIndex] == "Adrenaline Rush" && player.Stamina >= 20)
            {
                player.Stamina -= 20;
                PlayerAR[pIndex] += 2;
                now = false;
                Console.SetCursorPosition(0, 8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{player.Name} got an adrenaline rush!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                turn += 1;
            }
            else if (player.Abilities[AbilityIndex] == "Kick" && player.Stamina >= 10)
            {
                player.Stamina -= 10;
                Random random = new Random();

                int GetCASAbility()
                {
                    double d = random.NextDouble();
                    if (d <= 0.95)
                        return 1;
                    else if (d > 0.95)
                        return 2;
                    return 0;
                }
                int CASAbility = GetCASAbility();
                if (CASAbility == 1)
                    player2.Health -= 4.0 * (1.0 + (player.Strength / 100));
                if (CASAbility == 2)
                    player2.Health -= 2.5 * (1.0 + (player.Strength / 100));
                Console.SetCursorPosition(63, 8);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{player2.Name} was kicked by {player.Name}!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                turn += 1;
            }
            else if (player.Abilities[AbilityIndex] == "Soapbubble" && player.Stamina >= 20)
            {
                player.Stamina -= 20;
                Random rnd = new Random();
                int rndSoapE = rnd.Next(1, 3);
                if (rndSoapE == 2)
                {
                    player2.Stunned += 1;
                    Console.SetCursorPosition(63, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player2.Name} was catched in a soapbubble by {player.Name}!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (rndSoapE == 1)
                {
                    player2.Health -= 5.0 * (1.0 + (player.Strength / 100));
                    Console.SetCursorPosition(63, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player2.Name} is now leaching out caused by {player.Name}'s soapbubble!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Thread.Sleep(1000);
                turn += 1;
            }
            else if (player.Abilities[AbilityIndex] == "Potion Brewer" && player.Stamina >= 20)
            {
                player.Stamina -= 20;
                Random rnd = new Random();
                int rndPotion = rnd.Next(1, 5);
                if (rndPotion == 1)
                {
                    player.Health += 5.0 * (1.0 + (player.Educability / 100));
                    Console.SetCursorPosition(0, 8);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{player.Name} gained some health points by {player.Name}'s potion!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (rndPotion == 2)
                {
                    player.Agility = Program.Players[0].Agility;
                    Console.SetCursorPosition(0, 8);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{player.Name} refreshed and has now all agility points back!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (rndPotion == 3)
                {
                    Console.SetCursorPosition(63, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player2.Name} was popped into the sky by {player.Name}'s potion!");
                    Console.ForegroundColor = ConsoleColor.White;
                    player2.Health -= 2.5 * (1.0 + (player.Strength / 100));
                }
                if (rndPotion == 4)
                {
                    if (player.Abilities.Contains("Adrenaline Rush"))
                    {
                        PlayerAR[pIndex] += 2;
                        now = false;
                        Console.SetCursorPosition(0, 8);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{player.Name} got an andrenaline rush by the brewed potion!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 8);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{player.Name} isn't able to get an adrenaline rush by the brewed potion!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                Thread.Sleep(1000);
                turn += 1;
            }
            else if (player.Abilities[AbilityIndex] == "Tornado" && player.Stamina >= 25)
            {
                player.Stamina -= 25;
                bool Stun;
                Random random = new Random();

                int GetCASAbility()
                {
                    double d = random.NextDouble();
                    if (d < 0.33)
                        return 1;
                    else if (d > 0.33 && d < 0.66)
                        return 2;
                    else if (d > 0.66)
                        return 3;
                    return 0;
                }
                int CASAbility = GetCASAbility();
                if (CASAbility == 1)
                {
                    Console.SetCursorPosition(63, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player2.Name} was sucked in by {player.Name}'s tornado!");
                    Console.ForegroundColor = ConsoleColor.White;

                    if (player2.Element == "Water")
                        player2.Health -= 10.0 * (1.0 + (player.Strength / 100));
                    player2.Health -= 2.0 * (1.0 + (player.Strength / 100));
                    int ranStun = random.Next(1, 3);
                    if (ranStun == 1)
                    {
                        Console.SetCursorPosition(63, 9);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{player2.Name} got stunned by {player.Name}'s tornado too!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Stun = true;
                        if (Stun)
                            player2.Stunned += 1;
                    }
                }
                else if (CASAbility == 2)
                {
                    if (player2.Element == "Water")
                        player2.Health -= 10.0 * (1.0 + (player.Strength / 100));
                    Console.SetCursorPosition(63, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player2.Name} has been stunned by {player.Name}!");
                    Console.ForegroundColor = ConsoleColor.White;
                    player2.Stunned += 2;
                }
                else if (CASAbility == 3)
                {
                    Console.SetCursorPosition(0, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player.Name} made a tornado and was sucked in by it!");
                    Console.ForegroundColor = ConsoleColor.White;
                    player.Health -= 5 * (1.0 + (player.Strength / 100));
                }

                Thread.Sleep(5000);
                turn += 1;
            }
            else if (player.Abilities[AbilityIndex] == "Mossy Mountains" && player.Stamina >= 25)
            {
                player.Stamina -= 25;
                bool Stun;
                Random random = new Random();

                int GetCASAbility()
                {
                    double d = random.NextDouble();
                    if (d < 0.33)
                        return 1;
                    else if (d > 0.33 && d < 0.66)
                        return 2;
                    else if (d > 0.66)
                        return 3;
                    return 0;
                }
                int CASAbility = GetCASAbility();
                if (CASAbility == 1)
                {
                    Console.SetCursorPosition(63, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player2.Name} was thrown off with {player.Name}'s stone!");
                    Console.ForegroundColor = ConsoleColor.White;

                    if (player2.Element == "Air")
                        player2.Health -= 10.0 * (1.0 + (player.Strength / 100));
                    player2.Health -= 2.0 * (1.0 + (player.Strength / 100));
                    int ranStun = random.Next(1, 3);
                    if (ranStun == 1)
                    {
                        Console.SetCursorPosition(63, 9);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{player2.Name} got stunned by {player.Name}'s stone too!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Stun = true;
                        if (Stun)
                            player2.Stunned += 1;
                    }
                }
                else if (CASAbility == 2)
                {
                    if (player2.Element == "Air")
                        player2.Health -= 10.0 * (1.0 + (player.Strength / 100));
                    Console.SetCursorPosition(63, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player2.Name} has been stunned by {player.Name}!");
                    Console.ForegroundColor = ConsoleColor.White;
                    player2.Stunned += 2;
                }
                else if (CASAbility == 3)
                {
                    Console.SetCursorPosition(0, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player.Name} was run over by a rock!");
                    Console.ForegroundColor = ConsoleColor.White;
                    player.Health -= 5 * (1.0 + (player.Strength / 100));
                }

                Thread.Sleep(5000);
                turn += 1;
            }
            else if (player.Abilities[AbilityIndex] == "Flamethrower" && player.Stamina >= 25)
            {
                player.Stamina -= 25;
                bool Stun;
                Random random = new Random();

                int GetCASAbility()
                {
                    double d = random.NextDouble();
                    if (d < 0.33)
                        return 1;
                    else if (d > 0.33 && d < 0.66)
                        return 2;
                    else if (d > 0.66)
                        return 3;
                    return 0;
                }
                int CASAbility = GetCASAbility();
                if (CASAbility == 1)
                {
                    Console.SetCursorPosition(63, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player2.Name} was lit up by {player.Name}!");
                    Console.ForegroundColor = ConsoleColor.White;

                    if (player2.Element == "Earth")
                        player2.Health -= 10.0 * (1.0 + (player.Strength / 100));
                    player2.Health -= 2.0 * (1.0 + (player.Strength / 100));
                    int ranStun = random.Next(1, 3);
                    if (ranStun == 1)
                    {
                        Console.SetCursorPosition(63, 9);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{player2.Name} got stunned by {player.Name}'s throwed flames too!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Stun = true;
                        if (Stun)
                            player2.Stunned += 1;
                    }
                }
                else if (CASAbility == 2)
                {
                    if (player2.Element == "Earth")
                        player2.Health -= 10.0 * (1.0 + (player.Strength / 100));
                    Console.SetCursorPosition(63, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player2.Name} has been set in stunning flames by {player.Name}!");
                    Console.ForegroundColor = ConsoleColor.White;
                    player2.Stunned += 2;
                }
                else if (CASAbility == 3)
                {
                    Console.SetCursorPosition(0, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player.Name} set him-/her-/itself in flames!");
                    Console.ForegroundColor = ConsoleColor.White;
                    player.Health -= 5.0 * (1.0 + (player.Strength / 100));
                }

                Thread.Sleep(5000);
                turn += 1;
            }
            else if (player.Abilities[AbilityIndex] == "Change Aggregate State" && player.Stamina >= 25)
            {
                player.Stamina -= 25;
                bool Stun;
                Random random = new Random();

                int GetCASAbility()
                {
                    double d = random.NextDouble();
                    if (d < 0.33)
                        return 1;
                    else if (d > 0.33 && d < 0.66)
                        return 2;
                    else if (d > 0.66)
                        return 3;
                    return 0;
                }
                int CASAbility = GetCASAbility();
                if (CASAbility == 1)
                {
                    Console.SetCursorPosition(63, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player2.Name} got a water jet by {player.Name} in his face!");
                    Console.ForegroundColor = ConsoleColor.White;

                    if (player2.Element == "Fire")
                        player2.Health -= 10.0 * (1.0 + (player.Strength / 100));
                    player2.Health -= 2.0 * (1.0 + (player.Strength / 100));
                    int ranStun = random.Next(1, 3);
                    if (ranStun == 1)
                    {
                        Console.SetCursorPosition(63, 9);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"{player2.Name} got stunned by {player.Name}'s water jet too!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Stun = true;
                        if (Stun)
                            player2.Stunned += 1;
                    }
                }
                else if (CASAbility == 2)
                {
                    if (player2.Element == "Fire")
                        player2.Health -= 10.0 * (1.0 + (player.Strength / 100));
                    Console.SetCursorPosition(63, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player2.Name} has been freezed by {player.Name}!");
                    Console.ForegroundColor = ConsoleColor.White;
                    player2.Stunned += 2;
                }
                else if (CASAbility == 3)
                {
                    Console.SetCursorPosition(0, 8);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{player.Name} gassed him-/her-/itself!");
                    Console.ForegroundColor = ConsoleColor.White;
                    player.Health -= 5.0 * (1.0 + (player.Strength / 100));
                }

                Thread.Sleep(5000);
                turn += 1;
            }
            else
            {
                Console.SetCursorPosition(0, 8);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{player.Name}'s Ability Broke By An Error Or Not Enough Stamina!");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(5000);
                if (player.Abilities.Contains("Smash") && player.Stamina < 5)
                    turn += 1;
                else if (!player.Abilities.Contains("Smash") && player.Abilities.Contains("Kick") && player.Stamina < 10)
                    turn += 1;
                else
                    wdh = true;
            }
            for (int i = 0; i < Console.WindowWidth - 1; i++)
            {
                Console.SetCursorPosition(i, 8);
                Console.Write(" ");
            }
            for (int i = 0; i < Console.WindowWidth - 1; i++)
            {
                Console.SetCursorPosition(i, 9);
                Console.Write(" ");
            }
            for (int i = 0; i < Console.WindowWidth - 1; i++)
            {
                Console.SetCursorPosition(i, 10);
                Console.Write(" ");
            }
        }
    }
}
