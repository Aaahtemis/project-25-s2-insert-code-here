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
                int num = 0;
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
                            selectAnims(num);
                            Program.Room = 1;
                            Program.Clothing();
                            Console.WriteLine("This is Clothing\n" + "Press 0 to exit");
                            return "Clothing";

                        case 2:
                            Program.Room = 2;
                        Program.Electronics();
                            Console.WriteLine("This is Electronics\n" + "Press 0 to exit");
                            return "Electronics";

                        case 3:
                        Program.Room = 3;
                        Program.Toys();
                            Console.WriteLine("This is Toys\n" + "Press 0 to exit");
                            return "Toys";

                        case 4:
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
        public static void selectAnims(int i)
        {
            sr = new StreamReader($@"selction highlight\select-{i}.txt");
            Console.Clear();
            string aline;
            while (!sr.EndOfStream)//prints the new menu
            {
                aline = sr.ReadLine();
                Console.WriteLine(aline);
            }
            sr.Close();
            Thread.Sleep(100);

        }
        }
    

}
