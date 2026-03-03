using System.Runtime.Loader;

namespace AssemblyLoadContext_Usage
{
    public class PluginLoadContext : AssemblyLoadContext
    {
        public PluginLoadContext() : base(isCollectible: true) { }
    }
}