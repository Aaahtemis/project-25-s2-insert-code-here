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

        static string[,] enemyNames = {
            {"Clothesliner", "Fashion Police", "Velcrofiend", "Zipperfang", "Sweater? I Hardly Know Her!" },
            { "Cordspawn", "Dataleech", "Cable Golem", "Ampster", "Charger? I Hardly Know Her!" },
            { "Toy Shelf", "Spring-Snake", "Jack-In-The-Box", "Spooky Chest", "Quiggle" },
            { "Tent-Acles", "Leon Trotsky Memorial Iceaxe", "Carabiner? I Hardly Know Her!", "Freedom Camper", "Boots Made For Walkin'" }
        };


        static string[] enemyIdles =
            {
                "{onfield[i]} is rethinking its career path.",
                "{onfield[i]} is thinking about the Roman Empire.",
                "{onfield[i]} is silently judging you.",
                "{onfield[i]} pulled out its phone and started playing Subway Surfers.",
                "{onfield[i]} asked you if you believe in our lord, who art in Heaven.",
                "{onfield[i]} attempted to explain insider trading to you.",
                "{onfield[i]} asked you if your refrigerator is running.",
                "{onfield[i]} is beginning to Morb.",
                "{onfield[i]} wants to get off Mr. Bones' wild ride.",
                "{onfield[i]} loves legitimate theatre.",
                "{onfield[i]} asked you to spell ICUP.",
                "{onfield[i]} is suffering from Jaundice.",
                "{onfield[i]} did an impression of construction equipment.",
                "{onfield[i]} says: What's the deal with airline food?",
                "{onfield[i]} thought we were having Steamed Clams.",
                "{onfield[i]} asked you to play Wonderwall.",
                "{onfield[i]} took a swig from a brown paper bag.",
                "{onfield[i]} knows what you did.",
                "{onfield[i]} pulled your IP address."
            };



        static int Light = 20, Strong = 35; // < values are how much damage each attack does (and stamina drained?)


        //"1  Clothing\n" +
        //"2  Electronics\n" +
        //"3  Toys\n" +
        //"4  Camping\n" +


        static int health = 100;
        static int stamina = 100;


        //This one is for combat
        public static (int amount, string name)[] inventory = { (1, "Small Health potion"), (1, "Medium Health potion"), (1, "Large Health potion"), (1, "Small Stamina potion"), (1, "Medium Stamina potion"), (1, "Large Stamina potion") };


        static (string name, int health)[] onfield = new (string, int)[0];

        static int turns = 0;

        static bool guarding = false;




        public static void Start(int roomNum)
        {
            bool inCombat = true;

            for (int i = 0; i < introAnim.Length; i++)            // flashing lights intro animation
            {
                Console.Clear();
                Console.BackgroundColor = introAnim[i];
                Thread.Sleep(200);
            }


            // randomized enemy generation between 1 and 3
            Random rand = new Random();
            int enemyCount = rand.Next(1, 4);

            Array.Resize(ref onfield, enemyCount);
            for (int i = 0; i < enemyCount; i++)
            {
                onfield[i].name = (enemyNames[roomNum - 1, rand.Next(0, enemyNames.GetLength(roomNum - 1))]);
                onfield[i].health = 100;
            }

            // display starting text depending on number of enemies
            switch (enemyCount)
            {
                case 1:
                    Format.AddToResponse($"A wild {onfield[0]} approaches!");
                    break;

                case 2:
                    Format.AddToResponse($"You are stopped by {onfield[0]} and {onfield[1]}.");
                    break;

                case 3:
                    Format.AddToResponse($"You run into {onfield[0]}, {onfield[1]} and {onfield[2]}");
                    break;
            }

            Format.DisplayResponse();
            Thread.Sleep(2500);
            Console.Clear();









            // new loop.
            while (inCombat)
            {
                turns++;

                if (turns % 2 != 0)     // player takes turn

                {


                }
                else                    // enemies take turn

                {


                }

            }


            for (int i = 0; i < onfield.Length; i++)
            {



                // enemy idle
                Console.Clear();
                Format.AddToResponse($"" + enemyIdles[rand.Next(enemyIdles.Length)]);
                Format.DisplayResponse();
                Thread.Sleep(2000);
                Console.Clear();


                // attacked method:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Thread.Sleep(100);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

                int damageDealt = rand.Next(5, 21);
                Format.AddToResponse($"{onfield[i]} attacks for {damageDealt} damage!");


                if (guarding)
                {
                    Format.AddToResponse($"{onfield[i]} attacks for {damageDealt} damage!");
                }
                else
                {
                    Player.health -= damageDealt;
                }

                Format.DisplayResponse();
                Thread.Sleep(2500);
                Console.Clear();



                Console.Clear();


                if (health <= 0)
                {
                    Format.AddToResponse($"You died!");
                    Thread.Sleep(5000);
                }

                Console.Clear();

            }

            guarding = false; // resets guard after turn
        }


