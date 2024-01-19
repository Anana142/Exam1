using System;
using System.Collections.Generic;

namespace WpfApp4.DataBaseFolder;

public partial class Status
{
    public int StatusId { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<HotelNumber> HotelNumbers { get; set; } = new List<HotelNumber>();
}
