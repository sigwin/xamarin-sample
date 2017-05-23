using System;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SQLiteSample
{
    public class TodoDatabase
    {
        readonly SQLiteConnection db;
        public TodoDatabase()
        {
            db = DependencyService.Get<ISQLite>().GetConnection();
            db.CreateTable<Todo>();
        }

        public ObservableCollection<Todo> GetTodoList()
        {
            IEnumerable<Todo> _t = db.Table<Todo>();
            return new ObservableCollection<Todo>(_t);
            //return new ObservableCollection<Todo>();
        }

        public int UpdateTodo(Todo _t)
        {
            int c = 0;
            if(_t._id != 0)
            {
                c = db.Update(_t);
            }
            else
            {
                c = db.Insert(_t);
            }
            System.Diagnostics.Debug.WriteLine(c);
            return c;
        }

        public void AllDelete()
        {
            db.DeleteAll<Todo>();
        }
    }
}
