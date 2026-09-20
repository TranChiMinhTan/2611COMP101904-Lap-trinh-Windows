# COMP1019 - Lập trình trên Windows

## Lab 03 - Quản lý sinh viên bằng C#

## 1. Giới thiệu

Chương trình xây dựng một ứng dụng **quản lý sinh viên bằng Console** theo hướng **lập trình hướng đối tượng (OOP)**.

Chương trình cho phép người dùng quản lý danh sách sinh viên thông qua menu. Dữ liệu sinh viên được lưu trong bộ nhớ bằng `List<SinhVien>`.

Sau khi thực hiện một chức năng, chương trình sẽ quay lại menu để người dùng tiếp tục lựa chọn cho đến khi chọn **0 - Thoát**.

Chương trình được thực hiện bằng ngôn ngữ **C#** dưới dạng **Console App**.

---

## 2. Chức năng chương trình

Chương trình gồm các chức năng:

| Lựa chọn | Chức năng         | Mô tả                                            |
| -------- | ------------------| -------------------------------------------------|
| 1        | Thêm sinh viên    | Nhập thông tin sinh viên và thêm vào danh sách   |
| 2        | Xuất danh sách    | In toàn bộ thông tin sinh viên                   |
| 3        | Tìm theo mã       | Tìm sinh viên theo mã sinh viên                  |
| 4        | Tìm theo tên      | Tìm các sinh viên có họ tên chứa từ khóa         |
| 5        | Sửa điểm          | Cập nhật điểm trung bình của sinh viên           |
| 6        | Xóa sinh viên     | Xóa sinh viên theo mã sinh viên                  |
| 7        | Sắp xếp theo điểm | Sắp xếp sinh viên theo điểm giảm dần             |
| 8        | Lọc sinh viên đạt | In các sinh viên có điểm trung bình từ 5 trở lên |
| 0        | Thoát             | Kết thúc chương trình                            |

---

## 3. Yêu cầu kỹ thuật

* Sử dụng **C# Console App**.
* Áp dụng kiến thức **lập trình hướng đối tượng**.
* Sử dụng **class, object, property và constructor**.
* Có quan hệ **kế thừa** giữa class `SinhVien` và class `Nguoi`.
* Sử dụng `List<SinhVien>` để lưu danh sách sinh viên.
* Không viết toàn bộ chương trình trong `Main()`.
* Chương trình được chia thành nhiều class và phương thức riêng biệt.
* Class `Nguoi` phải có constructor và phương thức `LayThongTin()`.
* Class `SinhVien` kế thừa từ class `Nguoi`.
* Property `DiemTrungBinh` chỉ nhận giá trị từ `0` đến `10`.
* Mã sinh viên không được trùng.
* Sử dụng **LINQ** cho ít nhất một chức năng tìm kiếm, lọc hoặc sắp xếp.
* Kiểm tra dữ liệu nhập để chương trình không bị dừng khi người dùng nhập sai.
* Tên class, property và method rõ nghĩa, đúng quy ước **PascalCase** của C#.

---

## 4. Các class và phương thức chính

Chương trình được chia thành các class:

```
Nguoi.cs
SinhVien.cs
QuanLySinhVien.cs
Program.cs
```

### `Nguoi.cs`

Class `Nguoi` là class cha, dùng để lưu những thông tin chung của một người.

Các property:

```
HoTen
NgaySinh
```

Phương thức:

```
LayThongTin()
```

Class `Nguoi` có constructor để khởi tạo thông tin.

---

### `SinhVien.cs`

Class `SinhVien` kế thừa từ class `Nguoi`.

```
SinhVien : Nguoi
```

Các property:

```
MaSinhVien
DiemTrungBinh
MaLop
```

Phương thức:

```
XepLoai()
```

Property `DiemTrungBinh` có kiểm tra dữ liệu và chỉ cho phép nhập điểm trong khoảng từ `0` đến `10`.

Ví dụ:

```
Điểm < 0  → Không hợp lệ
Điểm > 10 → Không hợp lệ
0 ≤ Điểm ≤ 10 → Hợp lệ
```

---

### `QuanLySinhVien.cs`

Class `QuanLySinhVien` chịu trách nhiệm quản lý danh sách sinh viên.

Danh sách được lưu bằng:

```
List<SinhVien>
```

Các phương thức chính:

```
Them()
Sua()
Xoa()
TimTheoMa()
TimTheoTen()
SapXepTheoDiem()
LayDanhSach()
```

Class `QuanLySinhVien` chịu trách nhiệm xử lý danh sách, giúp `Program` không phải trực tiếp xử lý `List<SinhVien>`.

---

### `Program.cs`

Class `Program` chứa phương thức `Main()` và điều khiển luồng chính của chương trình.

Các phương thức chính:

```
Main()
HienThiMenu()
NhapSinhVien()
NhapDiem()
```

`Program` có nhiệm vụ:

* Hiển thị menu.
* Nhận lựa chọn của người dùng.
* Nhập dữ liệu.
* Kiểm tra dữ liệu nhập.
* Gọi các phương thức của `QuanLySinhVien`.
* Điều khiển vòng lặp của chương trình.

---

### `Them()`

Thêm một sinh viên mới vào danh sách.

