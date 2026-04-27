namespace MyProject.Console.Menu;

using System;
using System.Collections.Generic;

public class MenuHandler
{
    private readonly Dictionary<int, (string, Action)> _actions = new();

    public void Register(int key, string title, Action action)
    {
        _actions[key] = (title, action);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n MENU ");

            foreach (var item in _actions)
            {
                Console.WriteLine($"{item.Key}. {item.Value.Item1}");
            }

            Console.WriteLine("0. Exit");

            var input = Console.ReadLine();

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Invalid input");
                continue;
            }

            if (choice == 0)
                break;

            if (_actions.TryGetValue(choice, out var action))
            {
                try
                {
                    action.Item2.Invoke();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}