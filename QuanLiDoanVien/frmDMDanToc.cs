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
            dtgrvDanToc.DataSource = DanTocService.tbl_DanToc_GetByTop("","","");
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
            lst = DanTocService.tbl_DanToc_GetByTop("","","");
            if(lst.Count!=0)
            {
                txtmadt.Text = (Convert.ToInt32(lst[lst.Count - 1].MaDT) + 1).ToString();

            }
        }
    }
}
