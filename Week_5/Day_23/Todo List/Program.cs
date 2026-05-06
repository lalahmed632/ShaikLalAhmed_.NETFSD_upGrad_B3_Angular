using System;
using System.Collections.Generic;

namespace ToDoList
{
    class MyClass
    {
        static void Main(string[] args)
        {
            List<string> tasks = new List<string>();
            int choice = 0;

            while (choice != 4)
            {
                Console.WriteLine("\nTo-Do List Manager");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View Tasks");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. Exit");

                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Invalid choice, Enter betwwen 1–4.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter task: ");
                        string task = Console.ReadLine();

                        if (string.IsNullOrEmpty(task))
                        {
                            Console.WriteLine("Task cannot be empty.");
                        }
                        else
                        {
                            tasks.Add(task);
                            Console.WriteLine("Task added!");
                        }
                        break;

                    case 2:
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks available.");
                        }
                        else
                        {
                            Console.WriteLine("Tasks:");
                            for (int i = 0; i < tasks.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {tasks[i]}");
                            }
                        }
                        break;

                    case 3:
                        if (tasks.Count == 0)
                        {
                            Console.WriteLine("No tasks to remove.");
                            break;
                        }

                        Console.WriteLine("Tasks:");
                        for (int i = 0; i < tasks.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {tasks[i]}");
                        }

                        Console.Write("Enter task number: ");

                        if (int.TryParse(Console.ReadLine(), out int index) &&
                            index >= 1 && index <= tasks.Count)
                        {
                            Console.WriteLine("Removed: " + tasks[index - 1]);
                            tasks.RemoveAt(index - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid task number.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Exiting...");
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}