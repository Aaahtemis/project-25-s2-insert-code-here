//comment from main

using System;
using System.IO;
using System.Numerics;
using System.Threading;
using CombatSystem;

namespace TeamCSFile
{
    internal class Program
    {

        // The inventory amount holds how much of an item you have, the inventory name holds the name of the item.
        public static int[] InventoryAmount = { 0, 0, 0, 0 };

        public static string[] InventoryName = { "Baseball Cap", "Bluetooth Speaker", "Remote Control Car", "Yard Chair" }; //Maybe put these inside the inventory method


        //Random added
        public static Random rand = new Random();


        public static int Room = 0; // < lets combat method know which room the player is in and thus which set of enemies to pull from
        //------------------------------

        static void Main()
        { // Intro :

            

            introAnim();
            
            Console.WriteLine("Your goal is to get an item from all four rooms/sections. \nEach room has different obstacles. \nFind all four items and make it to checkout to finish shopping" +
                $" GOOD LUCK. \nYou need to find a {InventoryName[0]}, a {InventoryName[1]}, a {InventoryName[2]} and a {InventoryName[3]}");
            Console.WriteLine("Press Enter to proceed");
            Console.ReadLine();
            MainMenu.TheMainMenu();
        }

        public static void introAnim()//takes intro anim as it is atm and and makes it more efficient
        {
            Console.WriteLine("Please expand the console window.\n" +
                "Press enter to continue");
            Console.ReadLine();

            string aline;
            
            Console.Clear();
            StreamReader sr = new StreamReader($@"Kmart-logo.txt");
            while (!sr.EndOfStream)
            {
                aline = sr.ReadLine();
                Console.WriteLine(aline);
                Thread.Sleep(50);
            }
            sr.Close();
            
        }
        

            

            
            //public static string RoomSelection()
            //{
            //    int num = 0;
            //    bool inMenu = true;

            //    do
            //    {
            //        Console.Clear();

            //        Console.WriteLine("Main Menu\n" + "Please select from the numbers below\n");
            //        Console.WriteLine("1  Clothing\n" +
            //                          "2  Electronics\n" +
            //                          "3  Toys\n" +
            //                          "4  Camping\n" +
            //                          "0  Back to the menu");

            //        try
            //        {
            //            num = Convert.ToInt32(Console.ReadLine());
            //        }
            //        catch (Exception)
            //        {
            //            Console.WriteLine("Huh");
            //            Console.ReadLine();
            //        }

            //        switch (num)
            //        {
            //            case 1:
            //                Room = 1;
            //                Clothing();
            //                Console.WriteLine("This is Clothing\n" + "Press 0 to exit");
            //                return "Clothing";

            //            case 2:
            //                Room = 2;
            //                Electronics();
            //                Console.WriteLine("This is Electronics\n" + "Press 0 to exit");
            //                return "Electronics";

            //            case 3:
            //                Room = 3;
            //                Toys();
            //                Console.WriteLine("This is Toys\n" + "Press 0 to exit");
            //                return "Toys";

            //            case 4:
            //                Room = 4;
            //                Camping();
            //                Console.WriteLine("This is Camping\n" + "Press 0 to exit");
            //                return "Camping";

            //            case 0:

            //                inMenu = false;
            //                return "Exiting";
            //            default:
            //                Console.WriteLine("Invalid Input. Please keep it between 0-4");
            //                Console.ReadLine();
            //                return "Invalid";

            //        }

            //    } while (inMenu);


            //}

        

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


