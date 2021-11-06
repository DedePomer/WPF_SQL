using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_SQL
{
    public partial class Washhouse
    {
        public string FIO 
        {
        get
            {
                return Surname+" " + Name + " " + Secondname;
            }
        }

        public SolidColorBrush ColorCell
        {
            get 
            {
                switch (id_colors)
                {
                    case 1:
                        return Brushes.Black;
                    case 2:
                        return Brushes.White;
                    case 3:
                        return Brushes.SeaGreen;
                    case 4:
                        return Brushes.OrangeRed;
                    default:
                        return Brushes.Pink;
                }
            }
        }


        public SolidColorBrush ColorDate
        {
            get
            {
                DateTime d = new DateTime(2009,1,1);
                if (Date_of_receiving<d)
                {
                    return Brushes.LightGray;
                }
                return Brushes.White;
            }
        }


    }
}
