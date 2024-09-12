using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class CouponDiscountTable
{
    public string CoupondiscountId { get; set; } = null!;

    public DateTime? Expirationdate { get; set; }

    public decimal? Discountamount { get; set; }

    public virtual ICollection<Coupontable1> Coupontable1s { get; set; } = new List<Coupontable1>();
}
