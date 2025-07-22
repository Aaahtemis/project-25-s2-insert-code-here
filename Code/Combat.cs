using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamCSFile;

namespace CombatSystem
{
    internal class Combat
    {

        static ConsoleColor[] introAnim =
        {
            ConsoleColor.Blue,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Blue,
            ConsoleColor.Magenta,
            ConsoleColor.Cyan,
            ConsoleColor.Black,
            ConsoleColor.Red,
            ConsoleColor.Yellow,
            ConsoleColor.Green,
            ConsoleColor.Blue,
            ConsoleColor.Magenta,
            ConsoleColor.Cyan,
            ConsoleColor.Black
        };

        static string[] Room1Enemies = { "Clothesliner", "Fashion Police", "Velcrofiend", "Zipperfang", "Sweater? I Hardly Know Her!" };
        static string[] Room2Enemies = { "Cordspawn", "Dataleech", "Cable Golem", "Ampster", "Charger? I Hardly Know Her!" };
        static string[] Room3Enemies = { "Toy Shelf", "Spring-Snake", "Jack-In-The-Box", "Spooky Chest", "Quiggle" };
        static string[] Room4Enemies = { "Tent-Acles", "Leon Trotsky Memorial Iceaxe", "Carabiner? I Hardly Know Her!", "Freedom Camper", "Boots Made For Walkin'" };

        static int Light = 20, Strong = 35; // < values are how much damage each attack does (and stamina drained?)


        //"1  Clothing\n" +
        //"2  Electronics\n" +
        //"3  Toys\n" +
        //"4  Camping\n" +


        static int health = 100;
        static int stamina = 100;


        //This one is for combat
        public static (int amount, string name)[] inventory = { (1, "Small Health potion"), (1, "Medium Health potion"), (1, "Large Health potion"), (1, "Small Stamina potion"), (1, "Medium Stamina potion"), (1, "Large Stamina potion") };




        



        public static void Start(int roomNum)
        {
            
            // flashing lights
            for (int i = 0; i < introAnim.Length; i++)
            {
                Console.Clear();
                Console.BackgroundColor = introAnim[i];
                Thread.Sleep(200);
            }



            // v Amount of enemies, random number per battle

            int enemies = 0;        // < number of enemies in battle

            string[] onfield = { "null", "null", "null" };    // < array of the enemies that are on the field, will be populated by pulling from room's array of possible enemies

            int PullEnemy = 0;

            Random rand = new Random();

            enemies = rand.Next(1, 4);  // < generates number of enemies that will appear in the battle, from 1 - 3 (4 exclusive)

            int enem1Health = 0, enem2Health = 0, enem3Health = 0, bossHealth = 0, target = 0, option = 0, reel1 = 0, reel2 = 0, reel3 = 0, enemattack = 0, enemmove = 0;             //< initialize variables

            bool fightend = false, guard = false;

            for (int i = 0; i < enemies; i++)     // will loop as many times as there are enemies in the battle as decided by rng earlier (1-3 ^)
            {
                switch (roomNum)   // < depending on current room
                {
                    case 1:             // < if player is in Room 1 (Clothing Section)

                        PullEnemy = rand.Next(Room1Enemies.Length);     // < generates random number to pick random enemy from available

                        onfield[i] = Room1Enemies[PullEnemy];               // < assigns a random enemy as decided from the previous line to the current field slot

                        break;

                    case 2:

                        PullEnemy = rand.Next(Room2Enemies.Length);

                        onfield[i] = Room2Enemies[PullEnemy];

                        break;

                    case 3:

                        PullEnemy = rand.Next(Room3Enemies.Length);

                        onfield[i] = Room3Enemies[PullEnemy];

                        break;

                    case 4:

                        PullEnemy = rand.Next(Room4Enemies.Length);

                        onfield[i] = Room4Enemies[PullEnemy];

                        break;

                    default:
                        break;

                }





            }

            // v Enemy Names and amount
            string introText = "";

            switch (enemies)                        // < changes starting text depending on number of enemies
            {

                case 1:                            // < if there is only one enemy
                    introText = $"A wild {onfield[0]} approaches!";

                    enem1Health = 100;

                    break;

                case 2:

                    introText = $"You are stopped by {onfield[0]} and {onfield[1]}.";

                    enem1Health = 100;

                    enem2Health = 100;

                    break;

                case 3:
                    introText = $"You run into {onfield[0]}, {onfield[1]} and {onfield[2]}";

                    enem1Health = 100;

                    enem2Health = 100;

                    enem3Health = 100;

                    break;


                default:
                    // < for boss battles?
                    break;
            }





            Global.DisplayTextCentre(new string[] { introText });  // < tells user what enemy they are facing

            Thread.Sleep(2500);

            Console.Clear();



            // Combat UI v

            string border = new string('-', 209);

            do
            {

                Console.Write(border);

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tENEMIES");

                Console.ForegroundColor = ConsoleColor.White;

                if (enem1Health > 0) //if enemy 1 is alive
                {
                    Console.Write($"\n\n\t\t\t\t\t\t\t\t\t1. {onfield[0]}: ");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"{enem1Health}HP ");

                    Console.ForegroundColor = ConsoleColor.White;

                }

                if (enem2Health > 0) //if enemy 2 is alive
                {
                    Console.Write($"\t2. {onfield[1]}: ");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"{enem2Health}HP ");

                    Console.ForegroundColor = ConsoleColor.White;

                }

