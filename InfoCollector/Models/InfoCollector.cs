using InfoCollector.Models.CustomAssembly;
using System.Collections.Generic;

namespace InfoCollector.Models
{
    public static class InfoCollector
    {
        public static AssemblyInfo LoadAssembly(string assemblyPath)
        {
            var assembly = AssemblyLoader.LoadAssembly(assemblyPath);

            var namespaces = new Dictionary<string, NamespaceInfo>();

            foreach (var t in assembly.GetTypes())
            {
                var asmNamespace = t.Namespace;

                if (!namespaces.ContainsKey(asmNamespace))
                {
                    namespaces[asmNamespace] = new NamespaceInfo(t.Namespace);
                }

                namespaces[asmNamespace].AddType(t);
            }

            return new AssemblyInfo(assembly);
        }
    }
}