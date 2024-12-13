using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Crm
{
    public int Id { get; set; }

    public string? CompanyName { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? JobPosition { get; set; }

    public virtual ICollection<Client> Clients { get; set; }

    public virtual ICollection<Supplier> Suppliers { get; set; }
}
