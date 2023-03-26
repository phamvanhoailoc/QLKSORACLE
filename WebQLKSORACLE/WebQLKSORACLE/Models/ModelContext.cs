using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebQLKSORACLE.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Donvitien> Donvitiens { get; set; }
        public virtual DbSet<Giaphong> Giaphongs { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Khuvuc> Khuvucs { get; set; }
        public virtual DbSet<Loaiphong> Loaiphongs { get; set; }
        public virtual DbSet<Nhanvien> Nhanviens { get; set; }
        public virtual DbSet<PhieuDatPhong> PhieuDatPhongs { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<RoLe> RoLes { get; set; }
        public virtual DbSet<TrangthaiDp> TrangthaiDps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));User ID=anonymous;Password=sa;Persist Security Info=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ANONYMOUS")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Donvitien>(entity =>
            {
                entity.HasKey(e => e.MaDvt)
                    .HasName("DONVITIEN_PK");

                entity.ToTable("DONVITIEN");

                entity.Property(e => e.MaDvt)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MA_DVT");

                entity.Property(e => e.TenDvt)
                    .HasMaxLength(50)
                    .HasColumnName("TEN_DVT");
            });

            modelBuilder.Entity<Giaphong>(entity =>
            {
                entity.HasKey(e => e.MaGp)
                    .HasName("GIAPHONG_PK");

                entity.ToTable("GIAPHONG");

                entity.Property(e => e.MaGp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MA_GP");

                entity.Property(e => e.GiaP)
                    .HasColumnType("FLOAT")
                    .HasColumnName("GIA_P");

                entity.Property(e => e.MaDvt)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MA_DVT");

                entity.Property(e => e.MaP)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MA_P");

                entity.Property(e => e.NgaydenGp)
                    .HasColumnType("DATE")
                    .HasColumnName("NGAYDEN_GP");

                entity.Property(e => e.NgaydiGp)
                    .HasColumnType("DATE")
                    .HasColumnName("NGAYDI_GP");

                entity.HasOne(d => d.MaDvtNavigation)
                    .WithMany(p => p.Giaphongs)
                    .HasForeignKey(d => d.MaDvt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_2");

                entity.HasOne(d => d.MaPNavigation)
                    .WithMany(p => p.Giaphongs)
                    .HasForeignKey(d => d.MaP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_1");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("KHACHHANG_PK");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.MaKh)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MA_KH");

                entity.Property(e => e.DiachiKh)
                    .HasMaxLength(100)
                    .HasColumnName("DIACHI_KH");

                entity.Property(e => e.EmailKh)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_KH");

                entity.Property(e => e.Gioitinh)
                    .HasPrecision(1)
                    .HasColumnName("GIOITINH")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.KeyKh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("KEY_KH");

                entity.Property(e => e.MatkhauKh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MATKHAU_KH");

                entity.Property(e => e.SdtKh)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SDT_KH");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(50)
                    .HasColumnName("TEN_KH");

                entity.Property(e => e.TrangthaiKh)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("TRANGTHAI_KH")
                    .HasDefaultValueSql("0 ");
            });

            modelBuilder.Entity<Khuvuc>(entity =>
            {
                entity.HasKey(e => e.MaKv)
                    .HasName("KHUVUC_PK");

                entity.ToTable("KHUVUC");

                entity.Property(e => e.MaKv)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MA_KV");

                entity.Property(e => e.TenKv)
                    .HasMaxLength(200)
                    .HasColumnName("TEN_KV");
            });

            modelBuilder.Entity<Loaiphong>(entity =>
            {
                entity.HasKey(e => e.MaLp)
                    .HasName("LOAIPHONG_PK");

                entity.ToTable("LOAIPHONG");

                entity.Property(e => e.MaLp)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MA_LP");

                entity.Property(e => e.ChitietLp)
                    .HasMaxLength(200)
                    .HasColumnName("CHITIET_LP");

                entity.Property(e => e.TenLp)
                    .HasMaxLength(50)
                    .HasColumnName("TEN_LP");

                entity.Property(e => e.TrangthaiLp)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("TRANGTHAI_LP")
                    .HasDefaultValueSql("0 ");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNv)
                    .HasName("NHANVIEN_PK");

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.MaNv)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MA_NV");

                entity.Property(e => e.DiachiNv)
                    .HasMaxLength(200)
                    .HasColumnName("DIACHI_NV");

                entity.Property(e => e.EmailNv)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_NV");

                entity.Property(e => e.GioitinhNv)
                    .HasPrecision(1)
                    .HasColumnName("GIOITINH_NV")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.KeyNv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("KEY_NV");

                entity.Property(e => e.MatkhauNv)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MATKHAU_NV");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.SdtNv)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SDT_NV");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(200)
                    .HasColumnName("TEN_NV");

                entity.Property(e => e.TrangthaiNv)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("TRANGTHAI_NV")
                    .HasDefaultValueSql("0 ");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Nhanviens)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1");
            });

            modelBuilder.Entity<PhieuDatPhong>(entity =>
            {
                entity.HasKey(e => e.MaDp)
                    .HasName("PHIEU_DAT_PHONG_PK");

                entity.ToTable("PHIEU_DAT_PHONG");

                entity.Property(e => e.MaDp)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MA_DP");

                entity.Property(e => e.MaKh)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MA_KH");

                entity.Property(e => e.MaP)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MA_P");

                entity.Property(e => e.MaTtdp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MA_TTDP");

                entity.Property(e => e.NgaydenDp)
                    .HasColumnType("DATE")
                    .HasColumnName("NGAYDEN_DP");

                entity.Property(e => e.NgaydiDp)
                    .HasColumnType("DATE")
                    .HasColumnName("NGAYDI_DP");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.PhieuDatPhongs)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_5");

                entity.HasOne(d => d.MaPNavigation)
                    .WithMany(p => p.PhieuDatPhongs)
                    .HasForeignKey(d => d.MaP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_4");

                entity.HasOne(d => d.MaTtdpNavigation)
                    .WithMany(p => p.PhieuDatPhongs)
                    .HasForeignKey(d => d.MaTtdp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_6");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.MaP)
                    .HasName("PHONG_PK");

                entity.ToTable("PHONG");

                entity.Property(e => e.MaP)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MA_P");

                entity.Property(e => e.ChitietP).HasColumnName("CHITIET_P");

                entity.Property(e => e.MaLp)
                    .HasColumnType("NUMBER")
                    .HasColumnName("MA_LP");

                entity.Property(e => e.TenP)
                    .HasMaxLength(50)
                    .HasColumnName("TEN_P");

                entity.Property(e => e.TrangthaiP)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("TRANGTHAI_P")
                    .HasDefaultValueSql("0 ");
            });

            modelBuilder.Entity<RoLe>(entity =>
            {
                entity.ToTable("RO_LE");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.TenR)
                    .HasMaxLength(50)
                    .HasColumnName("TEN_R");

                entity.Property(e => e.TrangthaiR)
                    .HasPrecision(1)
                    .HasColumnName("TRANGTHAI_R")
                    .HasDefaultValueSql("0 ");
            });

            modelBuilder.Entity<TrangthaiDp>(entity =>
            {
                entity.HasKey(e => e.MaTtdp)
                    .HasName("TRANGTHAI_DP_PK");

                entity.ToTable("TRANGTHAI_DP");

                entity.Property(e => e.MaTtdp)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MA_TTDP");

                entity.Property(e => e.Chitiet)
                    .HasMaxLength(250)
                    .HasColumnName("CHITIET");

                entity.Property(e => e.TenTt)
                    .HasMaxLength(50)
                    .HasColumnName("TEN_TT");

                entity.Property(e => e.Trangthai)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("TRANGTHAI")
                    .HasDefaultValueSql("0 ");
            });

            modelBuilder.HasSequence("AUTO_INCREMENT_SEQUENCE");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
