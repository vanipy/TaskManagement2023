using System;
using Microsoft.Extensions.Hosting;
using Library.TaskManagement.Models;
using Library.TaskManagement.Services;
using TaskManagement2023;

namespace LibraryTaskManagement 
{
    class Program
    {
        static void Main(string[] args)
        {
            //set up a list of todo items
            var toDoService = new ToDoService();
            //CRUD = CREATE, READ, UPDATE, DELETE
            // Console.WriteLine("Welcome to the Task Management App for 2023!");
            CreateHostBuilder(args).Build().Run();

            while (true)
            {
                var action = PrintMenu();


                if (action == ActionType.Create)
                {
                    Console.WriteLine("You chose to add a task");
                    var newToDo = new Class1();
                    FillToDo(newToDo);

                    toDoService.Create(newToDo);


                }
                else if (action == ActionType.Read)
                {
                    Console.WriteLine("You chose to list all tasks");

                    for (int i = 0; i < toDoService.ToDos.Count; i++)
                    {
                        var toDo = toDoService.ToDos[i];
                        Console.WriteLine($"{i} {toDo}");
                    }

                }
                else if (action == ActionType.Update)
                {
                    Console.WriteLine("You chose to update a task");
                    Console.WriteLine("Which task would you like to update?");
                    var choice = int.Parse(Console.ReadLine() ?? "0");

                    var todoOfInterest = toDoService.ToDos[choice];

                    FillToDo(todoOfInterest);

                    toDoService.Update(todoOfInterest);
                }
                else if (action == ActionType.Delete)
                {
                    Console.WriteLine("You chose to delete a task");
                    Console.WriteLine("Which task would you like to delete?");
                    var choice = int.Parse(Console.ReadLine() ?? "0");

                    toDoService.Delete(choice);

                }
                else if (action == ActionType.Exit)
                {
                    Console.WriteLine("You chose to exit");
                        break;
                }
                


            }

            Console.WriteLine("Thank you for using the Task Management App");

        }

        public static void FillToDo(Class1 todo)
        {
            Console.WriteLine("What is the name for the task?");
            todo.Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("What is the descritption for the task?");
            todo.Description = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("What is the deadline for the task?");

            todo.Deadline = DateTime.Parse(Console.ReadLine() ?? "2023-01-01");

            todo.AssignedUser = 1;

        }

        public static ActionType PrintMenu()
        {

            Console.WriteLine("Select an option to begin:");
            Console.WriteLine("1. Add a ToDo");
            Console.WriteLine("2. List all ToDos");
            Console.WriteLine("3. Update a ToDo");
            Console.WriteLine("4. Delete a ToDo");
            Console.WriteLine("5. Exit");
            var input = int.Parse(Console.ReadLine() ?? "0");

            while (true)
            {
                switch (input)
                {
                    case 1:
                        return ActionType.Create;
                    case 2:
                        return ActionType.Read;
                    case 3:
                        return ActionType.Update;
                    case 4:
                        return ActionType.Delete;
                    case 5:
                        return ActionType.Exit;
                    default:
                        continue;
                }
            }

        }
        public static IHostBuilder CreateHostBuilder(string[] args)=>
        
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        

    }

    public enum ActionType
    {
        Create, Read, Update, Delete, Exit
    }

    
}