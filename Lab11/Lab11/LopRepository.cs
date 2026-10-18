using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLyLop
{
    /// <summary>
    /// Lớp truy cập dữ liệu cho bảng LOP. Mọi câu SQL đều dùng SqlParameter (F8).
    /// Tách riêng khỏi Form để dễ kiểm thử.
    /// </summary>
    public static class LopRepository
    {
        // Đổi Server cho phù hợp máy bạn:
        //   localhost               : SQL Server cài sẵn, đăng nhập Windows
        //   .\SQLEXPRESS            : bản Express
        //   (localdb)\MSSQLLocalDB  : LocalDB đi kèm Visual Studio
        private const string ConnectionString =
            "Server=localhost\\SQLEXPRESS;Database=EduManagerDB;Integrated Security=True;TrustServerCertificate=True;";

        public const int MaLopToiDa = 10;   // khớp VARCHAR(10) của DB buổi 10 (đề mẫu là 20)
        public const int TenLopToiDa = 100;

        private static SqlConnection TaoKetNoi() => new SqlConnection(ConnectionString);

        // ---------- Kiểm tra dữ liệu nhập (hàm thuần, không cần DB) ----------
        /// <returns>Chuỗi lỗi, hoặc null nếu hợp lệ.</returns>
        public static string KiemTraDuLieu(string maLop, string tenLop)
        {
            if (string.IsNullOrWhiteSpace(maLop)) return "Mã lớp không được để trống.";
            if (string.IsNullOrWhiteSpace(tenLop)) return "Tên lớp không được để trống.";
            if (maLop.Trim().Length > MaLopToiDa) return $"Mã lớp tối đa {MaLopToiDa} ký tự.";
            if (tenLop.Trim().Length > TenLopToiDa) return $"Tên lớp tối đa {TenLopToiDa} ký tự.";
            return null;
        }

        // ---------- Đọc dữ liệu ----------
        public static DataTable LayTatCa()
        {
            const string sql = "SELECT MaLop, TenLop FROM LOP ORDER BY MaLop";
            using var conn = TaoKetNoi();
            using var da = new SqlDataAdapter(sql, conn);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static DataTable TimKiem(string tuKhoa)
        {
            const string sql = @"SELECT MaLop, TenLop FROM LOP
                                 WHERE MaLop LIKE @kw OR TenLop LIKE @kw
                                 ORDER BY MaLop";
            using var conn = TaoKetNoi();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 200).Value = "%" + tuKhoa.Trim() + "%";
            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static bool TonTai(string maLop)
        {
            const string sql = "SELECT COUNT(*) FROM LOP WHERE MaLop = @MaLop";
            using var conn = TaoKetNoi();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = maLop.Trim();
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        public static bool CoSinhVien(string maLop)
        {
            const string sql = "SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @MaLop";
            using var conn = TaoKetNoi();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = maLop.Trim();
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }

        // ---------- Thêm / Sửa / Xóa ----------
        public static int Them(string maLop, string tenLop)
        {
            const string sql = "INSERT INTO LOP (MaLop, TenLop) VALUES (@MaLop, @TenLop)";
            using var conn = TaoKetNoi();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = maLop.Trim();
            cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar, TenLopToiDa).Value = tenLop.Trim();
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public static int Sua(string maLop, string tenLop)
        {
            const string sql = "UPDATE LOP SET TenLop = @TenLop WHERE MaLop = @MaLop";
            using var conn = TaoKetNoi();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = maLop.Trim();
            cmd.Parameters.Add("@TenLop", SqlDbType.NVarChar, TenLopToiDa).Value = tenLop.Trim();
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        public static int Xoa(string maLop)
        {
            const string sql = "DELETE FROM LOP WHERE MaLop = @MaLop";
            using var conn = TaoKetNoi();
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@MaLop", SqlDbType.VarChar, 20).Value = maLop.Trim();
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}
