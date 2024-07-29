using apiConsultorio.Data;
using apiConsultorio.infra;
using apiConsultorio.Models.Dtos;
using apiConsultorio.Models.Entities;
using apiConsultorio.Models.Filters;
using AutoMapper;

namespace apiConsultorio.Admins;

public abstract class BaseAdmin<TE,TD,TId,TDMinRes, TF>(Context ctx, IMapper mapper, IHttpContextAccessor accessor)
    where TE : EntityBase<TId>, new()
    where TF : BaseFilter
    where TD : BaseDto<TId>, new()
    where TId : struct
{
    protected IHttpContextAccessor Accessor { get; set; } = accessor;
    private Context Context { get; set; } = ctx;
    protected IQueryable<TE> Query { get; set; } = ctx.Set<TE>();
    protected IMapper Mapper { get; set; } = mapper;
    public abstract TE SetData(TE entity, TD dto);
    public abstract IQueryable<TE> FilterData(IQueryable<TE> query, TF filter);

    public PaginatedResponse<TD> Get(TF filter)
    {
        return FilterData(Query , filter)
            .ToPaginatedResponse<TE,TD>(filter.Page ?? 1, filter.PageSize ?? 10);
    }

    public TD GetById(TId id)
    {
        return Mapper.Map<TD>(FindEntity(id));
    }

    public TD Create(TD data)
    {
        var entity = SetData(new TE(), data);
        Context.Add(entity);
        Context.SaveChanges();
        return Mapper.Map<TD>(entity);
    }

    public TD Update(TD data)
    {
        if (data is null) throw new Exception("Es necesaria la información");

        var entity = FindEntity(data.Id);
        entity = SetData(entity, data);
        
        Context.SaveChanges();
        return Mapper.Map<TD>(entity);
    }

    public void Delete(TId id)
    {
        var entity = FindEntity(id);
        
        entity.Deleted = true;
        Context.SaveChanges();
    }

    private TE FindEntity(TId id)
    {
        return Query.SingleOrDefault(e => id.Equals(e.Id) && e.Enabled && !e.Deleted)
           ?? throw new Exception($"No se encontro {typeof(TE)}");
    }
}
