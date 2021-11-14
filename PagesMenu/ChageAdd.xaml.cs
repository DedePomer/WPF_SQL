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

            CBcolors.ItemsSource = Const.BD.Colors.ToList();
            CBcolors.SelectedValuePath = "id";
            CBcolors.DisplayMemberPath = "Colors1";

            CBclothes.ItemsSource = Const.BD.Clothes.ToList();
            CBclothes.SelectedValuePath = "id";
            CBclothes.DisplayMemberPath = "Clotges";
        }

        private void Breg_Click(object sender, RoutedEventArgs e)
        {           
            Washhouse WH = new Washhouse 
            {Name = TBOXname.Text, Surname = TBOXSurname.Text, Secondname = TBOXsecondname.Text,
            Date_of_receiving = DPdate.DisplayDate.Date, id_clothes = CBclothes.SelectedIndex+1, id_colors = CBcolors.SelectedIndex+1};
            Const.BD.Washhouse.Add(WH);
            Const.BD.SaveChanges();

            foreach (Material item in LBmaterials.SelectedItems)
            {
                UserMaterial UM = new UserMaterial();
                UM.id_user = WH.id;
                UM.id_material = item.id_material;
                Const.BD.UserMaterial.Add(UM);
            }

            foreach (Service item in LBservice.SelectedItems)
            {
                UsersService US = new UsersService();
                US.id_users = WH.id;
                US.id_service = item.id_servise;
                Const.BD.UsersService.Add(US);
            }
            MessageBox.Show("Данные записаны","",MessageBoxButton.OK);
            TBOXname.Text = "";
            TBOXsecondname.Text = "";
            TBOXSurname.Text = "";
            DPdate.SelectedDate = null;
            LBmaterials.SelectedItem = null;
            LBservice.SelectedItem = null;
            CBclothes.SelectedItem = null;
            CBcolors.SelectedItem = null;

            Const.BD.SaveChanges();

        }

        private void Lback_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Const.frame.Navigate(new OrderTable());
        }
    }
}
