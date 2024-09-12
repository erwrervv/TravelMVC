using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class CommodityInteractive
{
    public int? CommodityId { get; set; }

    public string? InteractiveId { get; set; }

    public virtual BasicCommodityInformation? Commodity { get; set; }

    public virtual InteractiveTable? Interactive { get; set; }
}
