using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class BasicMemberInformation
{
    public int MemberuniqueId { get; set; }

    public string? MemberName { get; set; }

    public bool? Activate { get; set; }

    public string? Phone { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? BeCommodity { get; set; }

    public int? LevelId { get; set; }

    public decimal? MemberValue { get; set; }

    public int? Followers { get; set; }

    public int? Tracks { get; set; }

    public string? Introduction { get; set; }

    public string? HouseName { get; set; }

    public DateTime? HouseCreatetime { get; set; }

    public DateTime? HouseRenewtime { get; set; }

    public byte[]? MemberPicture { get; set; }

    public virtual ICollection<ArticleList> ArticleLists { get; set; } = new List<ArticleList>();

    public virtual ICollection<ArticleOverview> ArticleOverviews { get; set; } = new List<ArticleOverview>();

    public virtual ICollection<BasicCommodityInformation> BasicCommodityInformations { get; set; } = new List<BasicCommodityInformation>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual LevelTable? Level { get; set; }

    public virtual ICollection<MallProductSpace> MallProductSpaces { get; set; } = new List<MallProductSpace>();

    public virtual ICollection<MembersLike> MembersLikes { get; set; } = new List<MembersLike>();

    public virtual ICollection<Storedrecord> Storedrecords { get; set; } = new List<Storedrecord>();

    public virtual ICollection<Tracklist> Tracklists { get; set; } = new List<Tracklist>();
}
