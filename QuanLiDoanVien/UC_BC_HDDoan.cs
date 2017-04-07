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
namespace QuanLiDoanVien
{
    public partial class UC_BC_HDDoan : UserControl
    {
        public static SqlConnection conn = new SqlConnection("Data Source=PHAMXUANDUY-PC\\SQLEXPRESS;Initial Catalog=QuanLiDoanVien;Integrated Security=True");
        public UC_BC_HDDoan()
        {
            InitializeComponent();
        }

        private void UC_BC_HDDoan_Load(object sender, EventArgs e)
        {
            dtiptungay.Value = DateTime.Now;
            dtipdenngay.Value = DateTime.Now;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            Report.crpt_BC_HoatDongDoan rpt = new Report.crpt_BC_HoatDongDoan();
            rpt.DataDefinition.FormulaFields["fromDate"].Text = dtiptungay.Value.ToString();
            conn.Open();
            SqlDataAdapter dap = new SqlDataAdapter("SELECT Id,TenHoatDong,CONVERT(varchar,ThoiGian,103) as ThoiGian,MaCB,KetQua FROM tbl_THONGTINHOATDONGDOAN where ThoiGian between '" + dtiptungay.Value+"' and '"+dtipdenngay.Value+"'", conn);
            DataSet ds = new DataSet();
            dap.Fill(ds);
            rpt.SetDataSource(ds.Tables[0]);
            crpt_BC_HDDoan.ReportSource = rpt;
            crpt_BC_HDDoan.Refresh();
            conn.Close();
        }
    }
}
