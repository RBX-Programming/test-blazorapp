using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Project
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public DateOnly? Date { get; set; }

    public string? Description { get; set; }

    public int? BranchId { get; set; }

    public int? ProjectStatusId { get; set; }

    public string? ClientShortName { get; set; }

    public int? ManufacturerId { get; set; }

    public int? LocationId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? FinishDate { get; set; }

    public int? Models { get; set; }

    public int? Plcs { get; set; }

    public int? Robots { get; set; }

    public decimal? Revenue { get; set; }

    public int? ProjectOwner { get; set; }

    public int? ProjectManager { get; set; }

    public int? ProjectTypeId { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Client? ClientShortNameNavigation { get; set; }

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<ExtInvoice> ExtInvoices { get; set; } = new List<ExtInvoice>();

    public virtual ICollection<ExtTimesheet> ExtTimesheets { get; set; } = new List<ExtTimesheet>();

    public virtual Location? Location { get; set; }

    public virtual Manufacturer? Manufacturer { get; set; }

    public virtual Employee? ProjectManagerNavigation { get; set; }

    public virtual Employee? ProjectOwnerNavigation { get; set; }

    public virtual ProcessStatus? ProjectStatus { get; set; }

    public virtual ProjectType? ProjectType { get; set; }

    public virtual ICollection<RbxInvoice> RbxInvoices { get; set; } = new List<RbxInvoice>();

    public virtual Sale? Sale { get; set; }

    public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
}
