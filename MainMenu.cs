using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCSFile
{
    class MainMenu
    {


        public static void TheMainMenu()
        {

            int userInput;

            string[] theK = new string[]
                                            {
                                                "_  __",
                                                "| |/ /",
                                                "| ' / ",
                                                "| . \\ ",
                                                "|_|\\_\\",
                                            };


            do
            {


                Console.Clear();
                Console.WriteLine(theK);
                Console.Write("-mart Game");
                Console.WriteLine("Main Menu\n" + "Please select from the numbers below\n");
                Console.WriteLine("1  Rest\n" +
                                  "2  Room Selection\n" +
                                  "3  Check Your inventory\n" +
                                  "4  Go to Checkout\n" +
                                  "0  Exit The Menu");

                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        //Rest
                        Rest();
                        break;

                    case 2:
                        //Room Selection
                        Program.RoomSelection();
                        break;
                    case 3:
                        // Check your inventory
                        Inventory();
                        break;
                    case 4:
                        // Go to Checkout
                        Checkout();
                        break;
                    case 0:
                        //Exit Function
                        Exit();
                        break;


                    default:
                        Console.WriteLine("Invalid Input. Please keep it between 0-4");
                        break;

                }

            }
            while (userInput != 0);
        }


        public static void Rest()
        {

            string[] chair = new string[]
{
    ".-===-.",
    "| . . |",
    "| .'. |",
    "() _____()",
    "||_____||",
    "W     W"
};

            Console.Clear();

            foreach (string line in chair)
            {
                Console.WriteLine(line);
            }


            Console.Write("You sit down at a chair and rest for a while");

            Thread.Sleep(1000);
            Program.Health = 100;
            Program.Stamina = 100;
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(10 + i, 1);
                Console.Write("z ");
                Thread.Sleep(500);

            }

            Console.SetCursorPosition(10, 25);
            Console.WriteLine($"\nYour Health: {Program.Health} and Stamina: {Program.Stamina} - is restored");
            Thread.Sleep(5000);


        }


        public static void Exit()
        {
            char playerInput;

            Console.WriteLine("Would you like to exit the programing?");
            Console.WriteLine("Press Y - to exit");
            Console.WriteLine("Press N - to cancel");

            playerInput = Convert.ToChar(Console.ReadLine());

            if (playerInput == 'y')
            {
                TheMainMenu();
            }
            else if (playerInput == 'n')
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid Input - Please make sure you enter either Y or N");
                Thread.Sleep(3000);
                Console.Clear();
                Exit();
            }


        }

        public static void Inventory()
        {
            Console.Clear();

            for (int i = 0; i < Program.InventoryAmount.Length; i++)
            {
                Console.WriteLine($"You have {Program.InventoryAmount[i]} {Program.InventoryName[i]}s.");
            }
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();

        }


        public static bool Checkout()
        {
            Console.Clear();
            if (Program.InventoryAmount[0] > 0 && Program.InventoryAmount[1] > 0 && Program.InventoryAmount[2] > 0 && Program.InventoryAmount[3] > 0)
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
        



