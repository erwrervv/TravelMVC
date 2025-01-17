﻿using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class Accommodation
{
    public int AccommodationId { get; set; }

    public string? AccommodationName { get; set; }

    public DateOnly? CheckinDate { get; set; }

    public DateOnly? CheckoutDate { get; set; }

    public string? Location { get; set; }
}