Trước khi thêm, chương trình kiểm tra mã sinh viên đã tồn tại hay chưa.

Nếu mã sinh viên bị trùng, chương trình thông báo và không thêm sinh viên.

---

### `Sua()`

Tìm sinh viên theo mã và cập nhật điểm trung bình.

Điểm mới phải nằm trong khoảng:

```
0 ≤ Điểm ≤ 10
```

---

### `Xoa()`

Tìm sinh viên theo mã và xóa sinh viên khỏi danh sách nếu tồn tại.

Nếu không tìm thấy mã sinh viên, chương trình thông báo không tìm thấy sinh viên.

---

### `TimTheoMa()`

Tìm sinh viên dựa trên mã sinh viên.

Nếu tìm thấy, chương trình hiển thị thông tin sinh viên.

---

### `TimTheoTen()`

Tìm tất cả sinh viên có họ tên chứa từ khóa được nhập.

Chức năng này sử dụng **LINQ** để tìm kiếm.

Ví dụ:

```
Từ khóa: Nguyễn
```

Chương trình sẽ hiển thị các sinh viên có họ tên chứa từ khóa `Nguyễn`.

---

### `SapXepTheoDiem()`

Sắp xếp danh sách sinh viên theo điểm trung bình **giảm dần**.

Chức năng sử dụng **LINQ** hoặc `Sort`.

Ví dụ:

```
9.5
8.7
8.2
7.5
6.8
```

---

### `LayDanhSach()`

Trả về danh sách sinh viên hiện tại để chương trình có thể xuất thông tin.

---

### `XepLoai()`

Dựa vào điểm trung bình để xác định xếp loại của sinh viên.

Ví dụ có thể sử dụng quy ước:

```
Điểm >= 8.0  → Giỏi
Điểm >= 6.5  → Khá
Điểm >= 5.0  → Trung bình
Điểm < 5.0   → Yếu
```

---

## 5. Menu chương trình

![Giao diện chương trình](images/giaodien.png)

## 6. Dữ liệu kiểm thử

### Dữ liệu được sử dụng để kiểm thử chương trình:

![Dữ liệu kiểm thử](images/testdata.png)

### Test 1: Thêm và xuất danh sách sinh viên

### Test 1.1: Thêm sinh viên

![Thêm sinh viên](images/themsinhvien.png)

### Test 1.2: Xuất danh sách sinh viên

![Xuất danh sách](images/xuatsinhvien.png)

### Test 2: Tìm kiếm sinh viên theo từ khóa

![Tìm kiếm sinh viên](images/timtheotukhoa.png)

### Test 3: Xóa mã sinh viên không tồn tại

Nhập mã sinh viên cần xóa.

Nếu mã sinh viên tồn tại, sinh viên sẽ được xóa khỏi danh sách.

![Xóa sinh viên](images/xoasinhvien.png)

Nếu mã sinh viên không tồn tại, chương trình thông báo không tìm thấy sinh viên.

![Không tìm thấy sinh viên](images/xoamakhongtontai.png)

### Test 4: Lọc sinh viên đạt

Chương trình chỉ hiển thị các sinh viên có điểm trung bình từ `5` trở lên.

![Lọc sinh viên đạt](images/locsinhviendat.png)

## 7. Kiểm tra dữ liệu không hợp lệ

### Test 7.1: Nhập điểm nhỏ hơn 0

Khi nhập điểm `-1` (hoặc các giá trị âm khác) hoặc `11` (hoặc các giá trị lớn hơn 10), chương trình thông báo điểm không hợp lệ và yêu cầu nhập lại

![Nhập điểm không hợp lệ](images/diemkhonghople.png)

### Test 7.2: Thêm sinh viên có mã bị trùng

Khi nhập mã sinh viên đã tồn tại, chương trình thông báo mã sinh viên đã tồn tại.

![Mã sinh viên bị trùng](images/matrung.png)

### Test 7.3: Xóa sinh viên không tồn tại

Khi nhập mã sinh viên không tồn tại, chương trình thông báo không tìm thấy sinh viên để xóa.

![Xóa sinh viên không tồn tại](images/xoamakhongtontai.png)

## 8. Kiến thức đã áp dụng

Qua bài Lab 03, chương trình đã áp dụng các kiến thức:

* Class.
* Object.
* Property.
* Constructor.
* Encapsulation.
* Kế thừa.
* Method.
* `List<T>`.
* LINQ.
* Kiểm tra dữ liệu đầu vào.
* Quản lý danh sách đối tượng.
* Tách chương trình thành nhiều class.

---

## 9. Kết luận

Bài Lab 03 giúp áp dụng kiến thức **C# và lập trình hướng đối tượng** vào một bài toán thực tế là quản lý sinh viên.

Chương trình đã thực hiện được các chức năng thêm, xuất, tìm kiếm, sửa, xóa, sắp xếp và lọc sinh viên. Đồng thời chương trình sử dụng `List<SinhVien>`, kế thừa giữa `Nguoi` và `SinhVien`, cũng như LINQ để xử lý dữ liệu.

Qua bài thực hành, có thể hiểu rõ hơn cách xây dựng một chương trình C# theo hướng đối tượng và cách chia chương trình thành các class, property và method riêng biệt.