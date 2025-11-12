USE MASTER 
GO
USE QLLK
SET DATEFORMAT DMY

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

--THEM DU LIEU KHO SAN PHAM
--GO
--INSERT INTO KHO_SANPHAM (MAKHO, MASP, NGAYNHAP, SOLUONGNHAP)
--VALUES
--('KHO01', 'SP001', '05/01/2025', 50),
--('KHO01', 'SP002', '10/01/2025', 40),
--('KHO01', 'SP003', '15/01/2025', 60),
--('KHO01', 'SP004', '20/01/2025', 30),
--('KHO01', 'SP005', '25/01/2025', 20),

--('KHO02', 'SP006', '05/02/2025', 80),
--('KHO02', 'SP007', '10/02/2025', 45),
--('KHO02', 'SP008', '15/02/2025', 70),
--('KHO02', 'SP009', '20/02/2025', 55),
--('KHO02', 'SP010', '25/02/2025', 35),

--('KHO03', 'SP001', '05/03/2025', 40),
--('KHO03', 'SP004', '10/03/2025', 25),
--('KHO03', 'SP006', '15/03/2025', 65),
--('KHO03', 'SP008', '20/03/2025', 50),
--('KHO03', 'SP010', '25/03/2025', 30);

--THEM DU LIEU TAI KHOAN
GO
INSERT INTO TAIKHOAN(EMAIL, PASS, QUYEN, TRANGTHAI)
VALUES (N'namle75@gmail.com','namle@123', N'USER', N'HOẠT ĐỘNG'),
		(N'tung98@gmail.com','tung@123', N'USER', N'HOẠT ĐỘNG')

--THEM DU LIEU NHAN VIEN
GO
INSERT INTO NHANVIEN (MANV, TENNV, GIOITINH, NGAYSINH, CHUC, LUONG, DIACHI, SDT, EMAIL)
VALUES ('NV001', N'Lê Hoài Nam', N'Nam', '30/04/1975', N'Nhân viên quản kho', 12000000, N'43 Hoàng Hoa Thám', 0977251843, N'namle75@gmail.com')

--THEM DU LIEU KHACH HANG
GO
INSERT INTO KHACHHANG(MAKH, TENKH, SDT, EMAIL, DIACHI, NGAYTAO)
VALUES ('KH001', N'Nguyễn Thanh Tùng', 0972581443, N'tung98@gmail.com', N'987 Võ Thượng Thái Quân', '30/04/2018')

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
('KHO010', N'Kho dây cáp và phụ kiện Quận 4', N'11 Hoàng Diệu, Quận 4', 'NV010', N'19 loại dây cáp và phụ kiện'),
('KHO011', N'Kho linh kiện máy in Quận 3', N'52 Võ Văn Tần, Quận 3', 'NV011', N'17 loại linh kiện máy in'),
('KHO012', N'Kho bo mạch & IC Gia Định', N'234 Phan Đăng Lưu, Phú Nhuận', 'NV012', N'38 loại bo mạch và vi mạch'),
('KHO013', N'Kho thiết bị văn phòng Quận 6', N'90 Hậu Giang, Quận 6', 'NV013', N'21 loại thiết bị văn phòng'),
('KHO014', N'Kho phụ kiện máy tính Quận 12', N'14 Tô Ký, Quận 12', 'NV014', N'29 loại phụ kiện máy tính'),
('KHO015', N'Kho dây điện – cáp mạng Bình Tân', N'67 Mã Lò, Bình Tân', 'NV015', N'24 loại dây & cáp mạng'),
('KHO016', N'Kho thiết bị camera giám sát Tân Bình', N'120 Cộng Hòa, Tân Bình', 'NV016', N'31 loại thiết bị camera & giám sát'),
('KHO017', N'Kho nguồn máy tính & UPS Gò Vấp', N'88 Nguyễn Oanh, Gò Vấp', 'NV017', N'16 loại nguồn máy & UPS'),
('KHO018', N'Kho CPU & bộ vi xử lý Quận 1', N'15 Pasteur, Quận 1', 'NV018', N'14 loại CPU và vi xử lý'),
('KHO019', N'Kho mainboard & thiết bị máy chủ Quận 7', N'300 Nguyễn Văn Linh, Quận 7', 'NV019', N'26 loại mainboard & linh kiện máy chủ'),
('KHO020', N'Kho RAM & bộ nhớ máy tính Bình Thạnh', N'102 Ung Văn Khiêm, Bình Thạnh', 'NV020', N'18 loại RAM & thiết bị bộ nhớ');


GO
INSERT INTO HOADON(MAHD, NGAYLAP, TONGTIEN, MAKH, MANV, Trangthai)
VALUES
  ('HD001', '22/10/2018', 2800000, 'KH001', 'NV001', N'Đã thanh toán'),
  ('HD002', '23/10/2018', 3200000, 'KH001', 'NV001', N'Chưa thanh toán'),
  ('HD003', '24/10/2018', 4500000, 'KH001', 'NV001', N'Đã thanh toán'),
  ('HD004', '25/10/2018', 5600000, 'KH001', 'NV001', N'Chưa thanh toán'),
  ('HD005', '26/10/2018', 2700000, 'KH001', 'NV001', N'Đã thanh toán'),
  ('HD006', '27/10/2018', 3100000, 'KH001', 'NV001', N'Chưa thanh toán'),
  ('HD007', '28/10/2018', 2200000, 'KH001', 'NV001', N'Đã thanh toán'),
  ('HD008', '29/10/2018', 4900000, 'KH001', 'NV001', N'Chưa thanh toán'),
  ('HD009', '30/10/2018', 3300000, 'KH001', 'NV001', N'Đã thanh toán'),
  ('HD010', '31/10/2018', 2400000, 'KH001', 'NV001', N'Chưa thanh toán'),
  ('HD011', '01/11/2018', 5100000, 'KH001', 'NV001', N'Đã thanh toán'),
  ('HD012', '02/11/2018', 6200000, 'KH001', 'NV001', N'Chưa thanh toán'),
  ('HD013', '03/11/2018', 3500000, 'KH001', 'NV001', N'Đã thanh toán'),
  ('HD014', '04/11/2018', 4200000, 'KH001', 'NV001', N'Chưa thanh toán'),
  ('HD015', '05/11/2018', 3000000, 'KH001', 'NV001', N'Đã thanh toán'),
  ('HD016', '06/11/2018', 5400000, 'KH001', 'NV001', N'Chưa thanh toán'),
  ('HD017', '07/11/2018', 4000000, 'KH001', 'NV001', N'Đã thanh toán'),
  ('HD018', '08/11/2018', 2800000, 'KH001', 'NV001', N'Chưa thanh toán'),
  ('HD019', '09/11/2018', 5700000, 'KH001', 'NV001', N'Đã thanh toán'),
  ('HD020', '10/11/2018', 3300000, 'KH001', 'NV001', N'Chưa thanh toán');