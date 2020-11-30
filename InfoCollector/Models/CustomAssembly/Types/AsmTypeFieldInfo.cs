using System;
using System.Reflection;

namespace InfoCollector.Models.CustomAssembly.Types
{
    public class AsmTypeFieldInfo : AsmMemberInfo
    {
        public override string Description
        {
            get => ToString();
        }
        private readonly string name;
        private readonly Type type;

        public AsmTypeFieldInfo(FieldInfo fieldInfo)
        {
            type = fieldInfo.FieldType;
            name = fieldInfo.Name;
        }

        public override string ToString()
        {
            return string.Format("Field: {0}: {1}", name, type);
        }
    }
}