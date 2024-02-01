using System;
using System.Collections.Generic;

class TaskManager
{
    static List<string> tasks = new List<string>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Task Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Edit Task");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine("4. View Tasks");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    EditTask();
                    break;
                case "3":
                    RemoveTask();
                    break;
                case "4":
                    ViewTasks();
                    break;
                case "5":
                    Console.WriteLine("Exiting Task Manager. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AddTask()
    {
        Console.Write("Enter the task: ");
        string newTask = Console.ReadLine();

        if (!string.IsNullOrEmpty(newTask))
        {
            tasks.Add(newTask);
            Console.WriteLine("Task added successfully!");
        }
        else
        {
            Console.WriteLine("Task cannot be empty. Please enter a valid task.");
        }
    }

    static void EditTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks to edit. Add tasks first.");
            return;
        }

        ViewTasks();

        Console.Write("Enter the index of the task to edit: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < tasks.Count)
        {
            Console.Write("Enter the updated task: ");
            string updatedTask = Console.ReadLine();

            if (!string.IsNullOrEmpty(updatedTask))
            {
                                tasks[index] = updatedTask;
                Console.WriteLine("Task updated successfully!");
            }
            else
            {
                Console.WriteLine("Updated task cannot be empty. Please enter a valid task.");
            }
        }
        else
        {
            Console.WriteLine("Invalid index. Please enter a valid index within the range of tasks.");
        }
    }

    static void RemoveTask()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks to remove. Add tasks first.");
            return;
        }

        ViewTasks();

        Console.Write("Enter the index of the task to remove: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < tasks.Count)
        {
            string removedTask = tasks[index];
            tasks.RemoveAt(index);
            Console.WriteLine($"Task '{removedTask}' removed successfully!");
        }
        else
        {
            Console.WriteLine("Invalid index. Please enter a valid index within the range of tasks.");
        }
    }

    static void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
        }
        else
        {
            Console.WriteLine("Tasks:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i}. {tasks[i]}");
            }
        }
    }
}

