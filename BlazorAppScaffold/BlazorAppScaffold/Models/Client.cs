using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BlazorAppScaffold.Models;

public partial class Client
{
    public int Id { get; set; }

    public string ClientShortName { get; set; } = null!;

    public string? ClientFullName { get; set; }

    public int? ClientBranch { get; set; }

    public string? ClientReg { get; set; }

    public string? ClientAddress { get; set; }

    public string? City { get; set; }

    public int? CountryId { get; set; }

    public int? CrmId { get; set; }

    public virtual Branch? ClientBranchNavigation { get; set; }

    public virtual Country? Country { get; set; }

	[JsonIgnore]
	public virtual Crm? Crm { get; set; }

    public virtual ICollection<InvoiceCoPayer> InvoiceCoPayers { get; set; } = new List<InvoiceCoPayer>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<RbxInvoice> RbxInvoices { get; set; } = new List<RbxInvoice>();

    public virtual ICollection<Rfq> Rfqs { get; set; } = new List<Rfq>();
}
