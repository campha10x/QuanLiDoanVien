using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiDoanVien.BUS;
using QuanLiDoanVien.Entity;
using System.Text.RegularExpressions;

namespace QuanLiDoanVien
{
    public partial class frmDeXuatDangVien : DevComponents.DotNetBar.Office2007Form
    {
        public  List<int>lst_DeXuatDV;
        public frmDeXuatDangVien()
        {
            lst_DeXuatDV = new List<int>();
            InitializeComponent();
        }

        private void frmDeXuatDangVien_Load(object sender, EventArgs e)
        {
            if(lst_DeXuatDV!=null)
            {
                List<tbl_SinhVien> lst = new List<tbl_SinhVien>();
                foreach (var item in lst_DeXuatDV)
                {
                    tbl_SinhVien obj = new tbl_SinhVien();
                    obj = SinhVienService.SinhVien_GetByTop("", " MaSV=" + item + "", "").First();
                    lst.Add(obj);
                }
                dtgrvSinhVien.DataSource = lst;
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
        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string textsearch = ConvertToUnSign(txtsearch.Text.ToLower());
            List<tbl_SinhVien> lst = new List<tbl_SinhVien>();
            lst = SinhVienService.SinhVien_GetByTop("", "", "");
            var v = (from p in lst
                     where ConvertToUnSign(p.HoTenSV.ToLower()).Contains(textsearch)
                     select p).ToList();
            dtgrvSinhVien.DataSource = v;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (h == DialogResult.Yes)
                this.Close();
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

            worksheet.Cells[2, 2] = "Danh sách đề xuất lên Đảng viên ";
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
