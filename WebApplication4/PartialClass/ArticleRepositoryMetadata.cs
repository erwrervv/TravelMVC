using System.ComponentModel.DataAnnotations;

namespace Travel.Admin.Models
{
    internal class ArticleRepositoryMetadata
    {

        [Display(Name = "個人文章列表編號")]
        public int ArticleRepositoryId { get; set; }
        [Display(Name = "文章列表編號")]
        public int? ArticleListId { get; set; }
        [Display(Name = "文章編號")]
        public int? ArticleId { get; set; }

    }
}