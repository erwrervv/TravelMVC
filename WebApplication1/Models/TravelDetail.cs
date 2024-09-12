using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class TravelDetail
{
    public int TravelDetailsId { get; set; }

    public int? TravelId { get; set; }

    public string? TravelDetailedIntroduction { get; set; }

    public bool? TourBus { get; set; }

    public bool? Bus { get; set; }

    public bool? Train { get; set; }

    public string? MorningName { get; set; }

    public string? LunchName { get; set; }

    public string? DinnerName { get; set; }

    public string? AccommodationName { get; set; }

    public int? WhichDay { get; set; }

    public virtual ProductTravel? Travel { get; set; }
}
