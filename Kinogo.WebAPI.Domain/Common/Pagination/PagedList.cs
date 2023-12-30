﻿using Newtonsoft.Json;

namespace Kinogo.WebAPI.Domain.Common.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public PagedList(IEnumerable<T> items, int count, int currentPage, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public string CreateMetaData()
            => JsonConvert.SerializeObject(new PaginationMetadata()
            {
                CurrentPage = CurrentPage,
                HasNext = HasNext,
                HasPrevious = HasPrevious,
                PageSize = PageSize,
                TotalCount = TotalCount,
                TotalPages = TotalPages
            });
    }
    
}
