using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class CostCategory
{
    public int Id { get; set; }

    public string CostCategory1 { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
}
