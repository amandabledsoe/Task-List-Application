using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_8
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Starter List of Tasks
            List<Task> theTaskList = new List<Task>() { };

            Task task1 = new Task();
            task1.TaskAssignee = "Amanda";
            task1.TaskDescription = "Pass The GC C#.NET Boot Camp!";
            task1.DueDate = DateTime.Parse("06/26/2020");
            task1.Complete = false;

            Task task2 = new Task();
            task2.TaskAssignee = "Marvin";
            task2.TaskDescription = "Kill The Spiders!";
            task2.DueDate = DateTime.Parse("06/10/2020");
            task2.Complete = false;

            theTaskList.Add(task1);
            theTaskList.Add(task2);
            #endregion

            DisplayWelcomeScript();

            bool runningProgram = true;
            while(runningProgram)
            {
                DisplayMainMenu();
                string decision = Console.ReadLine();
                int decisionNum;
                bool confirmedNum = int.TryParse(decision, out decisionNum);
                if (!confirmedNum)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"I'm sorry, \"{decision}\" is not a number. Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    if (decisionNum <= 0 || decisionNum > 6)
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"I'm sorry, your number choice of \"{decision}\" is either too high or too low. Please try again.");
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    else
                    {
                        switch (decisionNum)
                        {
                            case 1:
                                PrintAllTasks(theTaskList);
                                continue;
                            case 2:
                                PrintTaskById(theTaskList, GetTaskNumber());
                                continue;
                            case 3:
                                MarkTaskComplete(theTaskList);
                                continue;
                            case 4:
                                AddNewTask(theTaskList);
                                continue;
                            case 5:
                                RemoveATask(theTaskList, GetTaskNumber());
                                continue;
                            case 6:
                                DisplayExitScript();
                                break;
                        }
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                    }
                }
                runningProgram = true;
            }
        }
        public static void RemoveATask(List<Task> tasks, int index)
        {
            tasks.RemoveAt(index);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your task kas been REMOVED successfully!");
            Thread.Sleep(2000);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You will be redirected to the main menu in 5 seconds.");
            Thread.Sleep(5000);
            Console.Clear();

        }

        public static void AddNewTask(List<Task> tasks)
        {
            Task task = new Task();
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Enter The Task Assignee Name:");
            string assignee = Console.ReadLine();
            Console.WriteLine("Enter the Task Description:");
            string description = Console.ReadLine();
            Console.WriteLine("Enter the Task Due Date:");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            task.TaskAssignee = assignee;
            task.TaskDescription = description;
            task.DueDate = dueDate;
            task.Complete = false;

            tasks.Add(task);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your task kas been ADDED successfully!");
            Thread.Sleep(2000);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("You will be redirected to the main menu in 5 seconds.");
            Thread.Sleep(5000);
            Console.Clear();
        }

        public static int GetTaskNumber()
        {
            Console.Clear();
            bool gettingNumber = true;
            while(gettingNumber)
            {
                Console.WriteLine("");
                Console.WriteLine("Enter the task number you wish to work with:");
                string input = Console.ReadLine();
                int number;
                bool isANum = int.TryParse(input, out number);
                if(isANum)
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("I'm sorry, a number was not detected in your response. Please try again.");
                    gettingNumber = true;
                }
            }
            return -1;
        }

        public static void PrintTaskById(List<Task> tasks, int taskNo)
        {
            //need to work on validation here
            int index = taskNo - 1;
            foreach(Task task in tasks)
            {
                Console.WriteLine("");
                Console.WriteLine("Task Info:");
                Console.WriteLine($"Task No: {taskNo}");
                Console.WriteLine($"Task Assignee: {tasks[index].TaskAssignee}");
                Console.WriteLine($"Task Description: {tasks[index].TaskDescription}");
                Console.WriteLine($"Task Due Date: {tasks[index].DueDate.ToShortDateString()}");
                Console.WriteLine($"Task Status: {tasks[index].Complete}");
                Thread.Sleep(5000);
                Console.Clear();
                break;
            }
        }

        public static Task GetTaskByIndex(List<Task> tasks, int index)
        {
            Task task = new Task();
            for (int i = index; i < tasks.Count;)
            {
                tasks[i] = task;
            }
            return task;
        }

        public static void MarkTaskComplete(List<Task> tasks)
        {
            bool markingComplete = true;
            while(markingComplete)
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Enter The Task No. You Wish To Update:");
                string completeTask = Console.ReadLine();
                int taskNo;
                bool isANum = int.TryParse(completeTask, out taskNo);
                if(!isANum)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"I'm sorry, your number choice of \"{completeTask}\" could not be located. Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Thread.Sleep(1000);
                    Console.Clear();
                    markingComplete = true;
                }
                else
                {
                    for (int i = taskNo-1; i < tasks.Count;)
                    {
                        if(tasks[i].Complete == true)
                        {
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Oopsie:");
                            Console.WriteLine("This task has already been marked complete");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("");
                            markingComplete = true;
                        }
                        else
                        {
                            bool newStatus = true;
                            tasks[i].Complete = newStatus;
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Success!");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Your task, No. {0} to \"{1}\" has been marked {2} for completion status.", $"{taskNo}", $"{tasks[i].TaskDescription}", $"{tasks[i].Complete}");
                            Thread.Sleep(2000);
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("You will be redirected to the main menu in 2 seconds.");
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;
                        }
                        markingComplete = false;
                    }
                    markingComplete = false;
                }
                markingComplete = false;
            }
        }

        public static void DisplayWelcomeScript()
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to the Task List Application!");
            Thread.Sleep(1500);
            Console.Clear();
        }

        public static void DisplayExitScript()
        {
            Console.WriteLine("");
            Console.WriteLine("You are now exiting the Task List Application.");
            Console.WriteLine("Thank you, and have a great day!");
            Console.WriteLine("");
        }

        public static void DisplayMainMenu()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("========================================");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("             MAIN MENU                  ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("========================================");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            string[] menuOptions = new string[6] { "List All Tasks", "Print A Single Task", "Mark A Task Complete", "Add A New Task", "Delete A Task", "Exit The Program" };
            for (int i = menuOptions.GetLowerBound(0); i <= menuOptions.GetUpperBound(0); i++)
            {
                Console.WriteLine("      Option {0}: {1}", i+1, menuOptions[i]);
            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("");
            Console.WriteLine("========================================");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("What option would you like to proceed with?");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintAllTasks(List<Task> tasks)
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Printing All Tasks...");
            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("============================================================================================");
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("{0, -7} {1, -23} {2, -28} {3, -15} {4}", "NO.", "ASSIGNEE","DESCRIPTION","DUE DATE","COMPLETE STATUS");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("============================================================================================");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Task task in tasks)
            {
                Console.WriteLine("{0,-7} {1,-15} {2,-35} {3, -20} {4}", $"{tasks.IndexOf(task) + 1}", $"{task.TaskAssignee}", $"{task.TaskDescription}", $"{task.DueDate.ToShortDateString()}", $"{task.Complete} ");
            }
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Printing Complete!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(2000);
            Console.WriteLine("");
            Console.WriteLine("You will be redirected to the main menu in 5 seconds.");
            Thread.Sleep(5000);
            Console.Clear();
        }
    }
}
