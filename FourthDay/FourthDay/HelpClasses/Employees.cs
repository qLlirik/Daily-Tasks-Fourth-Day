using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthDay.DB
{
    partial class Employees
    {
        public bool t = false;
        public bool Cheif
        {
            get
            {
                return t;
            }
            set
            {
                t = value;
            }
        }
    }
}
