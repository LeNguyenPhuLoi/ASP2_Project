USE MASTER 
GO
USE QLLK
SET DATEFORMAT DMY

--THEM DU LIEU ASPNETROLES
GO
INSERT INTO AspNetRoles(Id, Name, NormalizedName, ConcurrencyStamp)
VALUES(N'07966728-3f96-465e-b7cb-f7bccb599965',N'User',N'USER',N'a69adb30-ff16-4b08-b6a5-5273e672ab99'),
		(N'ff980498-3cc9-47e6-9af8-8d27d498b436',N'Admin',N'ADMIN',N'ada11024-3e22-4d30-b2a2-391270796135')

--THEM DU LIEU ASPNETUSER
GO
INSERT INTO AspNetUsers(Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount,Address,DateOfBirth,FullName)
VALUES(N'04c4d31d-8960-41b4-8bbe-4823ba4db4e6',N'admin@local.test',N'ADMIN@LOCAL.TEST',N'admin@local.test',N'ADMIN@LOCAL.TEST',1,N'AQAAAAEAACcQAAAAEObgeg7NP3bMR3P8KP3chrrUHQhEtUETJUpIuHkO6YZm73j00j8oS6Ibj3diw5q/1g==',N'STYRKRHBLTS3NU5DM4XUO74RL2UMCMIK',N'b040131b-a5d5-4250-9a81-2c44af2d5adf',null,0,0,null,1,0,null,null,null),
		(N'c8be8d9d-8a69-4f1a-9a9d-f2d4d5acb001',N'namle75@gmail.com',N'NAMLE75@GMAIL.COM',N'namle75@gmail.com',N'NAMLE75@GMAIL.COM',1,N'AQAAAAEAACcQAAAAELNzunqKm62t0O/WxidAevmMlrvGjeqni/j4+sXNRpTGYmT9Rmx/pm6yl/VOMfgV9w==',N'6f2b2e5f-508c-4bca-a7b3-22394c30cd10',N'cf74daef-2c4d-48a6-a0a4-85e65e92b20f',NULL,0,0,NULL,1,0,NULL,NULL,N'Lê Nam'),
		(N'd920e2b6-7b94-4e59-93ae-3c2c6345d002',N'tung98@gmail.com',N'TUNG98@GMAIL.COM',N'tung98@gmail.com',N'TUNG98@GMAIL.COM',1,N'AQAAAAEAACcQAAAAEBnmM5nvBxeKmawf3y3beqQEalr3xrm90BENXmCG0f4FoVq8U7vksFB50fhaZN3lgA==',N'8b99aa3d-94fd-4b1b-9a45-b623eaf13ab2',N'3e6b8db2-0816-4e71-9dbe-093cb05a5214',NULL,0,0,NULL,1,0,NULL,NULL,N'Nguyễn Tùng'),
		(N'e12f8cd3-9c1a-4aa0-9b71-6c2f4c39a111',N'thanhlong87@gmail.com',N'THANHLONG87@GMAIL.COM',N'thanhlong87@gmail.com',N'THANHLONG87@GMAIL.COM',1,N'AQAAAAEAACcQAAAAEApqRL6oRp0iS/CwnfKqr3Tbooh0YzjPlyIRM4EepyTQ704H/V+eZX2w7tUkRqnZhg==',N'3f2d9c4e-9d44-4c1e-bc17-5b6a6f4c8c32',N'c4a1f2c1-6e3d-4b8e-bc41-4fd977c5b6f9',NULL,0,0,NULL,1,0,NULL,NULL,N'Thành Long'),
		(N'7b62a8f4-9984-49c5-b13d-5ac3632fd222',N'huunghi123@gmail.com',N'HUUNGHI123@GMAIL.COM',N'huunghi123@gmail.com',N'HUUNGHI123@GMAIL.COM',1,N'AQAAAAEAACcQAAAAEBFfxB5zBLvtUry1CR/Z61m5ULp4M0H8yMeNz5IEF2VVv7HrdRnVDSHgcCyZhK7P1w==',N'8f1c2e4b-bc72-4c1a-8c9e-3f4a6d7289d1',N'5e9b3c1d-47a2-4b8d-ae3f-9c2d7a4f11b8',NULL,0,0,NULL,1,0,NULL,NULL,N'Hữu Nghi')

