using System;

using System.Threading;
namespace TeamCSFile
{
    internal class Program
    {

        // The inventory amount holds how much of an item you have, the inventory name holds the name of the item.
        public static int[] InventoryAmount = { 0, 0, 0, 0 };

        public static string[] InventoryName = { "Baseball Cap", "Bluetooth Speaker", "Remote Control Car", "Yard Chair" }; //Maybe put these inside the inventory method

        //This one is for combat
        public static int[] CombatInventoryAmount = { 1, 1, 1, 1, 1, 1 };
        public static string[] CombatInventoryName = { "Small Health potion", "Medium Health potion", "Large Health potion", "Small Stamina potion", "Medium Stamina potion", "Large Stamina potion" };

        //Random added
        public static Random rand = new Random();

        //Global Combat Variables
        public static int Health = 100;

        public static int Stamina = 100;

        public static int Room = 0; // < lets combat method know which room the player is in and thus which set of enemies to pull from
        //------------------------------

        static void Main()
        { // Intro :

            string[] kmart = new string[] {"" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "" +
                "                                                                                                                                                                                 ",    
             "                            .=============================================-                 ..:----------------------------------------------------------------------------=--..                  ",
             "                           .=#*++++++++++++++++++++++++++++++++++++++++*#+.            ..:=+*++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++***###+=:.                     ",
             "                           -####*************************************###=.         .:=+**++++**************************************************************#########*=:.                          ",
             "                          :*###*************************************###=.      .-***+++++**************************************************************#########=.                                ",
             "                         .+###*************************************###=. .:-+#**+++++************************************************************#########*+-.                                    ",
             "                         +###**************************************##+=+****++++************************************************************##########=-:.                                        ",
             "                        =####**************************************##**++++*************************************************************#########*:..                                             ",
             "                      .-####***************************************++++************************************************************#########*=.                                                   ",
             "                      :*###**************************************+************************************************************#########*=:.                                                       ",
             "                     .+###***********************************************************************************************#########*=:.                                                            ",
             "                     =###********************************************************************************************#########+:..                                                                ",
             "                    -####**************************************************************************************##########*-.                                                                      ",
             "                   -####**********************************************************************************##########+=:.                                                                          ",
             "                  :*###*******************************************************************************#########*-:..                                                          ..:===.             ",
             "                 .+###***************************************************************************##########...............    .......     ..............................::.:+******-.....         ",
             "                 =###***********************************************************************#########*+-. .+******==******+--+*******..:=**********+******+.-******+*****+-+***********+:         ",
             "                -####**************************************************************************+++++***+=:=******-..=******:..+******.-******=....=******+.:******+:..  ..+******+.               ",
             "               :####********************************************************************************++=+-=******=. =******-. +******: -*********+=******+::*******:     .:************=.          ",
             "              :*###*************************************************************************************:---::::-+---:::::. .::::::..  ..........:::::::..:::::::..      ..:::::::::::.           ",
             "             .+###*********************************************************************************************+++++***+-:.                                                                       ",
             "            .=####**************************************************************************************************+++++***+=-.                                                                  ",
             "            :####********************************************************************************************************++=++**##*:.                                                             ",
             "           :####**************************************************************************************************************+++++***#+-:..                                                      ",
             "          :####**************************************##########*********************************************************************+++++***+=-.                                                  ",
             "         .+####************************************################**********************************************************************+++++****+=.                                             ",
             "        .=####************************************##%%*+-:..-+##%%#######**********************************************************************++++***#*=:..                                      ",
             "        -####************************************##%%+.         .-+*#%%%#######*********************************************************************+++++**#*=-:.                                 ",
             "       .####************************************##%%#:               .:-+%%%%%######*********************************************************************+++++****+=:.                            ",
             "      .####*************************************#%%%-                    ...-+%%%%%#####***********************************************************************+=++***#*+:.                       ",
             "     .+##########################################%%=                            .-+##%%%%#########################################################################**++++***#*=:..                 ",
             "    .=#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%+                                  .:=*#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#######*+=:.            ",
             "    .:::::::::::::::::::::::::::::::::::::::::::::.                                      ..:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::..          ", 
             "                                                                                                                                                                                                  ",
                                                                                                                                                                                                   
            };

            Console.WriteLine("Please expand the console window.\n"+
                "Press enter to continue");
            Console.ReadLine();
            
            foreach(string line in kmart)
            {
                Console.WriteLine(line);
                Thread.Sleep(100);
            } // do we want this ?
            
            
            Console.WriteLine("Your goal is to get an item from all four rooms/sections. \nEach room has different obstacles. \nFind all four items and make it to checkout to finish shopping" +
                $" GOOD LUCK. \nYou need to find a {InventoryName[0]}, a {InventoryName[1]}, a {InventoryName[2]} and a {InventoryName[3]}");
            Console.WriteLine("Press Enter to proceed");
            Console.ReadLine();
            Hub();
        }

