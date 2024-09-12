namespace Travel.WebApi.ViewModels
{
    public class CommentModel
    {
        public int CommentId { get; set; }

        public string? CommentContent { get; set; }

        public DateTime? CommentDateTime { get; set; }
        public string? ArticleName { get; set; }

        public string? MemberName { get; set; }

        public byte[]? MemberPicture { get; set; }

    }
}
