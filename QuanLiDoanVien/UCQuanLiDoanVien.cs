using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiDoanVien.Entity;
using QuanLiDoanVien.BUS;
using System.Data;
using System.Text.RegularExpressions;

namespace QuanLiDoanVien
{
    public partial class UCQuanLiDoanVien : UserControl
    {
        string MaChiDoan;
        
        public UCQuanLiDoanVien()
        {
            InitializeComponent();
            
        }
        void LamMoi()
        {
            if(MaChiDoan!=null)
            {
                var result = SinhVienService.SinhVien_GetByTop("", " MaChiDoan=" + MaChiDoan + "", "");
                dtgrvSinhVien.DataSource = result;
            }
        }
        private void Trvkhoahoc_AfterSelect(object sender, TreeViewEventArgs e)
        {

            MaChiDoan = e.Node.Tag.ToString();
            var result = SinhVienService.SinhVien_GetByTop("", " MaChiDoan=" + MaChiDoan + "", "");
             dtgrvSinhVien.DataSource= result ;

        }

        private void UCQuanLiDoanVien_Load(object sender, EventArgs e)
        {
            List<tbl_KhoaHoc> lstkhoahoc = new List<tbl_KhoaHoc>();
            List<tbl_ChiDoan> lstchidoan = new List<tbl_ChiDoan>();
            lstkhoahoc = KhoaHocService.KhoaHocGetByTop("","","");
           
            #region ListKhoaHoc
            TreeNode root = new TreeNode("Danh sách khóa học",0,0);
            root.Tag = 0;
            foreach (var item in lstkhoahoc)
            {
                TreeNode child = new TreeNode(item.ThoiGianDaoTao,2,2);
                lstchidoan = ChiDoanService.ChiDoanGetByTop("", " MaKhoaHoc = " + item.MaKhoaHoc+"", "");
                foreach (var itemCD in lstchidoan)
                {
                    TreeNode childCD = new TreeNode(itemCD.TenChiDoan,1,1);
                    childCD.Tag = itemCD.MaChiDoan;
                    child.Nodes.Add(childCD);
                }
                child.Tag = item.MaKhoaHoc;
                root.Nodes.Add(child);
            }
            Trvkhoahoc.Nodes.Add(root);
            Trvkhoahoc.ExpandAll();
            #endregion

        }

        private void UCQuanLiDoanVien_Resize(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if(MaChiDoan!=null)
            {
                frmSinhVien frm = new frmSinhVien();
                List<tbl_SinhVien> lst = new List<tbl_SinhVien>();
                lst = SinhVienService.SinhVien_GetByTop("", " MaChiDoan=" + MaChiDoan + "", "");
                if (lst.Count == 0)
                    frm.masv = "1";
                else
                    frm.masv = (lst.Count + 1).ToString();
                frm.them = true;
                frm.ShowDialog();
                LamMoi();
            }
           
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            frmSinhVien frm = new frmSinhVien();
            frm.them = false;
            frm.sv_sua.MaSV = dtgrvSinhVien.CurrentRow.Cells["masv"].Value.ToString();
            frm.sv_sua.HoTenSV = dtgrvSinhVien.CurrentRow.Cells["hoten"].Value.ToString();
            frm.sv_sua.NgaySinh = dtgrvSinhVien.CurrentRow.Cells["ngaysinh"].Value.ToString();
            frm.sv_sua.DiaChi = dtgrvSinhVien.CurrentRow.Cells["diachi"].Value.ToString();
            frm.sv_sua.DienThoai = dtgrvSinhVien.CurrentRow.Cells["dienthoai"].Value.ToString();
            frm.sv_sua.TinhTrang = dtgrvSinhVien.CurrentRow.Cells["tinhtrang"].Value.ToString();
            frm.sv_sua.MaDT = dtgrvSinhVien.CurrentRow.Cells["madt"].Value.ToString();
            frm.sv_sua.MaChiDoan = dtgrvSinhVien.CurrentRow.Cells["macd"].Value.ToString();
            frm.sv_sua.NgayVaoDoan = dtgrvSinhVien.CurrentRow.Cells["ngayvaodoan"].Value.ToString();
            frm.ShowDialog();
            LamMoi();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc muốn xoá không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (h == DialogResult.Yes)
            {
                tbl_SinhVien sv = new tbl_SinhVien();
                sv.MaSV = dtgrvSinhVien.CurrentRow.Cells["masv"].Value.ToString();
                SinhVienService.SinhVien_Delete(sv);
                LamMoi();
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
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
            if(MaChiDoan!=null)
            {
                string textsearch = ConvertToUnSign(txtsearch.Text.ToLower());
                List<tbl_SinhVien> lst = new List<tbl_SinhVien>();
                lst = SinhVienService.SinhVien_GetByTop("", "", "");
                var v = (from p in lst
                         where ConvertToUnSign(p.HoTenSV.ToLower()).Contains(textsearch)
                         && p.MaChiDoan == MaChiDoan
                         select p).ToList();
                dtgrvSinhVien.DataSource = v;
            }
            else
            {
                MessageBox.Show("Bạn phải chọn chi đoàn mới tìm kiếm được","Thông báo");
            }


        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
    }
}
