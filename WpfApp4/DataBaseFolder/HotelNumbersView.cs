using System;
using System.Collections.Generic;

namespace WpfApp4.DataBaseFolder;

public partial class HotelNumbersView
{
    public int HotelNumbersViewId { get; set; }

    public string? HotelNumbersViewName { get; set; }

    public virtual ICollection<HotelNumber> HotelNumbers { get; set; } = new List<HotelNumber>();
}
