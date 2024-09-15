namespace Travel.WebApi.ViewModels
{
    public class PageInfo
    {
        /// <summary>
        /// 一次幾筆資料
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 第幾頁
        /// </summary>
        /// <value></value>
        public int PageNumber { get; set; }
    }
}
