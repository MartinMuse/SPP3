using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InfoCollector.Models.CustomAssembly
{
    public class AssemblyInfo
    {
        public string AssemblyName { get; }
        public List<NamespaceInfo> AssemblyNamespaces { get; }

        public AssemblyInfo(Assembly assembly)
        {
            AssemblyName = assembly.FullName;
            var asmNamespaces = new Dictionary<string, NamespaceInfo>();
            foreach (var asmType in assembly.GetTypes())
            {
                var asmNamespace = asmType.Namespace;
                if (!asmNamespaces.ContainsKey(asmNamespace))
                {
                    asmNamespaces[asmNamespace] = new NamespaceInfo(asmType.Namespace);
                }
                asmNamespaces[asmNamespace].AddType(asmType);
            }
            AssemblyNamespaces = asmNamespaces.Values.ToList();
        }
    }
}