        static void Hub()
        {

            // move rooms - to which room new method
            // rest? 
            // place to check inventory 
            // show  list of rooms completed
            // cross off shopping list
            // 

            int num = 10;
            bool inMenu = true;

            do
            {
                Console.Clear();

                Console.WriteLine("Main Menu\n" + "Please select from the numbers below\n");
                Console.WriteLine("1  Rest\n" +
                                  "2  Room Selection\n" +
                                  "3  Check Your inventory\n" +
                                  "4  Go to Checkout\n" +
                                  "0  Exit The Menu");

                try
                {
                    num = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Huh");
                    Console.ReadLine();
                }

                Console.Clear();

                switch (num)
                {
                    case 1:
                        Rest();
                        break;

                    case 2:
                        RoomSelection();
                        break;

                    case 3:
                        Inventory();
                        break;

                    case 4:
                        inMenu = Checkout();
                        break;

                    case 0:
                        Exit();
                        inMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input. Please keep it between 0-4");
                        Console.ReadLine();
                        break;
                }


            } while (inMenu);

            void Rest()
            {
                Console.Write("You sit down at a chair and rest for a while");
                Thread.Sleep(1000);
                Health = 100;
                Stamina = 100;
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");
                    Thread.Sleep(500);

                }
                Console.WriteLine($"\nYour Health: {Health} and Stamina: {Stamina} are restored");
                Thread.Sleep(1000);
                Exit();

            }

            static void Exit()
            {
                Console.WriteLine("\nPlease press any key to exit");
                Console.ReadLine();
            }
            string RoomSelection()
            {
                int num = 0;
                bool inMenu = true;

                do
                {
                    Console.Clear();

                    Console.WriteLine("Main Menu\n" + "Please select from the numbers below\n");
                    Console.WriteLine("1  Clothing\n" +
                                      "2  Electronics\n" +
                                      "3  Toys\n" +
                                      "4  Camping\n" +
                                      "0  Back to the menu");

                    try
                    {
                        num = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Huh");
                        Console.ReadLine();
                    }

                    switch (num)
                    {
                        case 1:
                            Room = 1;
                            Clothing();
                            Console.WriteLine("This is Clothing\n" + "Press 0 to exit");
                            return "Clothing";

                        case 2:
                            Room = 2;
                            Electronics();
                            Console.WriteLine("This is Electronics\n" + "Press 0 to exit");
                            return "Electronics";

                        case 3:
                            Room = 3;
                            Toys();
                            Console.WriteLine("This is Toys\n" + "Press 0 to exit");
                            return "Toys";

                        case 4:
                            Room = 4;
                            Camping();
                            Console.WriteLine("This is Camping\n" + "Press 0 to exit");
                            return "Camping";

                        case 0:

                            inMenu = false;
                            return "Exiting";
                        default:
                            Console.WriteLine("Invalid Input. Please keep it between 0-4");
                            Console.ReadLine();
                            return "Invalid";

                    }

                } while (inMenu);


            }

        }

        static void Inventory()
        {
            Console.Clear();
            for (int i = 0; i < InventoryAmount.Length; i++)
            {
                Console.WriteLine($"You have {InventoryAmount[i]} {InventoryName[i]}s.");
            }
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();

        }

