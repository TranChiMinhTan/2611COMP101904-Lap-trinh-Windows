/* =====================================================================
   LAB 10 - EduManagerDB (SQL Server)
   File 03: Các truy vấn SELECT / JOIN / GROUP BY / UPDATE / DELETE
            và kiểm thử ràng buộc dữ liệu.
   Phải chạy 01_CreateDatabase.sql và 02_InsertSampleData.sql trước.

   Ghi chú:
   - Mỗi truy vấn nằm trong 1 batch riêng (ngăn cách bằng GO) nên có thể
     bôi đen từng phần rồi bấm Execute để chụp ảnh kết quả.
   - Câu 5 và 6 (UPDATE, DELETE) chạy trong giao dịch rồi ROLLBACK để dữ
     liệu mẫu không bị đổi; nhờ đó có thể chạy lại script nhiều lần.
   - Câu 11, 12 và các test bổ sung CỐ Ý gây lỗi. Lỗi được bắt bằng
     TRY...CATCH và in ra thông báo, nên script vẫn chạy tiếp được.
   ===================================================================== */

USE EduManagerDB;
GO

/* =====================================================================
   PHẦN A - TRUY VẤN DỮ LIỆU
   ===================================================================== */

/* ---------------------------------------------------------------------
   Câu 1. Liệt kê toàn bộ sinh viên
   --------------------------------------------------------------------- */
SELECT MaSV, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, MaLop
FROM   SINHVIEN
ORDER BY MaSV;
GO

/* ---------------------------------------------------------------------
   Câu 2. Liệt kê sinh viên kèm tên lớp và tên khoa
   SINHVIEN -> LOP (qua MaLop) -> KHOA (qua MaKhoa)
   --------------------------------------------------------------------- */
SELECT sv.MaSV,
       sv.HoTen,
       sv.GioiTinh,
       l.MaLop,
       l.TenLop,
       k.TenKhoa
FROM   SINHVIEN AS sv
       INNER JOIN LOP  AS l ON l.MaLop  = sv.MaLop
       INNER JOIN KHOA AS k ON k.MaKhoa = l.MaKhoa
ORDER BY k.TenKhoa, l.MaLop, sv.MaSV;
GO

/* ---------------------------------------------------------------------
   Câu 3. Tìm sinh viên theo một phần họ tên bằng LIKE
   Dấu % khớp với chuỗi ký tự bất kỳ. Đổi @TuKhoa để tìm tên khác.
   --------------------------------------------------------------------- */
DECLARE @TuKhoa NVARCHAR(50) = N'Minh';

SELECT MaSV, HoTen, MaLop
FROM   SINHVIEN
WHERE  HoTen LIKE N'%' + @TuKhoa + N'%'
ORDER BY HoTen;
GO

/* ---------------------------------------------------------------------
   Câu 4. Liệt kê sinh viên theo mã lớp
   --------------------------------------------------------------------- */
DECLARE @MaLop VARCHAR(10) = 'CNTT49A';

SELECT MaSV, HoTen, NgaySinh, GioiTinh
FROM   SINHVIEN
WHERE  MaLop = @MaLop
ORDER BY MaSV;
GO

/* =====================================================================
   PHẦN B - CẬP NHẬT VÀ XÓA DỮ LIỆU
   ===================================================================== */

/* ---------------------------------------------------------------------
   Câu 5. Cập nhật họ tên và lớp của một sinh viên
   Chạy trong giao dịch: xem dữ liệu trước/sau khi sửa, rồi ROLLBACK để
   trả lại như cũ. Muốn lưu thật thì đổi ROLLBACK thành COMMIT.
   --------------------------------------------------------------------- */
BEGIN TRANSACTION;

SELECT N'TRƯỚC KHI SỬA' AS TrangThai, MaSV, HoTen, MaLop FROM SINHVIEN WHERE MaSV = 'SV003';

UPDATE SINHVIEN
SET    HoTen = N'Lê Minh Cường (đã sửa)',
       MaLop = 'CNTT49B'
WHERE  MaSV  = 'SV003';          -- luôn có WHERE, nếu quên sẽ sửa TOÀN BỘ bảng

