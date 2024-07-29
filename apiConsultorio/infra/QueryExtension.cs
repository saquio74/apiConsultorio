using apiConsultorio.Models.Dtos;
using AutoMapper;

namespace apiConsultorio.infra;

public static class QueryExtension
{
    private static IMapper Mapper { get; set; }
    public static void SetMapper(IMapper mapper)
    {
        Mapper = mapper;
    }

    public static PaginatedResponse<TD> ToPaginatedResponse<T, TD>(this IQueryable<T> query, int pageNumber = 1, int pageSize = 10)
    {
        var totalItems = query.Count();
        var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return new PaginatedResponse<TD>
        {
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalItems = totalItems,
            TotalPages = totalPages,
            Data = Mapper.Map<List<TD>>(items)
        };
    }
}
