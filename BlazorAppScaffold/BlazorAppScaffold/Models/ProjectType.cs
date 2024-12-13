using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class ProjectType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<OutsourcingItem> OutsourcingItems { get; set; } = new List<OutsourcingItem>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<SalesEcrItem> SalesEcrItems { get; set; } = new List<SalesEcrItem>();

    public virtual ICollection<SalesItem> SalesItems { get; set; } = new List<SalesItem>();
}
