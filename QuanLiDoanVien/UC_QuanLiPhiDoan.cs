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
using System.Text.RegularExpressions;

namespace QuanLiDoanVien
{
    public partial class UC_QuanLiPhiDoan : UserControl
    {
        private bool them;
        private void LoadandSetData()
        {
            List<tbl_PhiDoanVien> lst = new List<tbl_PhiDoanVien>();
            lst = PhiDoanVienService.PhiDoanVien_GetByTop("", "", "");
            txtId.Text = "";
            nmrudNam.Value=2000;
            
            cbbmasv.DisplayMember = "HoTenSV";
            cbbmasv.ValueMember = "MaSV";
            cbbmasv.DataSource = SinhVienService.SinhVien_GetByTop("", "", "");
            nmrudPhidoan.Value=10000;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;

            btndelete.Enabled = true;
            txtId.Enabled = false;
            dtgrvPhiDoan.DataSource = lst;
        }
        public UC_QuanLiPhiDoan()
        {
            InitializeComponent();
        }

        private void UC_QuanLiPhiDoan_Load(object sender, EventArgs e)
        {
            LoadandSetData();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            them = true;
            List<Entity.tbl_PhiDoanVien> lst = new List<tbl_PhiDoanVien>();
            lst = PhiDoanVienService.PhiDoanVien_GetByTop("", "", "");
            if (lst.Count != 0)
            {
                txtId.Text = (Convert.ToInt32(lst[lst.Count - 1].ID) + 1).ToString();
            }
            else
                txtId.Text = "1";
            btnsua.Enabled = false;
            btndelete.Enabled = false;
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            them = false;
            txtId.Text = dtgrvPhiDoan.CurrentRow.Cells["ID"].Value.ToString();
            nmrudNam.Value = Convert.ToInt32(dtgrvPhiDoan.CurrentRow.Cells["Nam"].Value);
            cbbmasv.SelectedValue = dtgrvPhiDoan.CurrentRow.Cells["MaSV"].Value.ToString();
            nmrudPhidoan.Value = Convert.ToInt32(dtgrvPhiDoan.CurrentRow.Cells["PhiDoan"].Value);
            btnthem.Enabled = false;
            btndelete.Enabled = false;
            btnsua.Enabled = true;
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc muốn xoá không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (h == DialogResult.Yes)
            {
                tbl_PhiDoanVien dt = new tbl_PhiDoanVien();
                dt.ID = dtgrvPhiDoan.CurrentRow.Cells["ID"].Value.ToString();
                PhiDoanVienService.PhiDoanVien_Delete(dt);
                LoadandSetData();
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
          
                if (them == true)
                {
                    tbl_PhiDoanVien dt = new tbl_PhiDoanVien();
                    dt.MaSV = cbbmasv.SelectedValue.ToString();
                   dt.Nam = nmrudNam.Value.ToString() ;
                    dt.PhiDoan = nmrudPhidoan.Value.ToString();
                    PhiDoanVienService.PhiDoanVien_Insert(dt);
                    MessageBox.Show("Thêm thành công!!!", "Thông báo");
                }
                else
                {
                tbl_PhiDoanVien dt = new tbl_PhiDoanVien();
                    dt.ID = txtId.Text;
                    dt.MaSV = cbbmasv.SelectedValue.ToString();
                    dt.Nam = nmrudNam.Value.ToString();
                    dt.PhiDoan = nmrudPhidoan.Value.ToString();
                   PhiDoanVienService.PhiDoanVien_Update(dt);
                    MessageBox.Show("Sửa thành công!!!", "Thông báo");
                }
            LoadandSetData();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            LoadandSetData();
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
            worksheet.Cells[2, 2] = "Danh sách phí đoàn viên ";
            worksheet.Cells[7, 1] = "STT";
            worksheet.Cells[7, 2] = "ID";
            worksheet.Cells[7, 3] = "Năm";
            worksheet.Cells[7, 4] = "Mã sinh viên";
            worksheet.Cells[7, 5] = "Phí đoàn viên";
            for (int i = 0; i < dtgrvPhiDoan.RowCount; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    worksheet.Cells[i + 8, 1] = i + 1;
                    worksheet.Cells[i + 8, j + 2] = dtgrvPhiDoan.Rows[i].Cells[j].Value;
                }
            }
            int HD_Doan = dtgrvPhiDoan.RowCount;
            //Định dạng trang
            worksheet.PageSetup.Orientation = Microsoft.Office.Interop.Excel.XlPageOrientation.xlPortrait;
            worksheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
            worksheet.PageSetup.LeftMargin = 0;
            worksheet.PageSetup.RightMargin = 0;
            worksheet.PageSetup.TopMargin = 0;
            worksheet.PageSetup.BottomMargin = 0;
            //Định dang cột
            worksheet.Range["A1"].ColumnWidth = 8.43;
            worksheet.Range["B1"].ColumnWidth = 10;
            worksheet.Range["C1"].ColumnWidth = 27.71;
            worksheet.Range["D1"].ColumnWidth = 17;
            worksheet.Range["E1"].ColumnWidth = 18;
            //Định dạng font chữ
            worksheet.Range["A1", "E100"].Font.Name = "Times New Roman";
            worksheet.Range["A1", "E100"].Font.Size = 14;
            worksheet.Range["B2", "E2"].MergeCells = true;
            worksheet.Range["B2", "E2"].Font.Bold = true;
            worksheet.Range["A2", "E2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            worksheet.Range["B2", "E2"].Font.Size = 17;
            worksheet.Range["A7", "E" + (HD_Doan + 7)].Borders.LineStyle = 1;
        }
      
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
         
            List<tbl_PhiDoanVien> lst = new List<tbl_PhiDoanVien>();
            lst = PhiDoanVienService.PhiDoanVien_GetByTop("", "", "");
            var v = (from p in lst
                     where p.Nam.Contains(txtsearch.Text)
                     select p).ToList();
            dtgrvPhiDoan.DataSource = v;
        }
    }
}
