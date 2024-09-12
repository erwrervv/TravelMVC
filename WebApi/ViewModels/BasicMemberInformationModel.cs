namespace Travel.WebApi.ViewModels
{
    public class BasicMemberInformationModel
    {

        public int MemberuniqueId { get; set; }

        public string? MemberName { get; set; }

        public string? Email { get; set; }

        public string? Introduction { get; set; }

        public byte[]? MemberPicture { get; set; }
    }
}
