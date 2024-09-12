namespace Travel.WebApi.DTO
{
    public class ArticleOverviewDTOModel
    {
        public int ArticleId { get; set; }
        public int MemberuniqueId { get; set; }
        public string ArticleName { get; set; }
        public string ArticleContent { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public byte[] ArticleCoverImage { get; set; }
    }
}