/// <summary>
/// display combat inventory and allow access to items
/// </summary>
static void showInventory()
        {

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].amount != 0)
                {
                    Console.WriteLine($"Enter {i + 1} to use one of your {inventory[i].amount} {inventory[i].name}s.\n");
                }

            }

            Format.AddToResponse("Enter the item you want to do or 0 if you want to exit.");
            Format.DisplayResponse();

            Player.GetInt(3, 0);

            bool used = false;
            int amountChanged = 0;
            bool healthChanged = false;


            if (Player.input != 0)
            {
                if (inventory[Player.input - 1].amount > 0)
                {
                    used = true;

                    switch (Player.input)
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



                    inventory[Player.input - 1].amount--;
                    Console.ReadLine();
                }
            }



            if (used)
            {
                Format.AddToResponse($"You use one of your {inventory[Player.input - 1].name}s");
                if (healthChanged)
                {
                    health += amountChanged;
                    if (health > 100)
                    {
                        health = 100;
                    }
                    Format.AddToResponse($"You gain {amountChanged} Health. You have now have {health}HP.Enter to continue");
                }
                else
                {
                    stamina += amountChanged;
                    if (stamina > 100)
                    {
                        stamina = 100;
                    }
                    Format.AddToResponse($"You gain {amountChanged} Health. You have now have {stamina}STM.");
                }
            }
            else
            {
                Format.AddToResponse("You don't have enough of that item");
            }


            Format.AddToResponse("Enter to continue");
            Format.DisplayResponse();
            Console.ReadLine();

        }




        static void showHUD()
        {

            // Combat UI v

            string border = new string('-', 209);



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


        }










        static void performAction()
        {
            if (Player.input == 1)    // if Attack chosen
            {
                Console.WriteLine("\n\nSelect an attack\n\n");

                Console.WriteLine("\n\n1. Light Attack (20 DMG, req. 10 STM)\t\t2. Heavy Attack (40 DMG, req 20 STM)\t\t3. Hail Mary (Do I feel lucky?)\n\n");

                Player.GetInt();


                Console.WriteLine("\n\nSelect a target:\n\n");


                Player.GetInt();



                if (Player.input == 1)    // if Light Attack chosen
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

                        switch (Player.input) //enemy chosen
                        {

                            case 1:
                                enem1Health = enem1Health - 20;
                                break;

                            case 2:
                                enem2Health = enem2Health - 20;
                                break;

                            default:
                                enem3Health = enem3Health - 20;
                                break;
                        }

                        Format.AddToStringArray("You dealt {}");

                    }

                    else
                    {
                        Console.WriteLine("\n\nNot enough Stamina");

                        Thread.Sleep(1500);

                        Console.Clear();

                    }


                }

                else if (Player.input == 2)    // if Heavy Attack chosen
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

                        switch (Player.input) //enemy chosen
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

                else if (Player.input == 3)   // if Hail Mary chosen
                {
                    Console.Clear();

                    int reel1 = rand.Next(1, 8);
                    int reel2 = rand.Next(1, 8);
                    int reel3 = rand.Next(1, 8);

                    Console.Write($"\n\n\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t{reel1}");

                    Thread.Sleep(500);

                    Console.Write($" {reel2}");

                    Thread.Sleep(500);

                    Console.Write($" {reel3}");

                    Thread.Sleep(500);

                    if (reel1 == reel2 && reel1 == reel3)
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

            else if (Player.input == 2)  // if Items chosen
            {
                showInventory();
            }

            else if (Player.input == 3)  // if Guard chosen
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

                    guarding = true;

                }

                else
                {
                    Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\tNot enough Stamina");

                    Thread.Sleep(1500);

                    Console.Clear();

                }


            }
        }
    }
}
