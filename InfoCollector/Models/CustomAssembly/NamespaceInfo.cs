using InfoCollector.Models.CustomAssembly.Types;
using System;
using System.Collections.Generic;

namespace InfoCollector.Models.CustomAssembly
{
    public class NamespaceInfo
    {
        public string NamespaceName { get; set; }
        public List<TypeInfo> NamespaceTypes { get; set; }

        public NamespaceInfo(string asmNamespace)
        {
            NamespaceName = asmNamespace;
            NamespaceTypes = new List<TypeInfo>();
        }

        public void AddType(Type type)
        {
            NamespaceTypes.Add(new TypeInfo(type));
        }
    }
}