using System;
using System.Collections.Generic;

namespace WpfApp4.DataBaseFolder;

public partial class HotelNumbersTypeBed
{
    public int HotelNumbersId { get; set; }

    public int TypeBedId { get; set; }

    public int? CountBed { get; set; }

    public virtual HotelNumber HotelNumbers { get; set; } = null!;

    public virtual TypeBed TypeBed { get; set; } = null!;
}
