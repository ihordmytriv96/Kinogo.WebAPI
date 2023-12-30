using Kinogo.WebAPI.Domain.Common.Contracts.Pagination.Contracts;
using Kinogo.WebAPI.Domain.Common.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Kinogo.WebAPI.Host.Common.Controllers
{
    [ApiController]
    public abstract class BaseController : Controller
    {
        protected ActionResult<IEnumerable<T>> OkPaged<T>(IEnumerable<T> items, IPaginationParameters pagination, int itemsCount)
        {
            var pagedList = new PagedList<T>(items, itemsCount, pagination.CurrentPage, pagination.PageSize);

            Response?.Headers.Add("X-Pagination", pagedList.CreateMetaData());
            Response?.Headers.Add("Access-Control-Expose-Headers", "Content-Encoding, X-Pagination");

            return Ok(pagedList);
        }
    }
}
