using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhanVien
{
    // ============================================================
    // CHƯƠNG TRÌNH CHÍNH
    // ============================================================
    class Program
    {
        // Danh sách chứa MỌI loại nhân viên, khai báo theo kiểu lớp CHA.
        // Đây chính là nền tảng để áp dụng ĐA HÌNH (Polymorphism):
        // dù phần tử thực chất là NhanVienVanPhong, NhanVienKinhDoanh
        // hay NhanVienThoiVu, ta chỉ cần gọi TinhLuong() / HienThiThongTin()
        // và C# sẽ tự động chạy đúng phiên bản override tương ứng.
        static List<NhanVien> danhSach = new List<NhanVien>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // để hiển thị tiếng Việt có dấu

            TaoDuLieuMauBanDau(); // tạo sẵn ít nhất 5 nhân viên để có dữ liệu demo

            bool tiepTuc = true;
            while (tiepTuc)
            {
                HienThiMenu();
                string luaChon = Console.ReadLine();
                Console.WriteLine();

                switch (luaChon)
                {
                    case "1":
                        ThemNhanVien();
                        break;
                    case "2":
                        XuatDanhSach();
                        break;
                    case "3":
                        TimNhanVienTheoMa();
                        break;
                    case "4":
                        TimNhanVienLuongCaoNhat();
                        break;
                    case "5":
                        TinhTongLuongCongTy();
                        break;
                    case "0":
                        tiepTuc = false;
                        Console.WriteLine("Đã thoát chương trình. Tạm biệt!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                        break;
                }

                Console.WriteLine();
            }
        }

        // ----- Tạo sẵn dữ liệu mẫu (ít nhất 5 nhân viên) -----
        static void TaoDuLieuMauBanDau()
        {
            danhSach.Add(new NhanVienVanPhong("VP01", "Nguyen Van A", 5000000, 22));
            danhSach.Add(new NhanVienVanPhong("VP02", "Tran Thi B", 5500000, 20));
            danhSach.Add(new NhanVienKinhDoanh("KD01", "Le Van C", 4000000, 50000000));
            danhSach.Add(new NhanVienKinhDoanh("KD02", "Pham Thi D", 4200000, 30000000));
            danhSach.Add(new NhanVienThoiVu("TV01", "Hoang Van E", 80, 50000));
        }

        // ----- In menu ra màn hình -----
        static void HienThiMenu()
        {
            Console.WriteLine("========== MENU ==========");
            Console.WriteLine("1. Thêm nhân viên");
            Console.WriteLine("2. Xuất danh sách nhân viên");
            Console.WriteLine("3. Tìm nhân viên theo mã");
            Console.WriteLine("4. Tìm nhân viên có lương cao nhất");
            Console.WriteLine("5. Tính tổng lương công ty phải trả");
            Console.WriteLine("0. Thoát");
            Console.Write("Chọn chức năng: ");
        }

        // ----- 1. Thêm nhân viên -----
        // Lưu ý: việc chọn "loại" nhân viên ở bước NHẬP LIỆU này
        // (để biết nên gọi constructor nào) KHÔNG phải là hành vi
        // đa hình cần tránh if/switch - yêu cầu đề bài chỉ nói
        // KHÔNG dùng if/switch để phân loại khi XUẤT THÔNG TIN
        // và TÍNH LƯƠNG (2 việc đó dùng TinhLuong()/HienThiThongTin()).
        static void ThemNhanVien()
        {
            Console.WriteLine("Chọn loại nhân viên muốn thêm:");
            Console.WriteLine("1. Nhân viên văn phòng");
            Console.WriteLine("2. Nhân viên kinh doanh");
            Console.WriteLine("3. Nhân viên thời vụ");
            Console.Write("Loại: ");
            string loai = Console.ReadLine();

            try
            {
                Console.Write("Mã nhân viên: ");
                string ma = Console.ReadLine();

                Console.Write("Họ tên: ");
                string ten = Console.ReadLine();

                switch (loai)
                {
                    case "1":
                        {
                            Console.Write("Lương cơ bản: ");
                            double luongCoBan = double.Parse(Console.ReadLine());

                            Console.Write("Số ngày làm việc (0-31): ");
                            int soNgay = int.Parse(Console.ReadLine());

                            danhSach.Add(new NhanVienVanPhong(ma, ten, luongCoBan, soNgay));
                            Console.WriteLine("Thêm nhân viên văn phòng thành công!");
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Lương cơ bản: ");
                            double luongCoBan = double.Parse(Console.ReadLine());

                            Console.Write("Doanh số: ");
                            double doanhSo = double.Parse(Console.ReadLine());

                            danhSach.Add(new NhanVienKinhDoanh(ma, ten, luongCoBan, doanhSo));
                            Console.WriteLine("Thêm nhân viên kinh doanh thành công!");
                            break;
                        }
                    case "3":
                        {
                            Console.Write("Số giờ làm: ");
                            int soGio = int.Parse(Console.ReadLine());

                            Console.Write("Lương theo giờ: ");
                            double luongTheoGio = double.Parse(Console.ReadLine());

                            danhSach.Add(new NhanVienThoiVu(ma, ten, soGio, luongTheoGio));
                            Console.WriteLine("Thêm nhân viên thời vụ thành công!");
                            break;
                        }
                    default:
                        Console.WriteLine("Loại nhân viên không hợp lệ.");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Bắt lỗi khi nhập sai định dạng số, hoặc dữ liệu không hợp lệ
                // (do các Property đã kiểm tra và throw exception ở trên).
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }

        // ----- 2. Xuất danh sách nhân viên -----
        static void XuatDanhSach()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách nhân viên đang trống.");
                return;
            }

            Console.WriteLine("----- DANH SÁCH NHÂN VIÊN -----");
            foreach (NhanVien nv in danhSach)
            {
                // ĐA HÌNH: nv có thể là NhanVienVanPhong, NhanVienKinhDoanh
                // hay NhanVienThoiVu, nhưng ta chỉ cần gọi HienThiThongTin()
                // duy nhất một câu lệnh này, C# sẽ tự chọn đúng phiên bản
                // override phù hợp với kiểu thực sự của đối tượng.
                nv.HienThiThongTin();
            }
        }

        // ----- 3. Tìm nhân viên theo mã -----
        static void TimNhanVienTheoMa()
        {
            Console.Write("Nhập mã nhân viên cần tìm: ");
            string ma = Console.ReadLine();

            // Tìm phần tử có MaNV trùng khớp (không phân biệt hoa/thường)
            NhanVien ketQua = danhSach.FirstOrDefault(
                nv => nv.MaNV.Equals(ma, StringComparison.OrdinalIgnoreCase)
            );

            if (ketQua == null)
            {
                Console.WriteLine($"Không tìm thấy nhân viên có mã '{ma}'.");
            }
            else
            {
                Console.WriteLine("Đã tìm thấy nhân viên:");
                ketQua.HienThiThongTin(); // vẫn gọi qua đa hình
            }
        }

        // ----- 4. Tìm nhân viên có lương cao nhất -----
        static void TimNhanVienLuongCaoNhat()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách nhân viên đang trống.");
                return;
            }

            // Thuật toán này chỉ dựa vào TinhLuong() (đa hình),
            // hoàn toàn không quan tâm đối tượng là lớp con nào.
            // => Vì vậy khi thêm NhanVienThoiVu (hoặc bất kỳ loại mới nào
            // khác) trong tương lai, KHÔNG cần sửa đoạn code này.
            NhanVien nvLuongCaoNhat = danhSach[0];
            foreach (NhanVien nv in danhSach)
            {
                if (nv.TinhLuong() > nvLuongCaoNhat.TinhLuong())
                {
                    nvLuongCaoNhat = nv;
                }
            }

            Console.WriteLine("Nhân viên có lương cao nhất là:");
            nvLuongCaoNhat.HienThiThongTin();
        }

        // ----- 5. Tính tổng lương công ty phải trả -----
        static void TinhTongLuongCongTy()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách nhân viên đang trống.");
                return;
            }

            // Tương tự, chỉ cần cộng dồn TinhLuong() của từng nhân viên.
            // Nhờ đa hình, thuật toán này KHÔNG cần biết và KHÔNG cần
            // sửa đổi khi có thêm loại nhân viên mới.
            double tongLuong = 0;
            foreach (NhanVien nv in danhSach)
            {
                tongLuong += nv.TinhLuong();
            }

            Console.WriteLine($"Tổng lương công ty phải trả: {tongLuong:N0} VNĐ");
        }
    }
}
