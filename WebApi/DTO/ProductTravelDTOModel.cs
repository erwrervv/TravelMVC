namespace Travel.WebApi.DTO
{
    public class ProductTravelDTOModel
    {
        public int TravelId { get; set; }
        public int? AllDays { get; set; }
        public string TravelName { get; set; }
        public int? TravelareaId { get; set; }
        public DateTime? TravelDatetime { get; set; }
        public string TravelIntroduction { get; set; }
        public string TravelMeetingpoint { get; set; }
        public decimal? Price { get; set; }
        public string Pictures { get; set; }
    }
}
