using Dxk.SDK;
using System;


namespace DxkTitan;
public class DxkTitan : DxkPlugin
{
    public string Title => "DxkTitan";
    public string Description => "DxkTitan is a Dxk Plugin to get newer Dxk bindings to work on ARX gpus";

    public string Version => "1.0.10";

    public void onStart() {
        Console.WriteLine("DxkTitan stated");
    }

    public void onShutDown() {
        Console.WriteLine("DxkTitan shut down");
    }
}
