﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class mall_product_space
{
    public int pspace_id { get; set; }

    public int? memberunique_id { get; set; }

    public int? mall_product_table_id { get; set; }

    public int? mall_product_amount { get; set; }

    public virtual mall_product_table mall_product_table { get; set; }

    public virtual basic_member_information memberunique { get; set; }
}