SELECT N'SAU KHI SỬA' AS TrangThai, MaSV, HoTen, MaLop FROM SINHVIEN WHERE MaSV = 'SV003';

ROLLBACK TRANSACTION;            -- đổi thành COMMIT TRANSACTION để lưu thay đổi

SELECT N'SAU ROLLBACK' AS TrangThai, MaSV, HoTen, MaLop FROM SINHVIEN WHERE MaSV = 'SV003';
GO

/* ---------------------------------------------------------------------
   Câu 6. Xóa một sinh viên CHƯA có dữ liệu điểm
   Điều kiện NOT EXISTS đảm bảo chỉ xóa sinh viên không có dòng nào trong KETQUA.
   Chạy trong giao dịch rồi ROLLBACK để giữ nguyên dữ liệu mẫu.
   --------------------------------------------------------------------- */
BEGIN TRANSACTION;

-- (a) Thử xóa SV001 - sinh viên ĐÃ có điểm: không dòng nào bị xóa
DELETE FROM SINHVIEN
WHERE  MaSV = 'SV001'
  AND  NOT EXISTS (SELECT 1 FROM KETQUA kq WHERE kq.MaSV = SINHVIEN.MaSV);
SELECT N'Xóa SV001 (đã có điểm)' AS ThaoTac, @@ROWCOUNT AS SoDongBiXoa;

-- (b) Xóa SV007 - sinh viên CHƯA có điểm: xóa được 1 dòng
DELETE FROM SINHVIEN
WHERE  MaSV = 'SV007'
  AND  NOT EXISTS (SELECT 1 FROM KETQUA kq WHERE kq.MaSV = SINHVIEN.MaSV);
SELECT N'Xóa SV007 (chưa có điểm)' AS ThaoTac, @@ROWCOUNT AS SoDongBiXoa;

SELECT N'Danh sách sau khi xóa (trong giao dịch)' AS TrangThai, MaSV, HoTen FROM SINHVIEN ORDER BY MaSV;

ROLLBACK TRANSACTION;            -- đổi thành COMMIT TRANSACTION để xóa thật

SELECT N'Sau ROLLBACK, số sinh viên' AS TrangThai, COUNT(*) AS SoSinhVien FROM SINHVIEN;
GO

/* =====================================================================
   PHẦN C - TRUY VẤN KẾT QUẢ HỌC TẬP VÀ THỐNG KÊ
   ===================================================================== */

/* ---------------------------------------------------------------------
   Câu 7. Liệt kê điểm của từng sinh viên theo từng môn
   --------------------------------------------------------------------- */
SELECT sv.MaSV,
       sv.HoTen,
       mh.MaMH,
       mh.TenMH,
       mh.SoTinChi,
       kq.Diem
FROM   KETQUA AS kq
       INNER JOIN SINHVIEN AS sv ON sv.MaSV = kq.MaSV
       INNER JOIN MONHOC   AS mh ON mh.MaMH = kq.MaMH
ORDER BY sv.MaSV, mh.MaMH;
GO

/* ---------------------------------------------------------------------
   Câu 8. Tính điểm trung bình của từng sinh viên
   - DiemTB        : trung bình cộng các môn.
   - DiemTBTinChi  : trung bình có trọng số theo số tín chỉ.
   Dùng LEFT JOIN để sinh viên chưa có điểm (SV007) vẫn hiện, với điểm NULL.
   --------------------------------------------------------------------- */
SELECT sv.MaSV,
       sv.HoTen,
       COUNT(kq.MaMH)                                              AS SoMonDaCoDiem,
       CAST(AVG(kq.Diem) AS DECIMAL(4,2))                          AS DiemTB,
       CAST(SUM(kq.Diem * mh.SoTinChi) / NULLIF(SUM(mh.SoTinChi), 0) AS DECIMAL(4,2)) AS DiemTBTinChi
FROM   SINHVIEN AS sv
       LEFT JOIN KETQUA AS kq ON kq.MaSV = sv.MaSV
       LEFT JOIN MONHOC AS mh ON mh.MaMH = kq.MaMH
GROUP BY sv.MaSV, sv.HoTen
ORDER BY sv.MaSV;
GO

