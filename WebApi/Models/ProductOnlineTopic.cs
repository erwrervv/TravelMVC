using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class ProductOnlineTopic
{
    public int UptopicId { get; set; }

    public int? CommidityId { get; set; }

    public string? DatingId { get; set; }

    public string? OnlineTopicsName { get; set; }

    public string? OnlineTypeId { get; set; }

    public DateOnly? DatingDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public decimal? Price { get; set; }

    public bool? ProductShow { get; set; }
}
