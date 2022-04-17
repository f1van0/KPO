using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BatchImageProcessing
{
    class PluginLoader
    {
		public List<IFilterDynamicLibrary> ImageFiltersPlugins;
		private static FileInfo[] _pluginsFiles;
		private PluginFoldersManager _pluginFoldersManager;

		public PluginLoader(PluginFoldersManager foldersManager)
        {
			ImageFiltersPlugins = new List<IFilterDynamicLibrary>();
			_pluginFoldersManager = foldersManager;
		}

        public void LoadPlugins()
        {
			ImageFiltersPlugins = new List<IFilterDynamicLibrary>();
			if (!Directory.Exists("Plugins"))
				return;

			//Load the DLLs from the Plugins directory
			AssemblyName[] assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
			AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;

			foreach (var folder in _pluginFoldersManager.ActiveFolders)
            {
				_pluginsFiles = new DirectoryInfo(folder).GetFiles("*.dll");
				foreach (var file in _pluginsFiles)
					Assembly.LoadFile(file.FullName);
			}

			Type interfaceType = typeof(IFilterDynamicLibrary);
			//Fetch all types that implement the interface IPlugin and are a class
			Type[] types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(a => a.GetTypes())
				.Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
				.ToArray();

			//Create a new instance of all found types
			foreach (Type type in types)
				ImageFiltersPlugins.Add((IFilterDynamicLibrary)Activator.CreateInstance(type));
		}

		private Assembly ResolveAssembly(object sender, ResolveEventArgs args)
		{
			string dllName = args.Name.Split(',')[0];
			FileInfo dllFile = _pluginsFiles.FirstOrDefault(fileInfo => fileInfo.Name.Contains(dllName));
			if (dllFile == null)
			{
				return null;
			}

			return Assembly.LoadFrom(dllFile.FullName);
		}
	}
}
