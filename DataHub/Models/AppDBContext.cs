using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataHub.Models;

public partial class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BtGrp> BtGrps { get; set; }

    public virtual DbSet<BtGrpDtl> BtGrpDtls { get; set; }

    public virtual DbSet<BtTran> BtTrans { get; set; }

    public virtual DbSet<BtUser> BtUsers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=.;Database=MYAUDIT;User Id=sa;Password=p@ssw0rd;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BtGrp>(entity =>
        {
            entity.HasKey(e => e.GrpId);

            entity.ToTable("BT_GRP");

            entity.Property(e => e.GrpId)
                .HasMaxLength(10)
                .HasColumnName("GRP_ID");
            entity.Property(e => e.GrpName)
                .HasMaxLength(50)
                .HasColumnName("GRP_NAME");
            entity.Property(e => e.GrpSts)
                .HasMaxLength(2)
                .HasColumnName("GRP_STS");
            entity.Property(e => e.SysLog)
                .HasMaxLength(10)
                .HasColumnName("SYS_LOG");
            entity.Property(e => e.TimeLog)
                .HasColumnType("datetime")
                .HasColumnName("TIME_LOG");
            entity.Property(e => e.UserLog)
                .HasMaxLength(10)
                .HasColumnName("USER_LOG");
        });

        modelBuilder.Entity<BtGrpDtl>(entity =>
        {
            entity.HasKey(e => new { e.GrpId, e.GrlSrl });

            entity.ToTable("BT_GRP_DTL");

            entity.Property(e => e.GrpId)
                .HasMaxLength(10)
                .HasColumnName("GRP_ID");
            entity.Property(e => e.GrlSrl).HasColumnName("GRL_SRL");
            entity.Property(e => e.SysLog)
                .HasMaxLength(10)
                .HasColumnName("SYS_LOG");
            entity.Property(e => e.TimeLog)
                .HasColumnType("datetime")
                .HasColumnName("TIME_LOG");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .HasColumnName("USER_ID");
            entity.Property(e => e.UserLog)
                .HasMaxLength(10)
                .HasColumnName("USER_LOG");
        });

        modelBuilder.Entity<BtTran>(entity =>
        {
            entity.HasKey(e => e.TranId);

            entity.ToTable("BT_TRAN");

            entity.Property(e => e.TranId)
                .HasMaxLength(10)
                .HasColumnName("TRAN_ID");
            entity.Property(e => e.GrpId)
                .HasMaxLength(10)
                .HasColumnName("GRP_ID");
            entity.Property(e => e.ItemCost)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("ITEM_COST");
            entity.Property(e => e.ItemDesc)
                .HasMaxLength(100)
                .HasColumnName("ITEM_DESC");
            entity.Property(e => e.SysLog)
                .HasMaxLength(10)
                .HasColumnName("SYS_LOG");
            entity.Property(e => e.TimeLog)
                .HasColumnType("datetime")
                .HasColumnName("TIME_LOG");
            entity.Property(e => e.TranDate)
                .HasColumnType("datetime")
                .HasColumnName("TRAN_DATE");
            entity.Property(e => e.TranSts)
                .HasMaxLength(2)
                .HasColumnName("TRAN_STS");
            entity.Property(e => e.UserLog)
                .HasMaxLength(10)
                .HasColumnName("USER_LOG");
            entity.Property(e => e.XtraChar1)
                .HasMaxLength(30)
                .HasColumnName("XTRA_CHAR_1");
            entity.Property(e => e.XtraChar2)
                .HasMaxLength(30)
                .HasColumnName("XTRA_CHAR_2");
        });

        modelBuilder.Entity<BtUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("BT_USER");

            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .HasColumnName("USER_ID");
            entity.Property(e => e.SysLog)
                .HasMaxLength(10)
                .HasColumnName("SYS_LOG");
            entity.Property(e => e.TimeLog)
                .HasColumnType("datetime")
                .HasColumnName("TIME_LOG");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(20)
                .HasColumnName("USER_EMAIL");
            entity.Property(e => e.UserLog)
                .HasMaxLength(10)
                .HasColumnName("USER_LOG");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("USER_NAME");
            entity.Property(e => e.UserPass)
                .HasMaxLength(8)
                .HasColumnName("USER_PASS");
            entity.Property(e => e.UserSts)
                .HasMaxLength(2)
                .HasColumnName("USER_STS");
            entity.Property(e => e.XtraChar1)
                .HasMaxLength(30)
                .HasColumnName("XTRA_CHAR_1");
            entity.Property(e => e.XtraChar2)
                .HasMaxLength(30)
                .HasColumnName("XTRA_CHAR_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
