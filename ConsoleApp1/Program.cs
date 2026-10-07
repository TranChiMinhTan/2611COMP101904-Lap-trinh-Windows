using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.Write("Nhập số lượng sinh viên:");
            int soLuongSinhVien = int.Parse(Console.ReadLine());

            double Tong = 0;

            string tenSinhVienDiemCaoNhat = "";
            double diemCaoNhat = 0;

            int soSinhVienDat = 0;
            string danhSachSinhVienDat = "";

            for (int i = 0; i < soLuongSinhVien; i++)
            {
                Console.Write("Nhập họ tên sinh viên " + (i + 1) + ":");
                string hoTen = Console.ReadLine();
                Console.Write("Nhập điểm sinh viên " + (i + 1) + ":");
                double diem = double.Parse(Console.ReadLine());

                Tong = Tong + diem;

                if (diemCaoNhat < diem)
                {
                    diemCaoNhat = diem;
                    tenSinhVienDiemCaoNhat = hoTen;
                }

                if (diem >= 5)
                {
                    soSinhVienDat++;
                    danhSachSinhVienDat += hoTen + " (" + diem + ")\n";
                }
            }

            double DiemTB = Tong / soLuongSinhVien;
            Console.WriteLine("Điểm trung bình của lớp: " + DiemTB);

            Console.WriteLine("Sinh viên có điểm cao nhất: " + tenSinhVienDiemCaoNhat + " với điểm: " + diemCaoNhat);

            Console.WriteLine("Số sinh viên đạt yêu cầu: " + soSinhVienDat);
            Console.WriteLine("Danh sách sinh viên đạt yêu cầu:");
            Console.WriteLine(danhSachSinhVienDat);
        }
    }
}