using InfoCollector.Models;
using InfoCollector.Models.CustomAssembly;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;

using static InfoCollector.Models.InfoCollector;

namespace InfoCollectorTests
{
    [TestClass]
    public class InfoCollectorTests
    {
        [TestMethod]
        public void TestGettingNamespaces()
        {
            var assemblyInfo = LoadAssembly("ShapesLib.dll");
            var actual = assemblyInfo.AssemblyNamespaces[0].NamespaceName;
            var expected = "TestingNamespace";
            Assert.AreEqual(expected, actual);

            actual = assemblyInfo.AssemblyNamespaces[1].NamespaceName;
            expected = "ShapesLib";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGettingTypeNames()
        {
            var assemblyInfo = LoadAssembly("ShapesLib.dll");
            var actual = assemblyInfo.AssemblyNamespaces[1].NamespaceTypes[0].TypeName;
            var expected = "ShapesLib.Shape";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGettingMethodNames()
        {
            var assemblyInfo = LoadAssembly("ShapesLib.dll");
            var actual = assemblyInfo.AssemblyNamespaces[1].NamespaceTypes[0].MembersInfos[1].Description;
            var expected = "Method: Boolean One(System.Int32 a, System.String b)";
            Assert.AreEqual(expected, actual);
        }
    }
}