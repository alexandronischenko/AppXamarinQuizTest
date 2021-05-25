using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Models;
using SQLite;


namespace FirstApp.DataBase
{
    public class UserRepository
    {
        private SQLiteConnection database;
        static object locker = new object();
        public UserRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<User>();
        }

        public IEnumerable<User> GetItems()
        {
            return database.Table<User>().ToList();
        }

        public User GetItem(int id)
        {
            return database.Get<User>(id);
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<User>(id);
            }
        }

        public int SaveItem(User item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
