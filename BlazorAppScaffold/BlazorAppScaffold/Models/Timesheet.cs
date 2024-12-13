﻿using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Timesheet
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateOnly Date { get; set; }

    public int Week { get; set; }

    public int DepartmentsId { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? TaskObservation { get; set; }

    public TimeOnly? TimeIn { get; set; }

    public TimeOnly? TimeOut { get; set; }

    public TimeSpan? Break { get; set; }

    public bool Holiday { get; set; }

    public int TypeOfWorkId { get; set; }

    public bool Validation { get; set; }

    public int BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual Department Departments { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project ProjectNameNavigation { get; set; } = null!;

    public virtual TypeOfWork TypeOfWork { get; set; } = null!;
}
