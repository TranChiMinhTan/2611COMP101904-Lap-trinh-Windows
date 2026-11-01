/* =====================================================================
   COMP1019 - BUỔI 12 - LAB: Data Binding, Stored Procedure và Transaction
   File    : QLSinhVienLab12.sql
   Nội dung: Tạo database QLSinhVienLab12, 4 bảng, dữ liệu mẫu và 4 stored procedure:
             sp_Lop_GetAll, sp_MonHoc_GetAll, sp_KetQua_GetByLopMon, sp_KetQua_Save
   Cách chạy: mở file trong SSMS, bấm Execute (F5) MỘT LẦN cho cả file.
   Có thể chạy lại nhiều lần: script xóa database cũ rồi tạo mới (dữ liệu về như ban đầu).
   ===================================================================== */

USE master;
GO

IF DB_ID(N'QLSinhVienLab12') IS NOT NULL
BEGIN
    -- Đóng mọi kết nối đang mở (kể cả ứng dụng WinForms) để xóa được database.
    ALTER DATABASE QLSinhVienLab12 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
END
GO

DROP DATABASE IF EXISTS QLSinhVienLab12;
GO

CREATE DATABASE QLSinhVienLab12;
GO

USE QLSinhVienLab12;
GO

/* =====================================================================
   1. CÁC BẢNG
   ===================================================================== */
CREATE TABLE LOP
(
    MaLop   VARCHAR(20)   NOT NULL,
    TenLop  NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_LOP PRIMARY KEY (MaLop)
);
GO

CREATE TABLE SINHVIEN
(
    MaSV      VARCHAR(20)   NOT NULL,
    HoTen     NVARCHAR(100) NOT NULL,
    NgaySinh  DATE          NOT NULL,
    MaLop     VARCHAR(20)   NOT NULL,
    CONSTRAINT PK_SINHVIEN      PRIMARY KEY (MaSV),
    CONSTRAINT FK_SINHVIEN_LOP  FOREIGN KEY (MaLop) REFERENCES LOP (MaLop)
);
GO

CREATE TABLE MONHOC
(
    MaMon     VARCHAR(20)   NOT NULL,
    TenMon    NVARCHAR(100) NOT NULL,
    SoTinChi  INT           NOT NULL,
    CONSTRAINT PK_MONHOC          PRIMARY KEY (MaMon),
    CONSTRAINT CK_MONHOC_SoTinChi CHECK (SoTinChi > 0)
);
GO

CREATE TABLE KETQUA
(
    MaSV    VARCHAR(20)   NOT NULL,
    MaMon   VARCHAR(20)   NOT NULL,
    Diem    DECIMAL(4,2)  NOT NULL,          -- điểm hệ 10, tối đa 2 chữ số thập phân
    GhiChu  NVARCHAR(200) NULL,
    CONSTRAINT PK_KETQUA          PRIMARY KEY (MaSV, MaMon),   -- mỗi SV chỉ có 1 điểm cho 1 môn
    CONSTRAINT FK_KETQUA_SINHVIEN FOREIGN KEY (MaSV)  REFERENCES SINHVIEN (MaSV),
    CONSTRAINT FK_KETQUA_MONHOC   FOREIGN KEY (MaMon) REFERENCES MONHOC (MaMon),
    CONSTRAINT CK_KETQUA_Diem     CHECK (Diem BETWEEN 0 AND 10)
);
GO

-- Index cho khóa ngoại KETQUA.MaMon (khóa chính (MaSV, MaMon) đã phục vụ tìm theo MaSV)
-- và SINHVIEN.MaLop (dùng trong sp_KetQua_GetByLopMon).
CREATE INDEX IX_KETQUA_MaMon     ON KETQUA (MaMon);
CREATE INDEX IX_SINHVIEN_MaLop   ON SINHVIEN (MaLop);
GO

/* =====================================================================
   2. DỮ LIỆU MẪU
   ===================================================================== */
INSERT INTO LOP (MaLop, TenLop) VALUES
('CNTT01',  N'Công nghệ thông tin 01'),
('CNTT02',  N'Công nghệ thông tin 02'),
('SPTIN01', N'Sư phạm Tin học 01');          -- lớp chưa có sinh viên (để thử danh sách rỗng)
GO

INSERT INTO SINHVIEN (MaSV, HoTen, NgaySinh, MaLop) VALUES
('SV001', N'Nguyễn Văn An',  '2005-03-14', 'CNTT01'),
('SV002', N'Trần Thị Bình',  '2005-07-21', 'CNTT01'),
('SV003', N'Lê Minh Cường',  '2004-11-02', 'CNTT01'),
('SV004', N'Phạm Thu Dung',  '2005-01-30', 'CNTT01'),
('SV005', N'Hoàng Gia Huy',  '2005-09-09', 'CNTT02'),
('SV006', N'Đỗ Khánh Linh',  '2005-05-18', 'CNTT02'),
('SV007', N'Vũ Quang Minh',  '2004-12-25', 'CNTT02');
GO

