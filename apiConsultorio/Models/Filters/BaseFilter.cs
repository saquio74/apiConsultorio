namespace apiConsultorio.Models.Filters;

public class BaseFilter
{
    public string Search { get; set; }
    public int? Page { get; set; }
    public int? PageSize { get; set; }
}