--THEM DU LIEU ASPNETUSERROLES
GO
INSERT INTO AspNetUserRoles(UserId,RoleId)
VALUES(N'04c4d31d-8960-41b4-8bbe-4823ba4db4e6',N'ff980498-3cc9-47e6-9af8-8d27d498b436'),
		(N'c8be8d9d-8a69-4f1a-9a9d-f2d4d5acb001',N'ff980498-3cc9-47e6-9af8-8d27d498b436'),
		(N'd920e2b6-7b94-4e59-93ae-3c2c6345d002',N'07966728-3f96-465e-b7cb-f7bccb599965'),
		(N'e12f8cd3-9c1a-4aa0-9b71-6c2f4c39a111',N'07966728-3f96-465e-b7cb-f7bccb599965'),
		(N'7b62a8f4-9984-49c5-b13d-5ac3632fd222',N'07966728-3f96-465e-b7cb-f7bccb599965')

---THEM DU LIEU LOAI SAN PHAM
GO
INSERT INTO LOAISANPHAM (MALOAI, TENLOAI, MOTA)
VALUES
('LSP01', N'CPU - Bộ vi xử lý', N'Xử lý dữ liệu và điều khiển toàn bộ hoạt động của máy tính'),
('LSP02', N'RAM - Bộ nhớ trong', N'Lưu trữ tạm thời dữ liệu khi máy hoạt động'),
('LSP03', N'Card đồ họa - GPU', N'Xử lý hình ảnh, đồ họa, game và hiển thị'),
('LSP04', N'Ổ cứng SSD/HDD', N'Lưu trữ dữ liệu, hệ điều hành, phần mềm'),
('LSP05', N'Nguồn & Tản nhiệt', N'Cung cấp điện và làm mát linh kiện máy tính');

---THEM DU LIEU SAN PHAM
GO
INSERT INTO SANPHAM (MASP, TENSP, DONGIA, DVT, MOTA, HINHANH, SOLUONGTON, MALOAI)
VALUES
-- CPU
('SP001', N'Intel Core i3-8100', 2800000, N'VND', N'Bộ vi xử lý Intel Core i3-8100, 4 nhân 4 luồng, hiệu năng ổn định cho văn phòng và giải trí', 'intel_i3_8100.jpg', 15, 'LSP01'),
('SP002', N'Intel Core i5-9400F', 4200000, N'VND', N'CPU Intel Core i5-9400F, 6 nhân 6 luồng, phù hợp chơi game và làm việc đồ họa cơ bản', 'intel_i5_9400f.jpg', 12, 'LSP01'),
('SP003', N'Intel Core i7-9700K', 7500000, N'VND', N'CPU Intel Core i7-9700K, 8 nhân 8 luồng, hiệu năng mạnh mẽ cho đồ họa và gaming cao cấp', 'intel_i7_9700.jpg', 10, 'LSP01'),
('SP004', N'Intel Pentium G5400', 1900000, N'VND', N'CPU Intel Pentium G5400, 2 nhân 4 luồng, phù hợp máy tính văn phòng cơ bản', 'intel_pentium_g5400.jpg', 20, 'LSP01'),

-- RAM
('SP005', N'Corsair Vengeance RGB 8GB DDR4 3200MHz', 1200000, N'VND', N'RAM Corsair Vengeance RGB 8GB DDR4 3200MHz, thiết kế đẹp mắt và hiệu năng ổn định', 'corsair_ram_vegeance_rgb.jpg', 25, 'LSP02'),
('SP006', N'G.Skill Trident Z RGB 8GB DDR4 3600MHz', 1300000, N'VND', N'RAM G.Skill Trident Z RGB 8GB DDR4 3600MHz, tốc độ cao, tản nhiệt hiệu quả', 'dominator_platinum_rgb_x2.jpg', 18, 'LSP02'),
('SP007', N'Kingston HyperX 8GB DDR4 3200MHz', 1150000, N'VND', N'RAM Kingston HyperX 8GB DDR4 3200MHz, hiệu năng bền bỉ cho chơi game và đồ họa', 'kingston_hyperx_ddr4_3200.jpg', 22, 'LSP02'),
('SP008', N'Gigabyte Aorus 2x8GB DDR4 3200MHz', 2300000, N'VND', N'Bộ RAM đôi Gigabyte Aorus 16GB (2x8GB) bus 3200MHz, tản nhiệt tốt và độ ổn định cao', 'gigabyte_aorus_2x8gb_ddr4_3200.jpg', 10, 'LSP02'),

