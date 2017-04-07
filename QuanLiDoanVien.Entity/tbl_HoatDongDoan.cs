using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace QuanLiDoanVien.Entity
{
   public class tbl_HoatDongDoan
    {
        private string _Id;
        private string _TenHoatDong;
        private string _ThoiGian;
        private string _MaCB;
        private string _KetQua;

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

        public string TenHoatDong
        {
            get
            {
                return _TenHoatDong;
            }

            set
            {
                _TenHoatDong = value;
            }
        }

        public string ThoiGian
        {
            get
            {
                return _ThoiGian;
            }

            set
            {
                _ThoiGian = value;
            }
        }

        public string MaCB
        {
            get
            {
                return _MaCB;
            }

            set
            {
                _MaCB = value;
            }
        }

        public string KetQua
        {
            get
            {
                return _KetQua;
            }

            set
            {
                _KetQua = value;
            }
        }
        public tbl_HoatDongDoan HoatDongDoanIDataReader(IDataReader dr)
        {
            tbl_HoatDongDoan obj = new tbl_HoatDongDoan();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.TenHoatDong = (dr["TenHoatDong"] is DBNull) ? string.Empty : dr["TenHoatDong"].ToString();
            obj.ThoiGian = (dr["ThoiGian"] is DBNull) ? string.Empty : dr["ThoiGian"].ToString();
            obj.MaCB = (dr["MaCB"] is DBNull) ? string.Empty : dr["MaCB"].ToString();
            obj.KetQua = (dr["KetQua"] is DBNull) ? string.Empty : dr["KetQua"].ToString();
            return obj;
        }
    }
}
