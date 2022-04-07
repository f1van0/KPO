using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_image_preview
{
    class DB
    {
		SqliteConnection connection;
		public DB()
		{
			DateTime startTime = DateTime.Now;
			connection = new SqliteConnection("Data Source=info.db");
			connection.Open();
			createTable();
			Insert(new DBRow("Статус приложения", "Начало работы", DateTime.Now - startTime));
		}

		public List<DBRow> Select()
		{
			List<DBRow> data = new List<DBRow>();
			using (var command = connection.CreateCommand())
			{
				command.CommandText = @"SELECT command, context, process_time, date FROM Info ORDER BY command DESC";
				command.ExecuteNonQuery();
				var result = command.ExecuteReader();
				while (result.Read())
				{
					DBRow temp = new DBRow();
					temp.Command = result.GetString(0);
					temp.Context = result.GetString(1);
					temp.ProceedTime = result.GetInt32(2);
					temp.Date = DateTime.Parse(result.GetString(3));
					data.Add(temp);
				}
			}
			return data;
		}

		public void Insert(DBRow row)
		{
			if (row.Command == null || row.Context == null || row.Date == null)
				throw new Exception("Empty data passed");
			using (var command = connection.CreateCommand())
			{
				command.CommandText = @"INSERT INTO Info(command, context, process_time, date) 
										VALUES($command, $context, $process_time, $date)";
				command.Parameters.AddWithValue("$command", row.Command);
				command.Parameters.AddWithValue("$context", row.Context);
				command.Parameters.AddWithValue("$process_time", row.ProceedTime);
				command.Parameters.AddWithValue("$date", row.Date);
				command.ExecuteNonQuery();
			}
		}

		void createTable()
		{
			using (var command = connection.CreateCommand())
			{
				command.CommandText = @"
					CREATE TABLE IF NOT EXISTS Info
					(
						[id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
						[command] NVARCHAR(12) NOT NULL, 
						[context] NVARCHAR(20) NOT NULL, 
						[process_time] INT NOT NULL, 
						[date] TEXT NOT NULL
					)";
				command.ExecuteNonQuery();
			}
		}

		public void Dispose()
		{
			connection.Close();
		}
	}
}
