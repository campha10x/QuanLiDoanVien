using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiDoanVien.DAL;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien.BUS
{
   public class NguoiDungService
    {
        private static NguoiDungDAL cmb = new NguoiDungDAL();
        public static List<tbl_NguoiDung> NguoiDungGetByTop(string Top,string Where,string Order)
        {
            return cmb.NguoiDung_GetByTop(Top,Where,Order);
        }
        public static bool NguoiDung_Update(tbl_NguoiDung data)
        {
            return cmb.NguoiDung_Update(data);
        }
    }
}
