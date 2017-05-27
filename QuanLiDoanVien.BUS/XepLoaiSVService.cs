using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiDoanVien.DAL;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien.BUS
{
    public class XepLoaiSVService
    {
        private static XepLoaiSVDAL cmb = new XepLoaiSVDAL();
        public static List<tbl_XepLoaiSV> XepLoai_GetByTop(string Top, string Where, string Order)
        {
            return cmb.XepLoaiSV_GetByTop(Top, Where, Order);
        }
        public static bool XepLoai_Insert(tbl_XepLoaiSV data)
        {
            return cmb.XepLoaiSV_Insert(data);
        }

        public static bool XepLoai_Update(tbl_XepLoaiSV data)
        {
            return cmb.XepLoaiSV_Update(data);
        }
        public static bool XepLoai_Delete(tbl_XepLoaiSV data)
        {
            return cmb.XepLoaiSV_Delete(data);
        }
    }
}
