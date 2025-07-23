using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombatSystem;


public static class Format
{
    public static string[] response = new string[0];

    public static void AddToResponse(string input)
    {
        Array.Resize(ref response, response.Length + 1);
        response[response.Length - 1] = input;
    }

    public static void DisplayResponse(bool isDelayed = false)
    {
        Console.Clear(); // might remove later.

        if (response.Length != 0)
        {
            for (int i = 0; i < response.Length; i++)
            {
                Console.SetCursorPosition(WindowCentre().x - response[i].Length / 2, WindowCentre().y + (i - response.Length / 2));
                writeSpecial(response[i]);
                Console.WriteLine();
                Console.ResetColor();
            }
        }
        if (!isDelayed)
        {
            response = new string[0];
        }
    }



    public static (int x, int y) WindowCentre()
    {
        int xWindowCentre = Console.WindowWidth / 2;
        int yWindowCentre = Console.WindowHeight / 2;
        return (xWindowCentre, yWindowCentre);
    }



    public static void writeSpecial(string input)
    {
        string[] split = input.Split(' ');

        for (int i = 0; i < split.Length; i++)
        {
            if (split[i][0] == '/')
            {
                if (split[i] == "/red")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (split[i] == "/blue")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (split[i] == "/green")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (split[i] == "/yellow")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }


                else if (split[i] == "/reset")
                {
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("!!NullColour!!");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.Write(split[i]);

                if (i != split.Length - 1)
                {
                    Console.Write(" ");
                }

            }
        }
    }



}

public static class Player
{
    public const int maxHealth = 100;
    public static int health = maxHealth;

    public const int maxStamina = 100;
    public static int stamina = maxStamina;




    public static int input = -1;

    public static void GetInt(int max = 3, int min = 1)
    {
        while(!Int32.TryParse(Console.ReadLine(), out input) && input >= min && input <= max)
        {
            Format.AddToResponse(input + "is not a valid input.");
            Format.AddToResponse($"Please input a value between {min} and {max}.");
            Format.DisplayResponse();
        }
    }

    
}

