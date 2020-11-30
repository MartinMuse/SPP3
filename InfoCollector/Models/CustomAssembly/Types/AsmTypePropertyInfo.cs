using System;
using System.Reflection;

namespace InfoCollector.Models.CustomAssembly.Types
{
    public class AsmTypePropertyInfo : AsmMemberInfo
    {
        public override string Description
        {
            get => ToString();
        }

        private readonly string name;
        private readonly Type type;

        public AsmTypePropertyInfo(PropertyInfo propertyInfo)
        {
            type = propertyInfo.PropertyType;
            name = propertyInfo.Name;
        }

        public override string ToString()
        {
            return string.Format("Property: {0}: {1}", name, type);
        }
    }
}