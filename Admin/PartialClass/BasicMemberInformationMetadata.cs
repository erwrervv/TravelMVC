using System.ComponentModel.DataAnnotations;

namespace Travel.Admin.Models
{
    internal class BasicMemberInformationMetadata
    {
        [Display(Name = "會員編號")]
        public int MemberuniqueId { get; set; }
        [Display(Name = "會員名稱")]
        public string? MemberName { get; set; }
        [Display(Name = "啟用")]
        public bool? Activate { get; set; }
        [Display(Name = "電話")]
        public string? Phone { get; set; }
        [Display(Name = "會員生日")]
        public DateTime? Birthday { get; set; }
        [Display(Name = "電子郵件")]
        public string? Email { get; set; }
        [Display(Name = "密碼")]
        public string? Password { get; set; }
        [Display(Name = "會員活動")]
        public bool? BeCommodity { get; set; }
        [Display(Name = "會員等級")]
        public int? LevelId { get; set; }
        [Display(Name = "剩餘額度")]
        public decimal? MemberValue { get; set; }
        [Display(Name = "追隨者人數")]
        public int? Followers { get; set; }
        [Display(Name = "追蹤")]
        public int? Tracks { get; set; }
        [Display(Name = "自我介紹")]
        public string? Introduction { get; set; }
        [Display(Name = "小屋名稱")]
        public string? HouseName { get; set; }
        [Display(Name = "小屋建立時間")]
        public DateTime? HouseCreatetime { get; set; }
        [Display(Name = "小屋更新時間")]
        public DateTime? HouseRenewtime { get; set; }
        [Display(Name = "會員圖片")]
        public byte[]? MemberPicture { get; set; }
    }
}