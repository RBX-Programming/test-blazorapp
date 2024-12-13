using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Rfq
{
    public int Id { get; set; }

    public string? RfqName { get; set; }

    public DateOnly? Date { get; set; }

    public int? BranchId { get; set; }

    public string? ClientShortName { get; set; }

    public string? Description { get; set; }

    public string? RfqFolderName { get; set; }

    public int? RfqStatus { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual Client? ClientShortNameNavigation { get; set; }

    public virtual RfqStatus? RfqStatusNavigation { get; set; }
}
