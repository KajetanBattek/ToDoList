using System;
using System.IO;
using System.Collections.Generic;

public class TaskItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }

    public TaskItem(int id, string name)
    {
        Id = id;
        Name = name;
        IsCompleted = false;
    }
}

class Program
{
    static void Main(string[] args)
    {
        LoadTasks();

        bool isRunning = true;

        while (isRunning)
        {
            DisplayMenu();
            string input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    MarkTaskCompleted();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    SaveTasks();
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (isRunning)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }


    static List<TaskItem> tasks = new List<TaskItem>();
    static string filePath = "tasks.txt";

     
}