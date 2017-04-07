using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuanLiDoanVien.Entity;
using QuanLiDoanVien.BUS;
using System.Text.RegularExpressions;

namespace QuanLiDoanVien
{
    public partial class cbbCanBoDoan : Form
    {
        public delegate void Send_MaCB(string value1);
        public Send_MaCB send;
        public cbbCanBoDoan()
        {
            InitializeComponent();
        }

        private void cbbCanBoDoan_Load(object sender, EventArgs e)
        {
            List<tbl_CanBoDoan> lst = new List<tbl_CanBoDoan>();
            lst = CanBoDoanService.CanBoDoan_GetByTop("","","");
            dtgrvCanBoDoan.DataSource = lst;

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
            List<tbl_CanBoDoan> lst = new List<tbl_CanBoDoan>();
            lst = CanBoDoanService.CanBoDoan_GetByTop("", "", "");
            var v = (from p in lst
                     where ConvertToUnSign(p.HoTen.ToLower()).Contains(textsearch)
                     select p).ToList();
            dtgrvCanBoDoan.DataSource = v;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if(send!=null)
            {
                string MaCB = dtgrvCanBoDoan.CurrentRow.Cells["macb"].Value.ToString();
                send(MaCB);
                this.Hide();
            }
        }
    }
}
