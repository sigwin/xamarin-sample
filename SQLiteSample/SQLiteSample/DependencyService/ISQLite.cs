using SQLite;
namespace SQLiteSample
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
