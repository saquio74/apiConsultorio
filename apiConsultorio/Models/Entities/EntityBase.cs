﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiConsultorio.Models.Entities;

public class EntityBase<T>
    where T : struct
{
    [Key]
    public T Id { get; set; }
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
