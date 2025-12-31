using System.Collections.Generic;

namespace gLiter.Service.DTOs;

public class PagedResponse<T> : ApiResponse<IEnumerable<T>>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public static PagedResponse<T> Ok(IEnumerable<T> data, int pageNumber, int pageSize, int totalCount)
    {
        return new PagedResponse<T>
        {
            Success = true,
            Data = data,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount,
            Meta = new { pageNumber, pageSize, totalCount }
        };
    }
}
