using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiDoanVien.BUS;
using QuanLiDoanVien.Entity;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;

namespace QuanLiDoanVien
{
    public partial class UC_XepLoaiDV : UserControl
    {
        private bool them;
        string Masv = null;
        string Id_XeploaiSV;
        public UC_XepLoaiDV()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void UC_XepLoaiDV_Load(object sender, EventArgs e)
        {
            dtgrvDV.DataSource = SinhVienService.SinhVien_GetByTop("", "", "").Select(a => new { a.MaSV, a.HoTenSV, a.NgaySinh, a.DienThoai, a.TinhTrang }).ToList();
            dtgrvXeploaiDV.DataSource = XepLoaiSVService.XepLoai_GetByTop("", "", "").Select(a => new { a.Id, a.XepLoai, a.Nam }).ToList();

            cbbxeploai.Items.Add("Xuất sắc");
            cbbxeploai.Items.Add("Tốt");
            cbbxeploai.Items.Add("Khá");
            cbbxeploai.Items.Add("Trung Bình");
            cbbxeploai.Items.Add("Yếu");

        }

        private void dtgrvDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Masv = dtgrvDV.CurrentRow.Cells["masinhvien"].Value.ToString();
          
            dtgrvXeploaiDV.DataSource = XepLoaiSVService.XepLoai_GetByTop("", " MaSV="+ Masv + "", "");
        }
        void LamMoiXepLoaiDV()
        {
            nmrudNam.Value = 2000;
            cbbxeploai.ResetText();
            if(Masv==null)
            {
                dtgrvXeploaiDV.DataSource = XepLoaiSVService.XepLoai_GetByTop("", "", "");
            }
            else
                dtgrvXeploaiDV.DataSource = XepLoaiSVService.XepLoai_GetByTop("", " MaSV=" + Masv + "", "");
            btnluu.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnxoa.Enabled = true;
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            if(Masv!=null)
            {
                them = true;
                btnsua.Enabled = false;
                btnxoa.Enabled = false;
            }
            else
            {
                MessageBox.Show("Bạn phải chọn dòng trong bảng đoàn viên!! ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if(them==true)
            {
                tbl_XepLoaiSV obj = new tbl_XepLoaiSV();
                obj.MaSV = Masv;
                obj.Nam = nmrudNam.Value.ToString();
                obj.XepLoai = cbbxeploai.SelectedItem.ToString();
                if(XepLoaiSVService.XepLoai_Insert(obj)==true)
                {
                    MessageBox.Show("Thêm thành công!!");
                   
                }
            }
            else
            {
                tbl_XepLoaiSV obj = new tbl_XepLoaiSV();
                obj.MaSV = Masv;
                obj.Nam = nmrudNam.Value.ToString();
                obj.XepLoai = cbbxeploai.SelectedItem.ToString();
                obj.Id = Id_XeploaiSV;
                if (XepLoaiSVService.XepLoai_Update(obj) == true)
                {
                    MessageBox.Show("Sửa thành công!!");

                }
            }
            LamMoiXepLoaiDV();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if(Masv==null)
            {
                MessageBox.Show("Bạn phải chọn dòng trong bảng đoàn viên!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Id_XeploaiSV = dtgrvXeploaiDV.CurrentRow.Cells["Id"].Value.ToString();
               nmrudNam.Value= Convert.ToDecimal(dtgrvXeploaiDV.CurrentRow.Cells["Nam"].Value);
                cbbxeploai.SelectedItem = dtgrvXeploaiDV.CurrentRow.Cells["XepLoai"].Value.ToString();
                them = false;
                btnthem.Enabled = false;
                btnxoa.Enabled = false;
            }
         
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc muốn xoá không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (h == DialogResult.Yes)
            {
                tbl_XepLoaiSV dt = new tbl_XepLoaiSV();
                dt.Id = dtgrvXeploaiDV.CurrentRow.Cells["Id"].Value.ToString();
                XepLoaiSVService.XepLoai_Delete(dt);
                LamMoiXepLoaiDV();
            }
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string textsearch = ConvertToUnSign(txtSearch.Text.ToLower());
            //List<tbl_SinhVien> lst = new List<tbl_SinhVien>();
            var lst = SinhVienService.SinhVien_GetByTop("", "", "").Select(a => new { a.MaSV, a.HoTenSV, a.NgaySinh, a.DienThoai, a.TinhTrang }).ToList();
            var v = (from p in lst
                     where ConvertToUnSign(p.HoTenSV.ToLower()).Contains(textsearch)
                     select p).ToList();
            dtgrvDV.DataSource = v;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            LamMoiXepLoaiDV();
        }

        private void btnin_Click(object sender, EventArgs e)
        {
            //Khởi tạo Excel
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            //Khởi tạo WorkBook
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            //Khởi tạo WorkSheet
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            app.Visible = true;
            List<tbl_SinhVien> lst = SinhVienService.SinhVien_GetByTop("", " MaSV="+ Masv + "", "");
            
            worksheet.Cells[1, 4] = "Danh sách hạnh kiểm của đoàn viên ";
            worksheet.Cells[3, 3] = "Mã sinh viên : ";
            worksheet.Cells[3, 4] =  lst[0].MaSV;
            worksheet.Cells[4, 3] = "Họ và tên : ";
            worksheet.Cells[4, 4] = lst[0].HoTenSV;
            worksheet.Cells[5, 3] = "Ngày sinh : ";
            worksheet.Cells[5, 4] = lst[0].NgaySinh;
            worksheet.Cells[6, 3] = "Địa chỉ : ";
            worksheet.Cells[6, 4] = lst[0].DiaChi;
            worksheet.Cells[7, 3] = "Điện thoại : ";
            worksheet.Cells[7, 4] = lst[0].DienThoai;
            worksheet.Cells[8, 3] = "Ngày vào đoàn : ";
            worksheet.Cells[8, 4] = lst[0].NgayVaoDoan;
            worksheet.Cells[9, 3] = "Tình trạng : ";
            worksheet.Cells[9, 4] = lst[0].TinhTrang;
            worksheet.Cells[10, 3] = "Mã dân tộc : ";
            worksheet.Cells[10, 4] = lst[0].MaDT;
            worksheet.Cells[11, 3] = "Mã chi đoàn : ";
            worksheet.Cells[11, 4] = lst[0].MaChiDoan;

            worksheet.Cells[13, 3] = "ID";
            worksheet.Cells[13, 4] = "Năm";
            worksheet.Cells[13, 5] = "Xếp loại";
         
            for (int i = 0; i < dtgrvXeploaiDV.RowCount; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    worksheet.Cells[i + 14, j + 3] = dtgrvXeploaiDV.Rows[i].Cells[j].Value;
                }
            }
            int Sorow = dtgrvXeploaiDV.RowCount;
            //Định dang cột
            worksheet.Range["C1"].ColumnWidth = "17";
            worksheet.Range["D1"].ColumnWidth = "18";
            worksheet.Range["E1"].ColumnWidth = "48";
            //Định dang font chữ
            worksheet.Range["A1", "G100"].Font.Name = "Times New Roman";
            worksheet.Range["A1", "G100"].Font.Size = 14;
            worksheet.Range["D1", "E1"].MergeCells = true;
            worksheet.Range["D1", "E1"].Font.Bold = true;
            worksheet.Range["D1", "E1"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            worksheet.Range["D1", "E1"].Font.Size = 17;
            worksheet.Range["C13", "E"+(Sorow+13)].Borders.LineStyle = 1;

        }

        private void btndxdangvien_Click(object sender, EventArgs e)
        {
            List < int > lst_masv= new List<int>();
            lst_masv = SinhVienService.SinhVien_XetDangVien(Convert.ToInt32(DateTime.Now.Year)-5, Convert.ToInt32(DateTime.Now.Year));
            frmDeXuatDangVien frm = new frmDeXuatDangVien();
            frm.lst_DeXuatDV = lst_masv;
            frm.Show();
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            frmTinhTrangNopPhi frm = new frmTinhTrangNopPhi();
            frm.Show();
        }
    }
}
