using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SQliteTestApp
{
    public class SQliteHelper
    {
        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection("Data Source=Database.sqlite;");
        }

        public SQLiteConnection GetConnectionOpen()
        {
            var connection = new SQLiteConnection("Data Source=Database.sqlite;");
            connection.Open();
            return connection;
        }

        public void CreateFile()
        {
            if (!File.Exists("Database.sqlite"))
            {
                SQLiteConnection.CreateFile("Database.sqlite");
            }
        }

        public void AddTable(string tableName, string[] parameters)
        {
            var connection = GetConnection();
            connection.Open();

            string parametersForTable = string.Join(", ", parameters);
            string command = string.Format("create table {0} ({1})", tableName, parametersForTable);

            SQLiteCommand cmd = new SQLiteCommand(command, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public SQLiteCommand ConstructCommand(string[] commandText)
        {
            string commandString = string.Join(", ", commandText);
            Console.WriteLine(commandString);
            return new SQLiteCommand(commandString, GetConnection());
        }

        public SQLiteCommand ConstructCommand(string commandText)
        {
            return new SQLiteCommand(commandText, GetConnection());
        }

        public void AddScore(string user, int score)
        {
            string entryData = string.Format("('{0}', {1})", user, score);
            SQLiteCommand command = ConstructCommand("insert into scores (name, score) values " + entryData);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
    }
}
