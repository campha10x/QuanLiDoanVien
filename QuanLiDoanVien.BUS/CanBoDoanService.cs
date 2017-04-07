using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiDoanVien.DAL;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien.BUS
{
   public class CanBoDoanService
    {
        private static CanBoDoanDAL cmb = new CanBoDoanDAL();
        public static List<tbl_CanBoDoan> CanBoDoan_GetByTop(string Top, string Where, string Order)
        {
            return cmb.CanBoDoan_GetByTop(Top, Where, Order);
        }
        public static bool CanBoDoan_Insert(tbl_CanBoDoan data)
        {
            return cmb.CanBoDoan_Insert(data);
        }

        public static bool CanBoDoan_Update(tbl_CanBoDoan data)
        {
            return cmb.CanBoDoan_Update(data);
        }
        public static bool CanBoDoan_Delete(tbl_CanBoDoan data)
        {
            return cmb.CanBoDoan_Delete(data);
        }
    }
}