        static void CombatInventory()
        {
            Console.Clear();
            Console.WriteLine($"Your health is {Health}HP.\nYour stamina is {Stamina}Stm");
            for (int i = 0; i < CombatInventoryAmount.Length; i++)
            {
                if (CombatInventoryAmount[i] != 0)
                {
                    Console.WriteLine($"Enter {i + 1} to use one of your {CombatInventoryAmount[i]} {CombatInventoryName[i]}s.\n");
                }

            }
            Console.WriteLine("Enter the item you want to do or 0 if you want to exit.");
            int temp = 0;
            try
            {
                temp = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Huh");
                Console.ReadLine();
            }
            Console.Clear();
            switch (temp)
            {
                case 1:
                    if (CombatInventoryAmount[temp - 1] > 0)
                    {
                        Console.WriteLine($"You use one of your {CombatInventoryName[temp - 1]}s");
                        Health = Health + 25;  //Change this and the other values like this for the amount of health you want the potion to do. 
                        if (Health > 100)
                        {
                            Health = 100;
                        }
                        CombatInventoryAmount[temp - 1]--;
                        Console.WriteLine($"You gain 25 Health. You have now have {Health}HP.\nEnter to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough of that potion");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    if (CombatInventoryAmount[temp - 1] > 0)
                    {
                        Console.WriteLine($"You use one of your {CombatInventoryName[temp - 1]}s");
                        Health = Health + 50;
                        if (Health > 100)
                        {
                            Health = 100;
                        }
                        CombatInventoryAmount[temp - 1]--;
                        Console.WriteLine($"You gain 50 Health. You have now have {Health}HP.\nEnter to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough of that potion");
                        Console.ReadLine();
                    }
                    break;
                case 3:
                    if (CombatInventoryAmount[temp - 1] > 0)
                    {
                        Console.WriteLine($"You use one of your {CombatInventoryName[temp - 1]}s");
                        Health = Health + 100;
                        if (Health > 100)
                        {
                            Health = 100;
                        }
                        CombatInventoryAmount[temp - 1]--;
                        Console.WriteLine($"You gain 100 Health. You have now have {Health}HP.\nEnter to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough of that potion");
                        Console.ReadLine();
                    }
                    break;
                case 4:
                    if (CombatInventoryAmount[temp - 1] > 0)
                    {
                        Console.WriteLine($"You use one of your {CombatInventoryName[temp - 1]}s");
                        Stamina = Stamina + 25;
                        if (Stamina > 100)
                        {
                            Stamina = 100;
                        }
                        CombatInventoryAmount[temp - 1]--;
                        Console.WriteLine($"You gain 25 Stamina. You have now have {Stamina}Stm.\nEnter to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough of that potion");
                        Console.ReadLine();
                    }
                    break;
                case 5:
                    if (CombatInventoryAmount[temp - 1] > 0)
                    {
                        Console.WriteLine($"You use one of your {CombatInventoryName[temp - 1]}s");
                        Stamina = Health + 50;
                        if (Stamina > 100)
                        {
                            Stamina = 100;
                        }
                        CombatInventoryAmount[temp - 1]--;
                        Console.WriteLine($"You gain 50 Stamina. You have now have {Stamina}Stm.\nEnter to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough of that potion");
                        Console.ReadLine();
                    }
                    break;
                case 6:
                    if (CombatInventoryAmount[temp - 1] > 0)
                    {
                        Console.WriteLine($"You use one of your {CombatInventoryName[temp - 1]}s");
                        Stamina = Stamina + 100;
                        if (Stamina > 100)
                        {
                            Stamina = 100;
                        }
                        CombatInventoryAmount[temp - 1]--;
                        Console.WriteLine($"You gain 100 Stamina. You have now have {Stamina}Stm.\nEnter to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough of that potion");
                        Console.ReadLine();
                    }
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Invalid Input. Please keep it between 0-3");
                    Console.ReadLine();
                    break;

            }
            Console.Clear();

        }

        public static void Combat()
        {
            string[] Room1Enemies = { "Clothesliner", "Fashion Police", "Velcrofiend", "Zipperfang", "Sweater? I Hardly Know Her!" };

            string[] Room2Enemies = { "Cordspawn", "Dataleech", "Cable Golem", "Ampster", "Charger? I Hardly Know Her!" };

            string[] Room3Enemies = { "Toy Shelf", "Spring-Snake", "Jack-In-The-Box", "Spooky Chest", "Quiggle" };

            string[] Room4Enemies = { "Tent-Acles", "Leon Trotsky Memorial Iceaxe", "Carabiner? I Hardly Know Her!", "Freedom Camper", "Boots Made For Walkin'" };

            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Red;

            Console.Clear();

            Thread.Sleep(50);

            Console.BackgroundColor = ConsoleColor.Yellow;

            Console.Clear();

            Thread.Sleep(50);

            Console.BackgroundColor = ConsoleColor.Green;

            Console.Clear();

            Thread.Sleep(50);

            Console.BackgroundColor = ConsoleColor.Blue;

            Console.Clear();

            Thread.Sleep(50);

            Console.BackgroundColor = ConsoleColor.Magenta;

            Console.Clear();

            Thread.Sleep(50);

            Console.BackgroundColor = ConsoleColor.Cyan;

            Console.Clear();

            Thread.Sleep(50);

            Console.BackgroundColor = ConsoleColor.Black;

            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Red;

            Console.Clear();

            Thread.Sleep(50);

            Console.BackgroundColor = ConsoleColor.Yellow;

            Console.Clear();

            Thread.Sleep(50);

            Console.BackgroundColor = ConsoleColor.Green;

            Console.Clear();

            Thread.Sleep(50);

            Console.BackgroundColor = ConsoleColor.Blue;

            Console.Clear();

            Thread.Sleep(50);

            Console.BackgroundColor = ConsoleColor.Magenta;

            Console.Clear();

            Thread.Sleep(50);

            Console.BackgroundColor = ConsoleColor.Cyan;

            Console.Clear();

            Thread.Sleep(50);

            Console.BackgroundColor = ConsoleColor.Black;

            Console.Clear();

            Thread.Sleep(50);

            // ^ Intro to combat scenario




            // v Attack List

            int Light = 20, Strong = 35; // < values are how much damage each attack does (and stamina drained?)




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
                switch (Room)   // < depending on current room
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

            switch (enemies)                        // < changes starting text depending on number of enemies
            {

                case 1:                            // < if there is only one enemy

                    Console.WriteLine($"\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t\t\tA wild {onfield[0]} approaches!");  // < tells user what enemy they are facing

                    enem1Health = 100;

                    break;

                case 2:

                    Console.WriteLine($"\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t\t\tYou are stopped by {onfield[0]} and {onfield[1]}.");

                    enem1Health = 100;

                    enem2Health = 100;

                    break;

                case 3:

                    Console.WriteLine($"\n\n\n\n\n\n\t\t\t\t\t\t\t\t\t\t\tYou run into {onfield[0]}, {onfield[1]} and {onfield[2]}");

                    enem1Health = 100;

                    enem2Health = 100;

                    enem3Health = 100;

                    break;


                default:
                    // < for boss battles?
                    break;




            }

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

                Console.Write($"\n\nHP: {Health}\t\tSTM: {Stamina}\n\n\n1. Attack\t\t2. Items\t\t3. Guard (Take no damage for 1 turn, req. 20 STM)");

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

                    Console.WriteLine("\n\nSelect a target:\n\n");

                    try
                    {
                        target = Convert.ToInt32(Console.ReadLine());
                    }

                    catch
                    {
                        Console.Clear();

                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tInvalid input");

                        Thread.Sleep(2000);

                        Console.Clear();
                    }


                    if (option == 1)    // if Light Attack chosen
                    {
                        if (Stamina >= 10)
                        {
                            Stamina = Stamina - 10;

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
                        if (Stamina >= 20)
                        {
                            Stamina = Stamina - 20;

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
                    CombatInventory();
                }

                else if (option == 3)  // if Guard chosen
                {

                    if (Stamina >= 20)
                    {
                        Stamina = Stamina - 20;

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
                                    Health = Health - enemattack;
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
                                    Health = Health - enemattack;
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
                                    Health = Health - enemattack;
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
                                    Health = Health - enemattack;
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
                                    Health = Health - enemattack;
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
                                    Health = Health - enemattack;
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
                                    Health = Health - enemattack;
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
                                    Health = Health - enemattack;
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
                                    Health = Health - enemattack;
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
                                    Health = Health - enemattack;
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
                                    Health = Health - enemattack;
                                }

                                Thread.Sleep(2500);

                                Console.Clear();

                                break;

                        }

                    }   guard = false; // resets guard after turn

                }

                if (enem1Health <= 0 && enem2Health <= 0 && enem3Health <= 0 || Health <= 0)
                {
                    fightend = true;
                }

            } while (fightend != true);


            Console.Clear();

            if (Health <= 0)
            {
                Console.WriteLine("\n\n\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tYOU DIED");
                Health = 1; //resets hp

                Thread.Sleep(5000);
            }

            else
            {
                Console.WriteLine("\n\n\n\n\t\t\t\t\t\t\t\t\t\t\t\t\tA WINNER IS YOU");

                Thread.Sleep(5000);
            }

            Console.Clear();

        }

