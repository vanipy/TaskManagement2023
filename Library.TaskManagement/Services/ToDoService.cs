using System;
using Library.TaskManagement.Models;

namespace Library.TaskManagement.Services
{
	public class ToDoService
	{

        private List<Class1> toDoList;
        public List<Class1> ToDos
        {
            get
            {
                return toDoList;
            }

            private set
            {
                toDoList = value;
            }
        }

        public ToDoService()
        {
            toDoList = new List<Class1>();
        }

        public void Create(Class1 todo)
        {
            ToDos.Add(todo);
        }

        public void Update(Class1 todo)
        {

        }

        public void Delete(int index)
        {
            toDoList.RemoveAt(index);
        }

    }
}

