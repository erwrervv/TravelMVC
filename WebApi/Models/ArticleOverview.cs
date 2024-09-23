using System;
using System.Collections.Generic;

namespace Travel.WebApi.Models;

public partial class ArticleOverview
{
    public int ArticleId { get; set; }

    public int? MemberuniqueId { get; set; }

    public string? ArticleName { get; set; }

    public string? ArticleContent { get; set; }

    public DateTime? CreateTime { get; set; }

    public DateTime? UpdateTime { get; set; }

    public byte[]? ArticleCoverImage { get; set; }

    public string? ArticleCoverImageString { get; set; }

    public string? Tag { get; set; }

    public virtual ICollection<ArticlePicture> ArticlePictures { get; set; } = new List<ArticlePicture>();

    public virtual ICollection<ArticleRepository> ArticleRepositories { get; set; } = new List<ArticleRepository>();

    public virtual ICollection<comment> Comments { get; set; } = new List<comment>();

    public virtual ICollection<MembersLike> MembersLikes { get; set; } = new List<MembersLike>();

    public virtual BasicMemberInformation? Memberunique { get; set; }
}
