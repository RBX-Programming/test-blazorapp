using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Location
{
    public int Id { get; set; }

    public string? LocationName { get; set; }

    public string? CityName { get; set; }

    public int? CountryId { get; set; }

    public string? Address { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
