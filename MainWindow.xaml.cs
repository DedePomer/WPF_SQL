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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Const.frame = Fmain;
            Const.BD = new Entities();
            Fmain.Navigate(new Image()); // Данные для входа в файл Пароли.txt
            //Fmain.Navigate(new OrderTable());
        }

        private void Bsing_in_Click(object sender, RoutedEventArgs e)
        {
            Fmain.Navigate(new Auto());
        }

        private void Breg_Click(object sender, RoutedEventArgs e)
        {
            Fmain.Navigate(new Reg());
        }
    }
}
