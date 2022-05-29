using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace CourseStatistics
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
        private const string _fileName = "images.db";

        public ImagesDB()
        {
            if (Instance == null)
                Instance = this;

            connection = new SqliteConnection($"Data Source={_fileName}");
            connection.Open();
            createTable();
        }

        public ImagesDB(string path)
        {
            if (Instance == null)
                Instance = this;

            File.Copy(path, $"{Directory.GetCurrentDirectory()}\\{_fileName}", true);

            connection = new SqliteConnection($"Data Source={_fileName}");
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
                    temp.ProcessingTime = result.GetInt32(4);
                    temp.Date = DateTime.Parse(result.GetString(5));
                    data.Add(temp);
                }
            }
            return data;
        }

        public List<ImageRow> SelectWithStatus(int status)
        {
            List<ImageRow> data = new List<ImageRow>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $@"SELECT name, exported, resolution, filters_amount, processing_time, date FROM Image WHERE exported = {status}";
                command.ExecuteNonQuery();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    ImageRow temp = new ImageRow();
                    temp.Name = result.GetString(0);
                    temp.Exported = result.GetInt32(1);
                    temp.Resolution = result.GetString(2);
                    temp.AppliedFiltersAmount = result.GetInt32(3);
                    temp.ProcessingTime = result.GetInt32(4);
                    temp.Date = DateTime.Parse(result.GetString(5));
                    data.Add(temp);
                }
            }
            return data;
        }

        public int GetAmountOfImages(int status)
        {
            int amount = 0;
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $@"SELECT name, exported, resolution, filters_amount, processing_time, date FROM Image WHERE exported = {status}";
                command.ExecuteNonQuery();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    ImageRow temp = new ImageRow();
                    temp.Name = result.GetString(0);
                    temp.Exported = result.GetInt32(1);
                    temp.Resolution = result.GetString(2);
                    temp.AppliedFiltersAmount = result.GetInt32(3);
                    temp.ProcessingTime = result.GetInt32(4);
                    temp.Date = DateTime.Parse(result.GetString(5));
                    amount++;
                }
            }
            return amount;
        }

        public int GetAverageAmountOfFilters()
        {
            int iter = 0;
            int avgValue = 0;
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $@"SELECT name, exported, resolution, filters_amount, processing_time, date FROM Image WHERE exported = 1";
                command.ExecuteNonQuery();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    ImageRow temp = new ImageRow();
                    temp.Name = result.GetString(0);
                    temp.Exported = result.GetInt32(1);
                    temp.Resolution = result.GetString(2);
                    temp.AppliedFiltersAmount = result.GetInt32(3);
                    temp.ProcessingTime = result.GetInt32(4);
                    temp.Date = DateTime.Parse(result.GetString(5));
                    iter++;
                    avgValue += temp.AppliedFiltersAmount;
                }
            }
            return avgValue / iter;
        }

        public int GetAverageProcessingTime()
        {
            int iter = 0;
            int avgTime = 0;
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $@"SELECT name, exported, resolution, filters_amount, processing_time, date FROM Image WHERE exported = 1";
                command.ExecuteNonQuery();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    ImageRow temp = new ImageRow();
                    temp.Name = result.GetString(0);
                    temp.Exported = result.GetInt32(1);
                    temp.Resolution = result.GetString(2);
                    temp.AppliedFiltersAmount = result.GetInt32(3);
                    temp.ProcessingTime = result.GetInt32(4);
                    temp.Date = DateTime.Parse(result.GetString(5));
                    iter++;
                    avgTime += temp.ProcessingTime;
                }
            }
            return avgTime / iter;
        }

        public List<KeyValuePair<string, int>> SelectResolutionsGradation(int status)
        {
            Dictionary<string, int> gradation = new Dictionary<string, int>();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = $@"SELECT name, exported, resolution, filters_amount, processing_time, date FROM Image WHERE exported = {status}";
                command.ExecuteNonQuery();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    ImageRow temp = new ImageRow();
                    temp.Name = result.GetString(0);
                    temp.Exported = result.GetInt32(1);
                    temp.Resolution = result.GetString(2);
                    temp.AppliedFiltersAmount = result.GetInt32(3);
                    temp.ProcessingTime = result.GetInt32(4);
                    temp.Date = DateTime.Parse(result.GetString(5));
                    if (gradation.ContainsKey(temp.Resolution))
                    {
                        gradation[temp.Resolution]++;
                    }
                    else
                    {
                        gradation.Add(temp.Resolution, 1);
                    }
                }
            }

            List<KeyValuePair<string, int>> sorted = new List<KeyValuePair<string, int>>();
            sorted.AddRange(from entry in gradation orderby entry.Value ascending select entry);
            return sorted;
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
                try
                {
                    command.ExecuteNonQuery();
                }
                catch(SqliteException ex)
                {
                    throw(new Exception());
                }
            }
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
