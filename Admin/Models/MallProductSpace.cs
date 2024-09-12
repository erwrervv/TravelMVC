using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class MallProductSpace
{
    public int PspaceId { get; set; }

    public int? MemberuniqueId { get; set; }

    public int? MallProductTableId { get; set; }

    public int? MallProductAmount { get; set; }

    public virtual MallProductTable? MallProductTable { get; set; }

    public virtual BasicMemberInformation? Memberunique { get; set; }
}