-- GPU
('SP009', N'Asus GTX 1050 4GB GDDR5', 3400000, N'VND', N'Card đồ họa Asus GTX 1050 4GB GDDR5, hiệu năng phù hợp cho chơi game eSports', 'asus_gtx_1050_4gb_gddr5_cerberus.png', 8, 'LSP03'),
('SP010', N'Gigabyte RTX 2070 8GB GDDR6', 10500000, N'VND', N'Card đồ họa Gigabyte RTX 2070 8GB GDDR6, hiệu năng cao, hỗ trợ Ray Tracing', 'gigabyte_rtx_2070_8gb_gddr6.jpg', 5, 'LSP03'),
('SP011', N'MSI Radeon RX 5700 8GB GDDR6', 9200000, N'VND', N'Card đồ họa MSI Radeon RX 5700 8GB, hiệu năng tốt cho gaming và đồ họa chuyên nghiệp', 'msi_radeon_rx5700_8gb_gddr6.jpg', 6, 'LSP03'),
('SP012', N'MSI RTX 2080Ti 11GB GDDR6', 19800000, N'VND', N'Card đồ họa cao cấp MSI RTX 2080Ti 11GB GDDR6, dành cho chơi game 4K và dựng hình 3D', 'asus_rtx_2080ti.jpg', 4, 'LSP03'),

-- Ổ cứng
('SP013', N'SSD Kingston A2000 500GB NVMe', 1350000, N'VND', N'SSD Kingston A2000 dung lượng 500GB, chuẩn NVMe PCIe, tốc độ đọc ghi cao', 'kingston_500gb_ssd.jpg', 25, 'LSP04'),
('SP014', N'SSD Samsung 860 EVO 250GB', 1150000, N'VND', N'SSD Samsung 860 EVO 250GB, chuẩn SATA III, độ bền cao và ổn định', 'samsung_860evo250gb_m2280.png', 18, 'LSP04'),
('SP015', N'SSD Intel 660p 1TB NVMe', 2200000, N'VND', N'SSD Intel 660p 1TB NVMe, tốc độ cao, dung lượng lớn cho lưu trữ dữ liệu', 'intel_360gb_sata3_ssd.jpg', 10, 'LSP04'),
('SP016', N'HDD Seagate Barracuda 1TB 7200rpm', 1050000, N'VND', N'HDD Seagate Barracuda 1TB, tốc độ quay 7200rpm, dung lượng lớn, hoạt động bền bỉ', 'seagate_barracuda_1tb.jpg', 30, 'LSP04'),

-- Nguồn & Tản nhiệt
('SP017', N'Nguồn AcBel 600W', 950000, N'VND', N'Nguồn máy tính AcBel 600W, hoạt động ổn định và tiết kiệm điện năng', 'AcBel_600W.jpg', 25, 'LSP05'),
('SP018', N'Nguồn Gigabyte Aorus 850W', 2100000, N'VND', N'Nguồn Gigabyte Aorus 850W, chuẩn 80 Plus Gold, hiệu suất cao', 'gigabyte_aorus_850w.jpg', 15, 'LSP05'),
('SP019', N'Tản nhiệt Cooler Master Hyper 212 LED Turbo', 750000, N'VND', N'Tản nhiệt khí Cooler Master Hyper 212 LED Turbo, hiệu quả và êm ái', 'coolermaster_hyper212ledturbo.jpg', 20, 'LSP05'),
('SP020', N'Tản nhiệt nước Cooler Master ML240L', 1750000, N'VND', N'Tản nhiệt nước Cooler Master ML240L, làm mát tốt cho CPU hiệu năng cao', 'coolermaster_ml240l.jpg', 10, 'LSP05');

