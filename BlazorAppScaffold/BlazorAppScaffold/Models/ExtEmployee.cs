using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class ExtEmployee
{
    public int Id { get; set; }

    public bool Active { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public decimal HourlyCost { get; set; }

    public decimal ExtraHourlyCost { get; set; }

    public string UserId { get; set; } = null!;

    public int BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<ExtTimesheet> ExtTimesheets { get; set; } = new List<ExtTimesheet>();
}
