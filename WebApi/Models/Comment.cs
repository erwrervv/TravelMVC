using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? ArticleId { get; set; }

    public int? MemberuniqueId { get; set; }

    public string? CommentContent { get; set; }

    public DateTime? CommentDateTime { get; set; }

    public virtual ArticleOverview? Article { get; set; }

    public virtual BasicMemberInformation? Memberunique { get; set; }
}
