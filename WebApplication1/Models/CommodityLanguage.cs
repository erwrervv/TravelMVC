using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class CommodityLanguage
{
    public int? CommodityId { get; set; }

    public string? LanguageId { get; set; }

    public virtual BasicCommodityInformation? Commodity { get; set; }

    public virtual LanguageTable? Language { get; set; }
}
