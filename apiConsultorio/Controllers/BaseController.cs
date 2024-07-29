using apiConsultorio.Admins;
using apiConsultorio.Data;
using apiConsultorio.infra;
using apiConsultorio.Models.Dtos;
using apiConsultorio.Models.Entities;
using apiConsultorio.Models.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace apiConsultorio.Controllers;

public class BaseController<TE, TD, TId, TDMinRes, TF, TAdmin> : ControllerBase
    where TE : EntityBase<TId>, new ()
    where TF : BaseFilter
    where TD : BaseDto<TId>, new ()
    where TId : struct
    where TAdmin : BaseAdmin<TE, TD, TId, TDMinRes, TF>
{
    protected TAdmin Admin { get; set; }

    public BaseController(Context ctx, IMapper mapper, IHttpContextAccessor accessor)
    {
        QueryExtension.SetMapper(mapper);
        var admin = Activator.CreateInstance(typeof(TAdmin), ctx, mapper, accessor) 
            ?? throw new InvalidOperationException($"No se pudo crear una instancia de {typeof(TAdmin).FullName}.");
        Admin = (TAdmin)admin;
    }
    [HttpGet]
    public ActionResult Index([FromQuery]TF filter)
    {
        return Ok(Admin.Get(filter));
    }

    [HttpGet("{id}")]
    public ActionResult Details(TId id)
    {
        return Ok(Admin.GetById(id));
    }

    [HttpPost]
    public ActionResult Create([FromBody]TD data)
    {
        return Ok(Admin.Create(data));
    }

    [HttpPut]
    public ActionResult Update([FromBody] TD data)
    {
        return Ok(Admin.Update(data));
    }

    [HttpDelete("{id}")]
    public void Delete(TId id)
    {
        Admin.Delete(id);
    }
}
