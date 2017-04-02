using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiDoanVien.BUS;
using QuanLiDoanVien.Entity;
using System.Data;
using System.Data.SqlClient;
namespace QuanLiDoanVien
{
    public partial class UCBaoCaoTinhTrang : UserControl
    {
        public static SqlConnection conn = new SqlConnection("Data Source=PHAMXUANDUY-PC\\SQLEXPRESS;Initial Catalog=QuanLiDoanVien;Integrated Security=True");

        public UCBaoCaoTinhTrang()
        {
            InitializeComponent();
        }

        private void UCBaoCaoTinhTrang_Load(object sender, EventArgs e)
        {

            cbbtinhtrang.Items.Add("Đoàn viên");
            cbbtinhtrang.Items.Add("Thanh niên");
            cbbtinhtrang.Items.Add("Mới kết nạp");
            cbbtinhtrang.Items.Add("Trưởng thành");
            cbbtinhtrang.Items.Add("Khai trừ");
            cbbtinhtrang.SelectedIndex = 0;

            List<tbl_ChiDoan> lst_ChiDoan = new List<tbl_ChiDoan>();
            lst_ChiDoan = ChiDoanService.ChiDoanGetByTop("","","");
            cbbchidoan.DataSource = lst_ChiDoan;
            cbbchidoan.DisplayMember = "TenChiDoan";
            cbbchidoan.ValueMember = "MaChiDoan";

          
            List<tbl_KhoaHoc> lst_KhoaHoc = new List<tbl_KhoaHoc>();
            lst_KhoaHoc = KhoaHocService.KhoaHocGetByTop("","","");
            cbbkhoahoc.DataSource = lst_KhoaHoc;
            cbbkhoahoc.DisplayMember = "ThoiGianDaoTao";
            cbbkhoahoc.ValueMember = "MaKhoaHoc";
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            string tinhtrang = cbbtinhtrang.SelectedItem.ToString();
            string chidoan = cbbchidoan.SelectedValue.ToString();
            string khoahoc = cbbkhoahoc.SelectedValue.ToString();
            Report.crpt_TinhTrang rpt = new Report.crpt_TinhTrang();
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SELECT tbl_ChiDoan.MaChiDoan,TenChiDoan,tbl_KhoaHoc.MaKhoaHoc , ThoiGianDaoTao, MaSV, HoTenSV, CONVERT(varchar(50),NgaySinh,103) as NgaySinh , DiaChi, DienThoai, TinhTrang, MaDT, NgayVaoDoan from tbl_ChiDoan, tbl_KhoaHoc, tbl_SINHVIEN where tbl_SINHVIEN.MaChiDoan = '" + chidoan + "' and tbl_KhoaHoc.MaKhoaHoc = '" + khoahoc + "' and tbl_SINHVIEN.MaChiDoan = tbl_ChiDoan.MaChiDoan and tbl_KhoaHoc.MaKhoaHoc = tbl_ChiDoan.MaKhoaHoc and TinhTrang = N'" + tinhtrang + "' ", conn);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            rpt.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
            conn.Close();
        }

        private void panelDockContainer1_Click(object sender, EventArgs e)
        {

        }
    }
}
