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