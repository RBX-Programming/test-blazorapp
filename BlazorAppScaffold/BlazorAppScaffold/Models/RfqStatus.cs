using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class RfqStatus
{
    public int Id { get; set; }

    public string RfqStatus1 { get; set; } = null!;

    public virtual ICollection<Rfq> Rfqs { get; set; } = new List<Rfq>();
}
