using Kinogo.WebAPI.Domain.Common.Contracts.Pagination.Contracts;
using Newtonsoft.Json;

namespace Kinogo.WebAPI.Host.Utilities
{
    public class PaginationParameters : IPaginationParameters
    {
        const int maxPageSize = 50;
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; } = 1;
        private int _pageSize { get; set; } = 10;
        [JsonProperty("pageSize")]
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
