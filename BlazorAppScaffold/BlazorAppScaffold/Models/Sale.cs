using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Sale
{
    public int Id { get; set; }

    public string ProjectName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateOnly? AwardedDate { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public DateOnly? LastActionDate { get; set; }

    public bool? Invoiced { get; set; }

    public decimal? CostBudget { get; set; }

    public virtual Project ProjectNameNavigation { get; set; } = null!;
}
