using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp4.DataBaseFolder;
using WpfApp4.Tools;
using WpfApp4.View;

namespace WpfApp4.ViewModel
{
    internal class BronedVM : BaseVM
    {
        private List<HotelNumber> hotelNumbers;

        public HotelNumber Selected { get; set; }
        public List<HotelNumber> HotelNumbers { get => hotelNumbers;
            set { hotelNumbers = value; 
                Signal(); } }

        public CommandVM NoBroned { get; set; }
        public CommandVM GoToNoBroned { get; set; }

        public BronedVM()
        {
            GetList();
            NoBroned = new CommandVM(() =>
            {

                if (Selected == null)
                    return;

                Selected.HotelNumbersStatusId = 2;
                DataBase.instance.SaveChanges();
                GetList();

            }, () => true);

            GoToNoBroned = new CommandVM(() => {
                Navigation.CurrentPage = new NoBroned();
            }, ()=>  true);    
        }
        public void GetList()
        {
            HotelNumbers = DataBase.instance.HotelNumbers.Where(s => s.HotelNumbersStatusId == 1)
                .Include(s => s.HotelNumbersView)
                .Include(s => s.HotelNumbersType)
                .Include(s => s.HotelNumbersStatus)
                .Include(s => s.HotelNumbersType)
                .ToList();
        }
    }
}
