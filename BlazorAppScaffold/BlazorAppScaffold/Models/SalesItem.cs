using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class SalesItem
{
    public int Id { get; set; }

    public int RbxInvoiceId { get; set; }

    public string? Item { get; set; }

    public int? ItemType { get; set; }

    public decimal? OfferEuro { get; set; }

    public int? OfferCurrency { get; set; }

    public int? PercentagePaid { get; set; }

    public int? PaymentStatusId { get; set; }

    public decimal? OfferHours { get; set; }

    public string? Description { get; set; }

    public int? ItemProcessStatus { get; set; }

    public virtual ProcessStatus? ItemProcessStatusNavigation { get; set; }

    public virtual ProjectType? ItemTypeNavigation { get; set; }

    public virtual Currency? OfferCurrencyNavigation { get; set; }

    public virtual PaymentStatus? PaymentStatus { get; set; }

    public virtual RbxInvoice RbxInvoice { get; set; } = null!;
}
