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
        public static List<tbl_DanToc> tbl_DanToc_GetByTop(string Top, string Where, string Order)
        {
            return cmb.tbl_DanToc_GetByTop(Top, Where, Order);
        }
        public static bool tbl_DanToc_Insert(tbl_DanToc data)
        {
            return cmb.tbl_DanToc_Insert(data);
        }

        public static bool tbl_DanToc_Update(tbl_DanToc data)
        {
            return cmb.tbl_DanToc_Update(data);
        }
        public static bool tbl_DanToc_Delete(tbl_DanToc data)
        {
            return cmb.tbl_DanToc_Delete(data);
        }
    }
}
