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
  
    public partial class frmDoiMatKhau : Form
    {
        public  string ID_User;
        //public string UserName;
        List<tbl_NguoiDung> lst = new List<tbl_NguoiDung>();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

      

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
           
            lst = NguoiDungService.NguoiDungGetByTop("", " Id="+ID_User+"", "");

        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void txtmatkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtreplymatkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtmatkhau.Text==""||txtreplymatkhau.Text=="")
            {
                MessageBox.Show("Mật khẩu không được bỏ trống được!!");
                return;
            }
            else
            {
                if (String.Compare(txtmatkhau.Text, txtreplymatkhau.Text) != 0)
                {
                    MessageBox.Show("Mật khẩu bạn nhập phải trùng nhau!!!");
                    return;
                }
                else
                {
                    tbl_NguoiDung obj = new tbl_NguoiDung();
                    obj.TenDangNhap = lst[0].TenDangNhap;
                    obj.IdQuyen = lst[0].IdQuyen;
                    obj.MaCB = lst[0].MaCB;
                    obj.MatKhau = EncryptorMD5.MD5Hash(txtmatkhau.Text);
                    obj.Id = ID_User;
                    if (NguoiDungService.NguoiDung_Update(obj) == true)
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                }
            }
            this.Close();
          
        }
    }
}
