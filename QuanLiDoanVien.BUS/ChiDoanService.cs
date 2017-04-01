using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiDoanVien.DAL;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien.BUS
{
    public class ChiDoanService
    {
        private static ChiDoanDAL cmb = new ChiDoanDAL();
        public static List<tbl_ChiDoan> ChiDoanGetByTop(string Top, string Where, string Order)
        {
            return cmb.ChiDoanGetByTop(Top, Where, Order);
        }
    }
}
