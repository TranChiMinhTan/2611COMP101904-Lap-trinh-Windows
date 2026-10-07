using System;

namespace QuanLySanPham
{
    // ============================================================
    // CHƯƠNG TRÌNH CHÍNH
    // Chỉ lo việc hiển thị menu, nhận input, gọi ProductService và
    // hiển thị kết quả / bắt lỗi. TOÀN BỘ xử lý nghiệp vụ nằm ở
    // ProductService + Repository<T>, không viết ở đây.
    // ============================================================
    class Program
    {
        // repository là "kho chứa" thật sự, dùng generic Repository<Product>
        static Repository<Product> repository = new Repository<Product>();

        // service là nơi xử lý nghiệp vụ, Program chỉ gọi qua service
        static ProductService service = new ProductService(repository);

        static void Main(string[] args)
        {
            // ----- Đăng ký lắng nghe (subscribe) 2 event -----
            // Khi ProductAdded/ProductRemoved được "Invoke" bên trong
            // ProductService, đoạn code (phương thức) được đăng ký ở đây
            // sẽ tự động được gọi để in thông báo ra màn hình.
            service.ProductAdded += HandleProductAdded;
            service.ProductRemoved += HandleProductRemoved;

            Console.OutputEncoding = System.Text.Encoding.UTF8; // để hiển thị VND

            TaoDuLieuMauBanDau();

            bool tiepTuc = true;
            while (tiepTuc)
            {
                HienThiMenu();
                string luaChon = Console.ReadLine();
                Console.WriteLine();

                // try-catch bao quanh TOÀN BỘ xử lý của mỗi lựa chọn menu
                // để chương trình không bao giờ bị crash (dừng đột ngột)
                // dù người dùng nhập sai dữ liệu hay có lỗi nghiệp vụ.
                try
                {
                    switch (luaChon)
                    {
                        case "1":
                            ThemSanPham();
                            break;
                        case "2":
                            XuatDanhSach();
                            break;
                        case "3":
                            TimTheoMa();
                            break;
                        case "4":
                            TimTheoTen();
                            break;
                        case "5":
                            LocTheoKhoangGia();
                            break;
                        case "6":
                            XoaSanPham();
                            break;
                        case "7":
                            TinhTongGiaTriKho();
                            break;
                        case "0":
                            tiepTuc = false;
                            Console.WriteLine("Đã thoát chương trình. Tạm biệt!");
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                            break;
                    }
                }
                // ----- Bắt các exception TỰ TẠO trước (cụ thể hơn) -----
                catch (DuplicateProductException ex)
                {
                    Console.WriteLine("Lỗi trùng mã sản phẩm: " + ex.Message);
                }
                catch (ProductNotFoundException ex)
                {
                    Console.WriteLine("Lỗi không tìm thấy sản phẩm: " + ex.Message);
                }
                // ----- Bắt lỗi nhập liệu sai định dạng (vd nhập chữ cho số) -----
                catch (FormatException)
                {
                    Console.WriteLine("Lỗi nhập liệu: dữ liệu số không đúng định dạng.");
                }
                // ----- Bắt lỗi dữ liệu không hợp lệ (giá/số lượng âm, ...) -----
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Lỗi dữ liệu không hợp lệ: " + ex.Message);
                }
                // ----- Bắt mọi lỗi khác chưa lường trước, để chương trình -----
                // ----- không bao giờ dừng đột ngột. -----
                catch (Exception ex)
                {
                    Console.WriteLine("Đã có lỗi xảy ra: " + ex.Message);
                }

                Console.WriteLine();
            }
        }

        // ----- Các phương thức xử lý EVENT -----
        // Chữ ký phải khớp với delegate Action<Product>: nhận vào 1
        // Product, không trả về giá trị.
        static void HandleProductAdded(Product sp)
        {
            Console.WriteLine($">> [Event] Đã thêm sản phẩm mới: {sp.MaSP} - {sp.TenSP}");
        }

        static void HandleProductRemoved(Product sp)
        {
            Console.WriteLine($">> [Event] Đã xóa sản phẩm: {sp.MaSP} - {sp.TenSP}");
        }

