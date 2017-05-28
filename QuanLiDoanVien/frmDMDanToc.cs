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
using System.Text.RegularExpressions;

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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void txtmadt_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtgrvDanToc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txttendt_TextChanged(object sender, EventArgs e)
        {

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
            List<tbl_DanToc> lst = new List<tbl_DanToc>();
            lst = DanTocService.DanToc_GetByTop("", "", "");
            var v = (from p in lst
                     where ConvertToUnSign(p.TenDT.ToLower()).Contains(textsearch)
                     select p).ToList();
            dtgrvDanToc.DataSource = v;
        }
    }
}
