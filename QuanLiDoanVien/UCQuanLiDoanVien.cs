using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiDoanVien.Entity;
using QuanLiDoanVien.BUS;
using System.Data;
using System.Text.RegularExpressions;

namespace QuanLiDoanVien
{
    public partial class UCQuanLiDoanVien : UserControl
    {
        string MaChiDoan;
        
        public UCQuanLiDoanVien()
        {
            InitializeComponent();
            
        }
        void LamMoi()
        {
            if(MaChiDoan!=null)
            {
                var result = SinhVienService.SinhVien_GetByTop("", " MaChiDoan=" + MaChiDoan + "", "");
                dtgrvSinhVien.DataSource = result;
            }
        }
        private void Trvkhoahoc_AfterSelect(object sender, TreeViewEventArgs e)
        {

            MaChiDoan = e.Node.Tag.ToString();
            var result = SinhVienService.SinhVien_GetByTop("", " MaChiDoan=" + MaChiDoan + "", "");
             dtgrvSinhVien.DataSource= result ;

        }

        private void UCQuanLiDoanVien_Load(object sender, EventArgs e)
        {
            List<tbl_KhoaHoc> lstkhoahoc = new List<tbl_KhoaHoc>();
            List<tbl_ChiDoan> lstchidoan = new List<tbl_ChiDoan>();
            lstkhoahoc = KhoaHocService.KhoaHocGetByTop("","","");
           
            #region ListKhoaHoc
            TreeNode root = new TreeNode("Danh sách khóa học",0,0);
            root.Tag = 0;
            foreach (var item in lstkhoahoc)
            {
                TreeNode child = new TreeNode(item.ThoiGianDaoTao,2,2);
                lstchidoan = ChiDoanService.ChiDoanGetByTop("", " MaKhoaHoc = " + item.MaKhoaHoc+"", "");
                foreach (var itemCD in lstchidoan)
                {
                    TreeNode childCD = new TreeNode(itemCD.TenChiDoan,1,1);
                    childCD.Tag = itemCD.MaChiDoan;
                    child.Nodes.Add(childCD);
                }
                child.Tag = item.MaKhoaHoc;
                root.Nodes.Add(child);
            }
            Trvkhoahoc.Nodes.Add(root);
            Trvkhoahoc.ExpandAll();
            #endregion

        }

