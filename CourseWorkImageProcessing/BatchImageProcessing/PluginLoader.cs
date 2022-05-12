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
		public IImageFilterDynamicLibrary Filter { get; }
		public bool IsActive { get; set; }

		public FilterPlugin(IImageFilterDynamicLibrary filter)
        {
			Filter = filter;
			IsActive = true;
		}

		public FilterPlugin(IImageFilterDynamicLibrary filter, bool isActive)
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
		public License CurrentLicense;

		private static FileInfo[] _pluginsFiles;
		private PluginFoldersManager _pluginFoldersManager;

		public PluginLoader(PluginFoldersManager foldersManager, License license)
        {
			ImageFiltersPlugins = new List<FilterPlugin>();
			_pluginFoldersManager = foldersManager;
			CurrentLicense = license;
			LoadPlugins(CurrentLicense.Status);
		}

		public void LoadPlugins()
		{
			LoadPlugins(CurrentLicense.Status);
		}

		public void LoadPlugins(LicenseStatus status)
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
			
			Type interfaceType = typeof(IImageFilterDynamicLibrary);
			//Fetch all types that implement the interface IPlugin and are a class
			Type[] types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(a => a.GetTypes())
				.Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
				.ToArray();

			//Create a new instance of all found types
			foreach (Type type in types)
            {
				IImageFilterDynamicLibrary newFilter = (IImageFilterDynamicLibrary)Activator.CreateInstance(type);
				ImageFiltersPlugins.Add(new FilterPlugin(newFilter));
			}

			LoadSettingsForPlugins();
		}

		private void LoadSettingsForPlugins()
        {
			foreach (var plugin in ImageFiltersPlugins)
            {
				plugin.Filter.Settings.TryToLoadSettings();
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