INSERT INTO MONHOC (MaMon, TenMon, SoTinChi) VALUES
('LTWIN', N'Lập trình trên Windows', 3),
('CSDL',  N'Cơ sở dữ liệu',          3),
('LTCB',  N'Lập trình căn bản',      3),
('ANH1',  N'Tiếng Anh giao tiếp',    2);
GO

-- Điểm có sẵn: CNTT01 - LTWIN đã nhập cho SV001, SV002 (SV003, SV004 chưa có)
INSERT INTO KETQUA (MaSV, MaMon, Diem, GhiChu) VALUES
('SV001', 'LTWIN', 8.50, N'Làm bài tốt'),
('SV002', 'LTWIN', 7.00, NULL),
('SV001', 'CSDL',  9.00, NULL),
('SV005', 'CSDL',  6.50, N'Cần cố gắng thêm');
GO

/* =====================================================================
   3. STORED PROCEDURE
   ===================================================================== */

-- 3.1. Danh sách lớp
CREATE OR ALTER PROCEDURE dbo.sp_Lop_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaLop, TenLop
    FROM   dbo.LOP
    ORDER BY MaLop;
END
GO

-- 3.2. Danh sách môn học
CREATE OR ALTER PROCEDURE dbo.sp_MonHoc_GetAll
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MaMon, TenMon, SoTinChi
    FROM   dbo.MONHOC
    ORDER BY TenMon;
END
GO

-- 3.3. Sinh viên của một lớp kèm điểm môn học (nếu đã có).
--      LEFT JOIN để sinh viên CHƯA có điểm vẫn xuất hiện (Diem = NULL).
--      Điều kiện môn học đặt trong ON (không đặt trong WHERE) để không làm mất sinh viên chưa có điểm.
CREATE OR ALTER PROCEDURE dbo.sp_KetQua_GetByLopMon
    @MaLop VARCHAR(20),
    @MaMon VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT  sv.MaSV,
            sv.HoTen,
            kq.Diem,
            kq.GhiChu
    FROM    dbo.SINHVIEN sv
            LEFT JOIN dbo.KETQUA kq
                   ON kq.MaSV = sv.MaSV AND kq.MaMon = @MaMon
    WHERE   sv.MaLop = @MaLop
    ORDER BY sv.MaSV;
END
GO

-- 3.4. Lưu điểm của MỘT sinh viên: đã có thì cập nhật, chưa có thì thêm mới.
--      Procedure KHÔNG tự BEGIN/COMMIT: ứng dụng C# mở transaction và gọi procedure này
--      cho từng dòng, nên nếu một dòng lỗi thì C# rollback toàn bộ các dòng trước đó.
--      @KieuLuu (OUTPUT) cho biết đã 'INSERT' hay 'UPDATE' để ứng dụng thống kê.
CREATE OR ALTER PROCEDURE dbo.sp_KetQua_Save
    @MaSV     VARCHAR(20),
    @MaMon    VARCHAR(20),
    @Diem     DECIMAL(4,2),
    @GhiChu   NVARCHAR(200) = NULL,
    @KieuLuu  VARCHAR(6)    = NULL OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;   -- lỗi nào cũng hủy transaction đang mở, không bỏ dở giữa chừng

    IF @Diem IS NULL OR @Diem < 0 OR @Diem > 10
        THROW 50001, N'Điểm phải nằm trong khoảng từ 0 đến 10.', 1;

    UPDATE dbo.KETQUA
    SET    Diem = @Diem, GhiChu = @GhiChu
    WHERE  MaSV = @MaSV AND MaMon = @MaMon;

    IF @@ROWCOUNT > 0
    BEGIN
        SET @KieuLuu = 'UPDATE';
    END
    ELSE
    BEGIN
        -- Nếu MaSV hoặc MaMon không tồn tại, INSERT sẽ vi phạm khóa ngoại (lỗi 547).
        INSERT INTO dbo.KETQUA (MaSV, MaMon, Diem, GhiChu)
        VALUES (@MaSV, @MaMon, @Diem, @GhiChu);
        SET @KieuLuu = 'INSERT';
    END
END
GO

/* =====================================================================
   4. KIỂM TRA NHANH (chụp ảnh nộp bài)
   ===================================================================== */
EXEC dbo.sp_Lop_GetAll;                                      -- 3 lớp
EXEC dbo.sp_MonHoc_GetAll;                                   -- 4 môn
EXEC dbo.sp_KetQua_GetByLopMon @MaLop = 'CNTT01', @MaMon = 'LTWIN';
-- Mong đợi: 4 dòng; SV001 = 8.50, SV002 = 7.00, SV003 và SV004 = NULL
GO