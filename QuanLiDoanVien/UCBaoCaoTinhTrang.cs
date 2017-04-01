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
namespace QuanLiDoanVien
{
    public partial class UCBaoCaoTinhTrang : UserControl
    {
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
    }
}
