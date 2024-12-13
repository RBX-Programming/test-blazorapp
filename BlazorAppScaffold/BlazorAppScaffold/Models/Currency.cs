using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Currency
{
    public int Id { get; set; }

    public string Coin { get; set; } = null!;

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ICollection<ExtInvoice> ExtInvoices { get; set; } = new List<ExtInvoice>();

    public virtual ICollection<OutsourcingItem> OutsourcingItems { get; set; } = new List<OutsourcingItem>();

    public virtual ICollection<RbxInvoice> RbxInvoices { get; set; } = new List<RbxInvoice>();

    public virtual ICollection<SalesEcrItem> SalesEcrItems { get; set; } = new List<SalesEcrItem>();

    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();
}
