using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class OutsourcingItem
{
    public int Id { get; set; }

    public int ExtInvoiceId { get; set; }

    public string? Item { get; set; }

    public int? ProjectType { get; set; }

    public decimal? OfferEuro { get; set; }

    public int? CurrencyType { get; set; }

    public int? Percentage { get; set; }

    public decimal? OfferHours { get; set; }

    public int? DepartmentsId { get; set; }

    public decimal? DoneHours { get; set; }

    public int? ItemProcessStatus { get; set; }

    public string? Comments { get; set; }

    public int? PaymentStatusId { get; set; }

    public virtual Currency? CurrencyTypeNavigation { get; set; }

    public virtual Department? Departments { get; set; }

    public virtual ExtInvoice ExtInvoice { get; set; } = null!;

    public virtual ProcessStatus? ItemProcessStatusNavigation { get; set; }

    public virtual PaymentStatus? PaymentStatus { get; set; }

    public virtual ProjectType? ProjectTypeNavigation { get; set; }
}
