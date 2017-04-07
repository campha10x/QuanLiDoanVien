using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace QuanLiDoanVien.Entity
{
    public class tbl_CanBoDoan
    {
        private string _MaCB;
        private string _HoTen;
        private string _GioiTinh;
        private string _ChucVu;
        private string _DiaChi;
        private string _DienThoai;

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

        public string HoTen
        {
            get
            {
                return _HoTen;
            }

            set
            {
                _HoTen = value;
            }
        }

        public string GioiTinh
        {
            get
            {
                return _GioiTinh;
            }

            set
            {
                _GioiTinh = value;
            }
        }

        public string ChucVu
        {
            get
            {
                return _ChucVu;
            }

            set
            {
                _ChucVu = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return _DiaChi;
            }

            set
            {
                _DiaChi = value;
            }
        }

        public string DienThoai
        {
            get
            {
                return _DienThoai;
            }

            set
            {
                _DienThoai = value;
            }
        }
        public tbl_CanBoDoan CanBoDoanIDataReader(IDataReader dr)
        {
            tbl_CanBoDoan obj = new tbl_CanBoDoan();
            obj.MaCB = (dr["MaCB"] is DBNull) ? string.Empty : dr["MaCB"].ToString();
            obj.HoTen = (dr["HoTen"] is DBNull) ? string.Empty : dr["HoTen"].ToString();
            obj.GioiTinh = (dr["GioiTinh"] is DBNull) ? string.Empty : dr["GioiTinh"].ToString();
            obj.ChucVu = (dr["ChucVu"] is DBNull) ? string.Empty : dr["ChucVu"].ToString();
            obj.DiaChi = (dr["DiaChi"] is DBNull) ? string.Empty : dr["DiaChi"].ToString();
            obj.DienThoai = (dr["DienThoai"] is DBNull) ? string.Empty : dr["DienThoai"].ToString();
            return obj;
        }
    }
}
