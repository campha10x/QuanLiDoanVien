using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiDoanVien.DAL;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien.BUS
{
   public class DanTocService
    {
        private static DanTocDAL cmb = new DanTocDAL();
        public static List<tbl_DanToc> DanToc_GetByTop(string Top, string Where, string Order)
        {
            return cmb.DanToc_GetByTop(Top, Where, Order);
        }
        public static bool DanToc_Insert(tbl_DanToc data)
        {
            return cmb.DanToc_Insert(data);
        }

        public static bool DanToc_Update(tbl_DanToc data)
        {
            return cmb.DanToc_Update(data);
        }
        public static bool DanToc_Delete(tbl_DanToc data)
        {
            return cmb.DanToc_Delete(data);
        }
    }
}
