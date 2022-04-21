using EmployeeDirectory_WPF.Data;
using EmployeeDirectory_WPF.View;
using System.Windows;

namespace EmployeeDirectory_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            JsonHelper.InitGeneralFiltersData();
            JsonHelper.InitEmployeeData();
            MainContent.Content = new HomeView();

        }
        
        
    }
}
