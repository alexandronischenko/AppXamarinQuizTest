using System;
using System.Collections.Generic;
using System.Text;
using FirstApp.Models;
using SQLite;


namespace FirstApp.DataBase
{
    public class CourseRepository
    {
        private SQLiteConnection database;
        static object locker = new object();
        public CourseRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Course>();
        }

        public IEnumerable<Course> GetItems()
        {
            return database.Table<Course>().ToList();
        }

        public Course GetItem(int id)
        {
            return database.Get<Course>(id);
        }

        public int DeleteItem(int id)
        {
            lock (locker)
            {
                return database.Delete<Course>(id);
            }
        }

        public int SaveItem(Course item)
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