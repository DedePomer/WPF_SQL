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
using System.Windows.Shapes;

namespace WPF_SQL
{
    /// <summary>
    /// Логика взаимодействия для LogPassWindow.xaml
    /// </summary>
    public partial class LogPassWindow : Window
    {
        private static LogPassWindow _W;
        private Users _user;
        public LogPassWindow(Users user)
        {
            InitializeComponent();
            _W = this;
            _user = user;
            TBOXLogin.Text = _user.Login;
        }

        private void Drag(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                LogPassWindow._W.DragMove();
            }
        }

        private void Lback_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Bchange_Click(object sender, RoutedEventArgs e)
        {
            while(true)
            {
                if (PBOXSeсondPass.Password == "" && PBOXFirstPass.Password == "")
                {
                    _user.Login = TBOXLogin.Text;
                    Const.BD.SaveChanges();
                    break;
                }
                else
                {
                    if (Reg.VerificationPass(PBOXFirstPass.Password) && Reg.VerificationPass(PBOXSeсondPass.Password) && PBOXSeсondPass.Password == PBOXFirstPass.Password)
                    {
                        _user.Login = TBOXLogin.Text;
                        _user.Password = PBOXSeсondPass.Password.GetHashCode();
                        Const.BD.SaveChanges();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Что-то не так с данными", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            MessageBox.Show("Данные сохранены", "", MessageBoxButton.OK);
            this.Close();

        }

        private void PBOXFirstPass_LostMouseCapture(object sender, MouseEventArgs e)
        {
            popup.IsOpen = true;
        }

        private void PBOXFirstPass_KeyUp(object sender, KeyEventArgs e)
        {
            string pass1 = PBOXFirstPass.Password;
            string pass2 = PBOXSeсondPass.Password;
            var Zaglav = new Regex(@"[A-Z]+");
            var Storch = new Regex(@"(?=.{3,}[a-z])");
            var Cifr = new Regex(@"(?=.{2,}[0-9])");
            var SpecS = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]{1,}");
            var dlinMin8 = new Regex(@".{8,}");
            var Lat = new Regex(@"(?=.{1,}[А-я])");
            if (pass1 == "" && pass2 == "")
            {
                TBLOCKpopupS.Text = "";
            }
            else
            {
                if (pass1 != pass2)
                {
                    TBLOCKpopupS.Text = "Пароли должны совпадать";
                }
                else
                {
                    if (dlinMin8.IsMatch(pass1))
                    {
                        TBLOCKpopupS.Text = "";
                        if (!Lat.IsMatch(pass1))
                        {
                            if (!Zaglav.IsMatch(pass1))
                            {
                                TBLOCKpopupS.Text = "В пароле должна быть хотябы одна заглавная буква.";
                            }
                            if (!Storch.IsMatch(pass1))
                            {
                                TBLOCKpopupS.Text += "\nВ пароле должны быть хотябы 3 строчные буквы.";
                            }
                            if (!Cifr.IsMatch(pass1))
                            {
                                TBLOCKpopupS.Text += "\nВ пароле должно быть хотябы 2 цифры";
                            }
                            if (!SpecS.IsMatch(pass1))
                            {
                                TBLOCKpopupS.Text += "\nВ пароле должно быть мин. 1 спец. символа";
                            }
                            if (Reg.VerificationPass(pass1))
                            {
                                TBLOCKpopupS.Text = "Пароль подходит";
                            }
                        }
                        else
                            TBLOCKpopupS.Text = "Пароль должен содержать только латинские буквы";
                    }
                    else
                    {
                        TBLOCKpopupS.Text = "Пароль меньше 8 символов";
                    }
                }
            }
            popup.IsOpen = true;
        }
    }
}
