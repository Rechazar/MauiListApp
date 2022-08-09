using MauiList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiList.Repositories
{
    public class TodoRepository
    {
        //Singleton implementation
        //^ is a design pattern, here a class has only one isntance in the application. So no need to worry about creating new einstance of the TodoRepository every time
        //Thread safety Singleton -> thread locked on a shared object and checks whether an instance has been created or not.
        //Thus it takes care of the memory barrier issue and ensures that only one thread will create an instance.
        TodoRepository() { }
        private static TodoRepository instance = null;
        public static TodoRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TodoRepository();
                }
                return instance;
            }
        }


        //Below is called thread safe singleton without using locks nad no lazy instatiation
        //private static readonly TodoRepository instance = new TodoRepository();
        //static TodoRepository() 
        //{

        //}
        //private TodoRepository()
        //{ 
        //}
        //public static TodoRepository Instance
        //{
        //    get 
        //    {
        //        return Instance;
        //    }

        private List<TodoItem> _todoItems = new List<TodoItem>();
        public List<TodoItem> GetItems()
        {
            return _todoItems.ToList();
        }

        public List<TodoItem> GetItemsNotDone()
        {
            return _todoItems.Where(s => s.Done == false).ToList();
        }

        public TodoItem GetItem(Guid id)
        {
            return _todoItems.Where(i => i.ID == id).FirstOrDefault();
        }

        public Guid SaveItem(TodoItem item)
        {
            if (item.ID != Guid.Empty)
            {
                _todoItems.Remove(item);
                _todoItems.Add(item);
                return item.ID;
            }
            else
            {
                item.ID = Guid.NewGuid();
                _todoItems.Add(item);
                return item.ID;
            }
        }

        public void DeleteItem(TodoItem item)
        {
            _todoItems.Remove(item);
        }
    }
}
