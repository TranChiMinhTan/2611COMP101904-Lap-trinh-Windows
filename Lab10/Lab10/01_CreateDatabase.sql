/* =====================================================================
   COMP1019 - BUỔI 10 - LAB: Cơ sở dữ liệu EduManagerDB (SQL Server)
   File    : 01_CreateDatabase.sql
   Mục đích: Tạo database EduManagerDB và 6 bảng:
             KHOA, LOP, SINHVIEN, MONHOC, KETQUA, TAIKHOAN
   Thứ tự chạy: 01_CreateDatabase.sql -> 02_InsertSampleData.sql -> 03_Queries.sql
   Có thể chạy lại nhiều lần: script tự xóa database cũ rồi tạo mới.
   ===================================================================== */

USE master;
GO

-- Nếu database đã tồn tại: đóng mọi kết nối đang mở (kể cả cửa sổ query khác)
-- rồi mới xóa được. ROLLBACK IMMEDIATE hủy các giao dịch đang dở.
IF DB_ID(N'EduManagerDB') IS NOT NULL
BEGIN
    ALTER DATABASE EduManagerDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
END
GO

DROP DATABASE IF EXISTS EduManagerDB;
GO

CREATE DATABASE EduManagerDB;
GO

USE EduManagerDB;
GO

/* =====================================================================
   1. BẢNG KHOA
   Khóa chính: MaKhoa
   ===================================================================== */
CREATE TABLE KHOA
(
    MaKhoa      VARCHAR(10)   NOT NULL,   -- Mã khoa, ví dụ CNTT
    TenKhoa     NVARCHAR(100) NOT NULL,   -- Tên khoa (nvarchar để lưu tiếng Việt có dấu)
    TruongKhoa  NVARCHAR(100) NULL,       -- Tên trưởng khoa (không bắt buộc)

    CONSTRAINT PK_KHOA          PRIMARY KEY (MaKhoa),
    CONSTRAINT UQ_KHOA_TenKhoa  UNIQUE (TenKhoa)          -- Không có 2 khoa trùng tên
);
GO

/* =====================================================================
   2. BẢNG LOP
   Khóa chính: MaLop        Khóa ngoại: MaKhoa -> KHOA(MaKhoa)
   Mỗi lớp thuộc đúng một khoa.
   ===================================================================== */
CREATE TABLE LOP
(
    MaLop       VARCHAR(10)   NOT NULL,   -- Mã lớp, ví dụ CNTT49A
    TenLop      NVARCHAR(100) NOT NULL,   -- Tên lớp
    NamNhapHoc  INT           NOT NULL,   -- Năm nhập học của lớp
    MaKhoa      VARCHAR(10)   NOT NULL,   -- Lớp thuộc khoa nào

    CONSTRAINT PK_LOP           PRIMARY KEY (MaLop),
    CONSTRAINT FK_LOP_KHOA      FOREIGN KEY (MaKhoa) REFERENCES KHOA (MaKhoa),
    CONSTRAINT CK_LOP_NamNhapHoc CHECK (NamNhapHoc BETWEEN 1990 AND 2100)
);
GO

/* =====================================================================
   3. BẢNG SINHVIEN
   Khóa chính: MaSV         Khóa ngoại: MaLop -> LOP(MaLop)
   Mỗi sinh viên thuộc đúng một lớp.
   ===================================================================== */
