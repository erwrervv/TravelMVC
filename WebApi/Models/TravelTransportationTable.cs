﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class TravelTransportationTable
{
    public bool TransportationId { get; set; }

    public string TransportMode { get; set; }

    public DateOnly? DepartureDate { get; set; }

    public DateOnly? ArrivalDate { get; set; }
}