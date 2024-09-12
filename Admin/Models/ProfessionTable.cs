using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class ProfessionTable
{
    public string ProfessionId { get; set; } = null!;

    public string? ProfessionName { get; set; }

    public virtual ICollection<BasicCommodityInformation> BasicCommodityInformations { get; set; } = new List<BasicCommodityInformation>();
}
