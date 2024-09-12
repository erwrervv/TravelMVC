using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class BasicCommodityInformation
{
    public int CommodityId { get; set; }

    public int? MemberuniqueId { get; set; }

    public string? LoverNickname { get; set; }

    public string? ProfessionId { get; set; }

    public string? BodyshapeId { get; set; }

    public string? Gender { get; set; }

    public virtual BodyshapeTable? Bodyshape { get; set; }

    public virtual BasicMemberInformation? Memberunique { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ProductDatetime> ProductDatetimes { get; set; } = new List<ProductDatetime>();

    public virtual ProfessionTable? Profession { get; set; }
}