        static void Clothing()
        {
            Console.Clear();
            Console.WriteLine($"You enter the Clothing section in order to find the {InventoryName[0]}.");
            Console.WriteLine("Enter to continue.");
            Console.ReadLine();
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("You look around to see racks of clothing all around you, maybe what you're searching for is in these racks.");
                Console.WriteLine("You also see that you can continue forward between these racks, but it looks like the prime spot for you to get jumped.\nDo you");
                Console.WriteLine($"1: Search the clothing racks in hopes of finding a {InventoryName[0]}.\n2: Continue forward, knowing you are most likely to get jumped.");
                Console.WriteLine("3: Leave.");
                int temp = 0;
                try
                {
                    temp = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Huh");
                    Console.ReadLine();
                }
                Console.Clear();
                switch (temp)
                {
                    case 1:
                        Console.WriteLine("You look in the clothing racks.");
                        Thread.Sleep(1000);
                        temp = rand.Next(1000);
                        if (temp == 365)
                        {
                            Console.WriteLine($"And found a {InventoryName[0]}!");
                            InventoryAmount[0]++;
                            Console.WriteLine("Enter to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("And found nothing.");
                            Console.WriteLine("Enter to continue.");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine($"You venture between the racks to find a {InventoryName[0]}.");
                        Console.WriteLine("Enter to continue.");
                        Console.ReadLine();
                        ClothingDeeper();
                        break;
                    case 3:
                        Console.WriteLine("You decided to leave.\nEnter to continue.");
                        Console.ReadLine();
                        running = false;
                        break;
                    default:
                        break;
                }
            }
        }
        static void ClothingDeeper()
        {
            Console.Clear();
            //Continue with it here for clean look.
            Console.WriteLine("Halfway to the end, something lands behind you and knocks you over.");
            Console.ReadLine();
            Combat();
            Console.WriteLine($"After the battle and passing between the aisle you notice a pedestal ahead. On it is a {InventoryName[0]} on display. But it's under a glass container.");
            bool running = true;
            while (running)
            {
                Console.WriteLine("It looks like there is a dial on the pedestal that unlocks the glass container. Or maybe you just break the glass.\nDo you");
                Console.WriteLine("1: Break the glass.\n2: Try the dial.\n3: Leave.");
                int temp = 0;
                try
                {
                    temp = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Huh");
                    Console.ReadLine();
                }
                Console.Clear();
                switch (temp)
                {
                    case 1:
                        Console.WriteLine("You try to break the glass.");
                        Thread.Sleep(1000);
                        temp = rand.Next(100);
                        if (temp == 65)
                        {
                            Console.WriteLine($"And succeed!");
                            Console.WriteLine($"You got a {InventoryName[0]}!");
                            InventoryAmount[0]++;
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("And failed.");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine("You take a closer look at the dial. It is a four combination lock with 0-9 on each. Entering every option might take a while.");
                        Console.WriteLine("On the floor, a post-it note is crumpled on the floor.");
                        Console.WriteLine("On the note is the code to the lock. You enter it into the lock and see that the glass container has unlocked.");
                        Console.WriteLine($"You got a {InventoryName[0]}!");
                        InventoryAmount[0]++;
                        Console.WriteLine($"But so caught up in collecting the {InventoryName[0]}, you fail to spot the enemy behind you.");
                        Console.ReadLine();
                        Combat();
                        Console.WriteLine("After the battle, you decided to leave.\nEnter to continue.");
                        Console.ReadLine();
                        running = false;
                        break;
                    case 3:
                        Console.WriteLine("You decided to leave.\nEnter to continue.");
                        Console.ReadLine();
                        running = false;
                        break;
                    default:
                        break;
                }
                Console.Clear();
            }
        }

        static void Camping()
        {
            bool yesno, doNotSpamHubPlz = true;

            int threechoice = 0, twochoice = 0, reel1 = 0, reel2 = 0, reel3 = 0, gamblewin = 0;

            Console.Clear();

            while (doNotSpamHubPlz)
            {
                Console.WriteLine("\nYou head off in the direction of the store's Camping department in search of a foldable Yard Chair.");
                Thread.Sleep(3000);
                Console.WriteLine("\nAs you approach the outer aisles of the department you feel an inexplicable chill run over your body. Something isn't right, but you aren't sure what.");
                Thread.Sleep(3000);
                Console.WriteLine("\n\nWhat do you do next?\n\n");
                Console.Write("\n1. Proceed forward into the tents aisle");
                Console.Write("\n2. Go around and enter via the fishing aisle");
                Console.Write("\n3. Turn around and leave");

                try
                {
                    while (threechoice != 1 && threechoice != 2 && threechoice != 3)
                    {
                        threechoice = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Huh");
                    Console.ReadLine();
                }
                Console.Clear();
                Thread.Sleep(3000);
                switch (threechoice)
                {
                    case 1:
                        Console.WriteLine("\nAs you walk through the aisle the lights suddenly blow, one by one. Now enshrouded by darkness, you can faintly see what looks like a headtorch hanging on one of the racks.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\n\nDo you choose to reach out for it, or to stumble your way to the prized Yard Chair in the dark?");
                        Thread.Sleep(3000);
                        Console.Write("\n1. Attempt to grab the torch");
                        Console.Write("\n2. Continue without it");

                        try
                        {
                            while (threechoice != 1 && threechoice != 2 && threechoice != 3)
                            {
                                twochoice = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Huh");
                            Console.ReadLine();
                        }
                        Console.Clear();
                        Thread.Sleep(3000);
                        break;

                    case 2:
                        Console.WriteLine("\nAs you walk through the aisle you notice that the floor is wet, perhaps a cleaner left their job unfinished.");
                        Thread.Sleep(3000);
                        Console.WriteLine("\n..but upon looking down, you realise that you are somehow standing in the middle of a river flowing straight through the aisle?");
                        Thread.Sleep(3000);
                        Console.WriteLine("\n\nBefore you can react to this bizarre situation, a figure leaps toward you out of the water!");
                        Thread.Sleep(3000);
                        Combat();
                        

                        break;


                    case 3:
                        Console.Clear();
                        Console.Write("\nYou turned back and made a tactical retreat to the entrance.");
                        Thread.Sleep(3000);


                        break;


                }
                if (doNotSpamHubPlz)
                { 
                    switch (twochoice)
                    {
                        case 1:
                            Console.Clear();
                            Console.Write("\nYou take the torch and place it on your head. However, its light illuminates an enemy!");
                            Thread.Sleep(3000);
                            Combat();
                            break;


                        case 2:
                            Console.Clear();
                            Console.Write("\nYou choose to continue without the torch. Unfortunately, you overestimated how many carrots you eat and are hit by a sneak attack!");
                            Thread.Sleep(3000);
                            Combat();
                            break;
                        

                    }

                    Console.Clear();
                    Console.WriteLine("\nYou have arrived at your destination. You see a lone Yard Chair propped up against a shelf at the mouth of the unexplainable river that is now flowing through the store.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\n..but before you can get to it, a group of beavers jump out of the water and set a new record for dam construction speedrunning and block your path.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nUpon closer inspection, you notice there is a slot machine built into the dam, with a sign saying that you will gain entry if you hit the jackpot.");
                    Thread.Sleep(3000);
                    Console.WriteLine("\nIt seems you have no choice but to gamble if you want the chair...");
                    Thread.Sleep(6000);
                    Console.Clear();


                    while (gamblewin != 1)
                    {


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
                            gamblewin = 1;
                            Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\tToday is your lucky day");
                            Thread.Sleep(3000);
                            Console.WriteLine("\nYou hear a mechanism click as the slot machine moves to reveal a hidden passage through the dam.");
                            Thread.Sleep(3000);
                            Console.WriteLine("\nYou quickly grab the Yard Chair and make a beeline back to the entrance before any more chicanery can occur.");
                            InventoryAmount[3]++;
                            doNotSpamHubPlz = false;
                            Thread.Sleep(3000);
                            Console.Clear();
                        }

                        else
                        {
                            Console.WriteLine("\n\n\n\t\t\t\t\t\t\t\t\t\t\tTip: 90% of gamblers quit right before they win big");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                    }
                }
            }
        }

        static int GetValidInput(int min, int max)
        {
            int result = 0;
            bool validInput = false;

            while (!validInput)
            {
                string input = Console.ReadLine();
                try
                {
                    int value = Convert.ToInt32(input);
                    if (value >= min && value <= max)
                    {
                        result = value;
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine($"Please enter a number between {min} and {max}.");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            return result;
        }

        static void Toys()
        {

            int one6 = rand.Next(0 , CombatInventoryAmount.Length);
            int[] CombatItemCounts = new int[5];
            Random randomGenerator = new Random();

            bool sectionActive = true;
            bool gotItem = false;
            int playerChoice = 0;
            string answer = "";

            Console.Clear();
            Console.WriteLine("You step into the Toys section.");
            Console.WriteLine("Aisles are packed with plushies, plastic sets, and blinking gadgets.");
            Console.WriteLine($"\n\nYou’re here looking for a {InventoryName[2]} \n");

            do
            {
                Console.Clear();
                Console.WriteLine("What do you want to do?\n  " +
                                  "1) Check the spring-loaded toy snake\n  " +
                                  "2) Browse the toy shelf\n  " +
                                  "3) Crank the Jack-in-the-box\n  " +
                                  "4) Explore the spooky toy chest\n  " +
                                  "0) Leave\n");

                try
                {
                    playerChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                switch (playerChoice)
                {
                    case 0:
                        Console.WriteLine("You leave the Toys section.");
                        sectionActive = false;
                        break;

                    case 1:
                        SpringSnake();
                        break;

                    case 2:
                        ToyShelf();
                        break;

                    case 3:
                        JackInTheBox();
                        break;

                    case 4:
                        SpookyChest();
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please pick 1, 2, 3 or 4.");
                        break;
                }

                if (gotItem)
                {
                    sectionActive = false;
                    Console.WriteLine("\nPress Enter to leave.");
                    Console.ReadLine();
                }

            } while (sectionActive);

            void SpringSnake()
            {
                Console.WriteLine("You peek into a toy box. Suddenly, a spring-loaded snake leaps out!");
                StartCombat();
                CombatItemCounts[2]++;
                Console.WriteLine("\nPress Enter to continue.");
                Console.ReadLine();
            }

            void ToyShelf()
            {
                Console.WriteLine("You examine the shelves. A toy hums quietly in the back.");
                Thread.Sleep(1000);
                Console.WriteLine($"You find a {CombatInventoryName[one6]} resting in a toy crate and grab it.");
                CombatInventoryAmount[one6]++;
                Console.WriteLine("\nPress Enter to continue.");
                Console.ReadLine();
            }

            void JackInTheBox()
            {
                Console.WriteLine("A Jack-in-the-box sits motionless. Its crank dares you.");
                Console.Write("Crank it? (y/n): ");
                string yn = Console.ReadLine().Trim().ToLower();
                if (yn == "y" || yn == "yes")
                {
                    Console.Clear();
                    Console.WriteLine("POP! Out jumps Jack.\nRiddle: I roll with wheels and a remote in hand. What am I?");
                    answer = Console.ReadLine().Trim().ToLower();
                    if (answer.Contains("remote") || answer.Contains("car"))
                    {
                        Console.WriteLine("Jack winks and tosses you the Remote Controlled Car.");
                        InventoryAmount[2]++;
                        gotItem = true;
                       
                    }
                    else
                    {
                        Console.WriteLine("Jack giggles and sinks back into his box.");
                    }
                    Console.WriteLine("\nPress Enter to continue.");
                    Console.ReadLine();
                }
            }

            void SpookyChest()
            {
                Console.WriteLine("You approach a dusty, eerie chest. It creaks open on its own...");
                StartCombat();
                Console.WriteLine($"Inside, you find the {InventoryName[2]} gleaming beneath some old plush toys.");
                InventoryAmount[2]++;
                gotItem = true;

            }

            void StartCombat()
            {
                Console.WriteLine("\nA toy springs to life! You face off bravely.\n");
                Thread.Sleep(1000);
                Combat();
            }

        }

        static void Electronics()
        {

            bool sectionActive = true, gotItem = false; // keeps the section active until the player leaves
            int playerChoice = 0;
            string answer;
            string yn = "";
            bool validInput = false;

            Console.Clear();
            Console.WriteLine("You step into the Electronics section.");
            Thread.Sleep(1000);
            Console.WriteLine("Rows of glittering screens, RGB keyboards and tangled cables stretch before you.");
            Thread.Sleep(1000);
            Console.WriteLine($"\n\nYou’re here looking for a {InventoryName[1]} \n");
            Thread.Sleep(1000);
            do
            {
                Console.WriteLine("As you scan the shelves, you see:\n  " +
                                  "1) A neat stack of USB cables.\n  " +
                                  "2) A half-broken display of portable chargers.\n  " +
                                  "3) A frazzled Granny clutching a tangled headset.\n  " +
                                  "4) A dimly lit aisle that makes it hard to see what’s ahead.");
                Thread.Sleep(1000);
                Console.WriteLine("What do you want to do?\n  ");

                try
                {
                    playerChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Input");
                }
                Console.Clear();
                switch (playerChoice)
                {
                    case 0:
                        Console.WriteLine("You decide to leave the Electronics section.");
                        sectionActive = false;
                        break;

                    case 1:
                        UsbCables();
                        LeaveCase();
                        break;

                    case 2:
                        Chargers();
                        LeaveCase();
                        break;

                    case 3:
                        Granny();
                        LeaveCase();
                        break;

                    case 4:
                        DimlyLitAisle();

                        // InventoryAmount[2]+ 1 when getting the item
                        LeaveCase();
                        break;

                    default:
                        Console.WriteLine("Invalid choice, please pick 1, 2, 3 or 4.");
                        break;

                }
                Console.Clear();

                if (gotItem == true)
                {
                    sectionActive = false;
                }

            } while (sectionActive);

            void UsbCables()
            {
                int one6 = rand.Next(0, CombatInventoryAmount.Length);
                Console.WriteLine("You approach the USB cables. ");// combat section maybe 
                Thread.Sleep(800);
                Console.WriteLine("Most of them are coiled neatly on hooks... except one.");
                Thread.Sleep(800);
                Console.WriteLine("It lies loose on the shelf — unspooled, out of place, and strangely clean.");
                Thread.Sleep(800);
                Console.WriteLine("You reach for it...");
                Thread.Sleep(800);
                Console.WriteLine("Suddenly, it twitches.");
                Console.WriteLine("Before you can react, it whips itself into the air — and something steps out from behind the shelf!");

                LeaveCase();
                Combat();

                // if you win combat you get the item
                CombatInventoryAmount[one6] += 1; // how to fail combat and not get the item
            }

            void Chargers()
            {
                int one6 = rand.Next(0, CombatInventoryAmount.Length);
                Console.WriteLine("You sort through the pile of portable chargers. One claims to charge a fridge. Another has three buttons and no ports.\n");
                Thread.Sleep(2000);

                Console.WriteLine(
                          $"Then — jackpot! Behind a toppled charger display, you spot a {CombatInventoryName[one6]} just sitting there like a free sample.\nYou casually slip it into your inventory before anyone notices.");
                Thread.Sleep(2000);
                Console.WriteLine("You don't see anything else useful in the area.");

                CombatInventoryAmount[one6] += 1;
            }

            void Granny()
            {

                while (!validInput)
                {
                    Console.WriteLine("You approach the Granny, who’s poking at a wireless headset like it's an alien artifact.\nExcuse me, she says, adjusting her comically large glasses,\n'Help me get this contraption working, and I’ll make it worth your while.\n\n");
                    Thread.Sleep(1000);
                    Console.Write("Do you want to help her y/n? ");
                    yn = Console.ReadLine().Trim().ToLower();

                    if (yn == "y" || yn == "n")
                    {
                        validInput = true; // exit loop
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no.");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                validInput = false;
                if (yn == "y" || yn == "yes")
                {
                    Console.Clear();
                    Console.WriteLine("You say you will help her\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("Now listen here, dear — this thing says it's wireless, but I don’t see how it works without a wire!\nMaybe you can figure it out if you’re clever:\nI travel through air,\nbut I’m not a bird.\nI carry music,\nyet say not a word.\nWhat am I?");

                    answer = Convert.ToString(Console.ReadLine().Trim().ToLower());
                    if (answer == "bluetooth" || answer == "signal" || answer == "wifi")
                    {
                        Console.Clear();
                        Console.WriteLine("Granny blinks, then breaks into a wide grin.\n");
                        Thread.Sleep(1000);

                        Console.WriteLine("“Well I’ll be — you got it right! Smarter than the manager around here, that’s for sure.\n");// do i keep the -'s
                        Thread.Sleep(1000);
                        Console.WriteLine($"She digs around in her trolley, moving aside half a loaf of bread and some unlabelled cans.\nHere, take this. I grabbed it earlier thinking it was a fancy radio, but it’s actually what you’re after.\nShe hands you the {InventoryName[1]}.\n");
                        Thread.Sleep(1000);
                        Console.WriteLine("Your such a nice young person. Says the granny as she walks away\n");
                        Thread.Sleep(2500);

                        InventoryAmount[1] += 1;
                        Console.WriteLine("Item acquired! You successfully found what you were looking for.");
                        gotItem = true;

                    }
                    else
                    {
                        Console.WriteLine("Oh heavens, I was hoping you knew. Maybe we should both go back to using tin cans and string!\n");

                    }
                }
                else
                {
                    Console.WriteLine("You decide to leave the Granny alone.\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("She looks disappointed, but you can’t help everyone.");
                    Thread.Sleep(2000);
                }

            }
            void DimlyLitAisle()
            {
                int one6 = rand.Next(0, CombatInventoryAmount.Length);
                Console.Clear();

                while (!validInput)
                {
                    Console.WriteLine("You step cautiously into the dimly lit aisle.\n");
                    Thread.Sleep(2000);
                    Console.WriteLine("As your foot touches the worn tile, the soft hum of the overhead lights cuts out.\n");
                    Thread.Sleep(1500);
                    Console.WriteLine("The faint music from the store speakers? Gone.");
                    Thread.Sleep(1500);
                    Console.WriteLine("A heavy silence settles around you, thick and unnatural.");
                    Thread.Sleep(1500);
                    Console.WriteLine("\nIn front of you, a CRT television, old and dusty, clicks on without warning.");
                    Thread.Sleep(1500);
                    Console.WriteLine("A swirling pattern appears on the screen, hypnotic and strange.\nThen, a face forms.");
                    Thread.Sleep(1500);
                    Console.WriteLine("Pixelated.");
                    Thread.Sleep(1000);
                    Console.WriteLine("Smiling much too wide.\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("“Welcome, shopper,” it says in a stuttering monotone.\n“To claim what you seek... answer this riddle”\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("The screen flickers, as if waiting. Watching. The grin stays frozen. Unmoving");
                    Thread.Sleep(2000);
                    Console.Write("Do you answer the riddle... or do you turn and flee?\n");
                    yn = Console.ReadLine().Trim().ToLower();

                    if (yn.Contains("flee") || yn.Contains("riddle"))
                    {
                        validInput = true; // exit loop
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }

                }
                validInput = false;

                if (yn.Contains("answer") || yn.Contains("riddle"))// riddle
                {
                    Console.Clear();
                    Console.WriteLine("You decide try to answer the riddle.\n");
                    Thread.Sleep(1000);
                    Console.WriteLine("I glow without fire and speak without breath,\r\nI summon your gaze 'til long after death.\n");
                    Console.WriteLine("I'm always nearby, yet you'll never hold me tight,\nI live in your pocket and steal sleep each night.");

                    answer = Convert.ToString(Console.ReadLine().Trim().ToLower());
                    if (answer.Contains("phone") || answer.Contains("tablet"))// riddle answer options
                    {
                        Console.Clear();
                        Console.WriteLine("The screen glitches, its pixels warping into a sinster pout.\n");
                        Thread.Sleep(1000);

                        Console.WriteLine("“Impressive,” it croaks, voice now echoing. “Few remember the truth behind the glow.”\n");
                        Thread.Sleep(1000);
                        Console.WriteLine($"A drawer beneath the CRT clicks open with a hiss, revealing the {InventoryName[1]}.\n");
                        Thread.Sleep(1000);
                        Console.WriteLine("“Take your prize, clever one… but beware. The store watches those who see too much.”\n");
                        Thread.Sleep(2000);

                        InventoryAmount[1] += 1;
                        Console.WriteLine($"Item acquired! You successfully found what you were looking for.\n And as a bonus you got a {CombatInventoryName[one6]}");
                        gotItem = true;

                    }
                    else
                    {
                        Console.WriteLine("The screen flickers violently. The smile distorts into a sneer. A piercing static fills the aisle.\n");
                        Thread.Sleep(1000);
                        Console.WriteLine("“Foolish shopper,” it hisses, voice now a low growl. “You dare waste my time?”\n");
                        Thread.Sleep(1000);
                        Console.WriteLine("“Then let the forgotten ones remind you.”\n");
                        Thread.Sleep(1000);
                        Console.WriteLine("Vents rattle. Display shelves tremble. From the shadows of the electronics section, something stirs, cords twitching, batteries humming, plastic limbs dragging across linoleum.\n");
                        Thread.Sleep(1000);
                        Console.WriteLine("The store is sending its enforcers.\n");

                        LeaveCase();
                        Combat();

                    }
                }
                else
                {
                    Console.WriteLine("You turn and sprint away, heart pounding in your chest.\n");
                    Thread.Sleep(2000);
                    Console.WriteLine("The eerie glow fades behind you, but a chill lingers, like unseen eyes tracking your every step.");
                    Thread.Sleep(2000);
                }

            }

            void LeaveCase()
            {
                Console.Write("\nPress enter to continue.");
                Console.ReadLine();
            }
        }
        static bool Checkout()
        {
            Console.Clear();
            if (InventoryAmount[0] > 0 && InventoryAmount[1] > 0 && InventoryAmount[2] > 0 && InventoryAmount[3] > 0)
            {
                Console.WriteLine("With everything you need, you walk to the checkout." +
                    "\nYou approach the checkout worker and put your items on the counter." +
                    "\nThey scan the items and the total comes out to $129.96" +
                    "\nYou pay and exit the store, having completed your shopping for today.");
                Console.WriteLine("\nPress enter to finish the game.");
                Console.ReadLine();
                return false;
            }
            else
            {
                Console.WriteLine("You are missing items to contine to the checkout. " +
                    "\nMake sure you have got everything you need before checking out." +
                    "\nEnter to continue.");
                Console.ReadLine();
                return true;
            }
        }
    }
}