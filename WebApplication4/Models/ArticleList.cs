using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class ArticleList
{
    public int ArticleListId { get; set; }

    public string? ArticleListName { get; set; }

    public int? MemberuniqueId { get; set; }

    public virtual ICollection<ArticleRepository> ArticleRepositories { get; set; } = new List<ArticleRepository>();

    public virtual BasicMemberInformation? Memberunique { get; set; }
}