        private void UCQuanLiDoanVien_Resize(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if(MaChiDoan!=null)
            {
                frmSinhVien frm = new frmSinhVien();
                List<tbl_SinhVien> lst = new List<tbl_SinhVien>();
                lst = SinhVienService.SinhVien_GetByTop("", " MaChiDoan=" + MaChiDoan + "", "");
                if (lst.Count == 0)
                    frm.masv = "1";
                else
                    frm.masv = (lst.Count + 1).ToString();
                frm.them = true;
                frm.ShowDialog();
                LamMoi();
            }
           
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            frmSinhVien frm = new frmSinhVien();
            frm.them = false;
            frm.sv_sua.MaSV = dtgrvSinhVien.CurrentRow.Cells["masv"].Value.ToString();
            frm.sv_sua.HoTenSV = dtgrvSinhVien.CurrentRow.Cells["hoten"].Value.ToString();
            frm.sv_sua.NgaySinh = dtgrvSinhVien.CurrentRow.Cells["ngaysinh"].Value.ToString();
            frm.sv_sua.DiaChi = dtgrvSinhVien.CurrentRow.Cells["diachi"].Value.ToString();
            frm.sv_sua.DienThoai = dtgrvSinhVien.CurrentRow.Cells["dienthoai"].Value.ToString();
            frm.sv_sua.TinhTrang = dtgrvSinhVien.CurrentRow.Cells["tinhtrang"].Value.ToString();
            frm.sv_sua.MaDT = dtgrvSinhVien.CurrentRow.Cells["madt"].Value.ToString();
            frm.sv_sua.MaChiDoan = dtgrvSinhVien.CurrentRow.Cells["macd"].Value.ToString();
            frm.sv_sua.NgayVaoDoan = dtgrvSinhVien.CurrentRow.Cells["ngayvaodoan"].Value.ToString();
            frm.ShowDialog();
            LamMoi();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc muốn xoá không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (h == DialogResult.Yes)
            {
                tbl_SinhVien sv = new tbl_SinhVien();
                sv.MaSV = dtgrvSinhVien.CurrentRow.Cells["masv"].Value.ToString();
                SinhVienService.SinhVien_Delete(sv);
                LamMoi();
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
           
        }
        public static string ConvertToUnSign(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            text = text.Replace(" ", "-");
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if(MaChiDoan!=null)
            {
                string textsearch = ConvertToUnSign(txtsearch.Text.ToLower());
                List<tbl_SinhVien> lst = new List<tbl_SinhVien>();
                lst = SinhVienService.SinhVien_GetByTop("", "", "");
                var v = (from p in lst
                         where ConvertToUnSign(p.HoTenSV.ToLower()).Contains(textsearch)
                         && p.MaChiDoan == MaChiDoan
                         select p).ToList();
                dtgrvSinhVien.DataSource = v;
            }
            else
            {
                MessageBox.Show("Bạn phải chọn chi đoàn mới tìm kiếm được","Thông báo");
            }


        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            List<tbl_ChiDoan> TenChiDoan = null;
            TenChiDoan = ChiDoanService.ChiDoanGetByTop("", " MaChiDoan="+MaChiDoan+"", "");
            //Khởi tạo Excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            //Khởi tạo WorkBook
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //Khởi tạo WorkSheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            app.Visible = true;

            worksheet.Cells[2, 2] = "Danh sách thành viên chi đoàn ";
            worksheet.Cells[4, 2] = "Lớp: ";
            worksheet.Cells[4, 3] = TenChiDoan.First().TenChiDoan;
            worksheet.Cells[7, 1] = "STT";
            worksheet.Cells[7, 2] = "Mã sinh viên";
            worksheet.Cells[7, 3] = "Họ và tên";
            worksheet.Cells[7, 4] = "Ngày sinh";
            worksheet.Cells[7, 5] = "Địa chỉ";
            worksheet.Cells[7, 6] = "Điện thoại";
            worksheet.Cells[7, 7] = "Mã chi đoàn";
            worksheet.Cells[7, 8] = "Ngày vào đoàn";
            worksheet.Cells[7, 9] = "Tình trạng";
            worksheet.Cells[7, 10] = "Mã dân tộc";

            for (int i = 0; i < dtgrvSinhVien.RowCount; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    worksheet.Cells[i + 8, 1] = i + 1;
                    worksheet.Cells[i + 8, j + 2] = dtgrvSinhVien.Rows[i].Cells[j].Value;
                }
            }
            int Sorow = dtgrvSinhVien.RowCount;

            //Định dang cột
            worksheet.Range["A1"].ColumnWidth = "6";
            worksheet.Range["B1"].ColumnWidth = "15";
            worksheet.Range["C1"].ColumnWidth = "24";
            worksheet.Range["D1"].ColumnWidth = "12";
            worksheet.Range["E1"].ColumnWidth = "24";
            worksheet.Range["F1"].ColumnWidth = "17";
            worksheet.Range["G1"].ColumnWidth = "14";
            worksheet.Range["H1"].ColumnWidth = "17";
            worksheet.Range["I1"].ColumnWidth = "15";
            worksheet.Range["J1"].ColumnWidth = "16";
            //Định dang font chữ
            worksheet.Range["A1", "J100"].Font.Name = "Times New Roman";
            worksheet.Range["A1", "J100"].Font.Size = 14;
            worksheet.Range["A2", "J2"].MergeCells = true;
            worksheet.Range["A2", "J2"].Font.Bold = true;
            worksheet.Range["A2", "J2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            worksheet.Range["A2", "J2"].Font.Size = 17;
            worksheet.Range["A7", "J" + (Sorow + 7)].Borders.LineStyle = 1;


        }
    }
}
