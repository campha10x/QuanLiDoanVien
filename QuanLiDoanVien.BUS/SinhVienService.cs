using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiDoanVien.DAL;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien.BUS
{
    public class SinhVienService
    {
        private static SinhVienDAL cmb = new SinhVienDAL();
        public static List<tbl_SinhVien> SinhVien_GetByTop(string Top, string Where, string Order)
        {
            return cmb.SinhVien_GetByTop(Top, Where, Order);
        }
        public static bool SinhVien_Insert(tbl_SinhVien data)
        {
            return cmb.SinhVien_Insert(data);
        }

        public static bool SinhVien_Update(tbl_SinhVien data)
        {
            return cmb.SinhVien_Update(data);
        }
        public static bool SinhVien_Delete(tbl_SinhVien data)
        {
            return cmb.SinhVien_Delete(data);
        }
    }
}
