CREATE DATABASE BANHANGTRUCTUYEN
GO
USE BANHANGTRUCTUYEN
GO
CREATE TABLE [HANGHOA] (
  [MaMatHang] varchar(20) PRIMARY KEY,
  [TenMatHang] varchar(100),
  [MaChungLoai] varchar(20),
  [GiaTien] integer,
  [SoLuongTon] integer
)
GO

CREATE TABLE [CHUNGLOAI] (
  [MaChungLoai] varchar(20) PRIMARY KEY,
  [TenChungLoai] varchar(100)
)
GO


CREATE TABLE [DONNHAPHANG] (
  [MaDonNhapHang] varchar(20) PRIMARY KEY,
  [NgayNhap] datetime,
  [LyDoNhap] varchar(100),
  [NVNhapHang] varchar(20),
  [NVQuanLy] varchar(20),
  [MaNCC] varchar(20),
  [TongSoLuongHangNhap] integer
)
GO

CREATE TABLE [CT_DONNHAPHANG] (
  [MaCTDNH] varchar(20) PRIMARY KEY,
  [MaMatHang] varchar(20),
  [SLHangNhap] integer,
  [MaDonNhapHang] varchar(20)
)
GO

CREATE TABLE [DONTRAHANG] (
  [MaDonTraHang] varchar(20) PRIMARY KEY,
  [NgayLap] datetime,
  [NguoiLap] varchar(20),
  [MaNCC] varchar(20),
  [LyDoTra] varchar(100)
)
GO

CREATE TABLE [CT_DONTRAHANG] (
  [MaCTDTH] varchar(20) PRIMARY KEY,
  [MaDonTraHang] varchar(20),
  [MaMatHang] varchar(20),
  [SoLuongTra] integer
)
GO

CREATE TABLE [NHACUNGCAP] (
  [MaNCC] varchar(20) PRIMARY KEY,
  [TenNCC] varchar(100)
)
GO


CREATE TABLE [NHANVIEN] (
  [MaNhanVien] varchar(20) PRIMARY KEY,
  [TenNhanVien] varchar(100),
  [ChucVu] varchar(100)
)
GO



CREATE TABLE [COMMENT] (
  [MaComment] varchar(20) PRIMARY KEY,
  [Comment] varchar(255),
  [MaKhachHang] varchar(20),
  [MaMatHang] varchar(20),
  [NVQuanLy] varchar(20),
  [LoaiComment] varchar(20),
  [rate] integer									--Them
)
GO

CREATE TABLE [KHACHHANG] (
  [MaKhachHang] varchar(20) PRIMARY KEY,
  [TenKhachHang] varchar(100),
  [Email] varchar(100),
  [DiaChi] varchar(100),
  [DiemThuong] integer,									--Them
  [KhoaComment] bit									--Them
)
GO

CREATE TABLE [TINQUANGCAO] (
  [MaQuangCao] varchar(20) PRIMARY KEY,
  [MoTa] varchar(255),
  [NVDangTin] varchar(20),
  [TenQuangCao] varchar(100),
  [MaMatHang] varchar(20),
  [LoaiQuangCao] varchar(100),
  [MaDoiTacQuangCao] varchar(20),
  [KHNhanTin] varchar(20)
)
GO

CREATE TABLE [DOITACQUANGCAO] (
  [MaDTQC] varchar(20) PRIMARY KEY,
  [NgayKiHopDong] datetime,
  [TenDoiTac] varchar(100),
  [ThoiHan] datetime,
  [ViTriDang] varchar(100)
)
GO

CREATE TABLE [HOADON] (
  [MaHoaDon] varchar(20) PRIMARY KEY,
  [MaKhachHang] varchar(20),
  [KHXacNhan] varchar(100),
  [MaNVBanHang] varchar(20),
  [TongTien] integer
)
GO

CREATE TABLE [CT_HOADON] (
  [MaCTHD] varchar(20) PRIMARY KEY,
  [MaHoaDon] varchar(20),
  [MaMatHang] varchar(20),
  [SoLuong] integer,
  [ThanhTien] integer,
  [TT_TraHang] bit									--Them
)
GO

CREATE TABLE [PHIEUTRA] (
  [MaPhieuTra] varchar(20) PRIMARY KEY,
  [MaHoaDon] varchar(20)
)
GO

CREATE TABLE [CT_PHIEUTRA] (
  [MaCTPT] varchar(20) PRIMARY KEY,
  [MaPhieuTra] varchar(20),
  [MaMatHang] varchar(20),
  [SoLuongTra] integer,
  [TienHoanTra] integer,
  [LyDoTra] varchar(255)
)
GO

CREATE TABLE [PHIEUGIAO] (
  [MaPhieuGiao] varchar(20) PRIMARY KEY,
  [MaHoaDon] varchar(20),
  [MaNVGiaoHang] varchar(20),
  [DiaChi] varchar(255)
)
GO

