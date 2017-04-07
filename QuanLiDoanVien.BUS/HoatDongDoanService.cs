using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiDoanVien.DAL;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien.BUS
{
    public class HoatDongDoanService
    {
        private static HoatDongDoanDAL cmb = new HoatDongDoanDAL();
        public static List<tbl_HoatDongDoan> HoatDongDoan_GetByTop(string Top, string Where, string Order)
        {
            return cmb.HoatDongDoan_GetByTop(Top, Where, Order);
        }
        public static bool HoatDongDoan_Insert(tbl_HoatDongDoan data)
        {
            return cmb.HoatDongDoan_Insert(data);
        }

        public static bool HoatDongDoan_Update(tbl_HoatDongDoan data)
        {
            return cmb.HoatDongDoan_Update(data);
        }
        public static bool HoatDongDoan_Delete(tbl_HoatDongDoan data)
        {
            return cmb.HoatDongDoan_Delete(data);
        }
    }
}
