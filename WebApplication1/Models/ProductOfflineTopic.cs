using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class ProductOfflineTopic
{
    public int DowntopicId { get; set; }

    public int? CommidityId { get; set; }

    public string? DatingId { get; set; }

    public string? OfflineTopicsName { get; set; }

    public string? OfflineTypeId { get; set; }

    public string? AreaId { get; set; }

    public DateOnly? DatingDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public decimal? Price { get; set; }

    public bool? ProductShow { get; set; }
}
