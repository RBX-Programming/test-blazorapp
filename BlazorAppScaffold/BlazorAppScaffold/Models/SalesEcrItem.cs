using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class SalesEcrItem
{
    public int Id { get; set; }

    public int SalesEcrId { get; set; }

    public string? Item { get; set; }

    public int? ItemType { get; set; }

    public decimal? OfferEuro { get; set; }

    public int? CurrencyType { get; set; }

    public int? Percentage { get; set; }

    public int? PaymentStatusId { get; set; }

    public decimal? OfferHours { get; set; }

    public string? Description { get; set; }

    public int? ItemProcessStatus { get; set; }

    public virtual Currency? CurrencyTypeNavigation { get; set; }

    public virtual ProcessStatus? ItemProcessStatusNavigation { get; set; }

    public virtual ProjectType? ItemTypeNavigation { get; set; }

    public virtual PaymentStatus? PaymentStatus { get; set; }

    public virtual SalesEcr SalesEcr { get; set; } = null!;
}
