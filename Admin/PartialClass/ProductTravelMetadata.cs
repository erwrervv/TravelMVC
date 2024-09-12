using System.ComponentModel.DataAnnotations;

namespace Travel.Admin.Models
{
    internal class ProductTravelMetadata
    {
        public int TravelId { get; set; }
        [Required(ErrorMessage = "選項天數只能在1到3天")]
        [Range(1, 3, ErrorMessage = "選項天數只能在1到3天")]
        [Display(Name = "旅遊天數")]
        public int? AllDays { get; set; }
        [Required]
        [RegularExpression(@"^[\u4e00-\u9fa5]+$", ErrorMessage = "旅行名稱只能是中文")]
        [Display(Name = "旅遊地區")]
        public string? TravelName { get; set; }
        [Display(Name = "旅遊名稱")]
        public int? TravelareaId { get; set; }
        [Display(Name = "旅遊日期")]

        public DateTime? TravelDatetime { get; set; }
        [Display(Name = "旅遊介紹")]

        public string? TravelIntroduction { get; set; }
        [Display(Name = "旅遊集合地點")]

        public string? TravelMeetingpoint { get; set; }
        [Display(Name = "產品展示")]
        public bool? ProductShow { get; set; }
        [Display(Name = "價錢")]
        public decimal? Price { get; set; }
    }
}