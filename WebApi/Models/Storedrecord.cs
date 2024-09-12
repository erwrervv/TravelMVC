using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class Storedrecord
{
    public int StoreRecordId { get; set; }

    public int? MemberuniqueId { get; set; }

    public int? GoldDenominationId { get; set; }

    public DateTime? PurchaseDate { get; set; }

    public bool? PaymentStatus { get; set; }

    public bool? RefundStatus { get; set; }

    public virtual GoldExchangeTable? GoldDenomination { get; set; }

    public virtual BasicMemberInformation? Memberunique { get; set; }
}
