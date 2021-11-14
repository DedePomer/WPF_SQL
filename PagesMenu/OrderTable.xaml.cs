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
    /// Логика взаимодействия для OrderTable.xaml
    /// </summary>
    public partial class OrderTable : Page
    {
        public OrderTable()
        {
            InitializeComponent();
            //Const.frame.Refresh();
            LVwashhouse.ItemsSource = Const.BD.Washhouse.ToList();
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int ind = Convert.ToInt32(tb.Uid);
            List<UserMaterial> a = Const.BD.UserMaterial.Where(x => x.id_user == ind).ToList();
            string str = "Материалы: ";
            if (a.Count != 0)
            {
                foreach (UserMaterial item in a)
                {
                    str += item.Material.material1 + "|";
                }
                str = str.Substring(0, str.Length - 1);
                tb.Text = str;
            }
            else
                tb.Text = "Ничего нет";
        }

        private void TextBlock_Loaded_1(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int ind = Convert.ToInt32(tb.Uid);
            List<UsersService> a = Const.BD.UsersService.Where(x=> x.id_users == ind).ToList();
            string str = "Услуги: ";
            if (a.Count != 0)
            {
                foreach (UsersService item in a)
                {
                    str += item.Service.Servise + "|";
                }
                str = str.Substring(0, str.Length - 1);
                tb.Text = str;
            }
            else
                tb.Text = "Ничего нет";
        }

        private void TextBlock_Loaded_2(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int ind = Convert.ToInt32(tb.Uid);
            List<UsersService> a = Const.BD.UsersService.Where(x => x.id_users == ind).ToList();
            double summ = 0;
            if (a.Count != 0)
            {
                foreach (UsersService item in a)
                {
                    summ += (double)item.Service.Price;
                }

                tb.Text = "Стоймость услуг: "+Convert.ToString(summ);
            }
            else
                tb.Text = "Стоймость услуг: 0";
        }

        private void Lback_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Const.frame.Navigate(new AdminCab());
        }

        private void Ladd_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Const.frame.Navigate(new ChageAdd());
        }
    }
}
