using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace InfoCollector.Models.CustomAssembly.Types
{
    public class TypeInfo
    {
        public IList<AsmMemberInfo> MembersInfos { get; set; }
        public string TypeName => Type.ToString();
        public Type Type;

        private void AddMember(AsmMemberInfo memberInfo)
        {
            MembersInfos.Add(memberInfo);
        }

        public TypeInfo(Type type)
        {
            Type = type;

            MembersInfos = new List<AsmMemberInfo>();

            foreach (var fieldInfo in type.GetFields())
            {
                AddMember(new AsmTypeFieldInfo(fieldInfo));
            }

            foreach (var propertyInfo in type.GetProperties())
            {
                AddMember(new AsmTypePropertyInfo(propertyInfo));
            }

            foreach (var methodInfo in type.GetMethods())
            {
                if (methodInfo.IsDefined(typeof(ExtensionAttribute), false))
                {
                    AddMember(new AsmTypeExtensionMethodInfo(methodInfo));
                }
                else
                {
                    AddMember(new AsmTypeMethodInfo(methodInfo));
                }
            }
        }
    }
}