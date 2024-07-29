using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiConsultorio.Models.Entities;

public class User : IdentityUser
{
    public int CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public bool Deleted { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public bool Enabled { get; set; }
}
