namespace HawesAndCurtis.Application.Queries
{
    public class ProductParams
    {
        private const int MaxPageSize = 70;
        private int _pageSize = 10;
        private string _search;

        public int PageIndex { get; set; } = 1;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public int? ProductId { get; set; }
        public string ProductType { get; set; }
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}