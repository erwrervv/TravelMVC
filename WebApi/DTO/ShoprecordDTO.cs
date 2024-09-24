using Travel.WebApi.Models;

namespace Travel.WebApi.DTO
{
    public class ShoprecordDTO
    {

        public string? MemberName { get; set; }


        public int? TotalPrice { get; set; }

        public string? MemberPhone { get; set; }

        public string? Address { get; set; }

        public string? Shoporderid { get; set; }

        //這是9/24新增的部分
        public List<ShoprecordDetailDTO>? AllProducts { get; set; }
        

    }
}
