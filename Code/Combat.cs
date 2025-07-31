using System.ComponentModel;

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
                " is rethinking its career path.",
                " is thinking about the Roman Empire.",
                " is silently judging you.",
                " pulled out its phone and started playing Subway Surfers.",
                " asked you if you believe in our lord, who art in Heaven.",
                " attempted to explain insider trading to you.",
                " asked you if your refrigerator is running.",
                " is beginning to Morb.",
                " wants to get off Mr. Bones' wild ride.",
                " loves legitimate theatre.",
                " asked you to spell ICUP.",
                " is suffering from Jaundice.",
                " did an impression of construction equipment.",
                " says: What's the deal with airline food?",
                " thought we were having Steamed Clams.",
                " asked you to play Wonderwall.",
                " took a swig from a brown paper bag.",
                " knows what you did.",
                " pulled your IP address."
            };



        //"1  Clothing\n" +
        //"2  Electronics\n" +
        //"3  Toys\n" +
        //"4  Camping\n" +


        public static int health = 100;
        public static int stamina = 100;


        static (int power, int stamina) lightAttack = (20, 10), heavyAttack = (40, 15); // power and stamina cost for light and heavy attacks respectively
        static int guardStamina = 20; // stamina cost for guarding


        //This one is for combat
        public static (int amount, string name)[] inventory = { (1, "Small Health potion"), (1, "Medium Health potion"), (1, "Large Health potion"), (1, "Small Stamina potion"), (1, "Medium Stamina potion"), (1, "Large Stamina potion") };

        static (string name, int health)[] onfield = new (string, int)[0];

        static int turns = 0;

        static bool guarding = false; // used to determine if the player is guarding this turn
        static bool heavy = false; // used to determine if the player is using a heavy attack




        public static void Start(int roomNum)
        {
            bool inCombat = true;

            for (int i = 0; i < introAnim.Length; i++)            // flashing lights intro animation
            {
                Console.Clear();
                Console.BackgroundColor = introAnim[i];
                Thread.Sleep(200);
            }


            Random rand = new Random();
            int enemyCount = rand.Next(1, 4);            // randomized enemy generation between 1 and 3


            Array.Resize(ref onfield, enemyCount);

            if (roomNum > 0 && roomNum < enemyNames.Length)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    string chosenName = enemyNames[roomNum - 1, rand.Next(0, enemyNames.GetLength(1))];
                    onfield[i].name = chosenName + " " + (i + 1);
                    onfield[i].health = 100;

                    // rand.Next(0, enemyNames.GetLength( roomNum - 1))
                }
            } else
            {
                inCombat = false; // if room number is invalid, combat does not start
                Format.AddToResponse($"No enemies found in this room. Combat will not start in room {roomNum}");
                Format.DisplayResponse();
                Thread.Sleep(2500);
                return; // exit the method if no enemies are found
            }

            switch (enemyCount)            // display starting text depending on number of enemies

            {
                case 1:
                    Format.AddToResponse($"A wild {onfield[0].name} approaches!");
                    break;

                case 2:
                    Format.AddToResponse($"You are stopped by {onfield[0].name} and {onfield[1].name}.");
                    break;

                case 3:
                    Format.AddToResponse($"You run into {onfield[0].name}, {onfield[1].name} and {onfield[2].name}");
                    break;
            }


                Format.DisplayResponse();
                Thread.Sleep(2500);


            turns++; // increment turn to allow player to act first

            while (inCombat)            // new loop.
            {

                Console.Clear();
                BuildHUD();
                Format.DisplayResponse();
                if (turns % 2 != 0)     // player takes turn
                {
                    inCombat = PerformAction();
                }
                else                    // enemies take turn
                {
                    inCombat = EnemyAction();
                }

            }
        }


        /// <summary>
        /// display combat inventory and allow access to items
        /// </summary>
        static void ShowInventory()
        {
            BuildHUD();
            Format.AddToResponse($"Enter a number to use an item :)", 0 , 1);

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].amount != 0)
                {
                    Format.AddToResponse($"{i + 1} -- {inventory[i].amount} of {inventory[i].name}/s.");
                }
            }

            Format.AddToResponse("Enter the item you want to do or 0 if you want to exit.", 2);
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

                    Format.AddToResponse($"You use one of your {inventory[Player.input - 1].name}s");

                    switch (Player.input)
                    {
                        case 1:                     // health potions
                            healthChanged = true;
                            amountChanged += 25;
                            health += amountChanged;
                            if (health > 100)
                            {
                                health = 100;
                            }
                            Format.AddToResponse($"You gain {amountChanged} Health. You have now have {health}HP.Enter to continue");
                            break;
                        case 2:
                            amountChanged += 25;
                            goto case 1;
                        case 3:
                            amountChanged += 50;
                            goto case 2;


                        case 4:                     // stamina potions
                            amountChanged += 25;
                            stamina += amountChanged;
                            if (stamina > 100)
                            {
                                stamina = 100;
                            }
                            Format.AddToResponse($"You gain {amountChanged} Stamina. You have now have {stamina}STM.");
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

                    turns++; // increment turns to allow enemies to attack next turn

                    inventory[Player.input - 1].amount--;
                } 
                else
                {
                    Format.AddToResponse("You don't have enough of that item");
                }
            } 
            else
            {
                Format.AddToResponse("You exit the inventory menu without using an item.");
                Format.DisplayResponse();
                Thread.Sleep(1500);
                return;
            }


            Format.AddToResponse("Enter to continue");
            Format.DisplayResponse();
            Console.ReadLine();
        }


        /// <summary>
        /// builds the combat HUD, displaying player and enemy information
        /// </summary>
        static void BuildHUD()
        {
            // Combat UI v

            string border = new string('-', 20);




            Console.ForegroundColor = ConsoleColor.White;

            string[] enemyNamesToDisplay = new string[0];
            string[] enemyHealthToDisplay = new string[0];

            for (int i = 0; i < onfield.Length; i++) // loop through enemies
            {
                if (onfield[i].health > 0) //if enemy is alive
                {
                    Array.Resize(ref enemyNamesToDisplay, enemyNamesToDisplay.Length + 1);
                    enemyNamesToDisplay[enemyNamesToDisplay.Length - 1] = (i + 1) + ". " + onfield[i].name; // add enemy name to array

                    Array.Resize(ref enemyHealthToDisplay, enemyHealthToDisplay.Length + 1);
                    enemyHealthToDisplay[enemyHealthToDisplay.Length - 1] = $" /red {onfield[i].health}HP"; // add enemy health to array
                } 
            }


            Format.AddToResponse(border);
            Format.AddToResponse("/red ENEMIES", 1);
            Format.AddToResponse(String.Join("\t\t\t", enemyNamesToDisplay), 1);
            Format.AddToResponse(String.Join("\t\t\t", enemyHealthToDisplay));

            Format.AddToResponse("/green YOU", 4);
            Format.AddToResponse($"HP: /green {health}\t\t /reset STM: /blue {stamina}", 1);
            Format.AddToResponse("1. Attack\t\t2. Items\t\t3. Guard (Take no damage for 1 turn, req. 20 STM)\n\n", 1, 2);
            Format.AddToResponse(border);

        }



        /// <summary>
        /// performs the player's action based on input, allowing for attacks, item usage, or guarding.
        /// </summary>
        static bool PerformAction()
        {


            Player.GetInt();

            if (Player.input == 1)    // if Attack chosen
            {
                Random rand = new Random();
                BuildHUD();
                Format.AddToResponse("Select an attack");
                Format.AddToResponse($"/blue 1. Light Attack ({lightAttack.power} DMG, req. {lightAttack.stamina} STM, 1 TURN)\t\t /red 2. Heavy Attack ({heavyAttack.power} DMG, /reset req {heavyAttack.stamina} STM, 2 TURNs)\t\t /yellow 3. Hail Mary (Do I feel lucky?) req. (1 TURN)");
                Format.DisplayResponse(false);

                Player.GetInt();
                int attackChoice = Player.input; // store attack choice
                Console.Clear();

                
                int damageDealt = 0;    // variable to store damage dealt by the attack
                int staminaDrained = 0; // variable to store stamina drained by the attack
                int targetChoice = 0;


                if (attackChoice == 1 || attackChoice == 2)    // if Attack chosen
                {
                    BuildHUD();
                    Format.AddToResponse("Select a target:", 2, 2);
                    Format.DisplayResponse(false, false);

                    Player.GetInt(onfield.Length);
                    targetChoice = Player.input; // store target choice



                    switch (attackChoice)
                    {
                        case 1: // Light Attack
                            if (stamina >= lightAttack.stamina)
                            {
                                damageDealt = lightAttack.power;
                                staminaDrained = lightAttack.stamina;
                            }
                            else
                            {
                                Format.AddToResponse("Not enough Stamina");
                            }
                            break;
                        case 2: // Heavy Attack
                            if (stamina >= heavyAttack.stamina)
                            {
                                damageDealt = heavyAttack.power;
                                staminaDrained = heavyAttack.stamina;
                            }
                            else
                            {
                                Format.AddToResponse("Not enough Stamina");
                            }
                            break;
                    }


                }
                

                else if (attackChoice == 3)   // if Hail Mary chosen
                {
                    Console.Clear();

                    int roll1 = rand.Next(1, 10), roll2 = rand.Next(1, 10), roll3 = rand.Next(1, 10);

                    Format.AddToResponse(roll1.ToString());
                    Format.DisplayResponse(true);
                    Thread.Sleep(500);

                    Format.AddToResponse(roll2.ToString());
                    Format.DisplayResponse(true);
                    Thread.Sleep(500);

                    Format.AddToResponse(roll3.ToString());
                    Format.DisplayResponse(true);
                    Thread.Sleep(500);


                    if (roll1 == roll2 && roll1 == roll3)
                    {
                        damageDealt = 100;
                        Format.AddToResponse(" /green Today is your lucky day");
                    }
                    else
                    {
                        Format.AddToResponse("Alas, nothing happened");
                    }

                    turns++; // increment turns to allow enemies to attack next turn

                }

                if (damageDealt > 0) // possibly add contingency for multiple attacked enemies and simplify code further.
                {
                    bool targetDefeated = false; 

                    if (onfield.Length > targetChoice - 1 && targetChoice > 0 && attackChoice != 3) // check if enemy exists   ---- POTENTIAL ISSUE WITH PLAYER INPUT MAX ARRAY REF ************
                    {
                        onfield[targetChoice - 1].health = onfield[targetChoice - 1].health - damageDealt;
                        stamina -= staminaDrained; // drain stamina based on attack choice
                        if (onfield[targetChoice-1].health < 0) // if enemy health is below 0, set to 0
                        {
                            onfield[targetChoice - 1].health = 0;
                            targetDefeated = true;
                        }
                        Format.AddToResponse($" /blue You attack {onfield[targetChoice - 1]} for {damageDealt} damage! It has {onfield[targetChoice - 1].health} HP left.");
                        if (targetDefeated)
                        {
                            Format.AddToResponse($" /green {onfield[targetChoice - 1]} has been defeated!");
                        }

                        turns++; // increment turns to allow enemies to attack next turn
                    }
                    else if (attackChoice == 3)
                    {
                        for (int i = 0; i < onfield.Length; i++)
                        {
                            onfield[i].health = onfield[i].health - damageDealt; // set all enemies to 0 health
                            if (onfield[i].health < 0) // if enemy health is below 0, set to 0
                            {
                                onfield[i].health = 0;
                                targetDefeated = true;
                            }
                            Format.AddToResponse($"You attack {onfield[i]} for {damageDealt} damage! It has {onfield[i].health} HP left.");
                            if (targetDefeated)
                            {
                                Format.AddToResponse($"{onfield[targetChoice - 1]} has been defeated!");
                            }
                        }
                    } else
                    {
                        Format.AddToResponse($"You chose {targetChoice}. This target doesn't exist on the field");
                    }
                }

                Format.DisplayResponse();
                Thread.Sleep(2000);

                bool allDefeated = true; // variable to check if all enemies are defeated
                for (int i = 0; i < onfield.Length; i++)
                {
                    if (onfield[i].health > 0) // if any enemy is alive
                    {
                        allDefeated = false;
                        break;
                    }
                }
                if (allDefeated) // if all enemies are defeated
                {
                    Format.AddToResponse("You have defeated all enemies!");
                    Format.DisplayResponse();
                    Thread.Sleep(5000);
                    return false; // combat ends if all enemies are defeated
                    
                }
            }



            // non-combative actions
            else if (Player.input == 2)  // if Items chosen
            {
                ShowInventory();
            }

            else if (Player.input == 3)  // if Guard chosen
            {
                if (stamina >= 20)
                {
                    stamina = stamina - guardStamina;
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Thread.Sleep(100);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Format.AddToResponse("You put up your guard");
                    Format.DisplayResponse();
                    Thread.Sleep(1500);
                    turns++; // increment turns to allow enemies to attack next turn
                    guarding = true;
                }
                else
                {
                    Format.AddToResponse("Not enough Stamina");
                    Format.DisplayResponse();
                    Thread.Sleep(1500);
                }
            }

            return true; // combat continues if not all enemies are defeated

        }


        static bool EnemyAction()
        {

            for (int i = 0; i < onfield.Length; i++)
            {

                Random rand = new Random();

                int enemyAction = rand.Next(1, 4); // random enemy action between 1 and 3

                if (enemyAction > 1)
                {
                    // enemy idle
                    Console.Clear();
                    Format.AddToResponse($" /red {onfield[i].name} /reset {enemyIdles[rand.Next(enemyIdles.Length)]}");
                } 
                else
                {
                    // attacked method:
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Thread.Sleep(100);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();

                    int damageDealt = rand.Next(5, 21);

                    Format.AddToResponse($"{onfield[i].name} attacks for {damageDealt} damage!");

                    if (guarding)
                    {
                        Thread.Sleep(500);
                        Format.AddToResponse("But since you are guarding, you take /blue 0 /reset damage!");
                    }
                    else
                    {
                        health -= damageDealt;
                    }
                }

                Format.DisplayResponse();
                Thread.Sleep(2500);


                if (health <= 0)
                {
                    Format.AddToResponse($"You died!");
                    Format.DisplayResponse();
                    Thread.Sleep(5000);
                    Console.Clear();
                    return false; // combat ends if player dies
                }
            }

            if (!heavy)
            {
                turns++; // increment turns to allow player to attack next turn
            }

            guarding = false; // resets guard after turn
            heavy = false; // resets heavy attack after turn

            return true; // combat continues if player is alive

        }

    }
}
