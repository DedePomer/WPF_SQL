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
        Washhouse WashhouseObj;
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

        public ChageAdd(Washhouse Update)
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

            TBOXname.Text = Update.Name;
            TBOXSurname.Text = Update.Surname;
            TBOXsecondname.Text = Update.Secondname;
            DPdate.SelectedDate = Update.Date_of_receiving;
            CBcolors.SelectedIndex = Update.id_colors-1;
            CBclothes.SelectedIndex = Update.id_clothes-1;

            List<UserMaterial> UserMaterialList = Const.BD.UserMaterial.Where(x => x.id_user == Update.id).ToList();
            foreach (Material item in LBmaterials.Items)
            {
                if (UserMaterialList.FirstOrDefault(x=>x.id_material == item.id_material) != null )
                {
                    LBmaterials.SelectedItems.Add(item);
                }                
            }

            List<UsersService> UserServiceList = Const.BD.UsersService.Where(x => x.id_users == Update.id).ToList();
            int a = UserServiceList.Count;
            foreach (Service item in LBservice.Items)
            {
                if (UserServiceList.FirstOrDefault(x => x.id_service == item.id_servise) != null)
                {
                    LBservice.SelectedItems.Add(item);
                }
            }

        }

        private void Breg_Click(object sender, RoutedEventArgs e)
        {
            WashhouseObj.Name = TBOXname.Text; 
            WashhouseObj.Surname = TBOXSurname.Text;
            WashhouseObj.Secondname = TBOXsecondname.Text;
            WashhouseObj.Date_of_receiving = DPdate.DisplayDate.Date;
            WashhouseObj.id_clothes = CBclothes.SelectedIndex + 1;
            WashhouseObj.id_colors = CBcolors.SelectedIndex+1;
            Const.BD.Washhouse.Add(WashhouseObj);
            Const.BD.SaveChanges();

            foreach (Material item in LBmaterials.SelectedItems)
            {
                UserMaterial UM = new UserMaterial();
                UM.id_user = WashhouseObj.id;
                UM.id_material = item.id_material;
                Const.BD.UserMaterial.Add(UM);
            }

            foreach (Service item in LBservice.SelectedItems)
            {
                UsersService US = new UsersService();
                US.id_users = WashhouseObj.id;
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
