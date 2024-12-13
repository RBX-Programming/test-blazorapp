using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class CostType
{
    public int Id { get; set; }

    public string CostType1 { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
