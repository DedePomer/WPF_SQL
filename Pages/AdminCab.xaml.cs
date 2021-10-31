using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_SQL
{
    /// <summary>
    /// Логика взаимодействия для AdminCab.xaml
    /// </summary>
    public partial class AdminCab : Page
    {
        public AdminCab()
        {
            InitializeComponent();
        }

        private void Bexit_Click(object sender, RoutedEventArgs e)
        {
            Const.frame.Navigate(new Image());
        }

        private void Bdatausers_Click(object sender, RoutedEventArgs e)
        {
            Const.frame.Navigate(new UsersTable());
        }
    }
}
