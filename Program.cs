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

    static void DisplayMenu()
    {
        Console.WriteLine("Task Manager");
        Console.WriteLine("1. Add Task");
        Console.WriteLine("2. View Tasks");
        Console.WriteLine("3. Mark Task as Completed");
        Console.WriteLine("4. Delete Task");
        Console.WriteLine("5. Exit");
        Console.Write("Select an option: ");
    }
    static void AddTask() 
    {
    }
    static void ViewTasks() 
    {
    }
    static void MarkTaskCompleted() 
    {
    }
    static void DeleteTask() 
    {
    }
    static void SaveTasks() 
    {
    }
    static void LoadTasks() 
    {
    }
}