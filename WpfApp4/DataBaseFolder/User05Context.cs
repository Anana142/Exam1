using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WpfApp4.DataBaseFolder;

public partial class User05Context : DbContext
{
    public User05Context()
    {
    }

    public User05Context(DbContextOptions<User05Context> options)
        : base(options)
    {
    }

    public virtual DbSet<HotelNumber> HotelNumbers { get; set; }

    public virtual DbSet<HotelNumbersType> HotelNumbersTypes { get; set; }

    public virtual DbSet<HotelNumbersView> HotelNumbersViews { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<TypeBed> TypeBeds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=localhost;database=user05;TrustServerCertificate=true;Trusted_Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HotelNumber>(entity =>
        {
            entity.HasKey(e => e.HotelNumbersId);

            entity.Property(e => e.HotelNumbersId).HasColumnName("HotelNumbersID");
            entity.Property(e => e.HotelNumbersBedTypeId).HasColumnName("HotelNumbersBedTypeID");
            entity.Property(e => e.HotelNumbersCost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.HotelNumbersStatusId).HasColumnName("HotelNumbersStatusID");
            entity.Property(e => e.HotelNumbersTypeId).HasColumnName("HotelNumbersTypeID");
            entity.Property(e => e.HotelNumbersViewId).HasColumnName("HotelNumbersViewID");

            entity.HasOne(d => d.HotelNumbersBedType).WithMany(p => p.HotelNumbers)
                .HasForeignKey(d => d.HotelNumbersBedTypeId)
                .HasConstraintName("FK_HotelNumbers_TypeBed");

            entity.HasOne(d => d.HotelNumbersStatus).WithMany(p => p.HotelNumbers)
                .HasForeignKey(d => d.HotelNumbersStatusId)
                .HasConstraintName("FK_HotelNumbers_Status");

            entity.HasOne(d => d.HotelNumbersType).WithMany(p => p.HotelNumbers)
                .HasForeignKey(d => d.HotelNumbersTypeId)
                .HasConstraintName("FK_HotelNumbers_HotelNumbersType");

            entity.HasOne(d => d.HotelNumbersView).WithMany(p => p.HotelNumbers)
                .HasForeignKey(d => d.HotelNumbersViewId)
                .HasConstraintName("FK_HotelNumbers_HotelNumbersView");
        });

        modelBuilder.Entity<HotelNumbersType>(entity =>
        {
            entity.HasKey(e => e.HotelNumbersId);

            entity.ToTable("HotelNumbersType");

            entity.Property(e => e.HotelNumbersId).HasColumnName("HotelNumbersID");
            entity.Property(e => e.HotelNumbersName)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<HotelNumbersView>(entity =>
        {
            entity.ToTable("HotelNumbersView");

            entity.Property(e => e.HotelNumbersViewId).HasColumnName("HotelNumbersViewID");
            entity.Property(e => e.HotelNumbersViewName)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusName)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<TypeBed>(entity =>
        {
            entity.ToTable("TypeBed");

            entity.Property(e => e.TypeBedId)
                .ValueGeneratedNever()
                .HasColumnName("TypeBedID");
            entity.Property(e => e.TypeBedName)
                .HasMaxLength(200)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
