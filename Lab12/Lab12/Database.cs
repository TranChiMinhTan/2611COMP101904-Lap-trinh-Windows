using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    /// <summary>
    /// Nơi duy nhất chứa chuỗi kết nối và các hàm dùng chung để làm việc với SQL Server.
    /// </summary>
    public static class Database
    {
        // Sửa phần Server cho đúng máy của bạn:
        //   .\SQLEXPRESS            : SQL Server Express (phổ biến nhất)
        //   localhost               : bản Developer/Standard (instance mặc định)
        //   (localdb)\MSSQLLocalDB  : LocalDB đi kèm Visual Studio
        // Integrated Security=True  : đăng nhập bằng tài khoản Windows.
        // TrustServerCertificate    : tránh lỗi "certificate chain ... not trusted".
        private const string DefaultConnectionString =
            @"Server=.\SQLEXPRESS;Database=QLSinhVienLab12;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;Connect Timeout=5";

        /// <summary>Có thể ghi đè bằng biến môi trường QLSV_CONN mà không cần sửa code.</summary>
        public static string ConnectionString
        {
            get
            {
                string fromEnv = Environment.GetEnvironmentVariable("QLSV_CONN");
                return string.IsNullOrWhiteSpace(fromEnv) ? DefaultConnectionString : fromEnv;
            }
        }

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Gọi một stored procedure trả về bảng, đổ vào DataTable bằng SqlDataAdapter.
        /// Dữ liệu người dùng luôn truyền qua parameters, không nối chuỗi.
        /// </summary>
        public static DataTable LayBang(string tenStoredProcedure, params SqlParameter[] parameters)
        {
            DataTable bang = new DataTable();
            using (SqlConnection conn = CreateConnection())
            using (SqlCommand cmd = new SqlCommand(tenStoredProcedure, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(bang);   // Fill tự mở và đóng kết nối
                }
            }
            return bang;
        }
    }
}
