using Dxk.SDK;

namespace Dxk;

class Progam {
    public static void Main() {
        var _plugins = PluginManager.ReadPlugins("plugins");
        foreach (var plugin in _plugins)
        {
            Console.WriteLine($"loading {plugin.Title}#{plugin.Version}");
            plugin.onStart();
        }
        App.Run();
        foreach (var plugin in _plugins)
        {
            Console.WriteLine($"shutting down {plugin.Title}");
            plugin.onShutDown();
        }

    }
}

class App {
    public static void Run() {

    }
}