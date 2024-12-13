using System;
using System.Collections.Generic;

namespace BlazorAppScaffold.Models;

public partial class Expense
{
    public int Id { get; set; }

    public string? ProjectName { get; set; }

    public string? Comments { get; set; }

    public int? BranchId { get; set; }

    public int? ValidatorId { get; set; }

    public int? RequesterId { get; set; }

    public int? CostTypesId { get; set; }

    public int? CostCategoriesId { get; set; }

    public int? DepartmentsId { get; set; }

    public DateOnly? Date { get; set; }

    public int? PaymentTerms { get; set; }

    public DateOnly? DueDate { get; set; }

    public decimal? Cost { get; set; }

    public int? CurrencyType { get; set; }

    public decimal? ExchangeRate { get; set; }

    public decimal? NetEuro { get; set; }

    public decimal? Vat { get; set; }

    public decimal? VatEuro { get; set; }

    public decimal? Total { get; set; }

    public bool? Uploaded { get; set; }

    public bool? Paid { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public virtual Branch? Branch { get; set; }

    public virtual CostCategory? CostCategories { get; set; }

    public virtual CostType? CostTypes { get; set; }

    public virtual Currency? CurrencyTypeNavigation { get; set; }

    public virtual Department? Departments { get; set; }

    public virtual Project? ProjectNameNavigation { get; set; }

    public virtual Employee? Requester { get; set; }

    public virtual Employee? Validator { get; set; }
}
