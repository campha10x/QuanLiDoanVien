﻿using System;
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
using System.Text.RegularExpressions;

namespace QuanLiDoanVien
{
    public partial class frmChiDoan : DevComponents.DotNetBar.Office2007Form
    {
        private bool them;
        public frmChiDoan()
        {
            InitializeComponent();
        }
        private void LoadDataOnGriview()
        {
            txtmachidoan.Text = "";
            txttenchidoan.Text = "";

            cbbmakhoahoc.DisplayMember = "ThoiGianDaoTao";
            cbbmakhoahoc.ValueMember = "MaKhoaHoc";
            cbbmakhoahoc.DataSource = KhoaHocService.KhoaHocGetByTop("","","");
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnluu.Enabled = true;
            btnxoa.Enabled = true;
            dtgrvchidoan.DataSource = ChiDoanService.ChiDoanGetByTop("", "", "");
        }
        private void frmChiDoan_Load(object sender, EventArgs e)
        {
            txtmachidoan.Enabled = false;
            LoadDataOnGriview();
        }

        private void txttendt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtmadt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            them = false;
            txtmachidoan.Text = dtgrvchidoan.CurrentRow.Cells["MaChiDoan"].Value.ToString();
            txttenchidoan.Text = dtgrvchidoan.CurrentRow.Cells["TenChiDoan"].Value.ToString();
            cbbmakhoahoc.SelectedValue = dtgrvchidoan.CurrentRow.Cells["MaKhoaHoc"].Value.ToString();
            btnthem.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            them = true;
            List<Entity.tbl_ChiDoan> lst = new List<tbl_ChiDoan>();
            lst = ChiDoanService.ChiDoanGetByTop("", "", "");
            if (lst.Count != 0)
            {
                txtmachidoan.Text = (Convert.ToInt32(lst[lst.Count - 1].MaChiDoan) + 1).ToString();
            }
            else
                txtmachidoan.Text = "1";
            btnsua.Enabled = false;
            btnxoa.Enabled = false;
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (txttenchidoan.Text == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin!!!");
                return;
            }
            else
            {
                if (them == true)
                {
                    tbl_ChiDoan dt = new tbl_ChiDoan();
                    dt.TenChiDoan = txttenchidoan.Text;
                    dt.MaKhoaHoc = cbbmakhoahoc.SelectedValue.ToString();
                    ChiDoanService.ChiDoan_Insert(dt);
                    MessageBox.Show("Thêm thành công!!!", "Thông báo");
                }
                else
                {
                    tbl_ChiDoan dt = new tbl_ChiDoan();
                    dt.MaChiDoan = txtmachidoan.Text;
                    dt.TenChiDoan = txttenchidoan.Text;
                    dt.MaKhoaHoc = cbbmakhoahoc.SelectedValue.ToString();
                    ChiDoanService.ChiDoan_Update(dt);
                    MessageBox.Show("Sửa thành công!!!", "Thông báo");
                }
            }
            LoadDataOnGriview();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc muốn xoá không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (h == DialogResult.Yes)
            {
                tbl_ChiDoan dt = new tbl_ChiDoan();
                dt.MaChiDoan = dtgrvchidoan.CurrentRow.Cells["MaChiDoan"].Value.ToString();
                ChiDoanService.ChiDoan_Delete(dt);
                LoadDataOnGriview();
            }
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
            List<tbl_ChiDoan> lst = new List<tbl_ChiDoan>();
            lst = ChiDoanService.ChiDoanGetByTop("", "", "");
            var v = (from p in lst
                     where ConvertToUnSign(p.TenChiDoan.ToLower()).Contains(textsearch)
                     select p).ToList();
            dtgrvchidoan.DataSource = v;
        }
    }
}
