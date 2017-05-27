using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLiDoanVien.Entity
{
    public class tbl_SinhVien
    {
        private string _MaSV;
        private string _HoTenSV;
        private string _NgaySinh;
        private string _DiaChi;
        private string _DienThoai;
        private string _MaChiDoan;
        private string _MaKhoaHoc;
        private string _NgayVaoDoan;
        private string _TinhTrang;
        private string _MaDT;
        private string _TinhTrangNopPhi;
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

        public string HoTenSV
        {
            get
            {
                return _HoTenSV;
            }

            set
            {
                _HoTenSV = value;
            }
        }

        public string NgaySinh
        {
            get
            {
                return _NgaySinh;
            }

            set
            {
                _NgaySinh = value;
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

       

        public string NgayVaoDoan
        {
            get
            {
                return _NgayVaoDoan;
            }

            set
            {
                _NgayVaoDoan = value;
            }
        }

        public string TinhTrang
        {
            get
            {
                return _TinhTrang;
            }

            set
            {
                _TinhTrang = value;
            }
        }

       

        public string MaDT
        {
            get
            {
                return _MaDT;
            }

            set
            {
                _MaDT = value;
            }
        }

        public string TinhTrangNopPhi
        {
            get
            {
                return _TinhTrangNopPhi;
            }

            set
            {
                _TinhTrangNopPhi = value;
            }
        }

        public tbl_SinhVien SinhVienIDataReader(IDataReader dr)
        {
            tbl_SinhVien obj = new tbl_SinhVien();
            obj.MaSV = (dr["MaSV"] is DBNull) ? string.Empty : dr["MaSV"].ToString();
            obj.HoTenSV = (dr["HoTenSV"] is DBNull) ? string.Empty : dr["HoTenSV"].ToString();
            obj.NgaySinh = (dr["NgaySinh"] is DBNull) ? string.Empty : dr["NgaySinh"].ToString();
            obj.DiaChi = (dr["DiaChi"] is DBNull) ? string.Empty : dr["DiaChi"].ToString();
            obj.DienThoai = (dr["DienThoai"] is DBNull) ? string.Empty : dr["DienThoai"].ToString();
            obj.MaChiDoan = (dr["MaChiDoan"] is DBNull) ? string.Empty : dr["MaChiDoan"].ToString();
            obj.NgayVaoDoan = (dr["NgayVaoDoan"] is DBNull) ? string.Empty : dr["NgayVaoDoan"].ToString();
            obj.TinhTrang = (dr["TinhTrang"] is DBNull) ? string.Empty : dr["TinhTrang"].ToString();
            obj.MaDT = (dr["MaDT"] is DBNull) ? string.Empty : dr["MaDT"].ToString();
            obj.TinhTrangNopPhi = (dr["TinhTrangNopPhi"] is DBNull) ? string.Empty : dr["TinhTrangNopPhi"].ToString();
            return obj;
        }
    }
}
