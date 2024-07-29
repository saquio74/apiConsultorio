﻿namespace apiConsultorio.Models.Dtos;

public class PaginatedResponse<T>
{
    public List<T> Data { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
}
