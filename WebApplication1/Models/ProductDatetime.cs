using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class ProductDatetime
{
    public int NotypedatingId { get; set; }

    public int CommodityId { get; set; }

    public string? DatingId { get; set; }

    public DateOnly? Datingdate { get; set; }

    public TimeOnly? Startime { get; set; }

    public TimeOnly? Endtime { get; set; }

    public decimal? Price { get; set; }

    public bool? ProductShow { get; set; }

    public virtual BasicCommodityInformation Commodity { get; set; } = null!;
}
