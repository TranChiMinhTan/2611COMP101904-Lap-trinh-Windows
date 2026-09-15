using System;

namespace Lab02
{
    internal class Program
    {
        // Hàm nhập một số nguyên
        static int NhapSoNguyen(string message)
        {
            int n;

            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out n))
                {
                    return n;
                }

                Console.WriteLine("Du lieu khong hop le! Vui long nhap so nguyen.");
            }
        }

        // Hàm nhập số nguyên dương
        static int NhapSoNguyenDuong(string message)
        {
            int n;

            while (true)
            {
                n = NhapSoNguyen(message);

                if (n > 0)
                {
                    return n;
                }

                Console.WriteLine("Vui long nhap so nguyen duong!");
            }
        }

        // Hàm nhập mảng
        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhap so luong phan tu n: ");

            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen("Nhap a[" + i + "]: ");
            }

            return a;
        }

        // Hàm xuất mảng
        static void XuatMang(int[] a)
        {
            Console.WriteLine("Mang vua nhap la:");

            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }

            Console.WriteLine();
        }

        // Hàm tính tổng
        static int TinhTong(int[] a)
        {
            int tong = 0;

            for (int i = 0; i < a.Length; i++)
            {
                tong = tong + a[i];
            }

            return tong;
        }

        // Hàm tìm giá trị lớn nhất
        static int TimMax(int[] a)
        {
            int max = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }

            return max;
        }

        // Hàm tìm giá trị nhỏ nhất
        static int TimMin(int[] a)
        {
            int min = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }

            return min;
        }

        // Hàm đếm số chẵn
        static int DemChan(int[] a)
        {
            int dem = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                {
                    dem++;
                }
            }

            return dem;
        }

        // Hàm đếm số lẻ
        static int DemLe(int[] a)
        {
            int dem = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 != 0)
                {
                    dem++;
                }
            }

            return dem;
        }

        // Hàm sắp xếp tăng dần
        static void SapXepTangDan(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        // Hàm tìm kiếm
        // Trả về vị trí đầu tiên tìm thấy
        // Nếu không tìm thấy thì trả về -1
        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x)
                {
                    return i;
                }
            }

            return -1;
        }

        // Hàm hiển thị menu
        static void HienThiMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Nhap mang");
            Console.WriteLine("2. Xuat mang");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tim max/min");
            Console.WriteLine("5. Dem chan/le");
            Console.WriteLine("6. Sap xep tang dan");
            Console.WriteLine("7. Tim kiem");
            Console.WriteLine("0. Thoat");
            Console.WriteLine("================");
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Ban dau chua co mang
            int[] a = null;

            int luaChon;

            do
            {
                HienThiMenu();

                luaChon = NhapSoNguyen("Chon chuc nang: ");

                switch (luaChon)
                {
                    case 1:
                        // Nhập mảng
                        a = NhapMang();
                        Console.WriteLine("Nhap mang thanh cong!");
                        break;

                    case 2:
                        // Xuất mảng
                        if (a == null)
                        {
                            Console.WriteLine("Ban chua nhap mang!");
                        }
                        else
                        {
                            XuatMang(a);
                        }
                        break;

                    case 3:
                        // Tính tổng
                        if (a == null)
                        {
                            Console.WriteLine("Ban chua nhap mang!");
                        }
                        else
                        {
                            int tong = TinhTong(a);
                            Console.WriteLine("Tong cac phan tu = " + tong);
                        }
                        break;

                    case 4:
                        // Tìm max/min
                        if (a == null)
                        {
                            Console.WriteLine("Ban chua nhap mang!");
                        }
                        else
                        {
                            int max = TimMax(a);
                            int min = TimMin(a);

                            Console.WriteLine("Gia tri lon nhat = " + max);
                            Console.WriteLine("Gia tri nho nhat = " + min);
                        }
                        break;

                    case 5:
                        // Đếm chẵn/lẻ
                        if (a == null)
                        {
                            Console.WriteLine("Ban chua nhap mang!");
                        }
                        else
                        {
                            int soChan = DemChan(a);
                            int soLe = DemLe(a);

                            Console.WriteLine("So luong phan tu chan = " + soChan);
                            Console.WriteLine("So luong phan tu le = " + soLe);
                        }
                        break;

                    case 6:
                        // Sắp xếp tăng dần
                        if (a == null)
                        {
                            Console.WriteLine("Ban chua nhap mang!");
                        }
                        else
                        {
                            SapXepTangDan(a);

                            Console.WriteLine("Mang sau khi sap xep tang dan:");
                            XuatMang(a);
                        }
                        break;

                    case 7:
                        // Tìm kiếm
                        if (a == null)
                        {
                            Console.WriteLine("Ban chua nhap mang!");
                        }
                        else
                        {
                            int x = NhapSoNguyen("Nhap gia tri x can tim: ");

                            int viTri = TimKiem(a, x);

                            if (viTri == -1)
                            {
                                Console.WriteLine("Khong tim thay " + x + " trong mang.");
                            }
                            else
                            {
                                Console.WriteLine(
                                    "Tim thay " + x +
                                    " tai vi tri dau tien: " + viTri);
                            }
                        }
                        break;

                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh!");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le! Vui long chon lai.");
                        break;
                }

            } while (luaChon != 0);
        }
    }
}