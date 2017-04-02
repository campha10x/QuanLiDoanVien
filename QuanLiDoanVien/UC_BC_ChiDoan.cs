using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using QuanLiDoanVien.BUS;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien
{
    public partial class UC_BC_ChiDoan : UserControl
    {
        public static SqlConnection conn = new SqlConnection("Data Source=PHAMXUANDUY-PC\\SQLEXPRESS;Initial Catalog=QuanLiDoanVien;Integrated Security=True");
        public UC_BC_ChiDoan()
        {
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            string chidoan = cbbChiDoan.SelectedValue.ToString();
            Report.crpt_BaoCao_ChiDoan rpt = new Report.crpt_BaoCao_ChiDoan();
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SELECT HoTenSV,NgaySinh,TinhTrang,DienThoai,TenChiDoan from tbl_SINHVIEN, tbl_ChiDoan where tbl_SINHVIEN.MaChiDoan = tbl_ChiDoan.MaChiDoan and tbl_ChiDoan.MaChiDoan = "+chidoan+" group by tbl_ChiDoan.MaChiDoan, HoTenSV, NgaySinh, TinhTrang, DienThoai, TenChiDoan ", conn);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            rpt.SetDataSource(ds.Tables[0]);
            crpt_BaoCao_ChiDoan.ReportSource = rpt;
            crpt_BaoCao_ChiDoan.Refresh();
            conn.Close();
        }

        private void bar1_ItemClick(object sender, EventArgs e)
        {

        }

        private void crpt_BaoCao_ChiDoan_Load(object sender, EventArgs e)
        {

        }

        private void UC_BC_ChiDoan_Load(object sender, EventArgs e)
        {
            List<tbl_ChiDoan> lst_ChiDoan = new List<tbl_ChiDoan>();
            lst_ChiDoan = ChiDoanService.ChiDoanGetByTop("", "", "");
            cbbChiDoan.DataSource = lst_ChiDoan;
            cbbChiDoan.DisplayMember = "TenChiDoan";
            cbbChiDoan.ValueMember = "MaChiDoan";

        }
    }
}
