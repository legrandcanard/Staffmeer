using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Staffmeer.Server.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brandname> Brandnames { get; set; }

    public virtual DbSet<Counterparty> Counterparties { get; set; }

    public virtual DbSet<Departament> Departaments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Nomenclature> Nomenclatures { get; set; }

    public virtual DbSet<NomenclatureType> NomenclatureTypes { get; set; }

    public virtual DbSet<ProvisionRecord> ProvisionRecords { get; set; }

    public virtual DbSet<ProvisionRecordType> ProvisionRecordTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brandname>(entity =>
        {
            entity.ToTable("Brandname");

            entity.Property(e => e.Name).HasMaxLength(300);
        });

        modelBuilder.Entity<Counterparty>(entity =>
        {
            entity.ToTable("Counterparty");

            entity.Property(e => e.Address).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
        });

        modelBuilder.Entity<Departament>(entity =>
        {
            entity.ToTable("Departament");

            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.FirstName).HasMaxLength(150);
            entity.Property(e => e.LastName).HasMaxLength(150);
            entity.Property(e => e.Patronymic).HasMaxLength(150);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_Departament");
        });

        modelBuilder.Entity<Nomenclature>(entity =>
        {
            entity.ToTable("Nomenclature");

            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.SerialNumber).HasMaxLength(150);

            entity.HasOne(d => d.Brandname).WithMany(p => p.Nomenclatures)
                .HasForeignKey(d => d.BrandnameId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nomenclature_Brandname");

            entity.HasOne(d => d.Counterparty).WithMany(p => p.Nomenclatures)
                .HasForeignKey(d => d.CounterpartyId)
                .HasConstraintName("FK_Nomenclature_Counterparty");

            entity.HasOne(d => d.NomenclatureType).WithMany(p => p.Nomenclatures)
                .HasForeignKey(d => d.NomenclatureTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Nomenclature_NomenclatureType");
        });

        modelBuilder.Entity<NomenclatureType>(entity =>
        {
            entity.ToTable("NomenclatureType");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<ProvisionRecord>(entity =>
        {
            entity.ToTable("ProvisionRecord");

            entity.Property(e => e.Description).HasMaxLength(1000);

            entity.HasOne(d => d.Counterparty).WithMany(p => p.ProvisionRecords)
                .HasForeignKey(d => d.CounterpartyId)
                .HasConstraintName("FK_ProvisionRecord_Counterparty");

            entity.HasOne(d => d.Employee1).WithMany(p => p.ProvisionRecordEmployee1s)
                .HasForeignKey(d => d.Employee1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProvisionRecord_Employee1");

            entity.HasOne(d => d.Employee2).WithMany(p => p.ProvisionRecordEmployee2s)
                .HasForeignKey(d => d.Employee2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProvisionRecord_Employee2");

            entity.HasOne(d => d.Nomenclature1).WithMany(p => p.ProvisionRecordNomenclature1s)
                .HasForeignKey(d => d.Nomenclature1Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProvisionRecord_Nomenclature1");

            entity.HasOne(d => d.Nomenclature2).WithMany(p => p.ProvisionRecordNomenclature2s)
                .HasForeignKey(d => d.Nomenclature2Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProvisionRecord_Nomenclature2");

            entity.HasOne(d => d.ProvisionRecordType).WithMany(p => p.ProvisionRecords)
                .HasForeignKey(d => d.ProvisionRecordTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProvisionRecord_ProvisionRecordType");
        });

        modelBuilder.Entity<ProvisionRecordType>(entity =>
        {
            entity.ToTable("ProvisionRecordType");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
