﻿using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class MallProductTable
{
    public int MallProductTableId { get; set; }

    public string? MallProductId { get; set; }

    public string? MallProductName { get; set; }

    public int? GoldAmount { get; set; }

    public byte[]? Pimage { get; set; }

    public virtual ICollection<MallProductPurchaseRecord> MallProductPurchaseRecords { get; set; } = new List<MallProductPurchaseRecord>();

    public virtual ICollection<MallProductSpace> MallProductSpaces { get; set; } = new List<MallProductSpace>();

    public virtual ICollection<ShoprecordDetail> ShoprecordDetails { get; set; } = new List<ShoprecordDetail>();
}
