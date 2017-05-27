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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
namespace QuanLiDoanVien
{
    public partial class UC_frmHoatDongDoan : UserControl
    {
        private bool them;
        private void LoadandSetData()
        {
            List<tbl_HoatDongDoan> lst = new List<tbl_HoatDongDoan>();
            lst = HoatDongDoanService.HoatDongDoan_GetByTop("", "", "");
            txtketqua.Text = "";
            txtTenHD.Text = "";
            cbbNguoiphutrach.Text = "";
            dtipThoiGian.ResetValue();
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = false;
            btnhuy.Enabled = false;

            btndelete.Enabled = true;
            txtId.Enabled = false;
            dtgrvHdDoan.DataSource = lst;
        }
        public UC_frmHoatDongDoan()
        {
            InitializeComponent();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            them = true;
            List<Entity.tbl_HoatDongDoan> lst = new List<tbl_HoatDongDoan>();
            lst = HoatDongDoanService.HoatDongDoan_GetByTop("", "", "");
            if (lst.Count != 0)
            {
                txtId.Text = (Convert.ToInt32(lst[lst.Count - 1].Id) + 1).ToString();
            }
            else
                txtId.Text = "1";
            btnsua.Enabled = false;
            btndelete.Enabled = false;
            btnhuy.Enabled = true;
            btnluu.Enabled = true;
        }

        private void UC_frmHoatDongDoan_Load(object sender, EventArgs e)
        {
            LoadandSetData();
        }
        private void GetMaCanBo(string macb)
        {
            cbbNguoiphutrach.Text = macb;
        }

        private void cbbNguoiphutrach_Click(object sender, EventArgs e)
        {
            cbbCanBoDoan cbbCB = new cbbCanBoDoan();
            cbbCB.send = new cbbCanBoDoan.Send_MaCB(GetMaCanBo);
            cbbCB.ShowDialog();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            them = false;
            txtId.Text = dtgrvHdDoan.CurrentRow.Cells["columnid"].Value.ToString();
            txtTenHD.Text = dtgrvHdDoan.CurrentRow.Cells["columnTenHD"].Value.ToString();
            dtipThoiGian.Value = Convert.ToDateTime(dtgrvHdDoan.CurrentRow.Cells["columnThoiGian"].Value.ToString());
            cbbNguoiphutrach.Text = dtgrvHdDoan.CurrentRow.Cells["columnmaCB"].Value.ToString();
            txtketqua.Text = dtgrvHdDoan.CurrentRow.Cells["columnKQ"].Value.ToString();
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
                tbl_HoatDongDoan dt = new tbl_HoatDongDoan();
                dt.Id = dtgrvHdDoan.CurrentRow.Cells["columnid"].Value.ToString();
                HoatDongDoanService.HoatDongDoan_Delete(dt);
                LoadandSetData();
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (txtTenHD.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!!!");
                return;
            }
            else
            {
                if (them == true)
                {
                    tbl_HoatDongDoan dt = new tbl_HoatDongDoan();
                    dt.KetQua = txtketqua.Text;
                    dt.MaCB = cbbNguoiphutrach.Text.ToString();
                    dt.TenHoatDong = txtTenHD.Text;
                    dt.ThoiGian = dtipThoiGian.Value.ToString();
                    HoatDongDoanService.HoatDongDoan_Insert(dt);
                    MessageBox.Show("Thêm thành công!!!", "Thông báo");
                }
                else
                {
                    tbl_HoatDongDoan dt = new tbl_HoatDongDoan();
                    dt.KetQua = txtketqua.Text;
                    dt.MaCB = cbbNguoiphutrach.Text.ToString();
                    dt.TenHoatDong = txtTenHD.Text;
                    dt.ThoiGian = dtipThoiGian.Value.ToString();
                    dt.Id = txtId.Text;
                    HoatDongDoanService.HoatDongDoan_Update(dt);
                    MessageBox.Show("Sửa thành công!!!", "Thông báo");
                }
            }
            LoadandSetData();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            LoadandSetData();
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
            string textsearch = ConvertToUnSign(txtsearch.Text.ToLower());
            List<tbl_HoatDongDoan> lst = new List<tbl_HoatDongDoan>();
            lst = HoatDongDoanService.HoatDongDoan_GetByTop("", "", "");
            var v = (from p in lst
                     where ConvertToUnSign(p.TenHoatDong.ToLower()).Contains(textsearch)
                     select p).ToList();
            dtgrvHdDoan.DataSource = v;
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
            worksheet.Cells[2, 2] = "Danh sách hoạt động đoàn thanh niên ";
            worksheet.Cells[7, 1] = "STT";
            worksheet.Cells[7, 2] = "ID";
            worksheet.Cells[7, 3] = "Tên hoạt động";
            worksheet.Cells[7, 4] = "Thời gian";
            worksheet.Cells[7, 5] = "Mã cán bộ";
            worksheet.Cells[7, 6] = "Kết quả";
            for (int i = 0; i < dtgrvHdDoan.RowCount; i++)
            {
                for (int j = 0; j <5; j++)
                {
                    worksheet.Cells[i + 8, 1] = i + 1;
                    worksheet.Cells[i + 8, j + 2] = dtgrvHdDoan.Rows[i].Cells[j].Value;
                }
            }
            int HD_Doan = dtgrvHdDoan.RowCount;
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
            worksheet.Range["D1"].ColumnWidth = 13;
            worksheet.Range["E1"].ColumnWidth = 12.14;
            worksheet.Range["F1"].ColumnWidth = 21;

          
            //Định dạng font chữ
            worksheet.Range["A1", "F100"].Font.Name = "Times New Roman";
            worksheet.Range["A1", "F100"].Font.Size = 14;
            worksheet.Range["A2", "F2"].MergeCells = true;
            worksheet.Range["A2", "F2"].Font.Bold = true;
            worksheet.Range["A2", "F2"].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            worksheet.Range["A2", "F2"].Font.Size = 17;
            worksheet.Range["A7", "F" + (HD_Doan + 7)].Borders.LineStyle = 1;
        }

        private void btnhome_Click(object sender, EventArgs e)
        {

        }
    }
}
