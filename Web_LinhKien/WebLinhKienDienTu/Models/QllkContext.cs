using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebLinhKienDienTu.Models;

public partial class QllkContext : DbContext
{
    public QllkContext()
    {
    }

    public QllkContext(DbContextOptions<QllkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chitietgiohang> Chitietgiohangs { get; set; }

    public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }

    public virtual DbSet<Giohang> Giohangs { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<KhoSanpham> KhoSanphams { get; set; }

    public virtual DbSet<Khohang> Khohangs { get; set; }

    public virtual DbSet<Lichsuhoatdong> Lichsuhoatdongs { get; set; }

    public virtual DbSet<Lichsumuahang> Lichsumuahangs { get; set; }

    public virtual DbSet<Loaisanpham> Loaisanphams { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Sanpham> Sanphams { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Thanhtoan> Thanhtoans { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=ADMIN-PC\\SQLEXPRESS;Database=QLLK;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitietgiohang>(entity =>
        {
            entity.HasKey(e => new { e.Magh, e.Masp }).HasName("PK_CTGH");

            entity.ToTable("CHITIETGIOHANG");

            entity.Property(e => e.Magh).HasColumnName("MAGH");
            entity.Property(e => e.Masp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MASP");
            entity.Property(e => e.Dongia)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DONGIA");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Thanhtien)
                .HasComputedColumnSql("([SOLUONG]*[DONGIA])", false)
                .HasColumnType("decimal(29, 2)")
                .HasColumnName("THANHTIEN");

            entity.HasOne(d => d.MaghNavigation).WithMany(p => p.Chitietgiohangs)
                .HasForeignKey(d => d.Magh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CTGH_GH");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Chitietgiohangs)
                .HasForeignKey(d => d.Masp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CTGH_SP");
        });

        modelBuilder.Entity<Chitiethoadon>(entity =>
        {
            entity.HasKey(e => new { e.Mahd, e.Masp }).HasName("PK_CTHD");

            entity.ToTable("CHITIETHOADON");

            entity.Property(e => e.Mahd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHD");
            entity.Property(e => e.Masp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MASP");
            entity.Property(e => e.Dongia)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("DONGIA");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Makho).HasColumnName("MAKHO");
            entity.Property(e => e.Thanhtien)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("THANHTIEN");

            entity.HasOne(d => d.MahdNavigation).WithMany(p => p.Chitiethoadons)
                .HasForeignKey(d => d.Mahd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CTHD_HD");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Chitiethoadons)
                .HasForeignKey(d => d.Masp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CTHD_SP");

            entity.HasOne(d => d.MakhoNavigation).WithMany(p => p.Chitiethoadons)
                .HasForeignKey(d => d.Makho)
                .HasConstraintName("FK_CTHD_K");
        });

        modelBuilder.Entity<Giohang>(entity =>
        {
            entity.HasKey(e => e.Magh).HasName("PK__GIOHANG__603F38A3C0DE190B");

            entity.ToTable("GIOHANG");

            entity.Property(e => e.Magh).HasColumnName("MAGH");
            entity.Property(e => e.Mahd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHD");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAKH");
            entity.Property(e => e.Masp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MASP");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

            entity.HasOne(d => d.MahdNavigation).WithMany(p => p.Giohangs)
                .HasForeignKey(d => d.Mahd)
                .HasConstraintName("FK_GH_HD");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Giohangs)
                .HasForeignKey(d => d.Makh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GH_KH");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.Giohangs)
                .HasForeignKey(d => d.Masp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GH_SP");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.Mahd).HasName("PK_HD");

            entity.ToTable("HOADON");

            entity.Property(e => e.Mahd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHD");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAKH");
            entity.Property(e => e.Manv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MANV");
            entity.Property(e => e.Ngaylap)
                .HasColumnType("datetime")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Tongtien)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TONGTIEN");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.Makh)
                .HasConstraintName("FK_HD_KH");

            entity.HasOne(d => d.ManvNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.Manv)
                .HasConstraintName("FK_H_NV");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.Makh).HasName("PK_KH");

            entity.ToTable("KHACHHANG");

            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAKH");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Ngaytao)
                .HasColumnType("datetime")
                .HasColumnName("NGAYTAO");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Tenkh)
                .HasMaxLength(70)
                .HasColumnName("TENKH");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Khachhangs)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK_KH_TK");
        });

        modelBuilder.Entity<KhoSanpham>(entity =>
        {
            entity.HasKey(e => new { e.Makho, e.Masp, e.Ngaynhap }).HasName("PK_K_SP");

            entity.ToTable("KHO_SANPHAM");

            entity.Property(e => e.Makho).HasColumnName("MAKHO");
            entity.Property(e => e.Masp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MASP");
            entity.Property(e => e.Ngaynhap)
                .HasColumnType("datetime")
                .HasColumnName("NGAYNHAP");
            entity.Property(e => e.Soluongnhap).HasColumnName("SOLUONGNHAP");

            entity.HasOne(d => d.MaspNavigation).WithMany(p => p.KhoSanphams)
                .HasForeignKey(d => d.Masp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KSP_SANPHAM");

            entity.HasOne(d => d.MakhoNavigation).WithMany(p => p.KhoSanphams)
                .HasForeignKey(d => d.Makho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_KSP_KHO");
        });

        modelBuilder.Entity<Khohang>(entity =>
        {
            entity.HasKey(e => e.Makho).HasName("PK__KHOHANG__CA1EB690DBCC293B");

            entity.ToTable("KHOHANG");

            entity.Property(e => e.Diachikho)
                .HasMaxLength(300)
                .HasColumnName("DIACHIKHO");
            entity.Property(e => e.Makho)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAKHO");
            entity.Property(e => e.Manv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MANV");
            entity.Property(e => e.Soluongloaihang)
                .HasMaxLength(50)
                .HasColumnName("SOLUONGLOAIHANG");
            entity.Property(e => e.Tenkho)
                .HasMaxLength(200)
                .HasColumnName("TENKHO");
        });

        modelBuilder.Entity<Lichsuhoatdong>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LICHSUHO__3214EC2713995A09");

            entity.ToTable("LICHSUHOATDONG");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Chitiet)
                .HasMaxLength(500)
                .HasColumnName("CHITIET");
            entity.Property(e => e.Doituong)
                .HasMaxLength(100)
                .HasColumnName("DOITUONG");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Hoatdong)
                .HasMaxLength(200)
                .HasColumnName("HOATDONG");
            entity.Property(e => e.Thoigian)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("THOIGIAN");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Lichsuhoatdongs)
                .HasForeignKey(d => d.Email)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LICHSUHOATDONG_TAIKHOAN");
        });

        modelBuilder.Entity<Lichsumuahang>(entity =>
        {
            entity.HasKey(e => e.Malsmh).HasName("PK_LSMH");

            entity.ToTable("LICHSUMUAHANG");

            entity.Property(e => e.Malsmh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MALSMH");
            entity.Property(e => e.Mahd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHD");
            entity.Property(e => e.Makh)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAKH");
            entity.Property(e => e.Ngaymua)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("NGAYMUA");
            entity.Property(e => e.Tongtien)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TONGTIEN");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(30)
                .HasDefaultValue("Hoàn tất")
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MahdNavigation).WithMany(p => p.Lichsumuahangs)
                .HasForeignKey(d => d.Mahd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LSMH_HD");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Lichsumuahangs)
                .HasForeignKey(d => d.Makh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LSMH_KH");
        });

        modelBuilder.Entity<Loaisanpham>(entity =>
        {
            entity.HasKey(e => e.Maloai).HasName("PK_LSP");

            entity.ToTable("LOAISANPHAM");

            entity.Property(e => e.Maloai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MALOAI");
            entity.Property(e => e.Mota)
                .HasMaxLength(100)
                .HasColumnName("MOTA");
            entity.Property(e => e.Tenloai)
                .HasMaxLength(100)
                .HasColumnName("TENLOAI");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Manv).HasName("PK_NV");

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.Manv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MANV");
            entity.Property(e => e.Chuc)
                .HasMaxLength(50)
                .HasColumnName("CHUC");
            entity.Property(e => e.Diachi)
                .HasMaxLength(50)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(5)
                .HasColumnName("GIOITINH");
            entity.Property(e => e.Luong)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("LUONG");
            entity.Property(e => e.Ngaysinh).HasColumnName("NGAYSINH");
            entity.Property(e => e.Sdt).HasColumnName("SDT");
            entity.Property(e => e.Tennv)
                .HasMaxLength(30)
                .HasColumnName("TENNV");

            entity.HasOne(d => d.EmailNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.Email)
                .HasConstraintName("FK_NV_TK");
        });

        modelBuilder.Entity<Sanpham>(entity =>
        {
            entity.HasKey(e => e.Masp).HasName("PK_SP");

            entity.ToTable("SANPHAM");

            entity.Property(e => e.Masp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MASP");
            entity.Property(e => e.Dongia)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DONGIA");
            entity.Property(e => e.Dvt)
                .HasMaxLength(50)
                .HasColumnName("DVT");
            entity.Property(e => e.Hinhanh)
                .HasMaxLength(200)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("HINHANH");
            entity.Property(e => e.Maloai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MALOAI");
            entity.Property(e => e.Mota)
                .HasMaxLength(250)
                .HasColumnName("MOTA");
            entity.Property(e => e.Soluongton).HasColumnName("SOLUONGTON");
            entity.Property(e => e.Tensp)
                .HasMaxLength(100)
                .HasColumnName("TENSP");

            entity.HasOne(d => d.MaloaiNavigation).WithMany(p => p.Sanphams)
                .HasForeignKey(d => d.Maloai)
                .HasConstraintName("FK_SP_LSP");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK_TK");

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("PASS");
            entity.Property(e => e.Quyen)
                .HasMaxLength(50)
                .HasColumnName("QUYEN");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(20)
                .HasColumnName("TRANGTHAI");
        });

        modelBuilder.Entity<Thanhtoan>(entity =>
        {
            entity.HasKey(e => e.Matt).HasName("PK_TT");

            entity.ToTable("THANHTOAN");

            entity.Property(e => e.Matt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MATT");
            entity.Property(e => e.Mahd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("MAHD");
            entity.Property(e => e.Ngaytt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("NGAYTT");
            entity.Property(e => e.Phuongthuc)
                .HasMaxLength(50)
                .HasColumnName("PHUONGTHUC");
            entity.Property(e => e.Tongtien)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TONGTIEN");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(30)
                .HasDefaultValue("Đã thanh toán")
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MahdNavigation).WithMany(p => p.Thanhtoans)
                .HasForeignKey(d => d.Mahd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TT_HD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
