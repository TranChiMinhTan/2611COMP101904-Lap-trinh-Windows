using System;

namespace Lab03_QuanLySinhVienOOP
{
    /// <summary>
    /// Class Program chỉ lo việc: hiển thị menu, đọc dữ liệu người dùng nhập,
    /// và gọi các method tương ứng bên trong QuanLySinhVien.
    /// Toàn bộ logic xử lý danh sách nằm bên QuanLySinhVien, không xử lý ở đây.
    /// </summary>
    class Program
    {
        // Tạo 1 đối tượng quản lý dùng chung cho cả chương trình.
        static QuanLySinhVien quanLy = new QuanLySinhVien();

        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;  // để nhập tiếng Việt có dấu đúng
            Console.OutputEncoding = System.Text.Encoding.UTF8; // để hiển thị tiếng Việt có dấu đúng

            bool tiepTuc = true;
            while (tiepTuc)
            {
                HienThiMenu();
                int luaChon = DocSoNguyen("Chọn chức năng: ");

                switch (luaChon)
                {
                    case 1: ThemSinhVien(); break;
                    case 2: XuatDanhSach(); break;
                    case 3: TimTheoMa(); break;
                    case 4: TimTheoTen(); break;
                    case 5: SuaDiem(); break;
                    case 6: XoaSinhVien(); break;
                    case 7: SapXepTheoDiem(); break;
                    case 8: LocSinhVienDat(); break;
                    case 0:
                        tiepTuc = false;
                        Console.WriteLine("Tạm biệt!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.\n");
                        break;
                }
            }
        }

        // ================== MENU ==================
        static void HienThiMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== QUAN LY SINH VIEN =====");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim sinh vien theo ten");
            Console.WriteLine("5. Sua diem trung binh");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo diem giam dan");
            Console.WriteLine("8. Loc sinh vien dat");
            Console.WriteLine("0. Thoat");
        }

        // ================== CÁC CHỨC NĂNG ==================

        static void ThemSinhVien()
        {
            Console.WriteLine("\n--- THÊM SINH VIÊN ---");

            string maSV = DocChuoiKhongRong("Nhập mã sinh viên: ");
            string hoTen = DocChuoiKhongRong("Nhập họ tên: ");
            DateTime ngaySinh = DocNgay("Nhập ngày sinh (dd/MM/yyyy): ");
            string maLop = DocChuoiKhongRong("Nhập mã lớp: ");
            double diem = DocDiem("Nhập điểm trung bình (0-10): ");

            SinhVien svMoi = new SinhVien(maSV, hoTen, ngaySinh, maLop, diem);
            bool thanhCong = quanLy.Them(svMoi);

            if (thanhCong)
                Console.WriteLine("Thêm sinh viên thành công!");
            else
                Console.WriteLine($"Mã sinh viên '{maSV}' đã tồn tại. Không thể thêm.");
        }

        static void XuatDanhSach()
        {
            Console.WriteLine("\n--- DANH SÁCH SINH VIÊN ---");
            var danhSach = quanLy.LayDanhSach();
            InDanhSach(danhSach);
        }

        static void TimTheoMa()
        {
            Console.WriteLine("\n--- TÌM SINH VIÊN THEO MÃ ---");
            string maSV = DocChuoiKhongRong("Nhập mã sinh viên cần tìm: ");
            SinhVien sv = quanLy.TimTheoMa(maSV);

            if (sv == null)
                Console.WriteLine("Không tìm thấy sinh viên có mã này.");
            else
                Console.WriteLine(sv.LayThongTin());
        }

        static void TimTheoTen()
        {
            Console.WriteLine("\n--- TÌM SINH VIÊN THEO TÊN ---");
            string tuKhoa = DocChuoiKhongRong("Nhập từ khóa họ tên: ");
            var ketQua = quanLy.TimTheoTen(tuKhoa);

            if (ketQua.Count == 0)
                Console.WriteLine("Không có sinh viên nào phù hợp.");
            else
                InDanhSach(ketQua);
        }

        static void SuaDiem()
        {
            Console.WriteLine("\n--- SỬA ĐIỂM TRUNG BÌNH ---");
            string maSV = DocChuoiKhongRong("Nhập mã sinh viên cần sửa: ");

            if (quanLy.TimTheoMa(maSV) == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên có mã này.");
                return;
            }

            double diemMoi = DocDiem("Nhập điểm trung bình mới (0-10): ");
            bool thanhCong = quanLy.Sua(maSV, diemMoi);

            Console.WriteLine(thanhCong
                ? "Cập nhật điểm thành công!"
                : "Cập nhật thất bại (điểm không hợp lệ).");
        }

        static void XoaSinhVien()
        {
            Console.WriteLine("\n--- XÓA SINH VIÊN ---");
            string maSV = DocChuoiKhongRong("Nhập mã sinh viên cần xóa: ");
            bool thanhCong = quanLy.Xoa(maSV);

            Console.WriteLine(thanhCong
                ? "Xóa sinh viên thành công!"
                : "Không tìm thấy sinh viên có mã này.");
        }

        static void SapXepTheoDiem()
        {
            Console.WriteLine("\n--- DANH SÁCH SẮP XẾP THEO ĐIỂM GIẢM DẦN ---");
            var danhSach = quanLy.SapXepTheoDiem();
            InDanhSach(danhSach);
        }

        static void LocSinhVienDat()
        {
            Console.WriteLine("\n--- DANH SÁCH SINH VIÊN ĐẠT (ĐIỂM >= 5) ---");
            var danhSach = quanLy.LocSinhVienDat();
            InDanhSach(danhSach);
        }

        // ================== HÀM DÙNG CHUNG ==================

        static void InDanhSach(System.Collections.Generic.List<SinhVien> danhSach)
        {
            if (danhSach == null || danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách trống.");
                return;
            }

            foreach (SinhVien sv in danhSach)
            {
                Console.WriteLine(sv.LayThongTin());
            }
        }

        // ================== CÁC HÀM NHẬP DỮ LIỆU AN TOÀN ==================
        // Các hàm dưới đây dùng vòng lặp + try/catch để đảm bảo chương trình
        // KHÔNG bị crash khi người dùng nhập sai kiểu dữ liệu (ví dụ chữ thay vì số).

        static int DocSoNguyen(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int ketQua))
                    return ketQua;

                Console.WriteLine("Giá trị không hợp lệ, vui lòng nhập một số nguyên.");
            }
        }

        static double DocDiem(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();

                if (!double.TryParse(input, out double diem))
                {
                    Console.WriteLine("Giá trị không hợp lệ, vui lòng nhập một số (ví dụ 7.5).");
                    continue;
                }

                if (diem < 0 || diem > 10)
                {
                    Console.WriteLine("Điểm không hợp lệ, phải nằm trong khoảng 0 đến 10. Vui lòng nhập lại.");
                    continue;
                }

                return diem;
            }
        }

        static DateTime DocNgay(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();

                if (DateTime.TryParseExact(
                        input,
                        "dd/MM/yyyy",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None,
                        out DateTime ngay))
                {
                    return ngay;
                }

                Console.WriteLine("Ngày không hợp lệ, vui lòng nhập theo định dạng dd/MM/yyyy (ví dụ 15/03/2004).");
            }
        }

        static string DocChuoiKhongRong(string thongBao)
        {
            while (true)
            {
                Console.Write(thongBao);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine("Giá trị không được để trống, vui lòng nhập lại.");
            }
        }
    }
}
