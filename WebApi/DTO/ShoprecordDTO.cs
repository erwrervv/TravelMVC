using Travel.WebApi.Models;

namespace Travel.WebApi.DTO
{
    public class ShoprecordDTO
    {
        public int? ShopRecordid { get; set; }  // 訂單識別碼，可選 

        public string? MemberName { get; set; }


        public int? TotalPrice { get; set; }

        public string? MemberPhone { get; set; }

        public string? Address { get; set; }

        public DateTime? PurchaseTime { get; set; }

        public bool? ExchangeStatus { get; set; }

        public string? Shoporderid { get; set; }

        //這是9/24新增的部分
        public List<ShoprecordDetailDTO>? AllProducts { get; set; }


    }
}