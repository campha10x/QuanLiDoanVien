using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiDoanVien.Entity;
using QuanLiDoanVien.DAL;
namespace QuanLiDoanVien.BUS
{
    public class PhiDoanVienService
    {
        private static PhiDoanVienDAL cmb = new PhiDoanVienDAL();
        public static List<tbl_PhiDoanVien> PhiDoanVien_GetByTop(string Top, string Where, string Order)
        {
            return cmb.PhiDoanVien_GetByTop(Top, Where, Order);
        }
        public static bool PhiDoanVien_Insert(tbl_PhiDoanVien data)
        {
            return cmb.PhiDoanVien_Insert(data);
        }

        public static bool PhiDoanVien_Update(tbl_PhiDoanVien data)
        {
            return cmb.PhiDoanVien_Update(data);
        }
        public static bool PhiDoanVien_Delete(tbl_PhiDoanVien data)
        {
            return cmb.PhiDoanVien_Delete(data);
        }
    }
}
