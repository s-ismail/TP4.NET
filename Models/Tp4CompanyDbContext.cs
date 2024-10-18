using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Prog.NETTp4.Models.ViewModel;

namespace Prog.NETTp4.Models;

public partial class Tp4CompanyDbContext : DbContext
{
    public Tp4CompanyDbContext()
    {
    }

    public Tp4CompanyDbContext(DbContextOptions<Tp4CompanyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departement> Departements { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departement>(entity =>
        {
            entity.HasKey(e => e.IdDepartement);

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F117C19097B");

            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.JoiningDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdDepartementNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdDepartement)
                .HasConstraintName("FK_Employees_Departements");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<Prog.NETTp4.Models.ViewModel.EmployeeVM> EmployeeVM { get; set; } = default!;
}
