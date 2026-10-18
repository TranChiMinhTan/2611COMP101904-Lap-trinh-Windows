/* =====================================================================
   LAB 10 - EduManagerDB (SQL Server)
   File 02: Nhập dữ liệu mẫu
   Yêu cầu tối thiểu: 2 khoa, 3 lớp, 6 sinh viên, 4 môn học,
                      8 kết quả học tập, 2 tài khoản.
   Dữ liệu dưới đây: 2 khoa, 4 lớp, 7 sinh viên, 4 môn học,
                      12 kết quả học tập, 2 tài khoản.
   Phải chạy 01_CreateDatabase.sql trước.
   ===================================================================== */

USE EduManagerDB;
GO

-- Nếu có lỗi ở bất kỳ câu lệnh nào thì hủy cả giao dịch, không để dữ liệu nhập dở dang.
SET XACT_ABORT ON;
BEGIN TRANSACTION;

/* ---------------------------------------------------------------------
   Thứ tự nhập phải đi từ bảng "cha" xuống bảng "con" để không vi phạm
   khóa ngoại:  KHOA -> LOP -> SINHVIEN -> MONHOC -> KETQUA -> TAIKHOAN
   --------------------------------------------------------------------- */

-- 1. KHOA (2 khoa)
INSERT INTO KHOA (MaKhoa, TenKhoa, TruongKhoa) VALUES
('CNTT', N'Công nghệ thông tin', N'Trần Quốc Bảo'),
('NN',   N'Ngoại ngữ',          N'Lê Thị Thu Hà');

-- 2. LOP (4 lớp; lớp NN50A cố ý chưa có sinh viên để test LEFT JOIN)
INSERT INTO LOP (MaLop, TenLop, MaKhoa, NamNhapHoc) VALUES
('CNTT49A', N'Công nghệ thông tin K49 - Lớp A', 'CNTT', 2023),
('CNTT49B', N'Công nghệ thông tin K49 - Lớp B', 'CNTT', 2023),
('NN49A',   N'Ngoại ngữ K49 - Lớp A',           'NN',   2023),
('NN50A',   N'Ngoại ngữ K50 - Lớp A',           'NN',   2024);

-- 3. SINHVIEN (7 sinh viên; SV007 cố ý chưa có điểm để test xóa)
INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, MaLop) VALUES
('SV001', N'Nguyễn Văn An',   '2005-03-14', N'Nam', N'12 Nguyễn Trãi, Quận 5, TP.HCM',     '0901000001', 'CNTT49A'),
('SV002', N'Trần Thị Bình',   '2005-07-21', N'Nữ',  N'45 Lê Lợi, Quận 1, TP.HCM',          '0901000002', 'CNTT49A'),
('SV003', N'Lê Minh Cường',   '2004-11-02', N'Nam', N'8 Hai Bà Trưng, Quận 3, TP.HCM',     '0901000003', 'CNTT49A'),
('SV004', N'Phạm Thu Dung',   '2005-01-30', N'Nữ',  N'99 Cách Mạng Tháng 8, Quận 10, TP.HCM', '0901000004', 'CNTT49B'),
('SV005', N'Hoàng Gia Huy',   '2005-09-09', N'Nam', N'27 Võ Văn Tần, Quận 3, TP.HCM',      '0901000005', 'CNTT49B'),
('SV006', N'Đỗ Khánh Linh',   '2005-05-18', N'Nữ',  N'63 Pasteur, Quận 1, TP.HCM',         '0901000006', 'NN49A'),
('SV007', N'Vũ Quang Minh',   '2004-12-25', N'Nam', N'5 Lý Thường Kiệt, Quận 10, TP.HCM',  '0901000007', 'NN49A');

-- 4. MONHOC (4 môn)
INSERT INTO MONHOC (MaMH, TenMH, SoTinChi) VALUES
('MH01', N'Lập trình căn bản',      3),
('MH02', N'Cơ sở dữ liệu',          3),
('MH03', N'Lập trình trên Windows', 4),
('MH04', N'Tiếng Anh giao tiếp',    2);

-- 5. KETQUA (12 kết quả; mỗi cặp (MaSV, MaMH) chỉ xuất hiện 1 lần)
INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES
('SV001', 'MH01', 8.50),
('SV001', 'MH02', 7.00),
('SV001', 'MH03', 9.00),
('SV002', 'MH01', 9.00),
('SV002', 'MH02', 8.00),
('SV003', 'MH01', 6.50),
('SV003', 'MH04', 7.50),
('SV004', 'MH02', 5.50),
('SV004', 'MH03', 6.00),
('SV005', 'MH01', 4.00),
('SV006', 'MH04', 9.50),
('SV006', 'MH03', 8.00);

-- 6. TAIKHOAN (2 tài khoản demo)
-- Mật khẩu demo:  admin -> Admin@123   |   user01 -> User@123
-- Lưu mã băm SHA-256 (hex, 64 ký tự) thay vì chữ thường. CONVERT(..., 2) đổi
-- kết quả HASHBYTES sang chuỗi hex không có tiền tố 0x.
INSERT INTO TAIKHOAN (TenDangNhap, MatKhauHash, HoTen, VaiTro) VALUES
('admin',  CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'Admin@123'), 2), N'Quản trị viên',      N'Admin'),
('user01', CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'User@123'),  2), N'Nhân viên giáo vụ',  N'User');

COMMIT TRANSACTION;
GO

/* ---------------------------------------------------------------------
   Kiểm tra số dòng của từng bảng (dùng để chụp ảnh nộp bài)
   Kết quả mong đợi: KHOA 2, LOP 4, SINHVIEN 7, MONHOC 4, KETQUA 12, TAIKHOAN 2
   --------------------------------------------------------------------- */
SELECT 'KHOA'     AS Bang, COUNT(*) AS SoDong FROM KHOA
UNION ALL SELECT 'LOP',      COUNT(*) FROM LOP
UNION ALL SELECT 'SINHVIEN', COUNT(*) FROM SINHVIEN
UNION ALL SELECT 'MONHOC',   COUNT(*) FROM MONHOC
UNION ALL SELECT 'KETQUA',   COUNT(*) FROM KETQUA
UNION ALL SELECT 'TAIKHOAN', COUNT(*) FROM TAIKHOAN;
GO
