using EF.models;
using Microsoft.EntityFrameworkCore;

namespace EF.services;

public class AdventureWorksContext : DbContext
{
    public DbSet<Department> Department { get; set; } = null!;

    public DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; } = null!;

    public DbSet<EmployeePayHistory> EmployeePayHistory { get; set; } = null!;

    public DbSet<JobCandidate> JobCandidate { get; set; } = null!;

    public DbSet<Shift> Shift { get; set; } = null!;

    public AdventureWorksContext(DbContextOptions<AdventureWorksContext> options) : base(options)
    { }
}