CREATE TABLE SINHVIEN
(
    MaSV        VARCHAR(10)   NOT NULL,   -- Mã sinh viên, ví dụ SV001
    HoTen       NVARCHAR(100) NOT NULL,   -- Họ và tên
    NgaySinh    DATE          NOT NULL,   -- Ngày sinh
    GioiTinh    NVARCHAR(3)   NOT NULL,   -- Chỉ nhận 'Nam' hoặc 'Nữ'
    DiaChi      NVARCHAR(200) NULL,       -- Địa chỉ (không bắt buộc)
    SoDienThoai VARCHAR(15)   NULL,       -- Số điện thoại (không bắt buộc)
    MaLop       VARCHAR(10)   NOT NULL,   -- Sinh viên thuộc lớp nào

    CONSTRAINT PK_SINHVIEN          PRIMARY KEY (MaSV),
    CONSTRAINT FK_SINHVIEN_LOP      FOREIGN KEY (MaLop) REFERENCES LOP (MaLop),
    CONSTRAINT CK_SINHVIEN_GioiTinh CHECK (GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT CK_SINHVIEN_NgaySinh CHECK (NgaySinh <= GETDATE())   -- Không sinh ở tương lai
);
GO

/* =====================================================================
   4. BẢNG MONHOC
   Khóa chính: MaMH
   ===================================================================== */
CREATE TABLE MONHOC
(
    MaMH        VARCHAR(10)   NOT NULL,   -- Mã môn học, ví dụ CSDL
    TenMH       NVARCHAR(100) NOT NULL,   -- Tên môn học
    SoTinChi    INT           NOT NULL,   -- Số tín chỉ, phải > 0

    CONSTRAINT PK_MONHOC            PRIMARY KEY (MaMH),
    CONSTRAINT CK_MONHOC_SoTinChi   CHECK (SoTinChi > 0)
);
GO

/* =====================================================================
   5. BẢNG KETQUA
   Khóa chính (kép): (MaSV, MaMH)  => mỗi sinh viên chỉ có 1 điểm cho 1 môn
   Khóa ngoại: MaSV -> SINHVIEN(MaSV), MaMH -> MONHOC(MaMH)
   ===================================================================== */
CREATE TABLE KETQUA
(
    MaSV        VARCHAR(10)   NOT NULL,
    MaMH        VARCHAR(10)   NOT NULL,
    Diem        DECIMAL(4,2)  NOT NULL,   -- Điểm hệ 10, tối đa 2 chữ số thập phân (vd 8.75)

    CONSTRAINT PK_KETQUA            PRIMARY KEY (MaSV, MaMH),
    CONSTRAINT FK_KETQUA_SINHVIEN   FOREIGN KEY (MaSV) REFERENCES SINHVIEN (MaSV),
    CONSTRAINT FK_KETQUA_MONHOC     FOREIGN KEY (MaMH) REFERENCES MONHOC (MaMH),
    CONSTRAINT CK_KETQUA_Diem       CHECK (Diem BETWEEN 0 AND 10)
);
GO

/* =====================================================================
   6. BẢNG TAIKHOAN (tài khoản đăng nhập demo cho các bài lab ứng dụng)
   Khóa chính: TenDangNhap
   Mật khẩu KHÔNG lưu dạng chữ thường mà lưu mã băm SHA-256 dưới dạng chuỗi
   hex 64 ký tự, được tạo bằng CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', ...), 2)
   trong file 02. Khi đăng nhập chỉ cần băm mật khẩu người dùng nhập rồi so sánh.
   ===================================================================== */
CREATE TABLE TAIKHOAN
(
    TenDangNhap VARCHAR(50)    NOT NULL,
    MatKhauHash VARCHAR(64)    NOT NULL,  -- Mã băm SHA-256 (hex) của mật khẩu
    HoTen       NVARCHAR(100)  NOT NULL,  -- Tên hiển thị
    VaiTro      NVARCHAR(20)   NOT NULL,  -- 'Admin' hoặc 'User'
    TrangThai   BIT            NOT NULL CONSTRAINT DF_TAIKHOAN_TrangThai DEFAULT (1),  -- 1 = đang hoạt động

    CONSTRAINT PK_TAIKHOAN          PRIMARY KEY (TenDangNhap),
    CONSTRAINT CK_TAIKHOAN_VaiTro   CHECK (VaiTro IN (N'Admin', N'User'))
);
GO

/* =====================================================================
   INDEX cho các cột khóa ngoại
   SQL Server tự tạo index cho khóa chính nhưng KHÔNG tự tạo cho khóa ngoại.
   Các index này giúp JOIN và kiểm tra ràng buộc khi xóa/sửa nhanh hơn.
   (KETQUA đã có index theo (MaSV, MaMH) từ khóa chính nên chỉ cần thêm MaMH.)
   ===================================================================== */
CREATE INDEX IX_LOP_MaKhoa      ON LOP (MaKhoa);
CREATE INDEX IX_SINHVIEN_MaLop  ON SINHVIEN (MaLop);
CREATE INDEX IX_KETQUA_MaMH     ON KETQUA (MaMH);
GO

/* =====================================================================
   Kiểm tra nhanh: liệt kê 6 bảng vừa tạo
   ===================================================================== */
SELECT TABLE_NAME AS TenBang
FROM   INFORMATION_SCHEMA.TABLES
WHERE  TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;
GO
