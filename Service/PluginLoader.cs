using PluginBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Service
{
    public class PluginLoader
    {
        private static readonly DirectoryInfo pluginsDir = new(Environment.CurrentDirectory + @"\Plugins");
        
        private List<Assembly> LoadPlugins()
        {
            DirectoryInfo[] pluginDirs = pluginsDir.GetDirectories();
            FileInfo[] files = pluginDirs.SelectMany(d => d.GetFiles(d.Name + ".dll")).ToArray();
            return files.Select(f => LoadPlugin(f.FullName)).ToList();
        }

        public DirectoryInfo[] GetPluginDirectories()
        {
            return pluginsDir.GetDirectories();
        }

        public Dictionary<string, IServiceProvider> getServiceProviders()
        {
            List<Assembly> assemblies = LoadPlugins();
            return assemblies.Select(a => GetServiceProviderBuilder(a)).ToDictionary(b => b.DbName, b => b.GetServiceProvider());
        }

        private IServiceProviderBuilder GetServiceProviderBuilder(Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IServiceProviderBuilder).IsAssignableFrom(type))
                {
                    return Activator.CreateInstance(type) as IServiceProviderBuilder;
                }
            }
            throw new FileNotFoundException($"IServiceProviderBuilder not found in assembly {assembly.FullName}");
        }

        private Assembly LoadPlugin(string pluginLocation)
        {
            Console.WriteLine($"Loading commands from: {pluginLocation}");
            PluginLoadContext loadContext = new(pluginLocation);
            return loadContext.LoadFromAssemblyName(AssemblyName.GetAssemblyName(pluginLocation));
        }
    }
}
