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
    }
}
