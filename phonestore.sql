﻿
CREATE DATABASE phonestore2;
GO

USE phonestore2;
GO

CREATE TABLE LoaiSanPham (
MaLoaiSanPham INT IDENTITY(1,1) PRIMARY KEY,
TenLoaiSanPham NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE SanPham (
MaSanPham INT IDENTITY(1,1) PRIMARY KEY,
TenSanPham NVARCHAR(50) NOT NULL,
MaLoaiSanPham INT NOT NULL,
DaBan INT,
GiaBan DECIMAL(10, 2) NOT NULL,
HinhAnh VARCHAR(100),
CONSTRAINT CHK_GiaBan CHECK (GiaBan >= 0),
FOREIGN KEY (MaLoaiSanPham) REFERENCES LoaiSanPham(MaLoaiSanPham)
);
GO

CREATE TABLE ChiTietSanPham (
MaChiTietSanPham INT IDENTITY(1,1) PRIMARY KEY,
MaSanPham INT NOT NULL,
SoLuongTrongKho INT NOT NULL,
MauSac NVARCHAR(100),
FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
GO

CREATE TABLE KhachHang (
MaKhachHang INT IDENTITY(1,1) PRIMARY KEY,
TenKhachHang NVARCHAR(50) NOT NULL,
DiaChi NVARCHAR(100),
SoDienThoai NVARCHAR(20),
Email VARCHAR(50),
);
GO

CREATE TABLE NhanVien (
MaNhanVien INT IDENTITY(1,1) PRIMARY KEY,
TenNhanVien NVARCHAR(50) NOT NULL,
NgaySinh DATE,
DiaChi NVARCHAR(100),
role VARCHAR(10),
SoDienThoai VARCHAR(20),
Email VARCHAR(50) ,
);
GO

CREATE TABLE HoaDon (
MaHoaDon INT IDENTITY(1,1) PRIMARY KEY,
NgayLapHoaDon DATE NOT NULL,
TongTien DECIMAL(10, 2) NOT NULL,
MaKhachHang INT NOT NULL,
MaNhanVien INT NOT NULL,
FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
GO

CREATE TABLE ChiTietHoaDon (
MaHoaDon INT NOT NULL,
MaSanPham INT NOT NULL,
SoLuongMua INT NOT NULL,
GiaBan DECIMAL(10, 2) NOT NULL,
TongTien DECIMAL(10, 2) NOT NULL,
CONSTRAINT [PK_CTHD] PRIMARY KEY CLUSTERED (
[MaHoaDon] ASC,
[MaSanPham] ASC
) WITH (
PAD_INDEX = OFF,
STATISTICS_NORECOMPUTE = OFF,
IGNORE_DUP_KEY = OFF,
ALLOW_ROW_LOCKS = ON,
ALLOW_PAGE_LOCKS = ON
) ON [PRIMARY],
FOREIGN KEY (MaHoaDon) REFERENCES HoaDon(MaHoaDon),
FOREIGN KEY (MaSanPham) REFERENCES SanPham(MaSanPham)
);
GO

INSERT INTO LoaiSanPham (TenLoaiSanPham)
VALUES ('Iphone'),
('Ipad'),
('Apple Watch'),
('Macbook'),
('Airpod');
GO
INSERT INTO SanPham (TenSanPham, MaLoaiSanPham, DaBan, GiaBan, HinhAnh)
VALUES 
  ('Iphone14 pro max 1TB', 1, 32, 34500000, 'Images/14promax.jpg'),
  ('Iphone14 pro max 512GB', 1, 29, 32100000, 'Images/14promax.jpg'),
  ('Iphone14 pro max 256GB', 1, 132, 28000000, 'Images/14promax.jpg'),
  ('Iphone14 pro max 128GB', 1, 32, 26100000, 'Images/14promax.jpg'),
  ('Iphone14 pro 1TB', 1, 131, 31000000, 'Images/14promax.jpg'),
  ('Iphone14 pro 512GB', 1, 124, 29000000, 'Images/14promax.jpg'),
  ('Iphone14 pro 256GB', 1, 42, 26000000, 'Images/14promax.jpg'),
  ('Iphone14 pro 128GB', 1, 56, 24000000, 'Images/14promax.jpg'),
  ('Iphone14 Plus 512GB', 1, 29, 20100000, 'Images/14.jpg'),
  ('Iphone14 Plus 256GB', 1, 152, 19900000, 'Images/14.jpg'),
  ('Iphone14 Plus 128GB', 1, 132, 18500000, 'Images/14.jpg'),
  ('Iphone14 512GB', 1, 29, 21500000, 'Images/14.jpg'),
  ('Iphone14 256GB', 1, 132, 19900000, 'Images/14.jpg'),
  ('Iphone14 128GB', 1, 32, 17900000, 'Images/14.jpg'),
  ('Iphone13 pro max 1TB', 1, 32, 29000000, 'Images/13promax.jpg'),
  ('Iphone13 pro max 512GB', 1, 29, 26000000, 'Images/13promax.jpg'),
  ('Iphone13 pro max 256GB', 1, 132, 24000000, 'Images/13promax.jpg'),
  ('Iphone13 pro max 128GB', 1, 32, 21000000, 'Images/13promax.jpg'),
  ('Iphone13 pro 1TB', 1, 131, 26000000, 'Images/13promax.jpg'),
  ('Iphone13 pro 512GB', 1, 124, 24000000, 'Images/13promax.jpg'),
  ('Iphone13 pro 256GB', 1, 42, 21000000, 'Images/13promax.jpg'),
  ('Iphone12 pro max 512GB', 1, 29, 2000000, 'Images/12promax.jpg'),
  ('Iphone12 pro max 256GB', 1, 132, 19500000, 'Images/12promax.jpg'),
  ('Iphone12 pro max 128GB', 1, 32, 1900000, 'Images/12promax.jpg'),
  ('Iphone12 pro 256GB', 1, 132, 19500000, 'Images/12promax.jpg'),
  ('Iphone12 pro 128GB', 1, 32, 1900000, 'Images/12promax.jpg'),
  ('Ipad Gen 9', 2, 200, 6000000, 'Images/ipadgen9.jpg'),
  ('Ipad Gen 10', 2, 200, 9000000, 'Images/ipadgen10.jpg'),
  ('Ipad Mini', 2, 200, 10000000, 'Images/ipadmini.jpg'),
  ('Ipad Air', 2, 200, 11000000, 'Images/ipadair.jpg'),
  ('Ipad Pro', 2, 200, 20000000, 'Images/ipadpro.jpg'),
  ('Apple Watch Series 5', 3, 102, 6000000, 'Images/aws5.jpg'),
  ('Apple Watch Series 6', 3, 102, 7000000, 'Images/aws6.jpg'),
  ('Apple Watch Series 7', 3, 102, 8000000, 'Images/aws7.jpg'),
  ('Apple Watch Series 8', 3, 102, 9000000, 'Images/aws8.jpg'),
  ('Macbook Air M2 2022 -16inch', 4, 10, 29900000,'Images/airm2.jpg'),
  ('Macbook Pro M2-16inch', 4, 10, 34500000,'Images/prom2.jpg'),
  ('Macbook Air M1-16inch', 4, 10, 24000000,'Images/airm2.jpg'),
  ('Macbook Pro M1-16inch', 4, 10, 33900000,'Images/prom2.jpg'),
  ('AirPods 1', 5, 135, 2000000,'Images/airpod1.jpg'),
  ('AirPods 2', 5, 135, 3000000,'Images/airpod2.jpg'),
  ('AirPods 3', 5, 135, 4000000,'Images/airpod3.jpg'),
  ('AirPods Pro', 5, 135, 7000000,'Images/airpodpro.jpg');

INSERT INTO KhachHang (TenKhachHang, DiaChi, SoDienThoai, Email)
VALUES
(N'Châu Hoàng Lộc', N'TP.HCM', '0879330052', 'chauloc94@gmail.com'),
(N'Nguyễn Văn A', N'Tỉnh Long An', '0123456789', 'vana01@gmail.com'),
(N'Le Thị B', N'TP.Đà Lạt', '9876543210', 'thib@gmail.com');

INSERT INTO NhanVien (TenNhanVien, NgaySinh, DiaChi, SoDienThoai, Email)
VALUES
(N'Nhân viên 1', '2001-11-20', N'Quận 10', '0854490949', '1951012065loc@ou.edu.vn'),
(N'Nhân viên 2', '2001-11-20', N'Quận Phú Nhuận', '0395784253', 'nhanvien2@gmail.com');

INSERT INTO ChiTietSanPham (MaSanPham, SoLuongTrongKho, MauSac)
VALUES
(1, 100, N'Vàng'),
(1, 100, N'Đen'),
(1, 100, N'Bạc'),
(1, 100, N'Tím'),
(2, 100, N'Vàng'),
(2, 100, N'Đen'),
(2, 100, N'Bạc'),
(2, 100, N'Tím'),
(3, 100, N'Vàng'),
(3, 100, N'Đen'),
(3, 100, N'Bạc'),
(3, 100, N'Tím'),
(4, 100, N'Vàng'),
(4, 100, N'Đen'),
(4, 100, N'Bạc'),
(4, 100, N'Tím'),
(5, 100, N'Vàng'),
(5, 100, N'Đen'),
(5, 100, N'Bạc'),
(5, 100, N'Tím'),
(6, 100, N'Vàng'),
(6, 100, N'Đen'),
(6, 100, N'Bạc'),
(6, 100, N'Tím'),
(7, 100, N'Vàng'),
(7, 100, N'Đen'),
(7, 100, N'Bạc'),
(7, 100, N'Tím'),
(8, 100, N'Vàng'),
(8, 100, N'Đen'),
(8, 100, N'Bạc'),
(8, 100, N'Tím'),
(9, 100, N'Trắng'),
(9, 100, N'Đen'),
(9, 100, N'xanh'),
(10, 100, N'Trắng'),
(10, 100, N'Đen'),
(10, 100, N'Xanh'),
(11, 100, N'Trắng'),
(11, 100, N'Đen'),
(11, 100, N'Xanh'),
(12, 100, N'Trắng'),
(12, 100, N'Đen'),
(12, 100, N'Đỏ'),
(12, 100, N'Tím'),
(12, 100, N'Xanh Dương'),
(13, 100, N'Trắng'),
(13, 100, N'Đen'),
(13, 100, N'Đỏ'),
(13, 100, N'Tím'),
(13, 100, N'Xanh Dương'),
(14, 100, N'Trắng'),
(14, 100, N'Đen'),
(14, 100, N'Đỏ'),
(14, 100, N'Tím'),
(14, 100, N'Xanh Dương'),
(15, 100, N'Trắng'),
(15, 100, N'Đen'),
(15, 100, N'Vàng'),
(15, 100, N'Xanh Dương'),
(16, 100, N'Trắng'),
(16, 100, N'Đen'),
(16, 100, N'Vàng'),
(16, 100, N'Xanh Dương'),
(17, 100, N'Trắng'),
(17, 100, N'Đen'),
(17, 100, N'Vàng'),
(17, 100, N'Xanh Dương'),
(18, 100, N'Trắng'),
(18, 100, N'Đen'),
(18, 100, N'Vàng'),
(18, 100, N'Xanh Dương'),
(19, 100, N'Trắng'),
(19, 100, N'Đen'),
(19, 100, N'Vàng'),
(19, 100, N'Xanh Dương'),
(20, 100, N'Trắng'),
(20, 100, N'Đen'),
(20, 100, N'Vàng'),
(20, 100, N'Xanh Dương'),
(21, 100, N'Trắng'),
(21, 100, N'Đen'),
(21, 100, N'Vàng'),
(21, 100, N'Xanh Dương'),
(22, 100, N'Trắng'),
(22, 100, N'Đen'),
(22, 100, N'Vàng'),
(22, 100, N'Xanh Dương'),
(23, 100, N'Trắng'),
(23, 100, N'Đen'),
(23, 100, N'Vàng'),
(24, 100, N'Xanh Dương'),
(25, 100, N'Trắng'),
(25, 100, N'Đen'),
(25, 100, N'Vàng'),
(25, 100, N'Xanh Dương'),
(26, 100, N'Trắng'),
(26, 100, N'Đen'),
(26, 100, N'Vàng'),
(26, 100, N'Xanh Dương'),
(27, 100, N'Trắng '),
(27, 100, N'Đen'),
(28, 100, N'Xanh Dương'),
(28, 100, N'Trắng'),
(28, 100, N'Hồng'),
(28, 100, N'Vàng'),
(29, 100, N'Tím'),
(29, 100, N'Xám'),
(29, 100, N'Hồng'),
(29, 100, N'Vàng'),
(30, 100, N'Xanh Lá'),
(30, 100, N'Xanh Dương'),
(30, 100, N'Hồng'),
(30, 100, N'Xám'),
(31, 100, N'Bạc'),
(31, 100, N'Xám'),
(32, 100, N'Trắng'),
(32, 100, N'Đen'),
(32, 100, N'Vàng Hồng'),
(33, 100, N'Bạc'),
(33, 100, N'Xám'),
(33, 100, N'Vàng'),
(33, 100, N'Xanh Dương'),
(33, 100, N'Đỏ'),
(34, 100, N'Bạc'),
(34, 100, N'Xám'),
(34, 100, N'Xanh Lục'),
(34, 100, N'Xanh Dương'),
(34, 100, N'Đỏ'),
(35, 100, N'Nhôm Tối'),
(35, 100, N'Anh Sao'),
(35, 100, N'Bạc'),
(35, 100, N'Than Chì'),
(35, 100, N'Đỏ'),
(36, 100, N'Xám'),
(36, 100, N'Bạc'),
(36, 100, N'Xanh Bóng Đêm'),
(36, 100, N'Starlight'),
(37, 100, N'Đỏ'),
(37, 100, N'Xám'),
(37, 100, N'Bạc'),
(37, 100, N'Xanh Bóng Đêm'),
(38, 100, N'Bạc'),
(38, 100, N'Xanh Bóng Đêm'),
(39, 100, N'Bạc'),
(39, 100, N'Xanh Bóng Đêm'),
(40, 100, N'Bạc'),
(41, 100, N'Bạc'),
(42, 100, N'Bạc'),
(43, 100, N'Bạc');

INSERT INTO HoaDon (NgayLapHoaDon, TongTien, MaKhachHang, MaNhanVien)
VALUES 
('2020-11-20', 34500000, 1, 1),
('2020-03-13', 28000000, 2, 2),
('2020-11-20', 7000000, 3, 1);

INSERT INTO ChiTietHoaDon (MaHoaDon, MaSanPham, SoLuongMua, GiaBan, TongTien)
VALUES
(1, 1, 1, 34500000, 34500000),
(2, 3, 1, 28000000, 28000000),
(3, 43, 1, 7000000, 7000000);