using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class TypeOfWork
{
    public int Id { get; set; }

    public string TypeOfWork1 { get; set; } = null!;

    public virtual ICollection<ExtTimesheet> ExtTimesheets { get; set; } = new List<ExtTimesheet>();

    public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
}
