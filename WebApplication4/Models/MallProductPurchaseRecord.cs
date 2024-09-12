using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class MallProductPurchaseRecord
{
    public int MprecordId { get; set; }

    public string? MemberName { get; set; }

    public int? MallProductTableId { get; set; }

    public bool? ExchangeStatus { get; set; }

    public DateTime? ExchangeTime { get; set; }

    public virtual MallProductTable? MallProductTable { get; set; }
}
