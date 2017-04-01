using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLiDoanVien.Entity
{
   public class tbl_ChiDoan
    {
        private string _MaChiDoan;
        private string _TenChiDoan;
        private string _MaKhoaHoc;

        public string MaChiDoan
        {
            get
            {
                return _MaChiDoan;
            }

            set
            {
                _MaChiDoan = value;
            }
        }

        public string TenChiDoan
        {
            get
            {
                return _TenChiDoan;
            }

            set
            {
                _TenChiDoan = value;
            }
        }

        public string MaKhoaHoc
        {
            get
            {
                return _MaKhoaHoc;
            }

            set
            {
                _MaKhoaHoc = value;
            }
        }
        public tbl_ChiDoan ChiDoanIDataReader(IDataReader dr)
        {
            tbl_ChiDoan obj = new tbl_ChiDoan();
            obj.MaChiDoan = (dr["MaChiDoan"] is DBNull) ? string.Empty : dr["MaChiDoan"].ToString();
            obj.TenChiDoan = (dr["TenChiDoan"] is DBNull) ? string.Empty : dr["TenChiDoan"].ToString();
            obj.MaKhoaHoc = (dr["MaKhoaHoc"] is DBNull) ? string.Empty : dr["MaKhoaHoc"].ToString();
            return obj;
        }
    }
}
