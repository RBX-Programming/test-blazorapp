using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Country
{
    public int Id { get; set; }

    public string? CountryName { get; set; }

    public int ContinentId { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual Continent Continent { get; set; } = null!;

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
