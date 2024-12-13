using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class RbxInvoice
{
    public int Id { get; set; }

    public string RbxInvNumber { get; set; } = null!;

    public string? ClientPoNumber { get; set; }

    public string ProjectName { get; set; } = null!;

    public int BranchId { get; set; }

    public string? ClientShortName { get; set; }

    public string? Comments { get; set; }

    public DateOnly? ExpDate { get; set; }

    public int? PaymentTerms { get; set; }

    public DateOnly? DueDate { get; set; }

    public decimal? TotalNet { get; set; }

    public int? CurrencyType { get; set; }

    public decimal? ExchangeRate { get; set; }

    public decimal? NetEuro { get; set; }

    public decimal? Vat { get; set; }

    public decimal? VatEuro { get; set; }

    public decimal? TotalEuro { get; set; }

    public int? DepartmentsId { get; set; }

    public bool? Sent { get; set; }

    public bool? Uploaded { get; set; }

    public bool? Payer { get; set; }

    public bool? Paid { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public int? PaymentDays { get; set; }

    public int? CoPayersNumber { get; set; }

    public virtual Branch Branch { get; set; } = null!;

    public virtual Client? ClientShortNameNavigation { get; set; }

    public virtual Currency? CurrencyTypeNavigation { get; set; }

    public virtual Department? Departments { get; set; }

    public virtual ICollection<InvoiceCoPayer> InvoiceCoPayers { get; set; } = new List<InvoiceCoPayer>();

    public virtual Project ProjectNameNavigation { get; set; } = null!;

    public virtual ICollection<SalesEcr> SalesEcrs { get; set; } = new List<SalesEcr>();

    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();
}