CREATE TABLE [THANHTOAN] (
  [MaThanhToan] varchar(20) PRIMARY KEY,
  [MaHoaDon] varchar(20),
  [ThuQuy] varchar(20),
  [LoaiThanhToan] varchar(100),
  [KHXacThuc] varchar(100),
  [ThongTinThe] varchar(100),
  [ThuQuyXacThuc] varchar(100),
  [TinhTrangThanhToan] varchar(100)
)
GO

ALTER TABLE [HANGHOA] ADD FOREIGN KEY ([MaChungLoai]) REFERENCES [CHUNGLOAI] ([MaChungLoai])
GO

ALTER TABLE [CT_DONNHAPHANG] ADD FOREIGN KEY ([MaDonNhapHang]) REFERENCES [DONNHAPHANG] ([MaDonNhapHang])
GO

ALTER TABLE [CT_DONNHAPHANG] ADD FOREIGN KEY ([MaMatHang]) REFERENCES [HANGHOA] ([MaMatHang])
GO

ALTER TABLE [CT_DONTRAHANG] ADD FOREIGN KEY ([MaDonTraHang]) REFERENCES [DONTRAHANG] ([MaDonTraHang])
GO

ALTER TABLE [CT_DONTRAHANG] ADD FOREIGN KEY ([MaMatHang]) REFERENCES [HANGHOA] ([MaMatHang])
GO

ALTER TABLE [DONTRAHANG] ADD FOREIGN KEY ([MaNCC]) REFERENCES [NHACUNGCAP] ([MaNCC])
GO

ALTER TABLE [DONNHAPHANG] ADD FOREIGN KEY ([MaNCC]) REFERENCES [NHACUNGCAP] ([MaNCC])
GO

ALTER TABLE [DONTRAHANG] ADD FOREIGN KEY ([NguoiLap]) REFERENCES [NHANVIEN] ([MaNhanVien])
GO

ALTER TABLE [COMMENT] ADD FOREIGN KEY ([MaMatHang]) REFERENCES [HANGHOA] ([MaMatHang])
GO

ALTER TABLE [COMMENT] ADD FOREIGN KEY ([NVQuanLy]) REFERENCES [NHANVIEN] ([MaNhanVien])
GO

ALTER TABLE [COMMENT] ADD FOREIGN KEY ([MaKhachHang]) REFERENCES [KHACHHANG] ([MaKhachHang])
GO

ALTER TABLE [TINQUANGCAO] ADD FOREIGN KEY ([MaMatHang]) REFERENCES [HANGHOA] ([MaMatHang])
GO

ALTER TABLE [TINQUANGCAO] ADD FOREIGN KEY ([NVDangTin]) REFERENCES [NHANVIEN] ([MaNhanVien])
GO

ALTER TABLE [TINQUANGCAO] ADD FOREIGN KEY ([KHNhanTin]) REFERENCES [KHACHHANG] ([MaKhachHang])
GO

ALTER TABLE [TINQUANGCAO] ADD FOREIGN KEY ([MaDoiTacQuangCao]) REFERENCES [DOITACQUANGCAO] ([MaDTQC])
GO

ALTER TABLE [CT_HOADON] ADD FOREIGN KEY ([MaHoaDon]) REFERENCES [HOADON] ([MaHoaDon])
GO

ALTER TABLE [CT_HOADON] ADD FOREIGN KEY ([MaMatHang]) REFERENCES [HANGHOA] ([MaMatHang])
GO

ALTER TABLE [HOADON] ADD FOREIGN KEY ([MaKhachHang]) REFERENCES [KHACHHANG] ([MaKhachHang])
GO

ALTER TABLE [HOADON] ADD FOREIGN KEY ([MaNVBanHang]) REFERENCES [NHANVIEN] ([MaNhanVien])
GO

ALTER TABLE [CT_PHIEUTRA] ADD FOREIGN KEY ([MaPhieuTra]) REFERENCES [PHIEUTRA] ([MaPhieuTra])
GO

ALTER TABLE [CT_PHIEUTRA] ADD FOREIGN KEY ([MaMatHang]) REFERENCES [HANGHOA] ([MaMatHang])
GO

ALTER TABLE [PHIEUTRA] ADD FOREIGN KEY ([MaHoaDon]) REFERENCES [HOADON] ([MaHoaDon])
GO

ALTER TABLE [PHIEUGIAO] ADD FOREIGN KEY ([MaHoaDon]) REFERENCES [HOADON] ([MaHoaDon])
GO

ALTER TABLE [PHIEUGIAO] ADD FOREIGN KEY ([MaNVGiaoHang]) REFERENCES [NHANVIEN] ([MaNhanVien])
GO

ALTER TABLE [THANHTOAN] ADD FOREIGN KEY ([MaHoaDon]) REFERENCES [HOADON] ([MaHoaDon])
GO

ALTER TABLE [THANHTOAN] ADD FOREIGN KEY ([ThuQuy]) REFERENCES [NHANVIEN] ([MaNhanVien])
GO
