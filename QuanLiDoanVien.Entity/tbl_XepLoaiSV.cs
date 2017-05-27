using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace QuanLiDoanVien.Entity
{
   public class tbl_XepLoaiSV
    {
        private string _Id;
        private string _Nam;
        private string _XepLoai;
        private string _MaSV;

        public string Id
        {
            get
            {
                return _Id;
            }

            set
            {
                _Id = value;
            }
        }

        public string Nam
        {
            get
            {
                return _Nam;
            }

            set
            {
                _Nam = value;
            }
        }

        public string XepLoai
        {
            get
            {
                return _XepLoai;
            }

            set
            {
                _XepLoai = value;
            }
        }

        public string MaSV
        {
            get
            {
                return _MaSV;
            }

            set
            {
                _MaSV = value;
            }
        }
        public tbl_XepLoaiSV XepLoaiSVIDataReader(IDataReader dr)
        {
            tbl_XepLoaiSV obj = new tbl_XepLoaiSV();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Nam = (dr["Nam"] is DBNull) ? string.Empty : dr["Nam"].ToString();
            obj.XepLoai = (dr["XepLoai"] is DBNull) ? string.Empty : dr["XepLoai"].ToString();
            obj.MaSV = (dr["MaSV"] is DBNull) ? string.Empty : dr["MaSV"].ToString();
            return obj;
        }
    }
}
