using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class ExtInvoice
{
    public int Id { get; set; }

    public string RbxInvNumber { get; set; } = null!;

    public string? RbxPoNumber { get; set; }

    public int? BranchId { get; set; }

    public string? SupplierShortName { get; set; }

    public string? ProjectName { get; set; }

    public string? Comments { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public int? PaymentTerms { get; set; }

    public DateOnly? DueDate { get; set; }

    public decimal? TotalNet { get; set; }

    public int? CurrencyType { get; set; }

    public decimal? ExchangeRate { get; set; }

    public decimal? NetEuro { get; set; }

    public decimal? Vat { get; set; }

    public decimal? TotalEuro { get; set; }

    public int? DepartmentsId { get; set; }

    public bool? Uploaded { get; set; }

    public bool? Paid { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public int? PaymentDays { get; set; }

    public string? Concept { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Currency? CurrencyTypeNavigation { get; set; }

    public virtual Department? Departments { get; set; }

    public virtual ICollection<OutsourcingItem> OutsourcingItems { get; set; } = new List<OutsourcingItem>();

    public virtual Project? ProjectNameNavigation { get; set; }

    public virtual Supplier? SupplierShortNameNavigation { get; set; }
}
