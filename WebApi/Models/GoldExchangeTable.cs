using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class GoldExchangeTable
{
    public int GoldDenominationId { get; set; }

    public string? GoldDenominatioName { get; set; }

    public decimal? GoldAmount { get; set; }

    public decimal? StoredAmount { get; set; }

    public virtual ICollection<Storedrecord> Storedrecords { get; set; } = new List<Storedrecord>();
}
