using System;
using System.Collections.Generic;
using BlazorAppScaffold.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppScaffold.Data;

public partial class BlazorAppContext : DbContext
{
    public BlazorAppContext()
    {
    }

    public BlazorAppContext(DbContextOptions<BlazorAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Continent> Continents { get; set; }

    public virtual DbSet<CostCategory> CostCategories { get; set; }

    public virtual DbSet<CostType> CostTypes { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Crm> Crms { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExtEmployee> ExtEmployees { get; set; }

    public virtual DbSet<ExtInvoice> ExtInvoices { get; set; }

    public virtual DbSet<ExtTimesheet> ExtTimesheets { get; set; }

    public virtual DbSet<InvoiceCoPayer> InvoiceCoPayers { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Outsourcing> Outsourcings { get; set; }

    public virtual DbSet<OutsourcingItem> OutsourcingItems { get; set; }

    public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; }

    public virtual DbSet<ProcessStatus> ProcessStatuses { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<ProjectType> ProjectTypes { get; set; }

    public virtual DbSet<RbxInvoice> RbxInvoices { get; set; }

    public virtual DbSet<Rfq> Rfqs { get; set; }

    public virtual DbSet<RfqStatus> RfqStatuses { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesEcr> SalesEcrs { get; set; }

    public virtual DbSet<SalesEcrItem> SalesEcrItems { get; set; }

    public virtual DbSet<SalesItem> SalesItems { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Timesheet> Timesheets { get; set; }

    public virtual DbSet<TypeOfWork> TypeOfWorks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=172.16.143.200;Port=9100;Database=RBX;Username=dev_user;Password=ABCde123.");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Branch>(entity =>
        {
            entity.ToTable("branches", "erp_dev");

            entity.HasIndex(e => e.Branch1, "branches_branch_index").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Branch1)
                .HasMaxLength(255)
                .HasColumnName("branch");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientShortName);

            entity.ToTable("clients", "erp_dev");

            entity.HasIndex(e => e.CrmId, "IX_clients_crm_id");

            entity.HasIndex(e => e.Id, "clients_id_index");

            entity.Property(e => e.ClientShortName)
                .HasMaxLength(255)
                .HasColumnName("client_short_name");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.ClientAddress)
                .HasMaxLength(255)
                .HasColumnName("client_address");
            entity.Property(e => e.ClientBranch).HasColumnName("client_branch");
            entity.Property(e => e.ClientFullName)
                .HasMaxLength(255)
                .HasColumnName("client_full_name");
            entity.Property(e => e.ClientReg)
                .HasMaxLength(255)
                .HasColumnName("client_reg");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CrmId).HasColumnName("crm_id");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            entity.HasOne(d => d.ClientBranchNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ClientBranch)
                .HasConstraintName("fk_clients_branches");

            entity.HasOne(d => d.Country).WithMany(p => p.Clients)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("fk_clients_countries");

            entity.HasOne(d => d.Crm).WithMany(p => p.Clients)
                .HasForeignKey(d => d.CrmId)
                .HasConstraintName("fk_clients_crm");
        });

        modelBuilder.Entity<Continent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("continents_pkey");

            entity.ToTable("continents", "erp_dev");

            entity.HasIndex(e => e.ContinentName, "continents_name_index").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContinentName)
                .HasMaxLength(255)
                .HasColumnName("continent_name");
        });

        modelBuilder.Entity<CostCategory>(entity =>
        {
            entity.ToTable("cost_categories", "erp_dev");

            entity.HasIndex(e => e.CostCategory1, "cost_categories_cost_category_index").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CostCategory1)
                .HasMaxLength(255)
                .HasColumnName("cost_category");
        });

        modelBuilder.Entity<CostType>(entity =>
        {
            entity.ToTable("cost_types", "erp_dev");

            entity.HasIndex(e => e.CostType1, "cost_types_cost_type_index").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CostType1)
                .HasMaxLength(255)
                .HasColumnName("cost_type");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("countries", "erp_dev");

            entity.HasIndex(e => e.CountryName, "country_country_name_index").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContinentId).HasColumnName("continent_id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(255)
                .HasColumnName("country_name");

            entity.HasOne(d => d.Continent).WithMany(p => p.Countries)
                .HasForeignKey(d => d.ContinentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contries_Continents");
        });

        modelBuilder.Entity<Crm>(entity =>
        {
            entity.ToTable("crm", "erp_dev");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.JobPosition)
                .HasMaxLength(255)
                .HasColumnName("job_position");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("currency_type_pkey");

            entity.ToTable("currencies", "erp_dev");

            entity.HasIndex(e => e.Coin, "currencies_coin_index").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Coin)
                .HasMaxLength(255)
                .HasColumnName("coin");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("departments", "erp_dev");

            entity.HasIndex(e => e.Name, "departments_id_name").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("employee", "erp_dev");

            entity.HasIndex(e => e.BranchId, "IX_employee_branch_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.ExtraHourlyCost).HasColumnName("extra_hourly_cost");
            entity.Property(e => e.HourlyCost).HasColumnName("hourly_cost");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.SocialSecurityNumber)
                .HasMaxLength(255)
                .HasColumnName("social_security_number");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Branch).WithMany(p => p.Employees)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Employee_Branches");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.ToTable("expenses", "erp_dev");

            entity.HasIndex(e => e.BranchId, "IX_expenses_branch_id");

            entity.HasIndex(e => e.CostCategoriesId, "IX_expenses_cost_categories_id");

            entity.HasIndex(e => e.CostTypesId, "IX_expenses_cost_types_id");

            entity.HasIndex(e => e.DepartmentsId, "IX_expenses_departments_id");

            entity.HasIndex(e => e.ProjectName, "IX_expenses_project_name");

            entity.HasIndex(e => e.RequesterId, "IX_expenses_requester_id");

            entity.HasIndex(e => e.ValidatorId, "IX_expenses_validator_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .HasColumnName("comments");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.CostCategoriesId).HasColumnName("cost_categories_id");
            entity.Property(e => e.CostTypesId).HasColumnName("cost_types_id");
            entity.Property(e => e.CurrencyType).HasColumnName("currency_type");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DepartmentsId).HasColumnName("departments_id");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.ExchangeRate).HasColumnName("exchange_rate");
            entity.Property(e => e.NetEuro).HasColumnName("net_euro");
            entity.Property(e => e.Paid).HasColumnName("paid");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentTerms).HasColumnName("payment_terms");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("project_name");
            entity.Property(e => e.RequesterId).HasColumnName("requester_id");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.Uploaded).HasColumnName("uploaded");
            entity.Property(e => e.ValidatorId).HasColumnName("validator_id");
            entity.Property(e => e.Vat).HasColumnName("vat");
            entity.Property(e => e.VatEuro).HasColumnName("vat_euro");

            entity.HasOne(d => d.Branch).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Expenses_Branches");

            entity.HasOne(d => d.CostCategories).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.CostCategoriesId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Expenses_CostCategories");

            entity.HasOne(d => d.CostTypes).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.CostTypesId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Expenses_CostTypes");

            entity.HasOne(d => d.CurrencyTypeNavigation).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.CurrencyType)
                .HasConstraintName("fk_expenses_currency_type");

            entity.HasOne(d => d.Departments).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.DepartmentsId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Expenses_Departments");

            entity.HasOne(d => d.ProjectNameNavigation).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.ProjectName)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Expenses_Projects");

            entity.HasOne(d => d.Requester).WithMany(p => p.ExpenseRequesters)
                .HasForeignKey(d => d.RequesterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Expenses_Requester");

            entity.HasOne(d => d.Validator).WithMany(p => p.ExpenseValidators)
                .HasForeignKey(d => d.ValidatorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Expenses_Validator");
        });

        modelBuilder.Entity<ExtEmployee>(entity =>
        {
            entity.ToTable("ext_employee", "erp_dev");

            entity.HasIndex(e => e.BranchId, "IX_ext_employee_branch_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.ExtraHourlyCost).HasColumnName("extra_hourly_cost");
            entity.Property(e => e.HourlyCost).HasColumnName("hourly_cost");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Branch).WithMany(p => p.ExtEmployees)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ExtEmployees_Branches");
        });

        modelBuilder.Entity<ExtInvoice>(entity =>
        {
            entity.HasKey(e => e.RbxInvNumber);

            entity.ToTable("ext_invoices", "erp_dev");

            entity.HasIndex(e => e.BranchId, "IX_ext_invoices_branch_id");

            entity.HasIndex(e => e.DepartmentsId, "IX_ext_invoices_departments_id");

            entity.HasIndex(e => e.ProjectName, "IX_ext_invoices_project_name");

            entity.HasIndex(e => e.RbxPoNumber, "IX_ext_invoices_rbx_po_number");

            entity.HasIndex(e => e.SupplierShortName, "IX_ext_invoices_supplier_short_name");

            entity.HasIndex(e => e.Id, "unq_ext_invoices_id").IsUnique();

            entity.Property(e => e.RbxInvNumber)
                .HasMaxLength(255)
                .HasColumnName("rbx_inv_number");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .HasColumnName("comments");
            entity.Property(e => e.Concept)
                .HasMaxLength(255)
                .HasColumnName("concept");
            entity.Property(e => e.CurrencyType).HasColumnName("currency_type");
            entity.Property(e => e.DepartmentsId).HasColumnName("departments_id");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.ExchangeRate).HasColumnName("exchange_rate");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.NetEuro).HasColumnName("net_euro");
            entity.Property(e => e.Paid).HasColumnName("paid");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentDays).HasColumnName("payment_days");
            entity.Property(e => e.PaymentTerms).HasColumnName("payment_terms");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("project_name");
            entity.Property(e => e.RbxPoNumber)
                .HasMaxLength(255)
                .HasColumnName("rbx_po_number");
            entity.Property(e => e.SupplierShortName)
                .HasMaxLength(255)
                .HasColumnName("supplier_short_name");
            entity.Property(e => e.TotalEuro).HasColumnName("total_euro");
            entity.Property(e => e.TotalNet).HasColumnName("total_net");
            entity.Property(e => e.Uploaded).HasColumnName("uploaded");
            entity.Property(e => e.Vat).HasColumnName("vat");

            entity.HasOne(d => d.Branch).WithMany(p => p.ExtInvoices)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ExtInvoices_Branches");

            entity.HasOne(d => d.CurrencyTypeNavigation).WithMany(p => p.ExtInvoices)
                .HasForeignKey(d => d.CurrencyType)
                .HasConstraintName("fk_ext_invoices_currencies");

            entity.HasOne(d => d.Departments).WithMany(p => p.ExtInvoices)
                .HasForeignKey(d => d.DepartmentsId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ExtInvoices_Departments");

            entity.HasOne(d => d.ProjectNameNavigation).WithMany(p => p.ExtInvoices)
                .HasForeignKey(d => d.ProjectName)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ExtInvoices_Projects");

            entity.HasOne(d => d.SupplierShortNameNavigation).WithMany(p => p.ExtInvoices)
                .HasForeignKey(d => d.SupplierShortName)
                .HasConstraintName("fk_ext_invoices_suppliers");
        });

        modelBuilder.Entity<ExtTimesheet>(entity =>
        {
            entity.ToTable("ext_timesheets", "erp_dev");

            entity.HasIndex(e => e.BranchId, "IX_ext_timesheets_branch_id");

            entity.HasIndex(e => e.DepartmentsId, "IX_ext_timesheets_departments_id");

            entity.HasIndex(e => e.ExtEmployeeId, "IX_ext_timesheets_ext_employee_id");

            entity.HasIndex(e => e.TypeOfWorkId, "IX_ext_timesheets_type_of_work_id");

            entity.HasIndex(e => e.ProjectName, "ext_timesheets_project_name_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.Break).HasColumnName("break");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DepartmentsId).HasColumnName("departments_id");
            entity.Property(e => e.ExtEmployeeId).HasColumnName("ext_employee_id");
            entity.Property(e => e.Holiday).HasColumnName("holiday");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("project_name");
            entity.Property(e => e.TaskObservation)
                .HasMaxLength(255)
                .HasColumnName("task_observation");
            entity.Property(e => e.TimeIn).HasColumnName("time_in");
            entity.Property(e => e.TimeOut).HasColumnName("time_out");
            entity.Property(e => e.TypeOfWorkId).HasColumnName("type_of_work_id");
            entity.Property(e => e.Validation).HasColumnName("validation");
            entity.Property(e => e.Week).HasColumnName("week");

            entity.HasOne(d => d.Branch).WithMany(p => p.ExtTimesheets)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ExtTimesheets_Branches");

            entity.HasOne(d => d.Departments).WithMany(p => p.ExtTimesheets)
                .HasForeignKey(d => d.DepartmentsId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ExtTimesheets_Departments");

            entity.HasOne(d => d.ExtEmployee).WithMany(p => p.ExtTimesheets)
                .HasForeignKey(d => d.ExtEmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ExtTimesheets_ExtEmployee");

            entity.HasOne(d => d.ProjectNameNavigation).WithMany(p => p.ExtTimesheets)
                .HasForeignKey(d => d.ProjectName)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ExtTimesheets_Projects");

            entity.HasOne(d => d.TypeOfWork).WithMany(p => p.ExtTimesheets)
                .HasForeignKey(d => d.TypeOfWorkId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_ExtTimesheets_TypeOfWork");
        });

        modelBuilder.Entity<InvoiceCoPayer>(entity =>
        {
            entity.ToTable("invoice_co_payers", "erp_dev");

            entity.HasIndex(e => e.CoPayersNumber, "invoice_co_payers_number_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClientShortName)
                .HasMaxLength(255)
                .HasColumnName("client_short_name");
            entity.Property(e => e.CoPayersNumber).HasColumnName("co_payers_number");

            entity.HasOne(d => d.ClientShortNameNavigation).WithMany(p => p.InvoiceCoPayers)
                .HasForeignKey(d => d.ClientShortName)
                .HasConstraintName("fk_invoice_co_payers_clients");

            entity.HasOne(d => d.CoPayersNumberNavigation).WithMany(p => p.InvoiceCoPayers)
                .HasPrincipalKey(p => p.CoPayersNumber)
                .HasForeignKey(d => d.CoPayersNumber)
                .HasConstraintName("fk_invoice_co_payers_rbx_invoices");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.ToTable("locations", "erp_dev");

            entity.HasIndex(e => e.CityName, "locations_city_name_index").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CityName)
                .HasMaxLength(255)
                .HasColumnName("city_name");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.LocationName)
                .HasMaxLength(255)
                .HasColumnName("location_name");

            entity.HasOne(d => d.Country).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Locations_Countries");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.ToTable("manufacturer", "erp_dev");

            entity.HasIndex(e => e.ManufacturerName, "manufacturer_manufacturer_name_index").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(255)
                .HasColumnName("manufacturer_name");
        });

        modelBuilder.Entity<Outsourcing>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("outsourcing", "erp_dev");

            entity.HasIndex(e => e.SupplierShortName, "IX_outsourcing_supplier_short_name");

            entity.Property(e => e.AmountInvoiced).HasColumnName("amount_invoiced");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("project_name");
            entity.Property(e => e.SupplierShortName)
                .HasMaxLength(255)
                .HasColumnName("supplier_short_name");

            entity.HasOne(d => d.ProjectNameNavigation).WithMany()
                .HasForeignKey(d => d.ProjectName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_outsourcing_projects");

            entity.HasOne(d => d.SupplierShortNameNavigation).WithMany()
                .HasForeignKey(d => d.SupplierShortName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_outsourcing_suppliers");
        });

        modelBuilder.Entity<OutsourcingItem>(entity =>
        {
            entity.ToTable("outsourcing_item", "erp_dev");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .HasColumnName("comments");
            entity.Property(e => e.CurrencyType).HasColumnName("currency_type");
            entity.Property(e => e.DepartmentsId).HasColumnName("departments_id");
            entity.Property(e => e.DoneHours).HasColumnName("done_hours");
            entity.Property(e => e.ExtInvoiceId).HasColumnName("ext_invoice_id");
            entity.Property(e => e.Item)
                .HasColumnType("character varying")
                .HasColumnName("item");
            entity.Property(e => e.ItemProcessStatus).HasColumnName("item_process_status");
            entity.Property(e => e.OfferEuro).HasColumnName("offer_euro");
            entity.Property(e => e.OfferHours).HasColumnName("offer_hours");
            entity.Property(e => e.PaymentStatusId).HasColumnName("payment_status_id");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
            entity.Property(e => e.ProjectType).HasColumnName("project_type");

            entity.HasOne(d => d.CurrencyTypeNavigation).WithMany(p => p.OutsourcingItems)
                .HasForeignKey(d => d.CurrencyType)
                .HasConstraintName("FK_OutsourcingItem_CurrencyType");

            entity.HasOne(d => d.Departments).WithMany(p => p.OutsourcingItems)
                .HasForeignKey(d => d.DepartmentsId)
                .HasConstraintName("fk_outsourcing_item_departments");

            entity.HasOne(d => d.ExtInvoice).WithMany(p => p.OutsourcingItems)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.ExtInvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_outsourcing_item_ext_invoices");

            entity.HasOne(d => d.ItemProcessStatusNavigation).WithMany(p => p.OutsourcingItems)
                .HasForeignKey(d => d.ItemProcessStatus)
                .HasConstraintName("fk_outsourcing_item_project_status");

            entity.HasOne(d => d.PaymentStatus).WithMany(p => p.OutsourcingItems)
                .HasForeignKey(d => d.PaymentStatusId)
                .HasConstraintName("fk_outsourcing_item_payment_status");

            entity.HasOne(d => d.ProjectTypeNavigation).WithMany(p => p.OutsourcingItems)
                .HasForeignKey(d => d.ProjectType)
                .HasConstraintName("fk_outsourcing_item_project_type");
        });

        modelBuilder.Entity<PaymentStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_payment_status");

            entity.ToTable("payment_status", "erp_dev");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
        });

        modelBuilder.Entity<ProcessStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_project_status");

            entity.ToTable("process_status", "erp_dev");

            entity.HasIndex(e => e.Status, "project_status_status_index").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectName);

            entity.ToTable("projects", "erp_dev");

            entity.HasIndex(e => e.BranchId, "IX_projects_branch_id");

            entity.HasIndex(e => e.ClientShortName, "IX_projects_client_short_name");

            entity.HasIndex(e => e.ManufacturerId, "IX_projects_manufacturer_id");

            entity.HasIndex(e => e.ProjectManager, "IX_projects_project_manager");

            entity.HasIndex(e => e.ProjectOwner, "IX_projects_project_owner");

            entity.HasIndex(e => e.ProjectStatusId, "IX_projects_project_status_id");

            entity.HasIndex(e => e.ProjectTypeId, "IX_projects_project_type_id");

            entity.HasIndex(e => e.Id, "projects_id_index");

            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("project_name");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.ClientShortName)
                .HasMaxLength(255)
                .HasColumnName("client_short_name");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.FinishDate).HasColumnName("finish_date");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");
            entity.Property(e => e.Models).HasColumnName("models");
            entity.Property(e => e.Plcs).HasColumnName("plcs");
            entity.Property(e => e.ProjectManager).HasColumnName("project_manager");
            entity.Property(e => e.ProjectOwner).HasColumnName("project_owner");
            entity.Property(e => e.ProjectStatusId).HasColumnName("project_status_id");
            entity.Property(e => e.ProjectTypeId).HasColumnName("project_type_id");
            entity.Property(e => e.Revenue).HasColumnName("revenue");
            entity.Property(e => e.Robots).HasColumnName("robots");
            entity.Property(e => e.StartDate).HasColumnName("start_date");

            entity.HasOne(d => d.Branch).WithMany(p => p.Projects)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Projects_Branches");

            entity.HasOne(d => d.ClientShortNameNavigation).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ClientShortName)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Projects_Clients");

            entity.HasOne(d => d.Location).WithMany(p => p.Projects)
                .HasForeignKey(d => d.LocationId)
                .HasConstraintName("fk_projects_locations");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ManufacturerId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Projects_Manufacturer");

            entity.HasOne(d => d.ProjectManagerNavigation).WithMany(p => p.ProjectProjectManagerNavigations)
                .HasForeignKey(d => d.ProjectManager)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Projects_ProjectManager");

            entity.HasOne(d => d.ProjectOwnerNavigation).WithMany(p => p.ProjectProjectOwnerNavigations)
                .HasForeignKey(d => d.ProjectOwner)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Projects_ProjectOwner");

            entity.HasOne(d => d.ProjectStatus).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectStatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Projects_ProjectStatus");

            entity.HasOne(d => d.ProjectType).WithMany(p => p.Projects)
                .HasForeignKey(d => d.ProjectTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Projects_ProjectType");
        });

        modelBuilder.Entity<ProjectType>(entity =>
        {
            entity.ToTable("project_type", "erp_dev");

            entity.HasIndex(e => e.Type, "project_type_type_index").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<RbxInvoice>(entity =>
        {
            entity.HasKey(e => e.RbxInvNumber);

            entity.ToTable("rbx_invoices", "erp_dev");

            entity.HasIndex(e => e.BranchId, "IX_rbx_invoices_branch_id");

            entity.HasIndex(e => e.ClientPoNumber, "IX_rbx_invoices_client_po_number");

            entity.HasIndex(e => e.ClientShortName, "IX_rbx_invoices_client_short_name");

            entity.HasIndex(e => e.CoPayersNumber, "IX_rbx_invoices_co_payers_number").IsUnique();

            entity.HasIndex(e => e.DepartmentsId, "IX_rbx_invoices_departments_id");

            entity.HasIndex(e => e.ProjectName, "IX_rbx_invoices_project_name");

            entity.HasIndex(e => e.Id, "rbx_invoices_id_index").IsUnique();

            entity.Property(e => e.RbxInvNumber)
                .HasMaxLength(255)
                .HasColumnName("rbx_inv_number");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.ClientPoNumber)
                .HasMaxLength(255)
                .HasColumnName("client_po_number");
            entity.Property(e => e.ClientShortName)
                .HasMaxLength(255)
                .HasColumnName("client_short_name");
            entity.Property(e => e.CoPayersNumber)
                .IsRequired()
                .HasColumnName("co_payers_number");
            entity.Property(e => e.Comments)
                .HasMaxLength(255)
                .HasColumnName("comments");
            entity.Property(e => e.CurrencyType).HasColumnName("currency_type");
            entity.Property(e => e.DepartmentsId).HasColumnName("departments_id");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.ExchangeRate).HasColumnName("exchange_rate");
            entity.Property(e => e.ExpDate).HasColumnName("exp_date");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.NetEuro).HasColumnName("net_euro");
            entity.Property(e => e.Paid).HasColumnName("paid");
            entity.Property(e => e.Payer).HasColumnName("payer");
            entity.Property(e => e.PaymentDate).HasColumnName("payment_date");
            entity.Property(e => e.PaymentDays).HasColumnName("payment_days");
            entity.Property(e => e.PaymentTerms).HasColumnName("payment_terms");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("project_name");
            entity.Property(e => e.Sent).HasColumnName("sent");
            entity.Property(e => e.TotalEuro).HasColumnName("total_euro");
            entity.Property(e => e.TotalNet).HasColumnName("total_net");
            entity.Property(e => e.Uploaded).HasColumnName("uploaded");
            entity.Property(e => e.Vat).HasColumnName("vat");
            entity.Property(e => e.VatEuro).HasColumnName("vat_euro");

            entity.HasOne(d => d.Branch).WithMany(p => p.RbxInvoices)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rbx_invoices_branches");

            entity.HasOne(d => d.ClientShortNameNavigation).WithMany(p => p.RbxInvoices)
                .HasForeignKey(d => d.ClientShortName)
                .HasConstraintName("fk_rbx_invoices_clients");

            entity.HasOne(d => d.CurrencyTypeNavigation).WithMany(p => p.RbxInvoices)
                .HasForeignKey(d => d.CurrencyType)
                .HasConstraintName("fk_rbx_invoices_currencies");

            entity.HasOne(d => d.Departments).WithMany(p => p.RbxInvoices)
                .HasForeignKey(d => d.DepartmentsId)
                .HasConstraintName("fk_rbx_invoices_departments");

            entity.HasOne(d => d.ProjectNameNavigation).WithMany(p => p.RbxInvoices)
                .HasForeignKey(d => d.ProjectName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rbx_invoices_projects");
        });

        modelBuilder.Entity<Rfq>(entity =>
        {
            entity.ToTable("rfq", "erp_dev");

            entity.HasIndex(e => e.BranchId, "IX_rfq_branch_id");

            entity.HasIndex(e => e.ClientShortName, "IX_rfq_client_short_name");

            entity.HasIndex(e => e.RfqStatus, "unq_rfq_rfq_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.ClientShortName)
                .HasMaxLength(255)
                .HasColumnName("client_short_name");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.RfqFolderName)
                .HasMaxLength(255)
                .HasColumnName("rfq_folder_name");
            entity.Property(e => e.RfqName)
                .HasMaxLength(255)
                .HasColumnName("rfq_name");
            entity.Property(e => e.RfqStatus).HasColumnName("rfq_status");

            entity.HasOne(d => d.Branch).WithMany(p => p.Rfqs)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Rfqs_Branches");

            entity.HasOne(d => d.ClientShortNameNavigation).WithMany(p => p.Rfqs)
                .HasForeignKey(d => d.ClientShortName)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Rfqs_Clients");

            entity.HasOne(d => d.RfqStatusNavigation).WithMany(p => p.Rfqs)
                .HasForeignKey(d => d.RfqStatus)
                .HasConstraintName("fk_rfq_rfq_status");
        });

        modelBuilder.Entity<RfqStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rfq_status_pkey");

            entity.ToTable("rfq_status", "erp_dev");

            entity.HasIndex(e => e.RfqStatus1, "trfq_status_rfq_status_index").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RfqStatus1)
                .HasMaxLength(255)
                .HasColumnName("rfq_status");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sales_id_index");

            entity.ToTable("sales", "erp_dev");

            entity.HasIndex(e => e.ProjectName, "unq_sales_project_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AwardedDate).HasColumnName("awarded_date");
            entity.Property(e => e.CostBudget).HasColumnName("cost_budget");
            entity.Property(e => e.DeliveryDate).HasColumnName("delivery_date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Invoiced).HasColumnName("invoiced");
            entity.Property(e => e.LastActionDate).HasColumnName("last_action_date");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("project_name");

            entity.HasOne(d => d.ProjectNameNavigation).WithOne(p => p.Sale)
                .HasForeignKey<Sale>(d => d.ProjectName)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Sales_Projects");
        });

        modelBuilder.Entity<SalesEcr>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sales_ecr");

            entity.ToTable("sales_ecr", "erp_dev");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.RbxInvoiceId).HasColumnName("rbx_invoice_id");

            entity.HasOne(d => d.RbxInvoice).WithMany(p => p.SalesEcrs)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.RbxInvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sales_ecr_rbx_invoices");
        });

        modelBuilder.Entity<SalesEcrItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sales_ecr_item");

            entity.ToTable("sales_ecr_item", "erp_dev");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CurrencyType).HasColumnName("currency_type");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Item)
                .HasMaxLength(255)
                .HasColumnName("item");
            entity.Property(e => e.ItemProcessStatus).HasColumnName("item_process_status");
            entity.Property(e => e.ItemType).HasColumnName("item_type");
            entity.Property(e => e.OfferEuro).HasColumnName("offer_euro");
            entity.Property(e => e.OfferHours).HasColumnName("offer_hours");
            entity.Property(e => e.PaymentStatusId).HasColumnName("payment_status_id");
            entity.Property(e => e.Percentage).HasColumnName("percentage");
            entity.Property(e => e.SalesEcrId).HasColumnName("sales_ecr_id");

            entity.HasOne(d => d.CurrencyTypeNavigation).WithMany(p => p.SalesEcrItems)
                .HasForeignKey(d => d.CurrencyType)
                .HasConstraintName("fk_sales_ecr_item_currencies");

            entity.HasOne(d => d.ItemProcessStatusNavigation).WithMany(p => p.SalesEcrItems)
                .HasForeignKey(d => d.ItemProcessStatus)
                .HasConstraintName("fk_sales_ecr_item_process_status");

            entity.HasOne(d => d.ItemTypeNavigation).WithMany(p => p.SalesEcrItems)
                .HasForeignKey(d => d.ItemType)
                .HasConstraintName("fk_sales_ecr_item_project_type");

            entity.HasOne(d => d.PaymentStatus).WithMany(p => p.SalesEcrItems)
                .HasForeignKey(d => d.PaymentStatusId)
                .HasConstraintName("fk_sales_ecr_item_payment_status");

            entity.HasOne(d => d.SalesEcr).WithMany(p => p.SalesEcrItems)
                .HasForeignKey(d => d.SalesEcrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sales_ecr_item_sales_ecr");
        });

        modelBuilder.Entity<SalesItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sales_item");

            entity.ToTable("sales_item", "erp_dev");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Item)
                .HasMaxLength(255)
                .HasColumnName("item");
            entity.Property(e => e.ItemProcessStatus).HasColumnName("item_process_status");
            entity.Property(e => e.ItemType).HasColumnName("item_type");
            entity.Property(e => e.OfferCurrency).HasColumnName("offer_currency");
            entity.Property(e => e.OfferEuro).HasColumnName("offer_euro");
            entity.Property(e => e.OfferHours).HasColumnName("offer_hours");
            entity.Property(e => e.PaymentStatusId).HasColumnName("payment_status_id");
            entity.Property(e => e.PercentagePaid).HasColumnName("percentage_paid");
            entity.Property(e => e.RbxInvoiceId).HasColumnName("rbx_invoice_id");

            entity.HasOne(d => d.ItemProcessStatusNavigation).WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.ItemProcessStatus)
                .HasConstraintName("fk_sales_item_process_status");

            entity.HasOne(d => d.ItemTypeNavigation).WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.ItemType)
                .HasConstraintName("fk_sales_item_project_type");

            entity.HasOne(d => d.OfferCurrencyNavigation).WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.OfferCurrency)
                .HasConstraintName("fk_sales_item_currencies");

            entity.HasOne(d => d.PaymentStatus).WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.PaymentStatusId)
                .HasConstraintName("fk_sales_item_payment_status");

            entity.HasOne(d => d.RbxInvoice).WithMany(p => p.SalesItems)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.RbxInvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sales_item_rbx_invoices");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierShortName);

            entity.ToTable("suppliers", "erp_dev");

            entity.HasIndex(e => e.CrmId, "IX_suppliers_crm_id");

            entity.HasIndex(e => e.Id, "suppliers_id_index");

            entity.HasIndex(e => e.CountryId, "unq_suppliers_country_id");

            entity.Property(e => e.SupplierShortName)
                .HasMaxLength(255)
                .HasColumnName("supplier_short_name");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.CrmId).HasColumnName("crm_id");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.SupplierAccount)
                .HasMaxLength(255)
                .HasColumnName("supplier_account");
            entity.Property(e => e.SupplierAddress)
                .HasMaxLength(255)
                .HasColumnName("supplier_address");
            entity.Property(e => e.SupplierBranch).HasColumnName("supplier_branch");
            entity.Property(e => e.SupplierFullName)
                .HasMaxLength(255)
                .HasColumnName("supplier_full_name");
            entity.Property(e => e.SupplierReg)
                .HasMaxLength(255)
                .HasColumnName("supplier_reg");
            entity.Property(e => e.SupplierSwift)
                .HasMaxLength(255)
                .HasColumnName("supplier_swift");

            entity.HasOne(d => d.Country).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("fk_suppliers_countries");

            entity.HasOne(d => d.Crm).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.CrmId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Suppliers_Crm");

            entity.HasOne(d => d.SupplierBranchNavigation).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.SupplierBranch)
                .HasConstraintName("fk_suppliers_branches");
        });

        modelBuilder.Entity<Timesheet>(entity =>
        {
            entity.ToTable("timesheets", "erp_dev");

            entity.HasIndex(e => e.BranchId, "IX_timesheets_branch_id");

            entity.HasIndex(e => e.DepartmentsId, "IX_timesheets_departments_id");

            entity.HasIndex(e => e.EmployeeId, "IX_timesheets_employee_id");

            entity.HasIndex(e => e.ProjectName, "IX_timesheets_project_name");

            entity.HasIndex(e => e.TypeOfWorkId, "IX_timesheets_type_of_work_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchId).HasColumnName("branch_id");
            entity.Property(e => e.Break).HasColumnName("break");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DepartmentsId).HasColumnName("departments_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.Holiday).HasColumnName("holiday");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(255)
                .HasColumnName("project_name");
            entity.Property(e => e.TaskObservation)
                .HasMaxLength(255)
                .HasColumnName("task_observation");
            entity.Property(e => e.TimeIn).HasColumnName("time_in");
            entity.Property(e => e.TimeOut).HasColumnName("time_out");
            entity.Property(e => e.TypeOfWorkId).HasColumnName("type_of_work_id");
            entity.Property(e => e.Validation).HasColumnName("validation");
            entity.Property(e => e.Week).HasColumnName("week");

            entity.HasOne(d => d.Branch).WithMany(p => p.Timesheets)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Timesheet_Branches");

            entity.HasOne(d => d.Departments).WithMany(p => p.Timesheets)
                .HasForeignKey(d => d.DepartmentsId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Timesheets_Departments");

            entity.HasOne(d => d.Employee).WithMany(p => p.Timesheets)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Timesheets_Employee");

            entity.HasOne(d => d.ProjectNameNavigation).WithMany(p => p.Timesheets)
                .HasForeignKey(d => d.ProjectName)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Timesheets_Projects");

            entity.HasOne(d => d.TypeOfWork).WithMany(p => p.Timesheets)
                .HasForeignKey(d => d.TypeOfWorkId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Timesheets_TypeOfWork");
        });

        modelBuilder.Entity<TypeOfWork>(entity =>
        {
            entity.ToTable("type_of_work", "erp_dev");

            entity.HasIndex(e => e.TypeOfWork1, "type_of_work_type_of_work_index").HasAnnotation("Npgsql:StorageParameter:deduplicate_items", "false");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TypeOfWork1)
                .HasMaxLength(255)
                .HasColumnName("type_of_work");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
