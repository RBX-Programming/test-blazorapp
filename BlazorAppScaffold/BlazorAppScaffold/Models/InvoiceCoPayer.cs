using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class InvoiceCoPayer
{
    public int Id { get; set; }

    public int? CoPayersNumber { get; set; }

    public string? ClientShortName { get; set; }

    public virtual Client? ClientShortNameNavigation { get; set; }

    public virtual RbxInvoice? CoPayersNumberNavigation { get; set; }
}
