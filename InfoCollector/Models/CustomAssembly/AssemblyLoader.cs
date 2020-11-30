using System.Reflection;

namespace InfoCollector.Models.CustomAssembly
{
    public class AssemblyLoader
    {
        public static Assembly LoadAssembly(string relativeAssemblyPath)
        {
            return Assembly.LoadFrom(relativeAssemblyPath);
        }
    }
}