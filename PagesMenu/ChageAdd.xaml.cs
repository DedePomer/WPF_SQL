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
    /// Логика взаимодействия для ChageAdd.xaml
    /// </summary>
    public partial class ChageAdd : Page
    {
        public ChageAdd()
        {
            InitializeComponent();
            LBmaterials.ItemsSource = Const.BD.Material.ToList();
            LBmaterials.SelectedValuePath = "id_material";
            LBmaterials.DisplayMemberPath = "material1";

            LBservice.ItemsSource = Const.BD.Service.ToList();
            LBservice.SelectedValuePath = "id_service";
            LBservice.DisplayMemberPath = "Servise";
        }

        private void Breg_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Lback_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Const.frame.Navigate(new OrderTable());
        }
    }
}
