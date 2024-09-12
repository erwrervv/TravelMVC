namespace Travel.WebApi.ViewModels
{
    public class ArticleOverviewsModel
    {
        public int ArticleId { get; set; }

        public string? ArticleName { get; set; }

        public string? ArticleContent { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public byte[]? ArticleCoverImage { get; set; }

        public string? MemberName { get; set; }

    }
}