--THEM DU LIEU TAI KHOAN
GO
INSERT INTO TAIKHOAN(EMAIL, PASS, QUYEN, TRANGTHAI)
VALUES (N'namle75@gmail.com','namle@123', N'ADMIN', N'HOẠT ĐỘNG'),
		(N'tung98@gmail.com','tung@123', N'USER', N'HOẠT ĐỘNG'),
		(N'thanhlong87@gmail.com','thanhlong@123', N'USER', N'HOẠT ĐỘNG'),
		(N'huunghi123@gmail.com','huunghi@123', N'USER', N'HOẠT ĐỘNG')

--THEM DU LIEU NHAN VIEN
GO
INSERT INTO NHANVIEN (MANV, TENNV, GIOITINH, NGAYSINH, CHUC, LUONG, DIACHI, SDT, EMAIL)
VALUES ('NV001', N'Lê Hoài Nam', N'Nam', '30/04/1975', N'Nhân viên quản kho', 12000000, N'43 Hoàng Hoa Thám', 0977251843, N'namle75@gmail.com')

--THEM DU LIEU KHACH HANG
GO
INSERT INTO KHACHHANG(MAKH, TENKH, SDT, EMAIL, DIACHI, NGAYTAO)
VALUES ('KH001', N'Nguyễn Thanh Tùng', 0972581443, N'tung98@gmail.com', N'987 Võ Thượng Thái Quân', '30/04/2018'),
		('KH002', N'Trần Thành Long', 0972581443, N'thanhlong87@gmail.com', N'715 La Hán', '07/12/2018'),
		('KH003', N'Phạm Hữu Nghi', 0972581443, N'huunghi123@gmail.com', N'36 Hoàng Hà', '31/12/2018')

--THEM DU LIEU KHO HANG
GO
INSERT INTO KHOHANG(MAKHO, TENKHO, DIACHIKHO, MANV, SOLUONGLOAIHANG)
VALUES 
('KHO001', N'Kho linh kiện máy tính Hoàng Hoa Thám', N'số 43 Hoàng Hoa Thám', 'NV001', N'36 loại hàng linh kiện máy tính'),
('KHO002', N'Kho linh kiện điện tử Bình Thạnh', N'129 Điện Biên Phủ, Bình Thạnh', 'NV002', N'28 loại linh kiện điện tử'),
('KHO003', N'Kho phụ kiện công nghệ Tân Bình', N'75 Trường Chinh, Tân Bình', 'NV003', N'41 loại phụ kiện thiết bị'),
('KHO004', N'Kho thiết bị mạng Quận 7', N'18 Nguyễn Thị Thập, Quận 7', 'NV004', N'33 loại thiết bị mạng'),
('KHO005', N'Kho máy văn phòng Gò Vấp', N'254 Quang Trung, Gò Vấp', 'NV005', N'22 loại thiết bị máy văn phòng'),
('KHO006', N'Kho linh kiện điện tử Thủ Đức', N'47 Võ Văn Ngân, Thủ Đức', 'NV006', N'30 loại linh kiện điện tử'),
('KHO007', N'Kho thiết bị âm thanh Quận 10', N'190 Lý Thái Tổ, Quận 10', 'NV007', N'18 loại thiết bị âm thanh'),
('KHO008', N'Kho màn hình & thiết bị hiển thị Quận 1', N'22 Nguyễn Trãi, Quận 1', 'NV008', N'25 loại màn hình và thiết bị hiển thị'),
('KHO009', N'Kho thiết bị lưu trữ Tân Phú', N'65 Âu Cơ, Tân Phú', 'NV009', N'27 loại thiết bị lưu trữ'),
('KHO010', N'Kho dây cáp và phụ kiện Quận 4', N'11 Hoàng Diệu, Quận 4', 'NV010', N'19 loại dây cáp và phụ kiện')


