using System.ComponentModel.DataAnnotations;

namespace CategoryProducts.Models
{
    internal class ProductMetadata
    {
        [Required(ErrorMessage ="ProductName不可未填寫")]
        [StringLength(40)]
        [Display(Name ="商品名稱")]
        public string ProductName { get; set; } = null!;

        [DisplayFormat(DataFormatString ="{0:C}")]
        [Display(Name = "商品單價")] 
        public decimal? UnitPrice { get; set; }
    
        [Display(Name = "訂購數量")]
        [Range(1, 100, ErrorMessage ="訂購數量必須介於1~100之間")]
        public short? UnitsOnOrder { get; set; }

    }
}