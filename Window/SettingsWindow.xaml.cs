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
using System.Windows.Shapes;

namespace WPF_SQL
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private static SettingsWindow W;
        private Users _user;
        public SettingsWindow(Users user)
        {
            InitializeComponent();
            W = this;
            _user = user;
            TBOXName.Text = _user.Name;
            TBOXSeсondname.Text = _user.Secondname;
            TBOXSurname.Text = _user.Surname;
            TBOXSeсondname.Text = _user.Secondname;

            CBgender.ItemsSource = Const.BD.Gender.ToList();
            CBgender.SelectedValuePath = "id";
            CBgender.DisplayMemberPath = "Gender1";
            CBgender.SelectedIndex = _user.id_gender - 1;

        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                SettingsWindow.W.DragMove();
            }
        }

        private void Bchange_Click(object sender, RoutedEventArgs e)
        {
            _user.Name = TBOXName.Text;
            _user.Surname = TBOXSurname.Text;
            _user.Secondname = TBOXSeсondname.Text;
            _user.id_gender = CBgender.SelectedIndex + 1;
            Const.BD.SaveChanges();
            MessageBox.Show("Изменения сохранены", "",MessageBoxButton.OK);
            Const.frame.Navigate(new UsersCab(_user));
            this.Close();
        }

        private void Lback_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
