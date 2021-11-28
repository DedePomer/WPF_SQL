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
        List<Washhouse> StartFilter = Const.BD.Washhouse.ToList();
        List<Washhouse> OrderFilter;
        public OrderTable()
        {
            InitializeComponent();
            OrderFilter = StartFilter;
            LVwashhouse.ItemsSource = StartFilter;
            List<Colors> ColorsList = Const.BD.Colors.ToList();
            CBColors.Items.Add("Все");
            for (int i = 0; i < ColorsList.Count; i++)
            {
                CBColors.Items.Add(ColorsList[i].Colors1);
            }
            CBColors.SelectedIndex = 0;
            CBSort.SelectedIndex = 0;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender; 
            int ind = Convert.ToInt32(B.Uid); 
            Washhouse Delete = Const.BD.Washhouse.FirstOrDefault(y => y.id == ind);
            Const.BD.Washhouse.Remove(Delete);
            Const.BD.SaveChanges();
            Const.frame.Navigate(new OrderTable());
            MessageBox.Show("Запись удалена", "", MessageBoxButton.OK);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            int ind = Convert.ToInt32(B.Uid);
            Washhouse Update = Const.BD.Washhouse.FirstOrDefault(y => y.id == ind);
            Const.frame.Navigate(new ChageAdd(Update));
        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            int ind = Convert.ToInt32(B.Uid);
            if (B.Background == Brushes.Black)
            {
                B.Foreground = Brushes.White;
            }
            else if (B.Background == Brushes.White)
            {
                B.Foreground = Brushes.Black;
            }
            else if (B.Background == Brushes.SeaGreen)
            {
                B.Foreground = Brushes.Yellow;
            }
            else
            {
                B.Foreground = Brushes.Black;
            }
        }

        private void Filter()
        {
            int index = CBColors.SelectedIndex;
            if (CBColors.SelectedIndex != 0)
            {
                OrderFilter = StartFilter.Where(x => x.id_colors == index).ToList();
            }
            else
            {
                OrderFilter = StartFilter;
            }
            if (!string.IsNullOrWhiteSpace(TBOXSearch.Text))
            {
                OrderFilter = OrderFilter.Where(x => x.FIO.Contains(TBOXSearch.Text) ||
                x.FIO.ToLower().Contains(TBOXSearch.Text) ||
                x.FIO.ToUpper().Contains(TBOXSearch.Text)).ToList();
            }
            if (CheckBAllPhoto.IsChecked == true)
            {
                OrderFilter = OrderFilter.Where(x => x.id_clothes == 1).ToList();
            }
            LVwashhouse.ItemsSource = OrderFilter;

        }

        private void CBColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void TBOXSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void CheckBAllPhoto_Checked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void CheckBAllPhoto_Unchecked(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void CBSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sort();
            LVwashhouse.Items.Refresh();
        }

        private void BUp_Click(object sender, RoutedEventArgs e)
        {
            sort();
            LVwashhouse.Items.Refresh();
        }

        private void BDown_Click(object sender, RoutedEventArgs e)
        {            
            sort();
            OrderFilter.Reverse();
            LVwashhouse.Items.Refresh();
        }

        private int sort()
        {
            switch (CBSort.SelectedIndex)
            {
                case 0:
                    OrderFilter.Sort((x, y) => x.id_colors.CompareTo(y.id_colors));
                    return 0;

                case 1:
                    OrderFilter.Sort((x, y) => x.Date_of_receiving.CompareTo(y.Date_of_receiving));
                    return 1;

                case 2:
                    OrderFilter.Sort((x, y) => x.Name.CompareTo(y.Name));
                    return 2;

                case -1:
                    return -1;

                default:
                    return -2;
            }
        }
    }
}
