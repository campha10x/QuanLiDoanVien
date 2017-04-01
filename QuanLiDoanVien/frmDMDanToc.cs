using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiDoanVien.Entity;
using QuanLiDoanVien.BUS;
namespace QuanLiDoanVien
{
    public partial class frmDMDanToc : DevComponents.DotNetBar.Office2007Form
    {
        private bool them;
        public frmDMDanToc()
        {
            InitializeComponent();
        }
        private void LoadDataOnGriview()
        {
            txtmadt.Text = "";
            txttendt.Text = "";
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = true;
            btnxoa.Enabled = true;
            dtgrvDanToc.DataSource = DanTocService.DanToc_GetByTop("","","");
        }
        private void frmDMDanToc_Load(object sender, EventArgs e)
        {
            txtmadt.Enabled = false;
            LoadDataOnGriview();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            them = true;
            List<Entity.tbl_DanToc> lst = new List<tbl_DanToc>();
            lst = DanTocService.DanToc_GetByTop("","","");
            if (lst.Count != 0)
            {
                txtmadt.Text = (Convert.ToInt32(lst[lst.Count - 1].MaDT) + 1).ToString();
            }
            else
                txtmadt.Text = "1";
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            them = false;
            txtmadt.Text = dtgrvDanToc.CurrentRow.Cells["madt"].Value.ToString();
            txttendt.Text = dtgrvDanToc.CurrentRow.Cells["tenDT"].Value.ToString();
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc muốn xoá không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (h == DialogResult.Yes)
            {
                tbl_DanToc dt = new tbl_DanToc();
                dt.MaDT = dtgrvDanToc.CurrentRow.Cells["madt"].Value.ToString();
                DanTocService.DanToc_Delete(dt);
                LoadDataOnGriview();
            }

        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if(txttendt.Text=="")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!!!");
                return;
            }
            else
            {
                if(them==true)
                {
                    tbl_DanToc dt = new tbl_DanToc();
                    dt.TenDT = txttendt.Text;
                    DanTocService.DanToc_Insert(dt);
                    MessageBox.Show("Thêm thành công!!!","Thông báo");
                }
                else
                {
                    tbl_DanToc dt = new tbl_DanToc();
                    dt.MaDT = txtmadt.Text;
                    dt.TenDT = txttendt.Text;
                    DanTocService.DanToc_Update(dt);
                    MessageBox.Show("Sửa thành công!!!","Thông báo");
                }
            }
            LoadDataOnGriview();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            LoadDataOnGriview();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn chắc muốn thoát không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (h == DialogResult.Yes)
                this.Close();
        }
    }
}
