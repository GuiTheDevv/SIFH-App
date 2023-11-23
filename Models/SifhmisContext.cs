using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SIFHApp.Models;

public partial class SifhmisContext : DbContext
{
    public SifhmisContext()
    {
    }

    public SifhmisContext(DbContextOptions<SifhmisContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airline> Airlines { get; set; }

    public virtual DbSet<Conductor> Conductors { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerFile> CustomerFiles { get; set; }

    public virtual DbSet<GradeClass> GradeClasses { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<NextOrderNumber> NextOrderNumbers { get; set; }

    public virtual DbSet<PackingList> PackingLists { get; set; }

    public virtual DbSet<PackingListDetail> PackingListDetails { get; set; }

    public virtual DbSet<PackingListListView> PackingListListViews { get; set; }

    public virtual DbSet<PackingListReport> PackingListReports { get; set; }

    public virtual DbSet<PackingListReport1> PackingListReports1 { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductStatusClass> ProductStatusClasses { get; set; }

    public virtual DbSet<ProductUnitPriceHistoryListView> ProductUnitPriceHistoryListViews { get; set; }

    public virtual DbSet<ProductUnitePriceHistory> ProductUnitePriceHistories { get; set; }

    public virtual DbSet<ReceivingNote> ReceivingNotes { get; set; }

    public virtual DbSet<ReceivingNoteItem> ReceivingNoteItems { get; set; }

    public virtual DbSet<ReceivingNoteItemListView> ReceivingNoteItemListViews { get; set; }

    public virtual DbSet<ReceivingNoteListView> ReceivingNoteListViews { get; set; }

    public virtual DbSet<ReceivingNoteProductBreakdownListView> ReceivingNoteProductBreakdownListViews { get; set; }

    public virtual DbSet<StatusClass> StatusClasses { get; set; }

    public virtual DbSet<Truck> Trucks { get; set; }

    public virtual DbSet<Vessel> Vessels { get; set; }

    public virtual DbSet<VesselCertificate> VesselCertificates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("data source=mis.sifishhouse.com;initial catalog=sifhmis;user id=bgreene;password=@Kw5408bi;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("bgreene");

        modelBuilder.Entity<Airline>(entity =>
        {
            entity.ToTable("Airline", "dbo");

            entity.Property(e => e.AirlineId).HasColumnName("AirlineID");
            entity.Property(e => e.AirlineName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Conductor>(entity =>
        {
            entity.HasKey(e => e.ConductorId).HasName("PK__Conducto__BDDAB6E0CCC1FA76");

            entity.ToTable("Conductor");

            entity.Property(e => e.ConductorId).HasColumnName("ConductorID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LicenseNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer", "dbo");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CustomerFile>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
        });

        modelBuilder.Entity<GradeClass>(entity =>
        {
            entity.ToTable("GradeClass", "dbo");

            entity.Property(e => e.GradeClassId)
                .ValueGeneratedNever()
                .HasColumnName("GradeClassID");
            entity.Property(e => e.GradeClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory", "dbo");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<NextOrderNumber>(entity =>
        {
            entity.ToTable("NextOrderNumber", "dbo");

            entity.Property(e => e.NextOrderNumberId)
                .ValueGeneratedNever()
                .HasColumnName("NextOrderNumberID");
        });

        modelBuilder.Entity<PackingList>(entity =>
        {
            entity.ToTable("PackingList", "dbo");

            entity.Property(e => e.PackingListId).HasColumnName("PackingListID");
            entity.Property(e => e.AirlineId).HasColumnName("AirlineID");
            entity.Property(e => e.BoatName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductionDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReceivingNoteItemId).HasColumnName("ReceivingNoteItemID");
            entity.Property(e => e.StatusClassId).HasColumnName("StatusClassID");
            entity.Property(e => e.Weight).HasColumnType("decimal(9, 2)");

            entity.HasOne(d => d.Airline).WithMany(p => p.PackingLists)
                .HasForeignKey(d => d.AirlineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PackingList_Airline");

            entity.HasOne(d => d.Customer).WithMany(p => p.PackingLists)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PackingList_Customer");
        });

        modelBuilder.Entity<PackingListDetail>(entity =>
        {
            entity.HasKey(e => e.PackingListDetailsId);

            entity.Property(e => e.PackingListDetailsId).HasColumnName("PackingListDetailsID");
            entity.Property(e => e.PackingListId).HasColumnName("PackingListID");
            entity.Property(e => e.ReceivingNoteItemId).HasColumnName("ReceivingNoteItemID");
        });

        modelBuilder.Entity<PackingListListView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("PackingListListView", "dbo");

            entity.Property(e => e.AirlineName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PackingListId).HasColumnName("PackingListID");
            entity.Property(e => e.StatusClassId).HasColumnName("StatusClassID");
            entity.Property(e => e.StatusClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PackingListReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_PakcingListReport");

            entity.ToTable("PackingListReport");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BoatName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Weight).HasColumnType("decimal(9, 0)");
        });

        modelBuilder.Entity<PackingListReport1>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.PackingListReport");

            entity.ToTable("PackingListReport", "dbo");

            entity.Property(e => e.AirlineId).HasColumnName("AirlineID");
            entity.Property(e => e.BoatName).HasMaxLength(50);
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.InvoiceNumber).HasMaxLength(50);
            entity.Property(e => e.PackingListId).HasColumnName("PackingListID");
            entity.Property(e => e.StatusClassId).HasColumnName("StatusClassID");
            entity.Property(e => e.Weight).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product", "dbo");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("ProductID");
            entity.Property(e => e.CurrentUnitPrice).HasColumnType("money");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductStatusClass>(entity =>
        {
            entity.ToTable("ProductStatusClass", "dbo");

            entity.Property(e => e.ProductStatusClassId)
                .ValueGeneratedNever()
                .HasColumnName("ProductStatusClassID");
            entity.Property(e => e.ProductStatusClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductUnitPriceHistoryListView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ProductUnitPriceHistoryListView", "dbo");

            entity.Property(e => e.DateChanged).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductUnitPriceHistoryId).HasColumnName("ProductUnitPriceHistoryID");
            entity.Property(e => e.UnitPriceNew).HasColumnType("money");
            entity.Property(e => e.UnitPriceOld).HasColumnType("money");
        });

        modelBuilder.Entity<ProductUnitePriceHistory>(entity =>
        {
            entity.HasKey(e => e.ProductUnitPriceHistoryId);

            entity.ToTable("ProductUnitePriceHistory", "dbo");

            entity.Property(e => e.ProductUnitPriceHistoryId).HasColumnName("ProductUnitPriceHistoryID");
            entity.Property(e => e.DateChanged).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UnitPriceNew).HasColumnType("money");
            entity.Property(e => e.UnitPriceOld).HasColumnType("money");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductUnitePriceHistories)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductUnitePriceHistory_Product");
        });

        modelBuilder.Entity<ReceivingNote>(entity =>
        {
            entity.ToTable("ReceivingNote", "dbo");

            entity.Property(e => e.ReceivingNoteId).HasColumnName("ReceivingNoteID");
            entity.Property(e => e.CheckNumber1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CheckNumber2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusClassId).HasColumnName("StatusClassID");
            entity.Property(e => e.TotalPayments).HasColumnType("money");
            entity.Property(e => e.VesselId).HasColumnName("VesselID");

            entity.HasOne(d => d.StatusClass).WithMany(p => p.ReceivingNotes)
                .HasForeignKey(d => d.StatusClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivingNote_StatusClass");

            entity.HasOne(d => d.Vessel).WithMany(p => p.ReceivingNotes)
                .HasForeignKey(d => d.VesselId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivingNote_Vessel");
        });

        modelBuilder.Entity<ReceivingNoteItem>(entity =>
        {
            entity.ToTable("ReceivingNoteItem", "dbo");

            entity.Property(e => e.ReceivingNoteItemId).HasColumnName("ReceivingNoteItemID");
            entity.Property(e => e.GradeClassId).HasColumnName("GradeClassID");
            entity.Property(e => e.LineTotal)
                .HasComputedColumnSql("([UnitPrice]*[Quantity])", true)
                .HasColumnType("decimal(38, 6)");
            entity.Property(e => e.PackingListId).HasColumnName("PackingListID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductStatusClassId)
                .HasDefaultValueSql("((10))")
                .HasColumnName("ProductStatusClassID");
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReceivingNoteId).HasColumnName("ReceivingNoteID");
            entity.Property(e => e.SpeciesCode)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Temperature).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("money");

            entity.HasOne(d => d.GradeClass).WithMany(p => p.ReceivingNoteItems)
                .HasForeignKey(d => d.GradeClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivingNoteItem_GradeClass");

            entity.HasOne(d => d.PackingList).WithMany(p => p.ReceivingNoteItems)
                .HasForeignKey(d => d.PackingListId)
                .HasConstraintName("FK_ReceivingNoteItem_PackingList");

            entity.HasOne(d => d.Product).WithMany(p => p.ReceivingNoteItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivingNoteItem_Product");

            entity.HasOne(d => d.ProductStatusClass).WithMany(p => p.ReceivingNoteItems)
                .HasForeignKey(d => d.ProductStatusClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReceivingNoteItem_ProductStatusClass");

            entity.HasOne(d => d.ReceivingNote).WithMany(p => p.ReceivingNoteItems)
                .HasForeignKey(d => d.ReceivingNoteId)
                .HasConstraintName("FK_ReceivingNoteItem_ReceivingNote");
        });

        modelBuilder.Entity<ReceivingNoteItemListView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ReceivingNoteItemListView", "dbo");

            entity.Property(e => e.CurrentUnitPrice).HasColumnType("money");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GradeClassId).HasColumnName("GradeClassID");
            entity.Property(e => e.GradeClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LineTotal).HasColumnType("decimal(38, 6)");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PackingListId).HasColumnName("PackingListID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductStatusClassId).HasColumnName("ProductStatusClassID");
            entity.Property(e => e.ProductStatusClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ReceivingNoteId).HasColumnName("ReceivingNoteID");
            entity.Property(e => e.ReceivingNoteItemId).HasColumnName("ReceivingNoteItemID");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SpeciesCode)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Temperature).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("money");
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
            entity.Property(e => e.VesselName)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReceivingNoteListView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ReceivingNoteListView", "dbo");

            entity.Property(e => e.Address)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.AveragePrice).HasColumnType("money");
            entity.Property(e => e.CheckNumber1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CheckNumber2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.OrderTotal).HasColumnType("money");
            entity.Property(e => e.ReceivingNoteId).HasColumnName("ReceivingNoteID");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusClassId).HasColumnName("StatusClassID");
            entity.Property(e => e.StatusClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalDue).HasColumnType("money");
            entity.Property(e => e.TotalPayments).HasColumnType("money");
            entity.Property(e => e.TotalQuantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.VesselId).HasColumnName("VesselID");
            entity.Property(e => e.VesselName)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ReceivingNoteProductBreakdownListView>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ReceivingNoteProductBreakdownListView", "dbo");

            entity.Property(e => e.GradeClassId).HasColumnName("GradeClassID");
            entity.Property(e => e.GradeClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Qty).HasColumnType("decimal(38, 2)");
            entity.Property(e => e.ReceivingNoteId).HasColumnName("ReceivingNoteID");
            entity.Property(e => e.SubTotal).HasColumnType("decimal(38, 6)");
        });

        modelBuilder.Entity<StatusClass>(entity =>
        {
            entity.ToTable("StatusClass", "dbo");

            entity.Property(e => e.StatusClassId)
                .ValueGeneratedNever()
                .HasColumnName("StatusClassID");
            entity.Property(e => e.StatusClassName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Truck>(entity =>
        {
            entity.HasKey(e => e.TruckId).HasName("PK__Truck__6632E95BEA937C05");

            entity.ToTable("Truck");

            entity.Property(e => e.TruckId).HasColumnName("TruckID");
            entity.Property(e => e.License)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vessel>(entity =>
        {
            entity.ToTable("Vessel", "dbo");

            entity.Property(e => e.VesselId).HasColumnName("VesselID");
            entity.Property(e => e.Address)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.ContactName)
                .HasMaxLength(64)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RegistrationNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VesselName)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VesselCertificate>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("VesselCertificate");

            entity.Property(e => e.VesselId).HasColumnName("VesselID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
