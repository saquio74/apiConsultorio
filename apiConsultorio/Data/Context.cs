using apiConsultorio.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace apiConsultorio.Data;

public class Context(DbContextOptions opt) : IdentityDbContext<User>(opt)
{

}
