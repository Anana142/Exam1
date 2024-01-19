using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.DataBaseFolder;

namespace WpfApp4.Tools
{
    internal class DataBase
    {
        private static User05Context instance1;

        public DataBase()
        {

        }
        public static User05Context instance
        {
            get
            {

                if (instance1 == null)
                    instance1 = new User05Context();
                return instance1;

            }
            set => instance1 = value;
        }
    }
}
