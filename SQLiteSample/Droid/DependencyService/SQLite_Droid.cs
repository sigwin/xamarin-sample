using System.IO;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Droid))]
public class SQLite_Droid : SQLiteSample.ISQLite
{
    public SQLiteConnection GetConnection()
    {
        const string sqlfile = "cache.db";
        var docPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        var path = Path.Combine(docPath, sqlfile);
        return new SQLiteConnection(path);
    }
}

