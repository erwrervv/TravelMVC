namespace Travel.WebApi.DTO
{
    public class MallProductTableDTO
    {
        public int MallProductTableId { get; set; }

        public string? MallProductId { get; set; }

        public string? MallProductName { get; set; }

        public int? GoldAmount { get; set; }

        public byte[]? Pimage { get; set; }
    }
}
