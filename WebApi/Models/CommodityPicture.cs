using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class CommodityPicture
{
    public int? CommodityId { get; set; }

    public byte[]? CommodityPictures { get; set; }

    public virtual BasicCommodityInformation? Commodity { get; set; }
}