/* ---------------------------------------------------------------------
   Câu 9. Thống kê số sinh viên theo từng lớp
   LEFT JOIN từ LOP nên lớp chưa có sinh viên (NN50A) vẫn hiện với số 0.
   COUNT(sv.MaSV) chỉ đếm sinh viên thật, không đếm dòng NULL.
   --------------------------------------------------------------------- */
SELECT l.MaLop,
       l.TenLop,
       COUNT(sv.MaSV) AS SoSinhVien
FROM   LOP AS l
       LEFT JOIN SINHVIEN AS sv ON sv.MaLop = l.MaLop
GROUP BY l.MaLop, l.TenLop
ORDER BY l.MaLop;
GO

/* ---------------------------------------------------------------------
   Câu 10. Liệt kê các lớp có từ 2 sinh viên trở lên
   HAVING lọc SAU khi GROUP BY (WHERE không dùng được với hàm gộp COUNT).
   --------------------------------------------------------------------- */
SELECT l.MaLop,
       l.TenLop,
       COUNT(sv.MaSV) AS SoSinhVien
FROM   LOP AS l
       INNER JOIN SINHVIEN AS sv ON sv.MaLop = l.MaLop
GROUP BY l.MaLop, l.TenLop
HAVING COUNT(sv.MaSV) >= 2
ORDER BY SoSinhVien DESC, l.MaLop;
GO

/* =====================================================================
   PHẦN D - KIỂM THỬ RÀNG BUỘC (CỐ Ý NHẬP SAI)
   Mỗi test mong đợi SQL Server báo lỗi. Khối CATCH in ra mã lỗi và nội dung
   lỗi. Nếu câu lệnh lại thành công (thiếu ràng buộc) thì in cảnh báo và
   xóa dữ liệu rác vừa chèn.
   ===================================================================== */

/* ---------------------------------------------------------------------
   Câu 11. Thêm sinh viên vào lớp không tồn tại
   Mong đợi: lỗi 547 - vi phạm khóa ngoại FK_SINHVIEN_LOP
   --------------------------------------------------------------------- */
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV099', N'Sinh viên lớp ma', '2005-01-01', N'Nam', 'KHONGCO');

    PRINT N'CẢNH BÁO: INSERT đã thành công - ràng buộc khóa ngoại không hoạt động!';
    DELETE FROM SINHVIEN WHERE MaSV = 'SV099';
END TRY
BEGIN CATCH
    PRINT N'Câu 11 - ĐÚNG NHƯ MONG ĐỢI: SQL Server đã chặn lớp không tồn tại.';
    SELECT ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS NoiDungLoi;
END CATCH;
GO

/* ---------------------------------------------------------------------
   Câu 12. Nhập điểm ngoài khoảng 0 đến 10
   Mong đợi: lỗi 547 - vi phạm CK_KETQUA_Diem (cả INSERT điểm 11 và UPDATE điểm -1)
   --------------------------------------------------------------------- */
-- 12a. INSERT điểm 11 (> 10)
BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES ('SV004', 'MH01', 11);

    PRINT N'CẢNH BÁO: điểm 11 đã được nhập - ràng buộc CHECK không hoạt động!';
    DELETE FROM KETQUA WHERE MaSV = 'SV004' AND MaMH = 'MH01';
END TRY
BEGIN CATCH
    PRINT N'Câu 12a - ĐÚNG NHƯ MONG ĐỢI: điểm 11 bị chặn.';
    SELECT ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS NoiDungLoi;
END CATCH;
GO

-- 12b. UPDATE điểm -1 (< 0)
BEGIN TRY
    UPDATE KETQUA SET Diem = -1 WHERE MaSV = 'SV001' AND MaMH = 'MH01';

    PRINT N'CẢNH BÁO: điểm -1 đã được ghi - ràng buộc CHECK không hoạt động!';
    UPDATE KETQUA SET Diem = 8.50 WHERE MaSV = 'SV001' AND MaMH = 'MH01';   -- trả lại điểm gốc
END TRY
BEGIN CATCH
    PRINT N'Câu 12b - ĐÚNG NHƯ MONG ĐỢI: điểm -1 bị chặn.';
    SELECT ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS NoiDungLoi;
