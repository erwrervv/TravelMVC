using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class Tracklist
{
    public int TracklistId { get; set; }

    public int? MemberuniqueId { get; set; }

    public int? TrackMemberId { get; set; }

    public virtual BasicMemberInformation? Memberunique { get; set; }
}
