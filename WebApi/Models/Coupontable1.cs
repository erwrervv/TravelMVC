﻿using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class Coupontable1
{
    public int CouponId { get; set; }

    public string? Couponame { get; set; }

    public string? CoupondiscountId { get; set; }

    public virtual CouponDiscountTable? Coupondiscount { get; set; }
}
