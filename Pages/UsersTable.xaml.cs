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
    /// Логика взаимодействия для UsersTable.xaml
    /// </summary>
    public partial class UsersTable : Page
    {
        public UsersTable()
        {
            InitializeComponent();
            DGtable.ItemsSource = Const.BD.Users.ToList();

        }

        private void Lback_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Const.frame.Navigate(new AdminCab());
        }
    }
}
