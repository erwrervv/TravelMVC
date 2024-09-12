using System.ComponentModel.DataAnnotations;

namespace Travel.Admin.Models
{
    internal class ArticleOverviewMetadata
    {
        [Display(Name = "文章編號")]
        public int ArticleId { get; set; }

        [Display(Name = "會員編號")]
        public int? MemberuniqueId { get; set; }

        [Display(Name = "文章名稱")]
        public string? ArticleName { get; set; }

        [Display(Name = "文章內容")]
        public string? ArticleContent { get; set; }

        [Display(Name = "文章建立時間")]
        public DateTime? CreateTime { get; set; }

        [Display(Name = "文章修改時間")]
        public DateTime? UpdateTime { get; set; }

        [Display(Name = "文章封面圖片")]

        public byte[]? ArticleCoverImage { get; set; }

        [Display(Name = "文章封面圖片")]

        public string? ArticleCoverImageString { get; set; }

    }
}