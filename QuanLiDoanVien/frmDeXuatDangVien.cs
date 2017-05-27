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
    public partial class frmDeXuatDangVien : Form
    {
        public  List<int>lst_DeXuatDV;
        public frmDeXuatDangVien()
        {
            lst_DeXuatDV = new List<int>();
            InitializeComponent();
        }

        private void frmDeXuatDangVien_Load(object sender, EventArgs e)
        {
            if(lst_DeXuatDV!=null)
            {
                List<tbl_SinhVien> lst = new List<tbl_SinhVien>();
                foreach (var item in lst_DeXuatDV)
                {
                    tbl_SinhVien obj = new tbl_SinhVien();
                    obj = SinhVienService.SinhVien_GetByTop("", " MaSV=" + item + "", "").First();
                    lst.Add(obj);
                }
                dtgrvSinhVien.DataSource = lst;
            }
         
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
            List<tbl_SinhVien> lst = new List<tbl_SinhVien>();
            lst = SinhVienService.SinhVien_GetByTop("", "", "");
            var v = (from p in lst
                     where ConvertToUnSign(p.HoTenSV.ToLower()).Contains(textsearch)
                     select p).ToList();
            dtgrvSinhVien.DataSource = v;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (h == DialogResult.Yes)
                this.Close();
        }
    }
}
