using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLiDoanVien.Entity
{
    public class tbl_NguoiDung
    {
        private string _Id;
        private string _MaCB;
        private string _IdQuyen;
        private string _TenDangNhap;
        private string _MatKhau;

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

        public string IdQuyen
        {
            get
            {
                return _IdQuyen;
            }

            set
            {
                _IdQuyen = value;
            }
        }

        public string TenDangNhap
        {
            get
            {
                return _TenDangNhap;
            }

            set
            {
                _TenDangNhap = value;
            }
        }

        public string MatKhau
        {
            get
            {
                return _MatKhau;
            }

            set
            {
                _MatKhau = value;
            }
        }

        public tbl_NguoiDung NguoiDungIDataReader(IDataReader dr)
        {
            tbl_NguoiDung obj = new tbl_NguoiDung();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.IdQuyen = (dr["IdQuyen"] is DBNull) ? string.Empty : dr["IdQuyen"].ToString();
            obj.MaCB = (dr["MaCB"] is DBNull) ? string.Empty : dr["MaCB"].ToString();
            obj.TenDangNhap = (dr["TenDangNhap"] is DBNull) ? string.Empty : dr["TenDangNhap"].ToString();
            obj.MatKhau = (dr["MatKhau"] is DBNull) ? string.Empty : dr["MatKhau"].ToString();
            return obj;
        }
    }
}
