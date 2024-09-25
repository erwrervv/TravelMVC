using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class ProductTravel
{
    public int TravelId { get; set; }

    public int? AllDays { get; set; }

    public string? TravelName { get; set; }

    public int? TravelareaId { get; set; }

    public DateTime? TravelDatetime { get; set; }

    public string? TravelIntroduction { get; set; }

    public string? TravelMeetingpoint { get; set; }

    public bool? ProductShow { get; set; }

    public decimal? Price { get; set; }

    public string? Tag { get; set; }

    public string? Pictures { get; set; }

    public virtual ICollection<TravelDetail> TravelDetails { get; set; } = new List<TravelDetail>();

    public virtual TravelareaTable? Travelarea { get; set; }

    public virtual ICollection<TravelpicturesTable> TravelpicturesTables { get; set; } = new List<TravelpicturesTable>();
}
