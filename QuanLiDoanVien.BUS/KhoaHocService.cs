using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiDoanVien.DAL;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien.BUS
{
    public class KhoaHocService
    {
        private static KhoaHocDAL cmb = new KhoaHocDAL();
        public static List<tbl_KhoaHoc> KhoaHocGetByTop(string Top, string Where, string Order)
        {
            return cmb.KhoaHocGetByTop(Top, Where, Order);
        }
        public static bool KhoaHoc_Insert(tbl_KhoaHoc data)
        {
            return cmb.KhoaHoc_Insert(data);
        }

        public static bool KhoaHoc_Update(tbl_KhoaHoc data)
        {
            return cmb.KhoaHoc_Update(data);
        }
        public static bool KhoaHoc_Delete(tbl_KhoaHoc data)
        {
            return cmb.KhoaHoc_Delete(data);
        }
    }
}
