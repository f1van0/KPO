using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchImageProcessing
{
	public class ImageRow
    {
		public string Name;
		public int Exported;
		public string Resolution;
		public int AppliedFiltersAmount;
		public int ProcessingTime;
		public DateTime Date;

		public ImageRow()
        {
			Name = "";
			Exported = 0;
			Resolution = "";
			AppliedFiltersAmount = 0;
			ProcessingTime = 0;
			Date = DateTime.Now;
		}

		public ImageRow(string name, int exported, string resolution, int appliedFiltersAmount, int processingTime)
        {
			Name = name;
			Exported = exported;
			Resolution = resolution;
			AppliedFiltersAmount = appliedFiltersAmount;
			ProcessingTime = processingTime;
			Date = DateTime.Now;
		}

		public ImageRow(string name, int exported, string resolution, int appliedFiltersAmount, int processingTime, DateTime date)
		{
			Name = name;
			Exported = exported;
			Resolution = resolution;
			AppliedFiltersAmount = appliedFiltersAmount;
			ProcessingTime = processingTime;
			Date = date;
		}
	}

	public class ImagesDB
	{
		public static ImagesDB Instance;
		private SqliteConnection connection;

		public ImagesDB()
		{
			if (Instance == null)
				Instance = this;

			connection = new SqliteConnection("Data Source=images.db");
			connection.Open();
			createTable();
		}

		public List<ImageRow> Select()
		{
			List<ImageRow> data = new List<ImageRow>();
			using (var command = connection.CreateCommand())
			{
				command.CommandText = @"SELECT name, exported, resolution, filters_amount, processing_time, date FROM Image";
				command.ExecuteNonQuery();
				var result = command.ExecuteReader();
				while (result.Read())
				{
					ImageRow temp = new ImageRow();
					temp.Name = result.GetString(0);
					temp.Exported = result.GetInt32(1);
					temp.Resolution = result.GetString(2);
					temp.AppliedFiltersAmount = result.GetInt32(3);
					temp.Date = DateTime.Parse(result.GetString(4));
					data.Add(temp);
				}
			}
			return data;
		}

		public void Insert(ImageRow row)
		{
			if (row.Name == null || row.Date == null)
				throw new Exception("Empty data passed");
			using (var command = connection.CreateCommand())
			{
				command.CommandText = @"INSERT INTO Image(name, exported, resolution, filters_amount, processing_time, date) 
										VALUES($name, $exported, $resolution, $filters_amount, $processing_time, $date)";
				command.Parameters.AddWithValue("$name", row.Name);
				command.Parameters.AddWithValue("$exported", row.Exported);
				command.Parameters.AddWithValue("$resolution", row.Resolution);
				command.Parameters.AddWithValue("$filters_amount", row.AppliedFiltersAmount);
				command.Parameters.AddWithValue("$processing_time", row.ProcessingTime);
				command.Parameters.AddWithValue("$date", row.Date);
				command.ExecuteNonQuery();
			}
		}

		private void createTable()
		{
			using (var command = connection.CreateCommand())
			{
				command.CommandText = @"
					CREATE TABLE IF NOT EXISTS Image
					(
						[id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, 
						[name] NVARCHAR(12) NOT NULL, 
						[exported] INT NOT NULL, 
						[resolution] NVARCHAR(12) NOT NULL, 
						[filters_amount] INT NOT NULL,
						[processing_time] INT NOT NULL,
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
