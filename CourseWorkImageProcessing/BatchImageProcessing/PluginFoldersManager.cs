using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchImageProcessing
{
    public class PluginFoldersManager
    {
        private const string _basePluginFolder = "Plugins";
        private const string _fileWithFolders = "folders.json";
		public Action FolderListChanged;

		public List<string> ActiveFolders;

        public PluginFoldersManager()
        {
			LoadFolders();
        }

		public void LoadFolders()
		{
			List<string> foldersNames = new List<string>();
			if (File.Exists(_fileWithFolders))
			{
				string json = File.ReadAllText(_fileWithFolders);
				foldersNames = JsonConvert.DeserializeObject<List<string>>(json);
			}
			else
			{
				if (!Directory.Exists(_basePluginFolder))
					Directory.CreateDirectory(_basePluginFolder);

				foldersNames.Add(_basePluginFolder);
				string json = JsonConvert.SerializeObject(foldersNames, Formatting.Indented);
				File.WriteAllText(_fileWithFolders, json);
			}

			ActiveFolders = foldersNames;
		}

		public void AddFolder(string path)
        {
			if (!ActiveFolders.Contains(path))
			{
				ActiveFolders.Add(path);
				UpdateFileFolders();
			}
		}

		public void RemoveFolder(string path)
		{
			if (ActiveFolders.Contains(path))
            {
				ActiveFolders.Remove(path);
				UpdateFileFolders();
			}
		}

		public void UpdateFileFolders()
        {
			string json = JsonConvert.SerializeObject(ActiveFolders, Formatting.Indented);
			File.WriteAllText(_fileWithFolders, json);
		}
	}
}
