using System;
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
        List<TaskItem> tasks = new List<TaskItem>();
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\nTask Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task as Completed");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            string input = Console.ReadLine();
            Console.Clear();

            switch (input)
            {
                case "1":
                    Console.Write("Enter task name: ");
                    string name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name))
                    {
                        int newId = tasks.Count > 0 ? tasks[tasks.Count - 1].Id + 1 : 1;
                        tasks.Add(new TaskItem(newId, name));
                    }
                    break;
                case "2":
                    if (tasks.Count == 0)
                    {
                        Console.WriteLine("No tasks.");
                    }
                    else
                    {
                        foreach (TaskItem task in tasks)
                        {
                            string status = task.IsCompleted ? "[X]" : "[ ]";
                            Console.WriteLine($"{task.Id}. {status} {task.Name}");
                        }
                    }
                    break;
                case "3":
                    Console.Write("Enter task ID to complete: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        TaskItem foundTask = tasks.Find(t => t.Id == id);
                        if (foundTask != null)
                        {
                            foundTask.IsCompleted = true;
                        }
                    }
                    break;
                case "4":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}