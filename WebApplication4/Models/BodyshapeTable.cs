using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class BodyshapeTable
{
    public string BodyshapeId { get; set; } = null!;

    public string? BodyshapeName { get; set; }

    public virtual ICollection<BasicCommodityInformation> BasicCommodityInformations { get; set; } = new List<BasicCommodityInformation>();
}
