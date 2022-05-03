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
	public class FilterPlugin
    {
		public IFilterDynamicLibrary Filter { get; }
		public bool IsActive { get; set; }

		public FilterPlugin(IFilterDynamicLibrary filter)
        {
			Filter = filter;
			IsActive = true;
		}

		public FilterPlugin(IFilterDynamicLibrary filter, bool isActive)
		{
			Filter = filter;
			IsActive = isActive;
		}

		public override string ToString()
        {
			return Filter.Name;
		}
    }

    public class PluginLoader
    {
		public List<FilterPlugin> ImageFiltersPlugins;
		private static FileInfo[] _pluginsFiles;
		private PluginFoldersManager _pluginFoldersManager;

		public PluginLoader(PluginFoldersManager foldersManager)
        {
			ImageFiltersPlugins = new List<FilterPlugin>();
			_pluginFoldersManager = foldersManager;
			LoadPlugins();
		}

        public void LoadPlugins()
        {
			ImageFiltersPlugins = new List<FilterPlugin>();
			if (!Directory.Exists("Plugins"))
				return;

			//Load the DLLs from the Plugins directory
			//AppDomain.CurrentDomain.ClearPrivatePath();
			
			AssemblyName[] assemblies = Assembly.GetEntryAssembly().GetReferencedAssemblies();//Assembly.GetExecutingAssembly().GetReferencedAssemblies();
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
            {
				IFilterDynamicLibrary newFilter = (IFilterDynamicLibrary)Activator.CreateInstance(type);
				ImageFiltersPlugins.Add(new FilterPlugin(newFilter));
			}
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

		public FilterPlugin[] GetActiveFilters()
        {
			return ImageFiltersPlugins.Where(x => x.IsActive).ToArray();
		}
	}
}
