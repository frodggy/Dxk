using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Dxk.SDK;
public class PluginManager
{
    static public List<DxkPlugin> ReadPlugins(String pluginDir) {
        var pluginList = new List<DxkPlugin>();

        var files = Directory.GetFiles(pluginDir, "*.dll");

        foreach (var file in files) {
            var asm = Assembly.LoadFile(Path.Combine(Directory.GetCurrentDirectory(), file));

            var pluginTypes = asm.GetTypes().Where(t => typeof(DxkPlugin).IsAssignableFrom(t) && !t.IsInterface).ToArray();

            foreach (var pluginType in pluginTypes)
            {
                var pluginInstance = Activator.CreateInstance(pluginType) as DxkPlugin;
                pluginList.Add(pluginInstance);
            }
        }

        return pluginList;
    }
}
public interface DxkPlugin {
    string Title { get; }
    string Description { get; }

    string Version { get; }

    void onStart();
    void onShutDown();
}