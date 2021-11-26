using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SQL
{
    public partial class Users
    {
        public string FIO
        {
            get
            { return Surname + " " + Name + " " + Secondname; }
        }

    }
}
