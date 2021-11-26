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
    /// Логика взаимодействия для Auto.xaml
    /// </summary>
    public partial class Auto : Page
    {
        public Auto()
        {
            InitializeComponent();
        }
        
        private void Breg_Click(object sender, RoutedEventArgs e)
        {
            int pass = PBOXpassword.Password.GetHashCode();
            Users User = Const.BD.Users.FirstOrDefault
                (x => x.Login == TBOXlogin.Text && x.Password == pass);
            if (!(User == null))
            {
                MessageBox.Show("Здарова " + User.Name, "", MessageBoxButton.OK);
                switch (User.id_role)
                {
                    case 1:
                        Const.frame.Navigate(new AdminCab(User));
                        break;
                    case 2:
                        Const.frame.Navigate(new UsersCab(User));
                        break;
                }                
            }
            else 
            {
                MessageBox.Show("Вы не зарегестрированны","", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Lback_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Const.frame.Navigate(new Image());
        }
    }
}
