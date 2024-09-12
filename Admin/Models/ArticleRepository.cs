using System;
using System.Collections.Generic;

namespace Travel.Admin.Models;

public partial class ArticleRepository
{
    public int ArticleRepositoryId { get; set; }

    public int? ArticleListId { get; set; }

    public int? ArticleId { get; set; }

    public virtual ArticleOverview? Article { get; set; }

    public virtual ArticleList? ArticleList { get; set; }
}
