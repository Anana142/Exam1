using System;
using System.Collections.Generic;

namespace WpfApp4.DataBaseFolder;

public partial class HotelNumber
{
    public int HotelNumbersId { get; set; }

    public int? HotelNumbersTypeId { get; set; }

    public int? HotelNumbersCountRooms { get; set; }

    public int? HotelNumbersViewId { get; set; }

    public decimal? HotelNumbersCost { get; set; }

    public int? HotelNumbersStatusId { get; set; }

    public int? HotelNumbersBedCount { get; set; }

    public int? HotelNumbersBedTypeId { get; set; }

    public virtual TypeBed? HotelNumbersBedType { get; set; }

    public virtual Status? HotelNumbersStatus { get; set; }

    public virtual HotelNumbersType? HotelNumbersType { get; set; }

    public virtual HotelNumbersView? HotelNumbersView { get; set; }
}
