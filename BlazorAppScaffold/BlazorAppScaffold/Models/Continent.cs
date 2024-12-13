using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Continent
{
    public int Id { get; set; }

    public string? ContinentName { get; set; }

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}