                if (enem3Health > 0) //if enemy 3 is alive
                {
                    Console.Write($"\t3. {onfield[2]}: ");

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write($"{enem3Health}HP ");

                    Console.ForegroundColor = ConsoleColor.White;

                }


                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"\n\n\n\n\n\n\n\n\n\n  YOU");

                Console.ForegroundColor = ConsoleColor.White;

                Console.Write($"\n\nHP: {health}\t\tSTM: {stamina}\n\n\n1. Attack\t\t2. Items\t\t3. Guard (Take no damage for 1 turn, req. 20 STM)");

                Console.WriteLine("\n\n");

                Console.Write(border);

                Console.WriteLine("\n\n");

                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }

                catch
                {
                    Console.Clear();

                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tInvalid input");

                    Thread.Sleep(2000);

                    Console.Clear();
                }

                if (option == 1)    // if Attack chosen
                {
                    Console.WriteLine("\n\nSelect an attack\n\n");

                    Console.WriteLine("\n\n1. Light Attack (20 DMG, req. 10 STM)\t\t2. Heavy Attack (40 DMG, req 20 STM)\t\t3. Hail Mary (Do I feel lucky?)\n\n");

                    while (!Int32.TryParse(Console.ReadLine(), out option) && option < 4 || option > 0) // input check
                    {
                        Global.DisplayTextCentre(new string[] { "Invalid input" });
                        Thread.Sleep(2000);
                        Console.Clear();
                    }


                    Console.WriteLine("\n\nSelect a target:\n\n");

                    while (!Int32.TryParse(Console.ReadLine(), out target) && option < 4 || option > 0) // input check
                    {
                        Global.DisplayTextCentre(new string[] { "Invalid input" });
                        Thread.Sleep(2000);
                        Console.Clear();
                    }



                    if (option == 1)    // if Light Attack chosen
                    {
                        if (stamina >= 10)
                        {
                            stamina = stamina - 10;

                            Console.Clear();

                            Console.BackgroundColor = ConsoleColor.White;

                            Console.Clear();

                            Thread.Sleep(100);

                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.Clear();

                            switch (target) //enemy chosen
                            {

                                case 1:
                                    enem1Health = enem1Health - 20;
                                    Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t\tYou attack {onfield[0]} for 20 damage!");
                                    Thread.Sleep(2000);
                                    break;

                                case 2:
                                    enem2Health = enem2Health - 20;
                                    Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t\tYou attack {onfield[1]} for 20 damage!");
                                    Thread.Sleep(2000);
                                    break;

                                default:
                                    enem3Health = enem3Health - 20;
                                    Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t\tYou attack {onfield[2]} for 20 damage!");
                                    Thread.Sleep(2000);
                                    break;
                            }


                        }

                        else
                        {
                            Console.WriteLine("\n\nNot enough Stamina");

                            Thread.Sleep(1500);

                            Console.Clear();

                        }


                    }

                    else if (option == 2)    // if Heavy Attack chosen
                    {
                        if (stamina >= 20)
                        {
                            stamina = stamina - 20;

                            Console.Clear();

                            Console.BackgroundColor = ConsoleColor.White;

                            Console.Clear();

                            Thread.Sleep(100);

                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.Clear();

                            switch (target) //enemy chosen
                            {

                                case 1:
                                    enem1Health = enem1Health - 40;
                                    Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t\tYou attack {onfield[0]} for 40 damage!");
                                    Thread.Sleep(2000);
                                    break;

                                case 2:
                                    enem2Health = enem2Health - 40;
                                    Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t\tYou attack {onfield[1]} for 40 damage!");
                                    Thread.Sleep(2000);
                                    break;

                                default:
                                    enem3Health = enem3Health - 40;
                                    Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t\tYou attack {onfield[2]} for 40 damage!");
                                    Thread.Sleep(2000);
                                    break;
                            }

                        }

                        else
                        {
                            Console.WriteLine("\n\nNot enough Stamina");

                            Thread.Sleep(1500);

                            Console.Clear();

                        }


                    }

                    else if (option == 3)   // if Hail Mary chosen
                    {
                        Console.Clear();

                        reel1 = rand.Next(1, 8);

                        reel2 = rand.Next(1, 8);

                        reel3 = rand.Next(1, 8);

                        Console.Write($"\n\n\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t{reel1}");

                        Thread.Sleep(500);

                        Console.Write($" {reel2}");

                        Thread.Sleep(500);

                        Console.Write($" {reel3}");

                        Thread.Sleep(500);

                        if (reel1 == 7 && reel2 == 7 && reel3 == 7)
                        {
                            enem1Health = 0;

                            enem2Health = 0;

                            enem3Health = 0;

                            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\tToday is your lucky day");



                        }

                        else
                        {
                            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\tAlas, nothing happened");
                        }

                        Thread.Sleep(2000);

                        Console.Clear();

                    }


                }

                else if (option == 2)  // if Items chosen
                {
                    showInventory();
                }

                else if (option == 3)  // if Guard chosen
                {

                    if (stamina >= 20)
                    {
                        stamina = stamina - 20;

                        Console.Clear();

                        Console.BackgroundColor = ConsoleColor.DarkGreen;

                        Console.Clear();

                        Thread.Sleep(100);

                        Console.BackgroundColor = ConsoleColor.Black;

                        Console.Clear();

                        guard = true;

                    }

                    else
                    {
                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\tNot enough Stamina");

                        Thread.Sleep(1500);

                        Console.Clear();

                    }


                }


                // v Enemy Turn

                for (int i = 0; i < enemies; i++)
                {
                    if ((i == 0 && enem1Health > 0) || (i == 1 && enem2Health > 0) || (i == 2 && enem3Health > 0))
                    {



                        enemmove = rand.Next(1, 31);

                        switch (enemmove)
                        {

                            case 1:

                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.DarkRed;

                                Console.Clear();

                                Thread.Sleep(100);

                                Console.BackgroundColor = ConsoleColor.Black;

                                Console.Clear();

                                enemattack = rand.Next(5, 21);

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t\t{onfield[i]} attacks for {enemattack} damage!");

                                if (guard != false)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t\t..but you withstood the attack and sustained no damage!");

                                }

                                else
                                {
                                    health = health - enemattack;
                                }

                                Thread.Sleep(2500);

                                Console.Clear();

                                break;

                            case 2:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t\t{onfield[i]} is rethinking its career path.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 3:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t\t{onfield[i]} is thinking about the Roman Empire.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 4:

                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.DarkRed;

                                Console.Clear();

                                Thread.Sleep(100);

                                Console.BackgroundColor = ConsoleColor.Black;

                                Console.Clear();

                                enemattack = rand.Next(5, 21);

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} attacks for {enemattack} damage!");

                                if (guard != false)
                                {
                                    Thread.Sleep(1000);

                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t..But you withstood the attack and sustained no damage!");

                                }

                                else
                                {
                                    health = health - enemattack;
                                }

                                Thread.Sleep(2500);


                                Console.Clear();

                                break;

                            case 5:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} is silently judging you.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 6:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} pulled out its phone and started playing Subway Surfers.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 7:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} asked you if you believe in our lord, who art in Heaven.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 8:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} attempted to explain insider trading to you.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 9:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} asked you if your refrigerator is running.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;


                            case 10:

                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.DarkRed;

                                Console.Clear();

                                Thread.Sleep(100);

                                Console.BackgroundColor = ConsoleColor.Black;

                                Console.Clear();

                                enemattack = rand.Next(5, 21);

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} attacks for {enemattack} damage!");

                                if (guard != false)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t..but you withstood the attack and sustained no damage!");
                                    guard = false;
                                }

                                else
                                {
                                    health = health - enemattack;
                                }

                                Thread.Sleep(2500);

                                Console.Clear();

                                break;

                            case 11:

                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.DarkRed;

                                Console.Clear();

                                Thread.Sleep(100);

                                Console.BackgroundColor = ConsoleColor.Black;

                                Console.Clear();

                                enemattack = rand.Next(5, 21);

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t\t{onfield[i]} attacks for {enemattack} damage!");

                                if (guard != false)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t\t..but you withstood the attack and sustained no damage!");

                                }

                                else
                                {
                                    health = health - enemattack;
                                }

                                Thread.Sleep(2500);

                                Console.Clear();

                                break;

                            case 12:

                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.DarkRed;

                                Console.Clear();

                                Thread.Sleep(100);

                                Console.BackgroundColor = ConsoleColor.Black;

                                Console.Clear();

                                enemattack = rand.Next(5, 21);

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} attacks for {enemattack} damage!");

                                if (guard != false)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t..but you withstood the attack and sustained no damage!");
                                    guard = false;
                                }

                                else
                                {
                                    health = health - enemattack;
                                }

                                Thread.Sleep(2500);

                                Console.Clear();

                                break;

                            case 13:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} is beginning to Morb.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 14:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} wants to get off Mr. Bones' wild ride.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;


                            case 15:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} loves legitimate theatre.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 16:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} asked you to spell ICUP.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 17:

                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.DarkRed;

                                Console.Clear();

                                Thread.Sleep(100);

                                Console.BackgroundColor = ConsoleColor.Black;

                                Console.Clear();

                                enemattack = rand.Next(5, 21);

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} attacks for {enemattack} damage!");

                                if (guard != false)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t..but you withstood the attack and sustained no damage!");
                                    guard = false;
                                }

                                else
                                {
                                    health = health - enemattack;
                                }

                                Thread.Sleep(2500);

                                Console.Clear();

                                break;

                            case 18:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} is suffering from Jaundice.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 19:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} did an impression of construction equipment.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 20:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} says: What's the deal with airline food?");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 21:

                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.DarkRed;

                                Console.Clear();

                                Thread.Sleep(100);

                                Console.BackgroundColor = ConsoleColor.Black;

                                Console.Clear();

                                enemattack = rand.Next(5, 21);

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} attacks for {enemattack} damage!");

                                if (guard != false)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t..but you withstood the attack and sustained no damage!");

                                }

                                else
                                {
                                    health = health - enemattack;
                                }

                                Thread.Sleep(2500);

                                Console.Clear();

                                break;


                            case 22:

                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.DarkRed;

                                Console.Clear();

                                Thread.Sleep(100);

                                Console.BackgroundColor = ConsoleColor.Black;

                                Console.Clear();

                                enemattack = rand.Next(5, 21);

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} attacks for {enemattack} damage!");

                                if (guard != false)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t..but you withstood the attack and sustained no damage!");

                                }

                                else
                                {
                                    health = health - enemattack;
                                }

                                Thread.Sleep(2500);

                                Console.Clear();

                                break;

                            case 23:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} thought we were having Steamed Clams.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;


                            case 24:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} asked you to play Wonderwall.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;


                            case 25:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} took a swig from a brown paper bag.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 26:

                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.DarkRed;

                                Console.Clear();

                                Thread.Sleep(100);

                                Console.BackgroundColor = ConsoleColor.Black;

                                Console.Clear();

                                enemattack = rand.Next(5, 21);

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} attacks for {enemattack} damage!");

                                if (guard != false)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t..but you withstood the attack and sustained no damage!");

                                }

                                else
                                {
                                    health = health - enemattack;
                                }

                                Thread.Sleep(2500);

                                Console.Clear();

                                break;

                            case 27:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t{onfield[i]} knows what you did.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 28:

                                Console.Clear();

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t{onfield[i]} pulled your IP address.");

                                Thread.Sleep(2000);

                                Console.Clear();

                                break;

                            case 29:

                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.DarkRed;

                                Console.Clear();

                                Thread.Sleep(100);

                                Console.BackgroundColor = ConsoleColor.Black;

                                Console.Clear();

                                enemattack = rand.Next(5, 21);

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} attacks for {enemattack} damage!");

                                if (guard != false)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t..but you withstood the attack and sustained no damage!");

                                }

                                else
                                {
                                    health = health - enemattack;
                                }

                                Thread.Sleep(2500);

                                Console.Clear();

                                break;

                            case 30:

                                Console.Clear();

                                Console.BackgroundColor = ConsoleColor.DarkRed;

                                Console.Clear();

                                Thread.Sleep(100);

                                Console.BackgroundColor = ConsoleColor.Black;

                                Console.Clear();

                                enemattack = rand.Next(5, 21);

                                Console.WriteLine($"\n\n\n\n\t\t\t\t\t\t\t\t\t{onfield[i]} attacks for {enemattack} damage!");

                                if (guard != false)
                                {
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"\n\n\t\t\t\t\t\t\t\t\t..but you withstood the attack and sustained no damage!");

                                }

                                else
                                {
                                    health = health - enemattack;
                                }

                                Thread.Sleep(2500);

                                Console.Clear();

                                break;

                        }

                    }
                    guard = false; // resets guard after turn

                }

                if (enem1Health <= 0 && enem2Health <= 0 && enem3Health <= 0 || health <= 0)
                {
                    fightend = true;
                }

            } while (fightend != true);


            Console.Clear();

            if (health <= 0)
            {
                Console.WriteLine("\n\n\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tYOU DIED");
                health = 1; //resets hp

                Thread.Sleep(5000);
            }

            else
            {
                Console.WriteLine("\n\n\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tA WINNER IS YOU");

                Thread.Sleep(5000);
            }

            Console.Clear();

        }


        static void showInventory()
        {
            Console.Clear();
            Console.WriteLine($"Your health is {health}HP.\nYour stamina is {stamina}Stm");
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].amount != 0)
                {
                    Console.WriteLine($"Enter {i + 1} to use one of your {inventory[i].amount} {inventory[i].name}s.\n");
                }

            }
            Console.WriteLine("Enter the item you want to do or 0 if you want to exit.");
            int input = 0;
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Huh");
                Console.ReadLine();
            }
            Console.Clear();

            bool used = false;

            int amountChanged = 0;
            bool healthChanged = false;



            if (input != 0)
            {
                if (inventory[input - 1].amount > 0)
                {
                    used = true;

                    switch (input)
                    {
                        case 1:                     // health potions
                            healthChanged = true;
                            amountChanged += 25;
                            break;
                        case 2:
                            amountChanged += 25;
                            goto case 1;
                        case 3:
                            amountChanged += 50;
                            goto case 2;


                        case 4:                     // stamina potions
                            amountChanged += 25;
                            break;
                        case 5:
                            amountChanged += 25;
                            goto case 4;
                        case 6:
                            amountChanged += 50;
                            goto case 5;

                        default:
                            used = false; break;
                    }


                    
                    inventory[input - 1].amount--;
                    Console.ReadLine();
                }
            }



            if (used)
            {

                if (healthChanged)
                {
                    health += amountChanged;
                    if (health > 100)
                    {
                        health = 100;
                    }
                    Global.DisplayTextCentre(new string[] { $"You use one of your {inventory[input - 1].name}s", $"You gain {amountChanged} Health. You have now have {health}HP.\nEnter to continue" });

                } else
                {
                    stamina += amountChanged;
                    if (stamina > 100)
                    {
                        stamina = 100;
                    }
                    Global.DisplayTextCentre(new string[] { $"You use one of your {inventory[input - 1].name}s", $"You gain {amountChanged} Health. You have now have {stamina}STM.\nEnter to continue" });

                }
            }
            else
            {
                Global.DisplayTextCentre(new string[] { "You don't have enough of that potion" });
            }
            Console.ReadLine();

        }





        

    }
}
