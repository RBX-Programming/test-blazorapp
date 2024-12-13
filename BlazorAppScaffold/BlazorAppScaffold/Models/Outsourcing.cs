using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Outsourcing
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? Date { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public string SupplierShortName { get; set; } = null!;

    public decimal AmountInvoiced { get; set; }

    public virtual Project ProjectNameNavigation { get; set; } = null!;

    public virtual Supplier SupplierShortNameNavigation { get; set; } = null!;
}
