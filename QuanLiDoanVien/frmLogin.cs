using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiDoanVien.BUS;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien
{
    public partial class frmLogin : DevComponents.DotNetBar.Office2007Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        void Dangnhap()
        {
            if(txttaikhoan.Text==string.Empty||txtmatkhau.Text==string.Empty)
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttaikhoan.Focus();
                return;
            }
            List<Entity.tbl_NguoiDung> lst = new List<Entity.tbl_NguoiDung>();
            
            lst = NguoiDungService.NguoiDungGetByTop("", " TenDangNhap='" + txttaikhoan.Text + "' AND MatKhau='" + EncryptorMD5.MD5Hash(txtmatkhau.Text) + "'", "");
            if (lst.Count == 0)
            {
                MessageBox.Show("Bạn đã đăng nhập sai", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttaikhoan.Focus();
            }
            else
            {
                frmHeThong ht = new frmHeThong();
                //ht.UserName = txttaikhoan.Text;
                this.Hide();
                MessageBox.Show("Bạn đã đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ht.Show();
            }
        }
        private void btndangnhap_Click(object sender, EventArgs e)
        {
            Dangnhap();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Bạn chắc muốn thoát không!","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
                Application.Exit();
        }

        private void txtmatkhau_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                Dangnhap();
            }
        }

        private void txttaikhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Dangnhap();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
