using System.ComponentModel.DataAnnotations;

namespace Travel.Admin.Models
{
    internal class TravelDetailMetadata
    {
        public int TravelDetailsId { get; set; }

        public int? TravelId { get; set; }
        [Display(Name = "旅遊資訊")]
        public string? TravelDetailedIntroduction { get; set; }
        [Display(Name = "旅遊巴士")]
        public bool? TourBus { get; set; }
        [Display(Name = "公車")]
        public bool? Bus { get; set; }
        [Display(Name = "火車")]
        public bool? Train { get; set; }
        [Display(Name = "早餐名稱")]
        public string? MorningName { get; set; }
        [Display(Name = "中餐名稱")]
        public string? LunchName { get; set; }
        [Display(Name = "晚餐名稱")]
        public string? DinnerName { get; set; }
        [Display(Name = "住宿名稱")]
        public string? AccommodationName { get; set; }
        [Display(Name = "天數")]
        public int? WhichDay { get; set; }
    }
}