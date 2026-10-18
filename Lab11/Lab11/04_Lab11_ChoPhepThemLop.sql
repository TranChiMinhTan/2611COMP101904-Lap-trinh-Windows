/* =====================================================================
   LAB 11 - Điều chỉnh bảng LOP của buổi 10 để form chỉ nhập MaLop + TenLop
   Chỉ cần chạy nếu bạn dùng database EduManagerDB của buổi 10.
   (Bảng LOP buổi 10 có NamNhapHoc và MaKhoa là NOT NULL nên câu
    INSERT (MaLop, TenLop) của form sẽ bị lỗi nếu không chạy file này.)
   Có thể chạy lại nhiều lần. KHÔNG xóa dữ liệu.
   ===================================================================== */
USE EduManagerDB;
GO

-- Cho phép bỏ trống năm nhập học và khoa (khóa ngoại và CHECK vẫn hoạt động với NULL)
ALTER TABLE LOP ALTER COLUMN NamNhapHoc INT NULL;
ALTER TABLE LOP ALTER COLUMN MaKhoa VARCHAR(10) NULL;
GO

SELECT MaLop, TenLop, NamNhapHoc, MaKhoa FROM LOP;
GO