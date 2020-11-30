using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace InfoCollector.Models.CustomAssembly.Types
{
    public class AsmTypeExtensionMethodInfo : AsmMemberInfo
    {
        public override string Description
        {
            get => ToString();
        }
        private readonly string name;
        private readonly List<ParameterInfo> parameterInfos;
        private readonly Type returnType;

        public AsmTypeExtensionMethodInfo(MethodInfo methodInfo)
        {
            name = methodInfo.Name;
            returnType = methodInfo.ReturnType;
            parameterInfos = methodInfo.GetParameters().ToList();
        }

        public override string ToString()
        {
            var methodParams =
                string.Join(", ", parameterInfos.Select(
                    parameterInfo => string.Format("this {0} {1}", parameterInfo.ParameterType, parameterInfo.Name)));
            return string.Format("Extension Method: {0} {1}({2})", returnType.Name, name, methodParams);
        }
    }
}