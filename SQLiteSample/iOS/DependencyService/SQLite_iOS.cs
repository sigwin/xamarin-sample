using System;
using System.IO;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
public class SQLite_iOS: SQLiteSample.ISQLite
{
    public SQLiteConnection GetConnection()
    {
        const string sqlfile = "cache.db";
        var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        var libPath = Path.Combine(docPath, "..", "Library");
        var path = Path.Combine(libPath, sqlfile);
        return new SQLiteConnection(path);
    }
}
