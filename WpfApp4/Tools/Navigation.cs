using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp4.Tools
{
    internal class Navigation
    {
        public static EventHandler<Page> EventHandler;
        private static Page currentPage;

        public static Page CurrentPage { get => currentPage;
            set { currentPage = value;
                EventHandler?.Invoke(null, CurrentPage);
            } }
    }
}
