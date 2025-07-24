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


            do
            {


                Console.Clear();
                Console.WriteLine("K-mart Game");
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

                    case 3:
                    // Check your inventory

                    case 4:
                    // Go to Checkout

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






    }

}









    //static void Hub()
    //{

//    // move rooms - to which room new method
//    // rest? 
//    // place to check inventory 
//    // show  list of rooms completed
//    // cross off shopping list
//    // 

//    int num = 10;
//    bool inMenu = true;

//    do
//    {
//        Console.Clear();

//        Console.WriteLine("Main Menu\n" + "Please select from the numbers below\n");
//        Console.WriteLine("1  Rest\n" +
//                          "2  Room Selection\n" +
//                          "3  Check Your inventory\n" +
//                          "4  Go to Checkout\n" +
//                          "0  Exit The Menu");

//        try
//        {
//            num = Convert.ToInt32(Console.ReadLine());
//        }
//        catch (Exception)
//        {
//            Console.WriteLine("Huh");
//            Console.ReadLine();
//        }

//        Console.Clear();

//        switch (num)
//        {
//            case 1:
//                Rest();
//                break;

//            case 2:
//                RoomSelection();
//                break;

//            case 3:
//                Inventory();
//                break;

//            case 4:
//                inMenu = Checkout();
//                break;

//            case 0:
//                Exit();
//                inMenu = false;
//                break;
//            default:
//                Console.WriteLine("Invalid Input. Please keep it between 0-4");
//                Console.ReadLine();
//                break;
//        }


//    } while (inMenu);

//    void Rest()
//    {
//        Console.Write("You sit down at a chair and rest for a while");
//        Thread.Sleep(1000);
//        Health = 100;
//        Stamina = 100;
//        for (int i = 0; i < 10; i++)
//        {
//            Console.Write(".");
//            Thread.Sleep(500);

//        }
//        Console.WriteLine($"\nYour Health: {Health} and Stamina: {Stamina} are restored");
//        Thread.Sleep(1000);
//        Exit();

//    }

//    static void Exit()
//    {
//        Console.WriteLine("\nPlease press any key to exit");
//        Console.ReadLine();
//    }
//    string RoomSelection()
//    {
//        int num = 0;
//        bool inMenu = true;

//        do
//        {
//            Console.Clear();

//            Console.WriteLine("Main Menu\n" + "Please select from the numbers below\n");
//            Console.WriteLine("1  Clothing\n" +
//                              "2  Electronics\n" +
//                              "3  Toys\n" +
//                              "4  Camping\n" +
//                              "0  Back to the menu");

//            try
//            {
//                num = Convert.ToInt32(Console.ReadLine());
//            }
//            catch (Exception)
//            {
//                Console.WriteLine("Huh");
//                Console.ReadLine();
//            }

//            switch (num)
//            {
//                case 1:
//                    Room = 1;
//                    Clothing();
//                    Console.WriteLine("This is Clothing\n" + "Press 0 to exit");
//                    return "Clothing";

//                case 2:
//                    Room = 2;
//                    Electronics();
//                    Console.WriteLine("This is Electronics\n" + "Press 0 to exit");
//                    return "Electronics";

//                case 3:
//                    Room = 3;
//                    Toys();
//                    Console.WriteLine("This is Toys\n" + "Press 0 to exit");
//                    return "Toys";

//                case 4:
//                    Room = 4;
//                    Camping();
//                    Console.WriteLine("This is Camping\n" + "Press 0 to exit");
//                    return "Camping";

//                case 0:

//                    inMenu = false;
//                    return "Exiting";
//                default:
//                    Console.WriteLine("Invalid Input. Please keep it between 0-4");
//                    Console.ReadLine();
//                    return "Invalid";

//            }

//        } while (inMenu);


//    }

//}

//static void Inventory()
//{
//    Console.Clear();
//    for (int i = 0; i < InventoryAmount.Length; i++)
//    {
//        Console.WriteLine($"You have {InventoryAmount[i]} {InventoryName[i]}s.");
//    }
//    Console.WriteLine("Press enter to continue.");
//    Console.ReadLine();

//}



