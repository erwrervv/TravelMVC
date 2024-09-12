using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class CommodityInterest
{
    public int? CommodityId { get; set; }

    public string? InterestId { get; set; }

    public virtual BasicCommodityInformation? Commodity { get; set; }

    public virtual InterestTable? Interest { get; set; }
}
