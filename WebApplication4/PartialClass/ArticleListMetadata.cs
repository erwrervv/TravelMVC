using System.ComponentModel.DataAnnotations;

namespace Travel.Admin.Models
{
    internal class ArticleListMetadata
    {
        [Display(Name = "文章列表編號")] 
        public int ArticleListId { get; set; }
        [Display(Name = "文章列表名稱")]
        public string? ArticleListName { get; set; }
        [Display(Name = "會員編號")]
        public int? MemberuniqueId { get; set; }

    }
}