        // ----- Tạo sẵn vài sản phẩm mẫu để có dữ liệu demo -----
        static void TaoDuLieuMauBanDau()
        {
            service.AddProduct("SP01", "Ban phim co", 550000, 15);
            service.AddProduct("SP02", "Chuot khong day", 250000, 30);
            service.AddProduct("SP03", "Man hinh 24 inch", 3200000, 8);
            Console.WriteLine();
        }

        // ----- Hiển thị menu -----
        static void HienThiMenu()
        {
            Console.WriteLine("===== PRODUCT MANAGER =====");
            Console.WriteLine("1. Them san pham");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim theo ma");
            Console.WriteLine("4. Tim theo ten");
            Console.WriteLine("5. Loc theo khoang gia");
            Console.WriteLine("6. Xoa san pham");
            Console.WriteLine("7. Tinh tong gia tri kho");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon: ");
        }

        // ----- 1. Thêm sản phẩm -----
        static void ThemSanPham()
        {
            Console.Write("Ma san pham: ");
            string ma = Console.ReadLine();

            Console.Write("Ten san pham: ");
            string ten = Console.ReadLine();

            Console.Write("Don gia: ");
            decimal gia = decimal.Parse(Console.ReadLine());

            Console.Write("So luong: ");
            int soLuong = int.Parse(Console.ReadLine());

            // Mọi kiểm tra hợp lệ (mã rỗng, mã trùng, giá/số lượng âm)
            // đều nằm bên trong AddProduct và Product - ở đây chỉ gọi.
            service.AddProduct(ma, ten, gia, soLuong);
            Console.WriteLine("Them san pham thanh cong!");
        }

        // ----- 2. Xuất danh sách -----
        static void XuatDanhSach()
        {
            var danhSach = service.GetAll();

            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sach san pham dang trong.");
                return;
            }

            Console.WriteLine("----- DANH SACH SAN PHAM -----");
            foreach (var sp in danhSach)
            {
                Console.WriteLine(sp); // tự động gọi Product.ToString()
            }
        }

        // ----- 3. Tìm theo mã -----
        static void TimTheoMa()
        {
            Console.Write("Nhap ma san pham can tim: ");
            string ma = Console.ReadLine();

            // Nếu không tìm thấy, FindById sẽ throw ProductNotFoundException,
            // được bắt (catch) ở vòng lặp Main.
            Product sp = service.FindById(ma);

            Console.WriteLine("Da tim thay san pham:");
            Console.WriteLine(sp);
        }

        // ----- 4. Tìm theo tên -----
        static void TimTheoTen()
        {
            Console.Write("Nhap tu khoa ten can tim: ");
            string tuKhoa = Console.ReadLine();

            var ketQua = service.Search(tuKhoa);

            if (ketQua.Count == 0)
            {
                Console.WriteLine($"Khong tim thay san pham nao co ten chua '{tuKhoa}'.");
                return;
            }

            Console.WriteLine("----- KET QUA TIM KIEM -----");
            foreach (var sp in ketQua)
            {
                Console.WriteLine(sp);
            }
        }

        // ----- 5. Lọc theo khoảng giá -----
        static void LocTheoKhoangGia()
        {
            Console.Write("Nhap gia nho nhat: ");
            decimal giaMin = decimal.Parse(Console.ReadLine());

            Console.Write("Nhap gia lon nhat: ");
            decimal giaMax = decimal.Parse(Console.ReadLine());

            var ketQua = service.Filter(giaMin, giaMax);

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong co san pham nao trong khoang gia nay.");
                return;
            }

            Console.WriteLine("----- KET QUA LOC THEO GIA -----");
            foreach (var sp in ketQua)
            {
                Console.WriteLine(sp);
            }
        }

        // ----- 6. Xóa sản phẩm -----
        static void XoaSanPham()
        {
            Console.Write("Nhap ma san pham can xoa: ");
            string ma = Console.ReadLine();

            // Nếu không tồn tại, RemoveProduct sẽ throw ProductNotFoundException.
            // Nếu thành công, event ProductRemoved sẽ tự in thông báo
            // (xem HandleProductRemoved ở trên) - Program không cần in gì thêm.
            service.RemoveProduct(ma);
        }

        // ----- 7. Tính tổng giá trị kho -----
        static void TinhTongGiaTriKho()
        {
            decimal tong = service.TinhTongGiaTriKho();
            Console.WriteLine($"Tong gia tri kho hien tai: {tong:N0} VND");
        }
    }
}
