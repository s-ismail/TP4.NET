﻿using System;
using System.Collections.Generic;

namespace Prog.NETTp4.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Designation { get; set; }

    public decimal Salary { get; set; }

    public DateTime JoiningDate { get; set; }

    public int? IdDepartement { get; set; }

    public virtual Departement? IdDepartementNavigation { get; set; }
}
