using AssemblyBrowser.ViewModels;
using System.Windows;

namespace AssemblyBrowser.Views
{
    /// <summary>
    ///     Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var avm = new AssemblyViewModel();
            DataContext = avm;
        }
    }
}