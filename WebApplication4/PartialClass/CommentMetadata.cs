using System.ComponentModel.DataAnnotations;

namespace Travel.Admin.Models
{
    internal class CommentMetadata
    {
        [Display(Name = "評論編號")]
        public int CommentId { get; set; }
        [Display(Name = "文章編號")]
        public int? ArticleId { get; set; }
        [Display(Name = "會員編號")]
        public int? MemberuniqueId { get; set; }
        [Display(Name = "評論內容")]
        public string? CommentContent { get; set; }
        [Display(Name = "評論時間")]
        public DateTime? CommentDateTime { get; set; }

    }
}