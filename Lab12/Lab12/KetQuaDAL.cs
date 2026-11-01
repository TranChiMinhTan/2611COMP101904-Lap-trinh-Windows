using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using QLSinhVienLab12.Helpers;
using QLSinhVienLab12.Models;

namespace QLSinhVienLab12.DAL
{
    /// <summary>
    /// Data Access Layer: mọi thao tác SQL Server của module nhập điểm nằm ở đây.
    /// Form không chứa câu SQL hay SqlCommand nào.
    /// </summary>
    public class KetQuaDAL
    {
        /// <summary>sp_Lop_GetAll -> cột MaLop, TenLop.</summary>
        public DataTable GetLop()
        {
            return Database.LayBang("dbo.sp_Lop_GetAll");
        }

        /// <summary>sp_MonHoc_GetAll -> cột MaMon, TenMon, SoTinChi.</summary>
        public DataTable GetMonHoc()
        {
            return Database.LayBang("dbo.sp_MonHoc_GetAll");
        }

        /// <summary>
        /// sp_KetQua_GetByLopMon -> sinh viên của lớp kèm điểm (nếu đã có).
        /// Bảng trả về có 4 cột chuỗi MaSV, HoTen, Diem, GhiChu.
        /// Cột Diem được đổi sang chuỗi (đã định dạng bằng InvariantCulture) để lưới
        /// không bị phụ thuộc cách ghi số thập phân của Windows (8,5 hay 8.5)
        /// và người dùng gõ chữ vào ô điểm cũng không làm DataGridView báo lỗi định dạng.
        /// </summary>
        public DataTable GetByLopMon(string maLop, string maMon)
        {
            DataTable goc = Database.LayBang("dbo.sp_KetQua_GetByLopMon",
                new SqlParameter("@MaLop", SqlDbType.VarChar, 20) { Value = maLop },
                new SqlParameter("@MaMon", SqlDbType.VarChar, 20) { Value = maMon });

            DataTable bang = new DataTable("KetQua");
            bang.Columns.Add("MaSV", typeof(string));
            bang.Columns.Add("HoTen", typeof(string));
            bang.Columns.Add("Diem", typeof(string));
            bang.Columns.Add("GhiChu", typeof(string));

            foreach (DataRow dong in goc.Rows)
            {
                string diem = dong["Diem"] == DBNull.Value
                    ? ""
                    : DiemValidator.DinhDangDiem(Convert.ToDecimal(dong["Diem"]));
                string ghiChu = dong["GhiChu"] == DBNull.Value ? "" : Convert.ToString(dong["GhiChu"]);
                bang.Rows.Add(Convert.ToString(dong["MaSV"]), Convert.ToString(dong["HoTen"]), diem, ghiChu);
            }
            bang.AcceptChanges();   // coi như dữ liệu gốc, chưa có thay đổi
            return bang;
        }

        /// <summary>
        /// Lưu tất cả dòng điểm trong MỘT transaction:
        ///  - mở một kết nối, BeginTransaction;
        ///  - gọi sp_KetQua_Save cho từng dòng (cùng kết nối, cùng transaction);
        ///  - tất cả thành công -> Commit;
        ///  - bất kỳ dòng nào lỗi -> Rollback toàn bộ rồi ném lại lỗi cho Form hiển thị.
        /// </summary>
        public KetQuaLuu LuuTatCa(string maMon, IList<KetQuaDong> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0)
                throw new ArgumentException("Không có dòng nào để lưu.");

            KetQuaLuu ketQua = new KetQuaLuu();

            using (SqlConnection conn = Database.CreateConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    foreach (KetQuaDong dong in danhSach)
                    {
                        string kieuLuu = LuuMotDong(conn, tran, maMon, dong);
                        if (kieuLuu == "INSERT") ketQua.SoThemMoi++;
                        else ketQua.SoCapNhat++;
                    }

                    tran.Commit();
                    return ketQua;
                }
                catch
                {
                    try { tran.Rollback(); }
                    catch (Exception) { /* kết nối đã hỏng: server tự hủy transaction */ }
                    throw;
                }
                finally
                {
                    tran.Dispose();
                }
            }
        }

        /// <summary>Gọi sp_KetQua_Save cho một dòng; trả về "INSERT" hoặc "UPDATE".</summary>
        private string LuuMotDong(SqlConnection conn, SqlTransaction tran, string maMon, KetQuaDong dong)
        {
            using (SqlCommand cmd = new SqlCommand("dbo.sp_KetQua_Save", conn, tran))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20).Value = dong.MaSV;
                cmd.Parameters.Add("@MaMon", SqlDbType.VarChar, 20).Value = maMon;

                SqlParameter pDiem = cmd.Parameters.Add("@Diem", SqlDbType.Decimal);
                pDiem.Precision = 4;
                pDiem.Scale = 2;
                pDiem.Value = dong.Diem;

                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 200).Value =
                    dong.GhiChu == null ? (object)DBNull.Value : dong.GhiChu;

                SqlParameter pKieu = cmd.Parameters.Add("@KieuLuu", SqlDbType.VarChar, 6);
                pKieu.Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                return Convert.ToString(pKieu.Value);
            }
        }
    }
}
