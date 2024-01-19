using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp4.Tools;
using WpfApp4.View;

namespace WpfApp4.ViewModel
{
    internal class MainVm : BaseVM
    {
        private Page currentPage;

        public Page CurrentPage { get => Navigation.CurrentPage;}
        public MainVm()
        {
            Navigation.CurrentPage = new Broned();
            Navigation.EventHandler += CurrentPageChanged;
        }
        public void CurrentPageChanged(object? sender, Page e)
        {
            Signal(nameof(CurrentPage));    
        }
    }
}
