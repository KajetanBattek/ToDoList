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
    static List<TaskItem> tasks = new List<TaskItem>();
    static string filePath = "tasks.txt";

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
        Console.Write("Enter task name: ");
        string name = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(name))
        {
            int newId = tasks.Count > 0 ? tasks[tasks.Count - 1].Id + 1 : 1;
            tasks.Add(new TaskItem(newId, name));
            Console.WriteLine("Task added successfully.");
            SaveTasks();
        }
        else
        {
            Console.WriteLine("Task name cannot be empty.");
        }
    }

    static void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        foreach (var task in tasks)
        {
            string status = task.IsCompleted ? "[X]" : "[ ]";
            Console.WriteLine($"{task.Id}. {status} {task.Name}");
        }
    }

    static void MarkTaskCompleted()
    {
        ViewTasks();
        if (tasks.Count == 0) return;

        Console.Write("\nEnter task ID to mark as completed: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
                Console.WriteLine("Task marked as completed.");
                SaveTasks();
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    static void DeleteTask()
    {
        ViewTasks();
        if (tasks.Count == 0) return;

        Console.Write("\nEnter task ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
                Console.WriteLine("Task deleted.");
                SaveTasks();
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID format.");
        }
    }

    static void SaveTasks()
    {
        List<string> lines = new List<string>();
        foreach (var task in tasks)
        {
            lines.Add($"{task.Id};{task.Name};{task.IsCompleted}");
        }
        File.WriteAllLines(filePath, lines);
    }

    static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            tasks.Clear();
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 3)
                {
                    int id = int.Parse(parts[0]);
                    string name = parts[1];
                    bool isCompleted = bool.Parse(parts[2]);

                    TaskItem loadedTask = new TaskItem(id, name);
                    loadedTask.IsCompleted = isCompleted;
                    tasks.Add(loadedTask);
                }
            }
        }
    }
}