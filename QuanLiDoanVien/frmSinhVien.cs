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
    public partial class frmSinhVien : DevComponents.DotNetBar.Office2007Form
    {
        public bool them;
        public string masv;
        public tbl_SinhVien sv_sua = new tbl_SinhVien();
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            txtmasv.Text = masv;

            cbbmacd.DataSource = ChiDoanService.ChiDoanGetByTop("","","");
            cbbmacd.DisplayMember = "TenChiDoan";
            cbbmacd.ValueMember = "MaChiDoan";

            cbbmadt.DataSource = DanTocService.DanToc_GetByTop("","","");
            cbbmadt.DisplayMember = "TenDT";
            cbbmadt.ValueMember = "MaDT";

            cbbtinhtrang.Items.Add("Đoàn viên");
            cbbtinhtrang.Items.Add("Thanh niên");
            cbbtinhtrang.Items.Add("Mới kết nạp");
            cbbtinhtrang.Items.Add("Trưởng thành");
            cbbtinhtrang.Items.Add("Khai trừ");
            if(them==false)
            {
                txtmasv.Text = sv_sua.MaSV;
                txthoten.Text = sv_sua.HoTenSV;
                dtipngaysinh.Value = DateTime.ParseExact(sv_sua.NgaySinh,"dd/MM/yyyy",null);
                txtdienthoai.Text = sv_sua.DienThoai;
                cbbmacd.SelectedValue = sv_sua.MaChiDoan;
                cbbmadt.SelectedValue = sv_sua.MaDT;
                dtipngayvd.Value= DateTime.ParseExact(sv_sua.NgayVaoDoan, "dd/MM/yyyy", null);
                cbbtinhtrang.SelectedItem = sv_sua.TinhTrang;
                txtdiachi.Text = sv_sua.DiaChi;
            }
        }

        private void btndongy_Click(object sender, EventArgs e)
        {
            if(them==true)
            {
                tbl_SinhVien obj = new tbl_SinhVien();
                obj.HoTenSV = txthoten.Text;
                obj.NgaySinh = dtipngaysinh.Value.ToString("MM/dd/yyyy");
                obj.DienThoai = txtdienthoai.Text;
                obj.MaChiDoan = cbbmacd.SelectedValue.ToString();
                obj.MaDT = cbbmadt.SelectedValue.ToString();
                obj.NgayVaoDoan = dtipngayvd.Value.ToString("MM/dd/yyyy");
                obj.TinhTrang = cbbtinhtrang.SelectedItem.ToString();
                obj.MaDT = cbbmadt.SelectedValue.ToString();
                obj.MaChiDoan = cbbmacd.SelectedValue.ToString();
                obj.DiaChi = txtdiachi.Text;
                SinhVienService.SinhVien_Insert(obj);
                MessageBox.Show("Thêm thành công!!!", "Thông báo");
                this.Close();
            }
           else
            {
                tbl_SinhVien obj = new tbl_SinhVien();
                obj.MaSV = txtmasv.Text;
                obj.HoTenSV = txthoten.Text;
                obj.NgaySinh = dtipngaysinh.Value.ToString("MM/dd/yyyy");
                obj.DienThoai = txtdienthoai.Text;
                obj.MaChiDoan = cbbmacd.SelectedValue.ToString();
                obj.MaDT = cbbmadt.SelectedValue.ToString();
                obj.NgayVaoDoan = dtipngayvd.Value.ToString("MM/dd/yyyy");
                obj.TinhTrang = cbbtinhtrang.SelectedItem.ToString();
                obj.MaDT = cbbmadt.SelectedValue.ToString();
                obj.MaChiDoan = cbbmacd.SelectedValue.ToString();
                obj.DiaChi = txtdiachi.Text;
                SinhVienService.SinhVien_Update(obj);
                MessageBox.Show("Sửa thành công!!!", "Thông báo");
                this.Close();
            }
        }
    }
}
