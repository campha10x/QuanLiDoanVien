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
using System.Text.RegularExpressions;

namespace QuanLiDoanVien
{
    public partial class frmKhoaHoc : DevComponents.DotNetBar.Office2007Form
    {
        private bool them;
        private void LoadDataOnGriview()
        {
            txtmakh.Text = "";
            txttgdaotao.Text = "";
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = true;
            btnxoa.Enabled = true;
            dtgrvKhoahoc.DataSource = KhoaHocService.KhoaHocGetByTop("", "", "");
        }
        public frmKhoaHoc()
        {
            InitializeComponent();
        }

        private void frmKhoaHoc_Load(object sender, EventArgs e)
        {
            txtmakh.Enabled = false;
            LoadDataOnGriview();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            them = true;
            List<Entity.tbl_KhoaHoc> lst = new List<tbl_KhoaHoc>();
            lst = KhoaHocService.KhoaHocGetByTop("", "", "");
            if (lst.Count != 0)
            {
                txtmakh.Text = (Convert.ToInt32(lst[lst.Count - 1].MaKhoaHoc) + 1).ToString();
            }
            else
                txtmakh.Text = "1";
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            them = false;
            txtmakh.Text = dtgrvKhoahoc.CurrentRow.Cells["MaKhoaHoc"].Value.ToString();
            txttgdaotao.Text = dtgrvKhoahoc.CurrentRow.Cells["ThoiGianDaoTao"].Value.ToString();
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc muốn xoá không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (h == DialogResult.Yes)
            {
                tbl_KhoaHoc dt = new tbl_KhoaHoc();
                dt.MaKhoaHoc = dtgrvKhoahoc.CurrentRow.Cells["MaKhoaHoc"].Value.ToString();
                KhoaHocService.KhoaHoc_Delete(dt);
                LoadDataOnGriview();
            }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (txttgdaotao.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!!!");
                return;
            }
            else
            {
                if (them == true)
                {
                    tbl_KhoaHoc dt = new tbl_KhoaHoc();
                    dt.ThoiGianDaoTao = txttgdaotao.Text;
                    KhoaHocService.KhoaHoc_Insert(dt);
                    MessageBox.Show("Thêm thành công!!!", "Thông báo");
                }
                else
                {
                    tbl_KhoaHoc dt = new tbl_KhoaHoc();
                    dt.MaKhoaHoc = txtmakh.Text;
                    dt.ThoiGianDaoTao = txttgdaotao.Text;
                    KhoaHocService.KhoaHoc_Update(dt);
                    MessageBox.Show("Sửa thành công!!!", "Thông báo");
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
            DialogResult h = MessageBox.Show("Bạn chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (h == DialogResult.Yes)
                this.Close();
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
            List<tbl_KhoaHoc> lst = new List<tbl_KhoaHoc>();
            lst = KhoaHocService.KhoaHocGetByTop("", "", "");
            var v = (from p in lst
                     where ConvertToUnSign(p.ThoiGianDaoTao.ToLower()).Contains(textsearch)
                     select p).ToList();
            dtgrvKhoahoc.DataSource = v;
        }
    }
}
