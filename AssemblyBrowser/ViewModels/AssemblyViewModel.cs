using AssemblyBrowser.Commands;
using AssemblyBrowser.Models;
using InfoCollector.Models.CustomAssembly;
using System;
using System.IO;
using static InfoCollector.Models.InfoCollector;

namespace AssemblyBrowser.ViewModels
{
    public class AssemblyViewModel
    {
        public CustomObservableCollection<AssemblyInfo> AssemblyInfos { get; set; }
        public LoadAssemblyCommand LoadCommand { get; set; }

        public AssemblyViewModel()
        {
            AssemblyInfos = new CustomObservableCollection<AssemblyInfo>();
            LoadCommand = new LoadAssemblyCommand(RenewList);
        }

        private void RenewList(string path)
        {
            try
            {
                AssemblyInfos.AddElement(LoadAssembly(path));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
            }
        }
    }
}