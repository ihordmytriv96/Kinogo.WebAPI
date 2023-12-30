using Kinogo.WebAPI.Domain.Common.Contracts.Pagination.Contracts;
using Newtonsoft.Json;

namespace Kinogo.WebAPI.Domain.Common.Pagination
{
    public class PaginationParameters 
    {
        [JsonProperty("currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
    }
}
