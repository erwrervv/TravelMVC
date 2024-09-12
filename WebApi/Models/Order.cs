using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CommidityId { get; set; }

    public int? MemberuniqueId { get; set; }

    public DateTime? CreateTime { get; set; }

    public double? Discount { get; set; }

    public int? CouponId { get; set; }

    public bool? Paymentstatus { get; set; }

    public decimal? PriceUnfixed { get; set; }

    public decimal? PriceFixed { get; set; }

    public virtual BasicCommodityInformation? Commidity { get; set; }
}