END CATCH;
GO

/* =====================================================================
   PHẦN E - TEST RÀNG BUỘC BỔ SUNG (ngoài 12 câu bắt buộc)
   ===================================================================== */

-- E1. Giới tính ngoài 'Nam'/'Nữ'  -> lỗi 547 (CK_SINHVIEN_GioiTinh)
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV098', N'Giới tính sai', '2005-01-01', N'Khác', 'CNTT49A');

    PRINT N'CẢNH BÁO: giới tính "Khác" đã được nhập!';
    DELETE FROM SINHVIEN WHERE MaSV = 'SV098';
END TRY
BEGIN CATCH
    PRINT N'E1 - ĐÚNG NHƯ MONG ĐỢI: giới tính không hợp lệ bị chặn.';
    SELECT ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS NoiDungLoi;
END CATCH;
GO

-- E2. Số tín chỉ <= 0  -> lỗi 547 (CK_MONHOC_SoTinChi)
BEGIN TRY
    INSERT INTO MONHOC (MaMH, TenMH, SoTinChi) VALUES ('MH99', N'Môn lỗi', 0);

    PRINT N'CẢNH BÁO: môn học 0 tín chỉ đã được nhập!';
    DELETE FROM MONHOC WHERE MaMH = 'MH99';
END TRY
BEGIN CATCH
    PRINT N'E2 - ĐÚNG NHƯ MONG ĐỢI: số tín chỉ <= 0 bị chặn.';
    SELECT ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS NoiDungLoi;
END CATCH;
GO

-- E3. Trùng khóa chính (MaSV đã tồn tại)  -> lỗi 2627 (PK_SINHVIEN)
BEGIN TRY
    INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, GioiTinh, MaLop)
    VALUES ('SV001', N'Trùng mã', '2005-01-01', N'Nam', 'CNTT49A');

    PRINT N'CẢNH BÁO: mã sinh viên trùng đã được nhập!';
END TRY
BEGIN CATCH
    PRINT N'E3 - ĐÚNG NHƯ MONG ĐỢI: trùng khóa chính bị chặn.';
    SELECT ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS NoiDungLoi;
END CATCH;
GO

-- E4. Điểm cho môn học không tồn tại  -> lỗi 547 (FK_KETQUA_MONHOC)
BEGIN TRY
    INSERT INTO KETQUA (MaSV, MaMH, Diem) VALUES ('SV005', 'MH77', 8);

    PRINT N'CẢNH BÁO: điểm cho môn không tồn tại đã được nhập!';
    DELETE FROM KETQUA WHERE MaSV = 'SV005' AND MaMH = 'MH77';
END TRY
BEGIN CATCH
    PRINT N'E4 - ĐÚNG NHƯ MONG ĐỢI: môn học không tồn tại bị chặn.';
    SELECT ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS NoiDungLoi;
END CATCH;
GO

-- E5. Xóa lớp đang có sinh viên (không dùng ON DELETE CASCADE)  -> lỗi 547 (FK_SINHVIEN_LOP)
BEGIN TRY
    DELETE FROM LOP WHERE MaLop = 'CNTT49A';

    PRINT N'CẢNH BÁO: lớp đang có sinh viên đã bị xóa!';
END TRY
BEGIN CATCH
    PRINT N'E5 - ĐÚNG NHƯ MONG ĐỢI: không xóa được lớp đang có sinh viên.';
    SELECT ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS NoiDungLoi;
END CATCH;
GO

-- E6. Xóa sinh viên đã có điểm mà KHÔNG kiểm tra trước  -> lỗi 547 (FK_KETQUA_SINHVIEN)
BEGIN TRY
    DELETE FROM SINHVIEN WHERE MaSV = 'SV001';

    PRINT N'CẢNH BÁO: sinh viên đã có điểm đã bị xóa!';
END TRY
BEGIN CATCH
    PRINT N'E6 - ĐÚNG NHƯ MONG ĐỢI: không xóa được sinh viên đã có điểm.';
    SELECT ERROR_NUMBER() AS MaLoi, ERROR_MESSAGE() AS NoiDungLoi;
END CATCH;
GO
