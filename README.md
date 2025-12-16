# 📚 HỆ THỐNG QUẢN LÝ THƯ VIỆN  
## (Tập trung chức năng MƯỢN – TRẢ SÁCH)

## 1. Giới thiệu
Hệ thống **Quản Lý Thư Viện** được xây dựng nhằm hỗ trợ thư viện trong việc quản lý sách, bạn đọc và đặc biệt là **quy trình mượn – trả sách**.  
Mục tiêu chính là giảm thao tác thủ công, hạn chế sai sót, theo dõi chính xác tình trạng mượn trả và nâng cao hiệu quả quản lý.

---

## 2. Mục tiêu hệ thống
- Quản lý thông tin sách và bạn đọc
- Quản lý quá trình **mượn – trả sách**
- Theo dõi tình trạng sách (đang mượn, còn trong kho)
- Kiểm soát thời hạn trả sách
- Hỗ trợ thống kê, báo cáo

---

## 3. Đối tượng sử dụng
- **Thủ thư**: thực hiện mượn – trả, quản lý sách
- **Quản trị viên**: quản lý hệ thống, dữ liệu
- **Bạn đọc** (gián tiếp): mượn và trả sách thông qua thủ thư

---

## 4. Các chức năng chính

### 4.1 Quản lý sách
- Thêm, sửa, xóa thông tin sách
- Tìm kiếm sách theo:
  - Tên sách
  - Tác giả
  - Thể loại
- Theo dõi tình trạng sách:
  - Còn trong kho
  - Đang được mượn

---

### 4.2 Quản lý bạn đọc
- Thêm, sửa, xóa thông tin bạn đọc
- Lưu các thông tin:
  - Mã bạn đọc
  - Họ tên
  - Số điện thoại
  - Email
- Theo dõi lịch sử mượn trả của từng bạn đọc

---

### 4.3 Quản lý mượn sách (Chức năng trọng tâm)
- Lập **phiếu mượn sách**
- Mỗi phiếu mượn gồm:
  - Mã phiếu mượn
  - Bạn đọc
  - Ngày mượn
  - Ngày hẹn trả
  - Danh sách sách mượn
- Kiểm tra điều kiện mượn:
  - Sách còn trong kho
  - Bạn đọc chưa vượt quá số lượng sách cho phép
- Cập nhật trạng thái sách sang **Đang mượn**

---

### 4.4 Quản lý trả sách
- Lập **phiếu trả sách**
- Kiểm tra:
  - Sách trả đúng hay trễ hạn
- Cập nhật:
  - Ngày trả thực tế
  - Trạng thái sách về **Còn trong kho**
- Ghi nhận tình trạng trả sách

---

### 4.5 Thống kê – báo cáo
- Thống kê:
  - Số lượt mượn theo thời gian
  - Sách được mượn nhiều nhất
  - Bạn đọc mượn nhiều sách
- Xuất báo cáo:
  - Dạng bảng
  - Excel / PDF (nếu có)

---

## 5. Mô hình dữ liệu (tóm tắt)

### Các bảng chính:
- **Sach**  
- **BanDoc**  
- **PhieuMuon**  
- **ChiTietPhieuMuon**  

📌 Quan hệ:
- Một **phiếu mượn** có thể mượn **nhiều sách**
- Một **sách** có thể xuất hiện trong **nhiều phiếu mượn** (theo thời gian)

---

## 6. Công nghệ sử dụng
- **Ngôn ngữ**: C#
- **Giao diện**: WinForms
- **Cơ sở dữ liệu**: SQL Server
- **Mô hình**: MVC / MVP
- **Công cụ**: Visual Studio, SQL Server Management Studio

---

## 7. Ưu điểm của hệ thống
- Giao diện trực quan, dễ sử dụng
- Quản lý mượn – trả rõ ràng, chính xác
- Giảm sai sót so với ghi chép thủ công
- Dễ mở rộng thêm chức năng (phạt trễ hạn, đăng nhập, phân quyền)

---

## 8. Hướng phát triển
- Tính phí phạt trả trễ
- Đăng nhập phân quyền người dùng
- Quản lý số lượng sách theo đầu sách
- Kết nối máy quét mã vạch

---

## 9. Kết luận
Hệ thống Quản Lý Thư Viện với trọng tâm là **mượn – trả sách** giúp tự động hóa quy trình nghiệp vụ thư viện, nâng cao hiệu quả quản lý và đảm bảo tính chính xác trong theo dõi tài nguyên sách.

---

📌 **Tác giả**:  
📌 **Môn học / Đồ án**:  
📌 **Năm thực hiện**:
