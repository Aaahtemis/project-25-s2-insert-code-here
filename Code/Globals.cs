using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombatSystem;


public static class Global
{

    public static void DisplayTextCentre(string[] textArray)
    {
        if (textArray.Length != 0)
        {
            for (int i = 0; i < textArray.Length; i++)
            {
                Console.SetCursorPosition(WindowCentre().x - textArray[i].Length / 2, WindowCentre().y + (i - textArray.Length / 2));
                Console.WriteLine(textArray[i]);
            }
        }
    }

    public static (int x, int y) WindowCentre()
    {
        int xWindowCentre = Console.WindowWidth / 2;
        int yWindowCentre = Console.WindowHeight / 2;
        return (xWindowCentre, yWindowCentre);
    }


}

