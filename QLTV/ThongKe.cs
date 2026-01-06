using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace QLTV
{
    public partial class ThongKe : UserControl
    {
        public ThongKe()
        {
            InitializeComponent();
        }
        ThongKe_BUS tkb = new ThongKe_BUS();
        private void LOAD_DATA()
        {
            DataTable dt = tkb.Load_Sach();
            dataGridView1.DataSource = dt;
            DataTable dt2 = tkb.Load_DocGia();
            dataGridView2.DataSource = dt2;
            DataTable dt3 = tkb.Load_PhieuMuonTra();
            dataGridView3.DataSource = dt3;
            DataTable dt4 = tkb.Load_NhanVien();
            dataGridView4.DataSource = dt4;
        }
        private void ChiNhapSo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private int? ToIntorNull(string text)
        {
            if (int.TryParse(text, out int result)) return result;
            return null;
        }
        private void XuatExel(DataGridView dgv, string tenBaoCao, string dieuKienLoc = "")
        {
            if (dgv.Rows.Count == 0) { MessageBox.Show("Không có dữ liệu!"); return; }

            Excel.Application excel = new Excel.Application();
            Excel.Workbook wb = excel.Workbooks.Add();
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];

            try
            {
                excel.Visible = false;
                excel.ScreenUpdating = false;

                // Lấy danh sách cột thực tế (bỏ qua cột Ảnh)
                List<int> colIndices = new List<int>();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (!dgv.Columns[j].Name.ToLower().Contains("anh") && !(dgv.Columns[j] is DataGridViewImageColumn))
                        colIndices.Add(j);
                }
                int totalCols = colIndices.Count;

                // --- 1. GÓC TRÁI: HACTECH CĂN GIỮA ---
                ws.Cells[1, 1] = "THƯ VIỆN HACTECH";
                Excel.Range truongRange = ws.Range[ws.Cells[1, 1], ws.Cells[1, 1]]; // Gộp khoảng 3 cột đầu
                truongRange.Merge();
                truongRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                truongRange.Font.Bold = true;

                // --- 2. GÓC PHẢI: QUỐC HIỆU, TIÊU NGỮ, NGÀY THÁNG CĂN GIỮA NHAU ---
                int rightStartCol = totalCols - 3;
                if (rightStartCol < 4) rightStartCol = 4; // Tránh đè lên HACTECH

                // Quốc hiệu
                ws.Cells[1, rightStartCol] = "CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM";
                Excel.Range qhRange = ws.Range[ws.Cells[1, rightStartCol], ws.Cells[1, totalCols]];
                qhRange.Merge();
                qhRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                qhRange.Font.Bold = true;

                // Tiêu ngữ
                ws.Cells[2, rightStartCol] = "Độc lập - Tự do - Hạnh phúc";
                Excel.Range tnRange = ws.Range[ws.Cells[2, rightStartCol], ws.Cells[2, totalCols]];
                tnRange.Merge();
                tnRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                tnRange.Font.Underline = true;

                // Hà Nội, ngày... (Căn giữa cùng trục với Quốc hiệu)
                ws.Cells[3, rightStartCol] = "Hà Nội, ngày " + DateTime.Now.ToString("dd/MM/yyyy");
                Excel.Range dateRange = ws.Range[ws.Cells[3, rightStartCol], ws.Cells[3, totalCols]];
                dateRange.Merge();
                dateRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // --- 3. TIÊU ĐỀ BÁO CÁO ---
                ws.Cells[4, 1] = tenBaoCao.ToUpper();
                Excel.Range titleRange = ws.Range[ws.Cells[4, 1], ws.Cells[4, totalCols]];
                titleRange.Merge();
                titleRange.Font.Size = 16;
                titleRange.Font.Bold = true;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                // Điều kiện lọc
                int startRow = 6;
                if (!string.IsNullOrEmpty(dieuKienLoc))
                {
                    ws.Cells[5, 1] = "Điều kiện lọc: " + dieuKienLoc;
                    Excel.Range filterRange = ws.Range[ws.Cells[5, 1], ws.Cells[5, totalCols]];
                    filterRange.Merge();
                    filterRange.Font.Italic = true;            
                    filterRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                }

                // --- 4. XUẤT BẢNG DỮ LIỆU ---
                for (int i = 0; i < colIndices.Count; i++)
                {
                    Excel.Range headerCell = (Excel.Range)ws.Cells[startRow, i + 1];
                    headerCell.Value = dgv.Columns[colIndices[i]].HeaderText;
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = ColorTranslator.ToOle(Color.LightGray);
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    headerCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < colIndices.Count; j++)
                    {
                        Excel.Range dataCell = (Excel.Range)ws.Cells[i + startRow + 1, j + 1];
                        dataCell.Value = dgv.Rows[i].Cells[colIndices[j]].Value?.ToString();
                        dataCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                        if (dgv.Columns[colIndices[j]].HeaderText.ToLower().Contains("gia"))
                            dataCell.NumberFormat = "#,##0";
                    }
                }

                ws.Columns.AutoFit();
                // Giãn cột thêm một chút cho đẹp
                for (int j = 1; j <= totalCols; j++)
                    ((Excel.Range)ws.Columns[j]).ColumnWidth = (double)((Excel.Range)ws.Columns[j]).ColumnWidth + 3;

                // --- 5. FOOTER: NGƯỜI BÁO CÁO CĂN GIỮA VỚI NHAU ---
                int footerRow = startRow + dgv.Rows.Count + 3;

                // Gộp các ô vùng chữ ký để căn giữa nội dung với nhau
                Excel.Range signerTitle = ws.Range[ws.Cells[footerRow, rightStartCol], ws.Cells[footerRow, totalCols]];
                signerTitle.Merge();
                signerTitle.Value = "Người báo cáo";
                signerTitle.Font.Bold = true;
                signerTitle.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                Excel.Range signerSub = ws.Range[ws.Cells[footerRow + 1, rightStartCol], ws.Cells[footerRow + 1, totalCols]];
                signerSub.Merge();
                signerSub.Value = "(Ký và ghi rõ họ tên)";
                signerSub.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                excel.Visible = true;
                excel.ScreenUpdating = true;
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }
        private string LayDieuKien(string nhan, string giaTri)
        {
            if (string.IsNullOrWhiteSpace(giaTri) || giaTri == "-1") return "";
            return $"{nhan}: {giaTri}; ";
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtTenSach.Clear();
            txtTacGia.Clear();
            comboboxDanhMuc.SelectedIndex = -1;
            LOAD_DATA();
        }
        private void guna2GradientTileButton3_Click(object sender, EventArgs e)
        {
            DTO_ThongKeSach dk = new DTO_ThongKeSach
            {
                TenSach = txtTenSach.Text.Trim(),
                TenTG = txtTacGia.Text.Trim(),
                TenNXB = txtNXB.Text.Trim(),
                TenDM = comboboxDanhMuc.Text.Trim(),
                SoLuongTu = ToIntorNull(txtSLtu.Text),
                SoLuongDen = ToIntorNull(txtSLden.Text),
                TonKhoTu = ToIntorNull(txtTonKhotu.Text),
                TonKhoDen = ToIntorNull(txtTonKhoden.Text),
                GiaTu = ToIntorNull(txtGiatu.Text),
                GiaDen = ToIntorNull(txtGiaden.Text),
                NamTu = ToIntorNull(txtNamXBtu.Text),
                NamDen = ToIntorNull(txtNamXBden.Text)
            };
            dataGridView1.DataSource = tkb.ThongKe_Sach(dk);
        }

        private void guna2GradientTileButton5_Click(object sender, EventArgs e)
        {
            string dk = "";
            dk += LayDieuKien("Tên sách", txtTenSach.Text.Trim());
            dk += LayDieuKien("Tác giả", txtTacGia.Text.Trim());
            dk += LayDieuKien("Danh mục", comboboxDanhMuc.Text.Trim());
            dk += LayDieuKien("NXB", txtNXB.Text.Trim());

            // Xử lý khoảng số lượng/giá (nếu có nhập ít nhất 1 ô)
            if (!string.IsNullOrEmpty(txtSLtu.Text) || !string.IsNullOrEmpty(txtSLden.Text))
                dk += $"SL: {txtSLtu.Text} - {txtSLden.Text}; ";

            if (!string.IsNullOrEmpty(txtGiatu.Text) || !string.IsNullOrEmpty(txtGiaden.Text))
                dk += $"Giá: {txtGiatu.Text} - {txtGiaden.Text}; ";

            if (string.IsNullOrEmpty(dk)) dk = "Tất cả danh sách sách";

            XuatExel(dataGridView1, "Bảng Thống Kê Sách", dk);
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            DTO_ThongKeDocGia dk = new DTO_ThongKeDocGia
            {
                TenDocGia = txtDocGia.Text.Trim(),
                TrangThai = comboboxTrangThai.Text.Trim(),
                //SoSachMatDen = ToIntorNull(guna2TextBox13.Text),
                //SoSachMatTu = ToIntorNull(guna2TextBox12.Text),
                //SoSachMuonDen = ToIntorNull(guna2TextBox15.Text),
                //SoSachMuonTu = ToIntorNull(guna2TextBox14.Text)
            };
            dataGridView2.DataSource = tkb.ThongKe_DocGia(dk);
        }

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {
            string dk = "";
            dk += LayDieuKien("Tên độc giả", txtDocGia.Text.Trim());
            dk += LayDieuKien("Trạng thái", comboboxTrangThai.Text.Trim());

            if (string.IsNullOrEmpty(dk)) dk = "Tất cả danh sách độc giả";

            XuatExel(dataGridView2, "Báo Cáo Thống Kê Độc Giả", dk);
        }

        private void guna2GradientTileButton4_Click(object sender, EventArgs e)
        {
            if (DATEngaymuontu.Value > DATEngaymuonden.Value)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Thông báo");
                return;
            }
            DTO_ThongKeMuonTra dk = new DTO_ThongKeMuonTra
            {

                LoaiPhieu = txtLoaiPhieu.Text.Trim(),
                NgayMuonTu = DATEngaymuontu.Checked ? (DateTime?)DATEngaymuontu.Value : null,
                NgayMuonDen = DATEngaymuonden.Checked ? (DateTime?)DATEngaymuonden.Value : null
            };
            dataGridView3.DataSource = tkb.ThongKeMuonTra(dk);
        }

        private void guna2GradientTileButton6_Click(object sender, EventArgs e)
        {
            string dk = "";
            dk += LayDieuKien("Loại phiếu", txtLoaiPhieu.Text.Trim());

            // Kiểm tra nếu người dùng có tick chọn ngày
            if (DATEngaymuontu.Checked) dk += $"Từ ngày: {DATEngaymuontu.Value.ToShortDateString()}; ";
            if (DATEngaymuonden.Checked) dk += $"Đến ngày: {DATEngaymuonden.Value.ToShortDateString()}; ";

            if (string.IsNullOrEmpty(dk)) dk = "Tất cả phiếu mượn trả";

            XuatExel(dataGridView3, "Báo Cáo Thống Kê Mượn Trả", dk);
        }

        private void guna2GradientTileButton7_Click(object sender, EventArgs e)
        {
            DTO_ThongKeNhanVien dk = new DTO_ThongKeNhanVien
            {
                TenNV = txtTenNV.Text.Trim(),
                TrangThai = comboTrangThai.Text.Trim(),
                ID_BoPhan = comboBoPhan.SelectedValue?.ToString(),
                ID_ChucVu = comboChucVu.SelectedValue?.ToString()
            };
            dataGridView4.DataSource = tkb.ThongKe_NhanVien(dk);
        }

        private void guna2GradientTileButton8_Click(object sender, EventArgs e)
        {
            string dk = "";
            dk += LayDieuKien("Tên NV", txtTenNV.Text.Trim());
            dk += LayDieuKien("Bộ phận", comboBoPhan.Text.Trim());
            dk += LayDieuKien("Chức vụ", comboChucVu.Text.Trim());
            dk += LayDieuKien("Trạng thái", comboTrangThai.Text.Trim());

            if (string.IsNullOrEmpty(dk)) dk = "Toàn bộ danh sách nhân viên";

            XuatExel(dataGridView4, "Bảng Thống Kê Nhân Viên", dk);
        }
        Combobox_ThongKE_BUS cbbus = new Combobox_ThongKE_BUS();
        private void loadCombobox()
        {
            DataTable dtDM = cbbus.getDM();
            comboboxDanhMuc.DataSource = dtDM;
            comboboxDanhMuc.DisplayMember = "TenDM";
            comboboxDanhMuc.ValueMember = "ID_DM";
            comboboxDanhMuc.SelectedIndex = -1;
            DataTable dtPB = cbbus.getPB();
            comboBoPhan.DataSource = dtPB;
            comboBoPhan.DisplayMember = "TenPB";
            comboBoPhan.ValueMember = "ID_PB";
            comboBoPhan.SelectedIndex = -1;
            DataTable dtCV = cbbus.getCV();
            comboChucVu.DataSource = dtCV;
            comboChucVu.DisplayMember = "TenCV";
            comboChucVu.ValueMember = "ID_CV";
            comboChucVu.SelectedIndex = -1;
        }
        private void Loadcombobox2()
        {
            List<string> trangThai = new List<string> { "Đang mượn", "Chưa mượn" };
            comboboxTrangThai.DataSource = trangThai;
            comboboxTrangThai.SelectedIndex = -1;
            List<string> trangThaiNV = new List<string> { "Đang làm việc", "Nghỉ việc" };
            comboTrangThai.DataSource = trangThaiNV;
            comboTrangThai.SelectedIndex = -1;
            List<string> loaiPhieu = new List<string> { "Phiếu mượn", "Phiếu trả" };
            txtLoaiPhieu.DataSource = loaiPhieu;
            txtLoaiPhieu.SelectedIndex = -1;
        }
        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedIndex == 1 || guna2TabControl1.SelectedIndex == 4)
            {
                loadCombobox();
                LOAD_DATA();
                Top4NV();
            }
            if (guna2TabControl1.SelectedIndex == 2 || guna2TabControl1.SelectedIndex == 3 || guna2TabControl1.SelectedIndex == 4)
            {
                Loadcombobox2();
                LOAD_DATA();
                Top4NV();
            }
            if (guna2TabControl1.SelectedIndex == 0)
            {
                LoadTop4DocGiaToLabels();
                LoadThongKeTongQuat();
                LoadChart();
            }
        }
        private void LoadTop4DocGiaToLabels()
        {
            // Gọi hàm lấy dữ liệu từ BUS (Hàm này trả về DataTable có 4 dòng)
            DataTable dt = tkb.Top4DG();

            // Kiểm tra nếu có dữ liệu
            if (dt != null && dt.Rows.Count > 0)
            {
                // Dòng 1 (Top 1)
                label2.Text = dt.Rows[0]["TenDG"].ToString();
                label13.Text = dt.Rows[0]["SoLuongMuon"].ToString();

                // Dòng 2 (Top 2)
                if (dt.Rows.Count > 1)
                {
                    label3.Text = dt.Rows[1]["TenDG"].ToString();
                    label14.Text = dt.Rows[1]["SoLuongMuon"].ToString();
                }

                // Dòng 3 (Top 3)
                if (dt.Rows.Count > 2)
                {
                    label11.Text = dt.Rows[2]["TenDG"].ToString();
                    label15.Text = dt.Rows[2]["SoLuongMuon"].ToString();
                }

                // Dòng 4 (Top 4)
                if (dt.Rows.Count > 3)
                {
                    label12.Text = dt.Rows[3]["TenDG"].ToString();
                    label16.Text = dt.Rows[3]["SoLuongMuon"].ToString();
                }
            }
            else
            {
                // Nếu không có dữ liệu, đặt các label về rỗng hoặc giá trị mặc định
                label2.Text = "N/A";
                label13.Text = "0";
                label3.Text = "N/A";
                label14.Text = "0";
                label11.Text = "N/A";
                label15.Text = "0";
                label12.Text = "N/A";
                label16.Text = "0";
            }
        }
        private void LoadThongKeTongQuat()
        {
            DataTable dt = tkb.SLSach();
            if (dt != null && dt.Rows.Count > 0)
            {
                label17.Text = dt.Rows[0]["TongSoLuong"] != DBNull.Value
                                       ? dt.Rows[0]["TongSoLuong"].ToString()
                                       : "0";

                label18.Text = dt.Rows[0]["TongTonKho"] != DBNull.Value
                                     ? dt.Rows[0]["TongTonKho"].ToString()
                                     : "0";
                label19.Text = (Convert.ToInt32(label17.Text) - Convert.ToInt32(label18.Text)).ToString();
            }

        }
        private void LoadChart()
        {
            DataTable dt = tkb.SLSach();
            if (dt != null && dt.Rows.Count > 0)
            {
                label17.Text = dt.Rows[0]["TongSoLuong"] != DBNull.Value ? dt.Rows[0]["TongSoLuong"].ToString() : "0";
                label18.Text = dt.Rows[0]["TongTonKho"] != DBNull.Value ? dt.Rows[0]["TongTonKho"].ToString() : "0";
                int tong = Convert.ToInt32(label17.Text);
                int tonKho = Convert.ToInt32(label18.Text);
                int dangMuon = tong - tonKho;
                label19.Text = dangMuon.ToString();
                chart1.Series.Clear();
                chart1.Titles.Clear();
                chart1.Titles.Add("Tỉ lệ tình trạng sách");
                Series series = new Series("StatusSeries");
                series.ChartType = SeriesChartType.Pie;
                series.Points.AddXY("Đang ở kho", tonKho);
                series.Points.AddXY("Đang cho mượn", dangMuon);
                series.IsValueShownAsLabel = true;
                series.LabelFormat = "{0} cuốn";
                chart1.Series.Add(series);
            }
        }
        private void Top4NV()
        {
            DataTable dt = tkb.Top4NV();
            if (dt != null && dt.Rows.Count > 0)
            {
                // Dòng 1 (Top 1)
                label69.Text = dt.Rows[0]["TenNV"].ToString();
                label73.Text = dt.Rows[0]["TongSachChoMuon"].ToString();
                // Dòng 2 (Top 2)
                if (dt.Rows.Count > 1)
                {
                    label70.Text = dt.Rows[1]["TenNV"].ToString();
                    label74.Text = dt.Rows[1]["TongSachChoMuon"].ToString();
                }
                // Dòng 3 (Top 3)
                if (dt.Rows.Count > 2)
                {
                    label71.Text = dt.Rows[2]["TenNV"].ToString();
                    label75.Text = dt.Rows[2]["TongSachChoMuon"].ToString();
                }
                // Dòng 4 (Top 4)
                if (dt.Rows.Count > 3)
                {
                    label72.Text = dt.Rows[3]["TenNV"].ToString();
                    label76.Text = dt.Rows[3]["TongSachChoMuon"].ToString();
                }
            }
            else
            {
                // Nếu không có dữ liệu, đặt các label về rỗng hoặc giá trị mặc định
                label69.Text = "N/A";
                label73.Text = "0";
                label70.Text = "N/A";
                label74.Text = "0";
                label71.Text = "N/A";
                label75.Text = "0";
                label72.Text = "N/A";
                label76.Text = "0";
            }
        }
    }
}
