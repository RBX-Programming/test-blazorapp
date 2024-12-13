using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Employee
{
    public int Id { get; set; }

    public bool Active { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string? SocialSecurityNumber { get; set; }

    public decimal? HourlyCost { get; set; }

    public decimal ExtraHourlyCost { get; set; }

    public string? UserId { get; set; }

    public int BranchId { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual ICollection<Expense> ExpenseRequesters { get; set; } = new List<Expense>();

    public virtual ICollection<Expense> ExpenseValidators { get; set; } = new List<Expense>();

    public virtual ICollection<Project> ProjectProjectManagerNavigations { get; set; } = new List<Project>();

    public virtual ICollection<Project> ProjectProjectOwnerNavigations { get; set; } = new List<Project>();

    public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
}
