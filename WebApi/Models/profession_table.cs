﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class profession_table
{
    public string profession_id { get; set; }

    public string profession_name { get; set; }

    public virtual ICollection<basic_commodity_information> basic_commodity_information { get; set; } = new List<basic_commodity_information>();
}