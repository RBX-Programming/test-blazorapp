using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class SalesEcr
{
    public int Id { get; set; }

    public int RbxInvoiceId { get; set; }

    public DateOnly? Date { get; set; }

    public string? Description { get; set; }

    public virtual RbxInvoice RbxInvoice { get; set; } = null!;

    public virtual ICollection<SalesEcrItem> SalesEcrItems { get; set; } = new List<SalesEcrItem>();
}
