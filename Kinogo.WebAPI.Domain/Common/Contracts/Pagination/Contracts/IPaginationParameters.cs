namespace Kinogo.WebAPI.Domain.Common.Contracts.Pagination.Contracts
{
    public interface IPaginationParameters
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
