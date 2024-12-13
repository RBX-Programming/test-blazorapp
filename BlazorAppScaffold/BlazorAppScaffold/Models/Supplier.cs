using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Supplier
{
    public int Id { get; set; }

    public string SupplierShortName { get; set; } = null!;

    public string? SupplierFullName { get; set; }

    public int? SupplierBranch { get; set; }

    public string? SupplierReg { get; set; }

    public string? SupplierAddress { get; set; }

    public string? City { get; set; }

    public int? CountryId { get; set; }

    public string? SupplierAccount { get; set; }

    public string? SupplierSwift { get; set; }

    public int? CrmId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual Crm? Crm { get; set; }

    public virtual ICollection<ExtInvoice> ExtInvoices { get; set; } = new List<ExtInvoice>();

    public virtual Branch? SupplierBranchNavigation { get; set; }
}
