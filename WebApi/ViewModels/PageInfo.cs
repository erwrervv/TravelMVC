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
        /// <summary>
        /// 搜尋關鍵字
        /// </summary>
        public string? SearchKeyword{ get; set; }
        /// <summary>
        /// 搜尋Tag
        /// </summary>
        public string? SearchTagName { get; set; }
    }
}
