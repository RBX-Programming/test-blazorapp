using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<ExtInvoice> ExtInvoices { get; set; } = new List<ExtInvoice>();

    public virtual ICollection<ExtTimesheet> ExtTimesheets { get; set; } = new List<ExtTimesheet>();

    public virtual ICollection<OutsourcingItem> OutsourcingItems { get; set; } = new List<OutsourcingItem>();

    public virtual ICollection<RbxInvoice> RbxInvoices { get; set; } = new List<RbxInvoice>();

    public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
}
