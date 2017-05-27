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
namespace QuanLiDoanVien
{
    public partial class frmTinhTrangNopPhi : DevComponents.DotNetBar.Office2007Form
    {
        public frmTinhTrangNopPhi()
        {
            InitializeComponent();
        }

        private void frmTinhTrangNopPhi_Load(object sender, EventArgs e)
        {
            dtgrvdoanvien.DataSource = SinhVienService.SinhVien_GetByTop("", " TinhTrangNopPhi='True'", "");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(rdbtnDaNop.Checked==true)
                dtgrvdoanvien.DataSource = SinhVienService.SinhVien_GetByTop("", " TinhTrangNopPhi='True'", "");
            else
                dtgrvdoanvien.DataSource = SinhVienService.SinhVien_GetByTop("", " TinhTrangNopPhi='false'", "");
        }

        private void rdbtnChuanop_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
