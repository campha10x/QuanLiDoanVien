using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLiDoanVien.Entity
{
    public class tbl_KhoaHoc
    {
        private string _MaKhoaHoc;
        private string _ThoiGianDaoTao;
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

        public string ThoiGianDaoTao
        {
            get
            {
                return _ThoiGianDaoTao;
            }

            set
            {
                _ThoiGianDaoTao = value;
            }
        }

        public tbl_KhoaHoc KhoaHocIDataReader(IDataReader dr)
        {
            tbl_KhoaHoc obj = new tbl_KhoaHoc();
            obj.MaKhoaHoc = (dr["MaKhoaHoc"] is DBNull) ? string.Empty : dr["MaKhoaHoc"].ToString();
            obj.ThoiGianDaoTao = (dr["ThoiGianDaoTao"] is DBNull) ? string.Empty : dr["ThoiGianDaoTao"].ToString();
            return obj;
        }
    }
}
