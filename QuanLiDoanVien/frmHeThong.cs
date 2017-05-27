using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiDoanVien
{
    public partial class frmHeThong : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public static string Id_User="1";
        public frmHeThong()
        {
            InitializeComponent();
        }
        private void CloseThis()
        {
            TabItem selectedTab = tabMain.SelectedTab;
            if (MessageBox.Show("Bạn có chắc muốn tắt trang " + selectedTab.Text, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if(tabMain.SelectedTabIndex!=0)
                tabMain.Tabs.Remove(selectedTab);
        }
        private void tabControl1_TabItemClose(object sender, DevComponents.DotNetBar.TabStripActionEventArgs e)
        {
            CloseThis();
        }

        private void đóngTrangNàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseThis();
        }

      
        private void ctmnMain_Opening(object sender, CancelEventArgs e)
        {
            bool isShow = (tabMain.SelectedTabIndex == 0) ? false : true;
            đóngTrangNàyToolStripMenuItem.Enabled = isShow;
        
        }

        private void đóngCácTrangKhácToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabItem selectedTab = tabMain.SelectedTab;
            int index = tabMain.SelectedTabIndex;
            for (int i = tabMain.Tabs.Count - 1; i > 0; i--)
                if (index != i)
                    tabMain.Tabs.RemoveAt(i);
            tabMain.Refresh();
        }

        private void đóngTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabItem selectedTab = tabMain.SelectedTab;
            int index = tabMain.SelectedTabIndex;
            for (int i = tabMain.Tabs.Count - 1; i >0; i--)
                    tabMain.Tabs.RemoveAt(i);
            tabMain.Refresh();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }
        private void addNewTab(string strTabName, UserControl ucContent)
        {
            //-----------If exist tabpage then exit---------------
            foreach (TabItem tabPage in tabMain.Tabs)
                if (tabPage.Text == strTabName)
                {
                    tabMain.SelectedTab = tabPage;
                    return;
                }
            //-------------------------Clear Tab Before---------------
            if (tabMain.Tabs.Count > 1)
                tabMain.Tabs.RemoveAt(1);

            TabControlPanel newTabPanel = new DevComponents.DotNetBar.TabControlPanel();
            TabItem newTabPage = new TabItem(this.components);
            newTabPage.ImageIndex = 0;
            //newTabPage.MouseDown += new System.Windows.Forms.MouseEventHandler(tabItem_MouseDown);
            newTabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            newTabPanel.Location = new System.Drawing.Point(0, 26);
            newTabPanel.Name = "panel" + strTabName;
            newTabPanel.Padding = new System.Windows.Forms.Padding(1);
            newTabPanel.Size = new System.Drawing.Size(1230, 384);
            newTabPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            newTabPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            newTabPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            newTabPanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            newTabPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            newTabPanel.Style.GradientAngle = 90;
            newTabPanel.TabIndex = 2;
            newTabPanel.TabItem = newTabPage;
            //-------------New  tab page---------------------
            Random ran = new Random();
            newTabPage.Name = strTabName + ran.Next(100000) + ran.Next(22342);
            newTabPage.AttachedControl = newTabPanel;
            newTabPage.Text = strTabName;
            ucContent.Dock = DockStyle.Fill;
            newTabPanel.Controls.Add(ucContent);
            //------------add Tab page to Tab control-------------
            tabMain.Controls.Add(newTabPanel);
            tabMain.Tabs.Add(newTabPage);
            tabMain.SelectedTab = newTabPage;
        }

        private void btnaddDoanVien_Click(object sender, EventArgs e)
        {
            UCQuanLiDoanVien ucQLDV = new UCQuanLiDoanVien();
            addNewTab("Quản lí đoàn viên", ucQLDV);
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            UCBaoCaoTinhTrang ucBCTT = new UCBaoCaoTinhTrang();
            addNewTab("Báo cáo đoàn viên,thanh niên theo tình trạng ",ucBCTT);
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            UC_BC_ChiDoan ucBCTT = new UC_BC_ChiDoan();
            addNewTab("Báo cáo đoàn viên theo chi đoàn", ucBCTT);
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            UC_frmHoatDongDoan ucHDD = new UC_frmHoatDongDoan();
            addNewTab("Quản lí hoạt động đoàn",ucHDD);
        }

        private void buttonItem24_Click(object sender, EventArgs e)
        {
            UC_BC_HDDoan uc_BC_HDD = new UC_BC_HDDoan();
            addNewTab("Báo cáo hoạt động đoàn", uc_BC_HDD);
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau();
            frm.ID_User = Id_User;
            frm.ShowDialog();
        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {
           
        }

        private void btnXepLoaiDV_Click(object sender, EventArgs e)
        {
            UC_XepLoaiDV ucXepLoaiDV = new UC_XepLoaiDV();
            addNewTab("Quản lí xếp loại đoàn viên", ucXepLoaiDV);
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            frmDMDanToc frm = new frmDMDanToc();
            frm.Show();
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            UC_QuanLiPhiDoan ucQuanLiPhiDoan = new UC_QuanLiPhiDoan();
            addNewTab("Quản lí phí đoàn viên", ucQuanLiPhiDoan);
        }
    }
}
