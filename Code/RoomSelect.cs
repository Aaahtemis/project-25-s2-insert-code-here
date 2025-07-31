using System;
using System.IO;
using System.Numerics;
using System.Threading;



namespace TeamCSFile
{
    class RoomSelector
    {
        public static StreamReader sr = new StreamReader($@"room-selector-interface.txt");
        public static string RoomSelection()
            {
                int inputNum = 0;
                bool inMenu = true;
            string aline;
                do
                {
                    Console.Clear();

                Console.WriteLine("Main Menu\n" + "Please select from the numbers below\n");
                while (!sr.EndOfStream)//prints the new menu
                {
                    aline = sr.ReadLine();
                    Console.WriteLine(aline);
                }
                sr.Close();


                //input validation
                    try
                    {
                        inputNum = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Huh");
                        Console.ReadLine();
                    }

                //selection cases
                    switch (inputNum)
                    {
                        case 1:
                            selectAnims(inputNum);
                            Program.Room = 1;
                            Program.Clothing();
                            Console.WriteLine("This is Clothing\n" + "Press 0 to exit");
                            return "Clothing";

                        case 2:
                        selectAnims(inputNum);
                        Program.Room = 2;
                        Program.Electronics();
                            Console.WriteLine("This is Electronics\n" + "Press 0 to exit");
                            return "Electronics";

                        case 3:
                        selectAnims(inputNum);
                        Program.Room = 3;
                        Program.Toys();
                            Console.WriteLine("This is Toys\n" + "Press 0 to exit");
                            return "Toys";

                        case 4:
                        selectAnims(inputNum);
                        Program.Room = 4;
                        Program.Camping();
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
        public static void selectAnims(int i) //makes the selected option go white to make selection a little clearer - is a little slow atm, might tweak
        {
            sr = new StreamReader($@"selction highlight\select-{i}.txt");
            Console.Clear();
            string aline;
            while (!sr.EndOfStream)
            {
                aline = sr.ReadLine();
                Console.WriteLine(aline);
            }
            sr.Close();
            Thread.Sleep(100);

        }
        }
    

}