GO
INSERT INTO HOADON(MAHD, NGAYLAP, TONGTIEN, MAKH, MANV, Trangthai)
VALUES
  ('HD001', '22/10/2018', 2800000, 'KH001', 'NV001', N'Đã thanh toán'),
  ('HD002', '23/10/2018', 16800000, 'KH001', 'NV001', N'Chưa thanh toán'),
  ('HD003', '24/10/2018', 15000000, 'KH001', 'NV001', N'Đã thanh toán'),
  ('HD004', '25/10/2018', 5700000, 'KH002', 'NV001', N'Chưa thanh toán'),
  ('HD005', '26/10/2018', 6000000, 'KH002', 'NV001', N'Đã thanh toán'),
  ('HD006', '27/10/2018', 2600000, 'KH002', 'NV001', N'Chưa thanh toán'),
  ('HD007', '28/10/2018', 1150000, 'KH003', 'NV001', N'Đã thanh toán'),
  ('HD008', '29/10/2018', 4600000, 'KH003', 'NV001', N'Chưa thanh toán'),
  ('HD009', '30/10/2018', 3400000, 'KH003', 'NV001', N'Đã thanh toán'),
  ('HD010', '31/10/2018', 42000000, 'KH003', 'NV001', N'Chưa thanh toán')

  --THEM DU LIEU KHO SAN PHAM
GO
INSERT INTO KHO_SANPHAM (MAKHO, MASP, NGAYNHAP, SOLUONGNHAP)
VALUES
('KHO001', 'SP001', '05/01/2025', 50),
('KHO001', 'SP002', '10/01/2025', 40),
('KHO001', 'SP003', '15/01/2025', 60),
('KHO001', 'SP004', '20/01/2025', 30),
('KHO001', 'SP005', '25/01/2025', 20),

('KHO002', 'SP006', '05/02/2025', 80),
('KHO002', 'SP007', '10/02/2025', 45),
('KHO002', 'SP008', '15/02/2025', 70),
('KHO002', 'SP009', '20/02/2025', 55),
('KHO002', 'SP010', '25/02/2025', 35),

('KHO003', 'SP001', '05/03/2025', 40),
('KHO003', 'SP004', '10/03/2025', 25),
('KHO003', 'SP006', '15/03/2025', 65),
('KHO003', 'SP008', '20/03/2025', 50),
('KHO003', 'SP010', '25/03/2025', 30);

--THEM DU LIEU CHI TIET HOA DON
GO
INSERT INTO CHITIETHOADON(MAHD, MASP, MAKHO, SOLUONG, DONGIA, THANHTIEN)
VALUES ('HD001', 'SP001', 'KHO001', 1 , 2800000, 2800000),
		('HD002', 'SP002', 'KHO001', 4 , 4200000, 16800000),
		('HD003', 'SP003', 'KHO001', 2 , 7500000, 15000000),
		('HD004', 'SP004', 'KHO001', 3 , 1900000, 5700000),
		('HD005', 'SP005', 'KHO001', 5 , 1200000, 6000000),
		('HD006', 'SP006', 'KHO001', 2 , 1300000, 2600000),
		('HD007', 'SP007', 'KHO001', 1 , 1150000, 1150000),
		('HD008', 'SP008', 'KHO001', 2 , 2300000, 4600000),
		('HD009', 'SP009', 'KHO001', 1 , 3400000, 3400000),
		('HD010', 'SP010', 'KHO001', 4 , 10500000, 42000000)

--THEM DU LIEU GIO HANG
GO
INSERT INTO GIOHANG(MAKH, MASP, SOLUONG, MAHD)
VALUES ('KH001', 'SP001', 1, 'HD001'),
		('KH001', 'SP002', 4, 'HD002'),
		('KH001', 'SP003', 2, 'HD003'),
		('KH002', 'SP004', 3, 'HD004'),
		('KH002', 'SP005', 5, 'HD005'),
		('KH002', 'SP006', 2, 'HD006'),
		('KH003', 'SP007', 1, 'HD007'),
		('KH003', 'SP008', 2, 'HD008'),
		('KH003', 'SP009', 1, 'HD009'),
		('KH003', 'SP010', 4, 'HD010')
















GO
USE master