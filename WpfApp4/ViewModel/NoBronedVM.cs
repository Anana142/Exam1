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
    internal class NoBronedVM : BaseVM
    {
        private List<HotelNumber> hotelNumbers;

        public HotelNumber Selected { get; set; }
        public List<HotelNumber> HotelNumbers
        {
            get => hotelNumbers;
            set
            {
                hotelNumbers = value;
                Signal();
            }
        }

        public CommandVM Broned { get; set; }
        public CommandVM GoToBroned { get; set; }

        public NoBronedVM()
        {
            GetList();
            Broned = new CommandVM(() =>
            {

                if (Selected == null)
                    return;

                Selected.HotelNumbersStatusId = 1;
                DataBase.instance.SaveChanges();
                GetList();

            }, () => true);

            GoToBroned = new CommandVM(() => {
                Navigation.CurrentPage = new Broned();
            }, () => true);
        }
        public void GetList()
        {
            HotelNumbers = DataBase.instance.HotelNumbers.Where(s => s.HotelNumbersStatusId == 2)
                .Include(s => s.HotelNumbersView)
                .Include(s => s.HotelNumbersType)
                .Include(s => s.HotelNumbersStatus)
                .Include(s => s.HotelNumbersType)
                .ToList();
        }
    }
}