        public static void Clothing()
        {
            Console.Clear();
            Console.WriteLine($"You enter the Clothing section in order to find the {InventoryName[0]}.");
            Console.WriteLine("Enter to continue.");
            Console.ReadLine();
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine($@"you look around to see racks of clothing all around you, maybe what you're searching for is in one of these racks.
You also see that you can continue forward between these racks, but it looks like the prime spot for you to get jumped.
Do you:
1: Search the clothing racks in hopes of finding a {InventoryName[0]}.
2: Continue forward, knowing you are most likely to get jumped.
3: Leave.");

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
                        temp = rand.Next(5);
                        if (temp == 4)
                        {
                            Console.WriteLine($"And found a {InventoryName[0]}!");
                            InventoryAmount[0]++;
                            Console.WriteLine("Enter to continue.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("And found nothing, Perhaps look closer?");
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
            
            Console.WriteLine($@"After the battle and passing between the aisle you notice a pedestal ahead. 
On it is a {InventoryName[0]}, just sitting there. It almost seems as though it is waiting for you specifically. 
However upon closer inspection it becomes clear some fool has placed it inside a glass container.");
            bool running = true;
            while (running)
            {
                Console.WriteLine(@"It looks like there is a dial on the pedestal that unlocks the glass container. Or maybe you just break the glass.
Do you:
1: Break the glass.
2: Try the dial.
3: Leave.");
                
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
                        temp = rand.Next(10);
                        if (temp == 8)
                        {
                            Console.WriteLine($"And succeed!");
                            Console.WriteLine($"You got a {InventoryName[0]}!");
                            InventoryAmount[0]++;
                            Console.ReadLine();
                        }
                        if (temp == 3)
                        {
                            Console.WriteLine("And hurt your hand, turns out glass is hard.");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("And failed.");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.WriteLine(@"You take a closer look at the dial. It is a four combination lock with 0-9 on each. Entering every option might take a while.
You notice a crumpled post-it note on the floor with what looks like it could be the code.");
                        Thread.Sleep(50);
                        Console.WriteLine(@"upon entering the code the case springs open so violently you barely get out of the way.
amongst the dramitic fog now leaking from it's sundered form you spot the very item you came for");
                        Console.WriteLine($"You got a {InventoryName[0]}!");
                        InventoryAmount[0]++;
                        Console.WriteLine($"But so caught up in collecting the {InventoryName[0]}, you fail to spot the enemy behind you.");
                        Console.ReadLine();
                        Combat.Start(Room);
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

        public static void Camping()
        {
            bool inCampingRoom = true, gambleWin = false; // Loop control variables
            int spinCount = 0, spin1, spin2, spin3; // Variables for controlling the gambling game

            Console.Clear();
            Console.WriteLine("\nYou head off in the direction of the store's Camping department in search of a foldable Yard Chair.");
            Thread.Sleep(2000);
            Console.WriteLine("\nAs you approach the outer aisles of the department you feel an inexplicable chill run over your body. Something isn't right, but you aren't sure what.");
            Thread.Sleep(2000);

            while (inCampingRoom)
            {
                Console.WriteLine("\n\nWhat do you do next?\n\n1. Proceed forward into the tents aisle\n2. Go around and enter via the fishing aisle\n3. Turn around and leave");
                int campingDecision1 = GetValidInput(1, 3);
                Console.Clear();
                Thread.Sleep(2000);
                switch (campingDecision1)
                {
                    case 1:
                        Console.WriteLine("\nAs you walk through the aisle the lights suddenly blow, one by one. Now enshrouded by darkness, you can faintly see what looks like a headtorch hanging on one of the racks.");
                        Thread.Sleep(2000);
                        Console.WriteLine("\n\nDo you choose to reach out for it, or to stumble your way to the prized Yard Chair in the dark?");
                        Thread.Sleep(2000);
                        Console.Write("\n1. Attempt to grab the torch\n2. Continue without it\n");
                        int campingDecision2 = GetValidInput(1, 2);
                        switch (campingDecision2)
                        {
                            case 1:
                                Console.Clear();
                                Console.Write("\nYou take the torch and place it on your head. However, its light illuminates an enemy!");
                                Thread.Sleep(2000);
                                Combat.Start(Room);
                                break;
                            case 2:
                                Console.Clear();
                                Console.Write("\nYou choose to continue without the torch. Unfortunately, you overestimated how many carrots you eat and are hit by a sneak attack!");
                                Thread.Sleep(2000);
                                Combat.Start(Room);
                                break;
                            default:
                                break;
                        }
                        Console.Clear();
                        Thread.Sleep(2000);
                        break;

                    case 2:
                        Console.WriteLine("\nAs you walk through the aisle you notice that the floor is wet, perhaps a cleaner left their job unfinished.");
                        Thread.Sleep(2000);
                        Console.WriteLine("\n..but upon looking down, you realise that you are somehow standing in the middle of a river flowing straight through the aisle?");
                        Thread.Sleep(2000);
                        Console.WriteLine("\n\nBefore you can react to this bizarre situation, a figure leaps toward you out of the water!");
                        Thread.Sleep(2000);
                        Combat.Start(Room);
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("\nYou turned back and made a tactical retreat to the entrance.");
                        Thread.Sleep(2000);
                        inCampingRoom = false;
                        return;

                    default:
                        break;
                }
                Console.Clear();
                Console.WriteLine("\nYou have arrived at your destination. You see a lone Yard Chair propped up against a shelf at the mouth of the unexplainable river that is now flowing through the store.");
                Thread.Sleep(2000);
                Console.WriteLine("\n..but before you can get to it, a group of beavers jump out of the water and set a new record for dam construction speedrunning and block your path.");
                Thread.Sleep(2000);
                Console.WriteLine("\nUpon closer inspection, you notice there is a slot machine built into the dam, with a sign saying that you will gain entry if you hit the jackpot.");
                Thread.Sleep(2000);
                Console.WriteLine("\nIt seems you have no choice but to gamble if you want the chair...");
                Thread.Sleep(2000);
                Console.Clear();

                while (!gambleWin)
                {
                    if (spinCount >= 15) // Allows the user to progress gambling feature at 15 attempts
                    {
                        spin1 = 7;
                        spin2 = 7;
                        spin3 = 7;
                    }
                    else
                    {
                        spin1 = rand.Next(1, 8);
                        spin2 = rand.Next(1, 8);
                        spin3 = rand.Next(1, 8);
                    }

                    spinCount++;
                    Console.Write($"\n\n\n\n\t\t\t\t\t\t\t\t\t\t\t\t\t{spin1}");
                    Thread.Sleep(500);
                    Console.Write($" {spin2}");
                    Thread.Sleep(500);
                    Console.Write($" {spin3}");
                    Thread.Sleep(500);

                    if (spin1 == 7 && spin2 == 7 && spin3 == 7)
                    {
                        Console.WriteLine("\n\n\t\t\t\t\t\t\t\t\t\t\t\tToday is your lucky day");
                        Thread.Sleep(2000);
                        Console.WriteLine("\nYou hear a mechanism click as the slot machine moves to reveal a hidden passage through the dam.");
                        Thread.Sleep(2000);
                        Console.WriteLine("\nYou quickly grab the Yard Chair and make a beeline back to the entrance before any more chicanery can occur.");
                        InventoryAmount[3]++; // Adds 1 camping chair to players inventory
                        Thread.Sleep(2000);
                        Console.Clear();
                        gambleWin = true; // moves the user out of the gambling loop
                        inCampingRoom = false; // moves the user out of the camping room loop
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

        static int GetValidInput(int min, int max) // Simple method to manage input validation throughout the game
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

        public static void Toys()
        {

            int one6 = rand.Next(0 , Combat.inventory.Length);
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
                Console.WriteLine($"You find a {Combat.inventory[one6].name} resting in a toy crate and grab it.");
                Combat.inventory[one6].amount++;
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
                Combat.Start(Room);
            }

        }

        public static void Electronics()
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
                int one6 = rand.Next(0, Combat.inventory.Length);
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
                Combat.Start(Room);

                // if you win combat you get the item
                Combat.inventory[one6].amount += 1; // how to fail combat and not get the item
            }

            void Chargers()
            {
                int one6 = rand.Next(0, Combat.inventory.Length);
                Console.WriteLine("You sort through the pile of portable chargers. One claims to charge a fridge. Another has three buttons and no ports.\n");
                Thread.Sleep(2000);

                Console.WriteLine(
                          $"Then — jackpot! Behind a toppled charger display, you spot a {Combat.inventory[one6].name} just sitting there like a free sample.\nYou casually slip it into your inventory before anyone notices.");
                Thread.Sleep(2000);
                Console.WriteLine("You don't see anything else useful in the area.");

                Combat.inventory[one6].amount += 1;
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
                int one6 = rand.Next(0, Combat.inventory.Length);
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
                        Console.WriteLine($"Item acquired! You successfully found what you were looking for.\n And as a bonus you got a {Combat.inventory[one6].name}");
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
                        Combat.Start(Room);

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
        
        public static void CheckProgress()
        {
            Console.Clear();
            for (int i = 0; i < InventoryName.Length; i++)
            {
                
                if (InventoryAmount[i] >= 1)
                {
                    Console.Write($"{InventoryName[i]}:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" COLLECTED\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"{InventoryName[i]}:");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" NOT COLLECTED\n");
                    Console.ResetColor();
                }
            }
            Console.WriteLine("\n\n\nPress any key to return to room selection...");
            Console.ReadKey(true);
        }
    }
}
