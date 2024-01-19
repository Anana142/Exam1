using System;
using System.Collections.Generic;

namespace WpfApp4.DataBaseFolder;

public partial class TypeBed
{
    public int TypeBedId { get; set; }

    public string? TypeBedName { get; set; }

    public virtual ICollection<HotelNumber> HotelNumbers { get; set; } = new List<HotelNumber>();
}
