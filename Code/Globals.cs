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

    public static void DisplayResponse()
    {
        if (response.Length != 0)
        {
            for (int i = 0; i < response.Length; i++)
            {
                Console.SetCursorPosition(WindowCentre().x - response[i].Length / 2, WindowCentre().y + (i - response.Length / 2));
                Console.WriteLine(response[i]);
            }
        }
        response = new string[0];
    }

    public static (int x, int y) WindowCentre()
    {
        int xWindowCentre = Console.WindowWidth / 2;
        int yWindowCentre = Console.WindowHeight / 2;
        return (xWindowCentre, yWindowCentre);
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
            Console.Clear();
            Console.WriteLine(input + "is not a valid input.");
            Console.WriteLine($"Please input a value between {min} and {max}.");
        }
    }

    
}

