using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace pozdnev_kursach
{
    public class DataBase : DbContext
    {
        public static string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        // private SqliteConnection connection = new SqliteConnection(@"Data Source=" + DataBase.strExeFilePath.Substring(0, strExeFilePath.Length-10) + @"\accounting.sqlite");
        private SqliteConnection connection = new SqliteConnection(@"Data Source=C:\Users\kak7\Documents\GitHub\pozdnev-kursach\pozdnev-kursach\db.sqlite");

        public DataBase()
        {
            connection.Open();
        }

        public SqliteDataReader GetReader(string cmdText)
        {
            var command = connection.CreateCommand();
            command.CommandText = cmdText;

            return command.ExecuteReader();
        }

        public void ExecuteNonQuery(string cmdText)
        {
            var command = connection.CreateCommand();
            command.CommandText = cmdText;
            command.ExecuteNonQuery();
        }
    }
}