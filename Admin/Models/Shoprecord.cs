using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class Shoprecord
{
    public int ShopRecordid { get; set; }

    public string? MemberName { get; set; }

    public bool? ExchangeStatus { get; set; }

    public DateTime? PurchaseTime { get; set; }

    public int? TotalPrice { get; set; }

    public string? MemberPhone { get; set; }

    public string? Address { get; set; }

    public int? MallProductTableId { get; set; }

    public int? MallProductQuantity { get; set; }
}
