using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {

        public Reg()
        {
            InitializeComponent();
            CBgender.ItemsSource = Const.BD.Gender.ToList();
            CBgender.SelectedValuePath = "id";
            CBgender.DisplayMemberPath = "Gender1";
        }
        
        private void Breg_Click(object sender, RoutedEventArgs e)
        {
            TBOXlogin.BorderBrush = Brushes.Black;
            CBgender.Background = Brushes.White;
            TBOXname.BorderBrush = Brushes.Black;
            TBOXsecondname.BorderBrush = Brushes.Black;
            TBOXSurname.BorderBrush = Brushes.Black;
            PBOXpassword.BorderBrush = Brushes.Black;
            if (TBOXlogin.Text != "" && TBOXname.Text != "" && TBOXsecondname.Text != "" && TBOXSurname.Text != "" && PBOXpassword.Password != "" && CBgender.SelectedItem != null)
            {

                if (VerificationPass(PBOXpassword.Password))
                {
                    Users User = new Users()
                    {
                        Surname = TBOXSurname.Text,
                        Name = TBOXname.Text,
                        Password = PBOXpassword.Password.GetHashCode(),
                        id_gender = CBgender.SelectedIndex + 1,
                        id_role = 2,
                        Login = TBOXlogin.Text,
                        Secondname = TBOXsecondname.Text
                    };
                    Const.BD.Users.Add(User);
                    Const.BD.SaveChanges();
                    MessageBox.Show("Вы зарегистрировались", "Регистрация", MessageBoxButton.OK);
                    TBOXlogin.Text = "";
                    TBOXname.Text = "";
                    TBOXsecondname.Text = "";
                    TBOXSurname.Text = "";
                    PBOXpassword.Password = "";
                    CBgender.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("С паролем что-то не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                if (TBOXlogin.Text == "")
                { TBOXlogin.BorderBrush = Brushes.Red; }
                if (TBOXname.Text == "")
                { TBOXname.BorderBrush = Brushes.Red; }
                if (PBOXpassword.Password == "")
                { PBOXpassword.BorderBrush = Brushes.Red; }
                if (TBOXsecondname.Text == "")
                { TBOXsecondname.BorderBrush = Brushes.Red; }
                if (TBOXSurname.Text == "")
                { TBOXSurname.BorderBrush = Brushes.Red; }
                if (CBgender.SelectedItem == null)
                { CBgender.Background = Brushes.Red; }
            }

        }

        bool VerificationPass (string pass)
        {
            var Zaglav = new Regex(@"[A-Z]+");
            var Storch = new Regex(@"(?=.{3,}[a-z])");//[a-z]{3,} - это работает когда буквы идут друг за другом 
            var Cifr = new Regex(@"(?=.{2,}[0-9])");
            var SpecS = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]{1,}");
            var dlinMin8 = new Regex(@".{8,}");
            var Lat = new Regex(@"(?=.{1,}[А-я])");
            bool b = Zaglav.IsMatch(pass) && Storch.IsMatch(pass) && Cifr.IsMatch(pass) && SpecS.IsMatch(pass) && dlinMin8.IsMatch(pass) && !Lat.IsMatch(pass);
            return b;
        }

        

        private void PBOXpassword_KeyDown(object sender, KeyEventArgs e)
        {
            string pass = PBOXpassword.Password;
            var Zaglav = new Regex(@"[A-Z]+");
            var Storch = new Regex(@"(?=.{3,}[a-z])");
            var Cifr = new Regex(@"(?=.{2,}[0-9])");
            var SpecS = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]{1,}");
            var dlinMin8 = new Regex(@".{8,}");
            var Lat = new Regex(@"(?=.{1,}[А-я])");
            if (dlinMin8.IsMatch(pass))
            {
                TBLOCKpopup.Text = "";
                if (!Lat.IsMatch(pass))
                {
                    if (!Zaglav.IsMatch(pass))
                    {
                        TBLOCKpopup.Text = "В пароле должна быть хотябы одна заглавная буква.";
                    }
                    if (!Storch.IsMatch(pass))
                    {
                        TBLOCKpopup.Text += "\nВ пароле должны быть хотябы 3 строчные буквы.";
                    }
                    if (!Cifr.IsMatch(pass))
                    {
                        TBLOCKpopup.Text += "\nВ пароле должно быть хотябы 2 цифры";
                    }
                    if (!SpecS.IsMatch(pass))
                    {
                        TBLOCKpopup.Text += "\nВ пароле должно быть мин. 1 спец. символа";
                    }
                    if (VerificationPass(pass))
                    {
                        TBLOCKpopup.Text = "Пароль подходит";
                    }
                }
                else
                    TBLOCKpopup.Text = "Пароль должен содержать только латинские буквы";
            }
            else
            {
                TBLOCKpopup.Text = "Пароль менше 8 символов";
            }
            popup.IsOpen = true;


        }

        private void PBOXpassword_LostMouseCapture(object sender, MouseEventArgs e)
        {
            popup.IsOpen = true;
        }

        private void Lback_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Const.frame.Navigate(new Image());
        }
    }
}
