using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Branch
{
    public int Id { get; set; }

    public string Branch1 { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<ExtEmployee> ExtEmployees { get; set; } = new List<ExtEmployee>();

    public virtual ICollection<ExtInvoice> ExtInvoices { get; set; } = new List<ExtInvoice>();

    public virtual ICollection<ExtTimesheet> ExtTimesheets { get; set; } = new List<ExtTimesheet>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<RbxInvoice> RbxInvoices { get; set; } = new List<RbxInvoice>();

    public virtual ICollection<Rfq> Rfqs { get; set; } = new List<Rfq>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public virtual ICollection<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
}
