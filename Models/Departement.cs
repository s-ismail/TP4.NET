using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prog.NETTp4.Models;

public partial class Departement
{
    public int IdDepartement { get; set; }

    [Required(ErrorMessage ="Le nom est obligatoire")]
    public string? Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
