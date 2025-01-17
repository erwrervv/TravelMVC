﻿using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class ShoprecordDetail
{
    public int ShoprecordDetailid { get; set; }

    public int? ShopRecordid { get; set; }

    public int? MallProductTableId { get; set; }

    public string? MallProductName { get; set; }

    public int? MallProductQuantity { get; set; }

    public string? Shoporderid { get; set; }

    public virtual MallProductTable? MallProductTable { get; set; }

    public virtual Shoprecord? ShopRecord { get; set; }
}
