using System;
using System.Collections.Generic;

namespace WpfApp4.DataBaseFolder;

public partial class HotelNumbersType
{
    public int HotelNumbersId { get; set; }

    public string? HotelNumbersName { get; set; }

    public virtual ICollection<HotelNumber> HotelNumbers { get; set; } = new List<HotelNumber>();
}
