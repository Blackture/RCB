using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCB.Player
{
    public class Stats
    {
        public static void Create(ref int[] RandomPlayer, ref int[] Player1)
        {
            CreateCustomPlayer(ref Player1, out IPlayerStats CustomPlayer);
            Program.Players.Add(CustomPlayer);
            PrintPlayer(Program.Players[0]);
            Console.WriteLine("\nCreating Player 2... Please wait...\n");
            CreateRadnomPlayer(RandomPlayer, out IPlayerStats IRandomPlayer);
            Program.Players.Add(IRandomPlayer);
            PrintPlayer(Program.Players[1]);
            Program.createdCharacters = true;
            Console.Write("\n\n\t\tPush a button to continue..");
        }

        public static void PrintPlayer(IPlayerStats PlayerToPrint)
        {
            Console.WriteLine($"\nStats of {PlayerToPrint.Name}");
            Console.WriteLine($"Health:\t\t{PlayerToPrint.Health, 2}\t\tAgility:\t{PlayerToPrint.Agility, 2}");
            Console.WriteLine($"Stamina:\t{PlayerToPrint.Stamina, 2}\t\tStrength:\t{PlayerToPrint.Strength, 2}");
            Console.Write($"Educability:\t{PlayerToPrint.Educability, 2}");
            if (PlayerToPrint.Element != null)
                Console.Write($"\t\tElement:\t{PlayerToPrint.Element}");
        }

        public static void CreateCustomPlayer(ref int[] Player, out IPlayerStats Player1) 
        {
            Random rnd = new Random();
            bool fu;
            string[] ElChooseList = { "Water", "Fire", "Earth", "Air" };
            int rndEl = rnd.Next(0, 4);
            int[] maxSkillPoints;
            do
            {
                fu = false;
                maxSkillPoints = new int[] { 333, 333, 0 };
                Player[0] = rnd.Next(50, 91);
                maxSkillPoints[1] -= Player[0];
                Player[1] = rnd.Next(10, 81);
                maxSkillPoints[1] -= Player[1];
                Player[2] = rnd.Next(40, 91);
                maxSkillPoints[1] -= Player[2];
                if (maxSkillPoints[1] > 180)
                {
                    fu = true;
                }
                else if (maxSkillPoints[1] <= 180 && maxSkillPoints[1] >= 95 && maxSkillPoints[1] >= 5)
                {
                    do
                    {
                        Player[3] = rnd.Next(40, 91);
                        maxSkillPoints[1] -= Player[3];
                    } while (maxSkillPoints[1] > 90);
                    Player[4] = maxSkillPoints[1];
                }
                else if (maxSkillPoints[1] <= 180 && maxSkillPoints[1] < 95 && maxSkillPoints[1] % 2 == 0 && maxSkillPoints[1] >= 10)
                {
                    Player[3] = rnd.Next(5, maxSkillPoints[1] / 2);
                    Player[4] = rnd.Next(5, maxSkillPoints[1] / 2);
                }
                else if (maxSkillPoints[1] <= 180 && maxSkillPoints[1] < 95 && maxSkillPoints[1] % 2 != 0 && maxSkillPoints[1] >= 5)
                {
                    int ber = (maxSkillPoints[1] - 1) / 2;
                    Player[3] = rnd.Next(5, ber + 1);
                    Player[4] = rnd.Next(5, ber);
                }
                else
                {
                    fu = true;
                }
                maxSkillPoints[2] = Player.Sum();
            } while (maxSkillPoints[2] != maxSkillPoints[0] || fu);
            Console.Write("\nType in your character's name:\t");
            string name = Console.ReadLine();
            Player1 = new PlayerStats(Player, name, PlayersElement: ElChooseList[rndEl]);
        }

        public static void CreateRadnomPlayer(int[] Player, out IPlayerStats Player2)
        {
            Random rnd = new Random();
            bool fu;
            string[] ElChooseList = { "Water", "Fire", "Earth", "Air"};
            int rndEl = rnd.Next(0, 4);
            int[] maxSkillPoints;
            do
            {
                fu = false;
                maxSkillPoints = new int[] { 333, 333, 0 };
                Player[0] = rnd.Next(50, 91);
                maxSkillPoints[1] -= Player[0];
                Player[1] = rnd.Next(10, 81);
                maxSkillPoints[1] -= Player[1];
                Player[2] = rnd.Next(40, 91);
                maxSkillPoints[1] -= Player[2];
                if (maxSkillPoints[1] > 180)
                {
                    fu = true;
                }
                else if (maxSkillPoints[1] <= 180 && maxSkillPoints[1] >= 95 && maxSkillPoints[1] >= 5)
                {
                    do
                    {
                        Player[3] = rnd.Next(40, 91);
                        maxSkillPoints[1] -= Player[3];
                    } while (maxSkillPoints[1] > 90);
                    Player[4] = maxSkillPoints[1];
                }
                else if (maxSkillPoints[1] <= 180 && maxSkillPoints[1] < 95 && maxSkillPoints[1] % 2 == 0 && maxSkillPoints[1] >= 10)
                {
                    Player[3] = rnd.Next(5, maxSkillPoints[1] / 2);
                    Player[4] = rnd.Next(5, maxSkillPoints[1] / 2);
                }
                else if (maxSkillPoints[1] <= 180 && maxSkillPoints[1] < 95 && maxSkillPoints[1] % 2 != 0 && maxSkillPoints[1] >= 5)
                {
                    int ber = (maxSkillPoints[1] - 1) / 2;
                    Player[3] = rnd.Next(5, ber + 1);
                    Player[4] = rnd.Next(5, ber);
                }
                else
                {
                    fu = true;
                }
                maxSkillPoints[2] = Player.Sum();
            } while (maxSkillPoints[2] != maxSkillPoints[0] || fu);
            Console.Write("\nType in your character's name:\t");
            string name2 = Console.ReadLine();
            Player2 = new PlayerStats(Player, name2, PlayersElement: ElChooseList[rndEl]);
        }
    }

    public interface IPlayerStats
    {
        string Name { get; set; }
        double Health { get; set; }
        int Agility { get; set; }
        int Stamina { get; set; }
        int Strength { get; set; }
        int Educability { get; set; }
        string[] Abilities { get; set; }
        string Element { get; set; }
        int Stunned { get; set; }
    }

    public class PlayerStats : IPlayerStats
    {
        public PlayerStats(int[] Stats, string PlayerName = "UnknownPlayer", string AbilitiesAsString = "NONE", string PlayersElement = null)
        {
            if (!(Stats[0] < 5 && Stats[0] > 90))
                Health = Stats[0];
            if (!(Stats[1] < 5 && Stats[1] > 90))
                Agility = Stats[1];
            if (!(Stats[2] < 5 && Stats[2] > 90))
                Stamina = Stats[2];
            if (!(Stats[3] < 5 && Stats[3] > 90))
                Strength = Stats[3];
            if (!(Stats[4] < 5 && Stats[4] > 90))
                Educability = Stats[4];
            if (PlayerName != null && PlayerName != "")
                Name = PlayerName;
            else
                Name = "Unknown";
            if (AbilitiesAsString != "NONE")
                Abilities = AbilitiesAsString.Split(';');
            else
                Abilities = new string[] { "NONE" };
            if (PlayersElement != null)
                Element = PlayersElement;
            Stunned = 0;
        }

        public double Health { get; set; }
        public int Agility { get; set; }
        public int Stamina { get; set; }
        public int Strength { get; set; }
        public int Educability { get; set; }
        public string Name { get; set; }
        public string[] Abilities { get; set; }
        public string Element { get; set; }
        public int Stunned { get; set; }
    }
}
