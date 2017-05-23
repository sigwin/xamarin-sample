using SQLite;
namespace SQLiteSample
{
    public class Todo
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int _id { get; set; }
        public string title { get; set; }
    }
}
