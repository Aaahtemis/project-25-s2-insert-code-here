using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCSFile
{
    internal class MMInventory
    {

        public static (int amountOf, string item)[] mmInventoryItems = { (0, "Baseball Cap"), (0, "BlueTooth Speaker"), (0, "Remote Control Car"), (0, "Yard Chair") };
        

        public static void theInventory()
        {
            string[] theK = new string[]
                                            {
                                                " _  __",
                                                "| |/ /",
                                                "| ' / ",
                                                "| . \\ ",
                                                "|_|\\_\\",
                                            };

            bool inInventory = true;

            do
            {

                Console.Clear();
                foreach (string line in theK)
                {
                    Console.WriteLine(line);
                }
                Console.SetCursorPosition(7, 4);
                Console.WriteLine("-mart Game");
                Console.WriteLine();
                Console.WriteLine("-----------------");
                Console.WriteLine("   Inventory");
                Console.WriteLine("-----------------");


                Console.SetCursorPosition(0, 10);

                for (int i = 0; i < mmInventoryItems.Length; i++)
                {
                    if (mmInventoryItems[i].amountOf != 0)
                    {
                        Format.writeSpecial($" /green x{mmInventoryItems[i].amountOf}  ");
                        Console.WriteLine();
                        Format.writeSpecial($" /green {mmInventoryItems[i].item}  ");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                    else
                    {
                        Format.writeSpecial($" /red x{mmInventoryItems[i].amountOf}  ");
                        Console.WriteLine();
                        Format.writeSpecial($" /red {mmInventoryItems[i].item}  ");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ResetColor();
                    }
                }



                Console.WriteLine("--------------------------");
                Console.WriteLine("Press enter to continue.");
                Console.WriteLine("--------------------------");
                Console.ReadLine();
                inInventory = false;




            }
            while (inInventory == true);








        }







    }
}
