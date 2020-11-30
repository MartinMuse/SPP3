using Microsoft.Win32;
using System;
using System.Reflection;
using System.Windows.Input;

namespace AssemblyBrowser.Commands
{
    public class LoadAssemblyCommand : ICommand
    {
        public LoadAssemblyCommand(Action<string> action)
        {
            OnFileChooseExecute += action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Assembly.GetEntryAssembly().Location,
                Filter = "dll files (*.dll)|*.dll",
                RestoreDirectory = true
            };


            if (openFileDialog.ShowDialog() == true)
                OnFileChooseExecute?.Invoke(openFileDialog.FileName);
            //AssemblyInfos.Add(InfoCollector.LoadAssembly(openFileDialog.FileName));
        }

        private event Action<string> OnFileChooseExecute;
    }
}