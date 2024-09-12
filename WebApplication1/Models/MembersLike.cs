using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class MembersLike
{
    public int LikesId { get; set; }

    public int? ArticleId { get; set; }

    public int? MemberuniqueId { get; set; }

    public bool? Likes { get; set; }

    public virtual ArticleOverview? Article { get; set; }

    public virtual BasicMemberInformation? Memberunique { get; set; }
}
