using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QuanLiDoanVien.Entity
{
   public class tbl_PhiDoanVien
    {
        private string _ID;
        private string _Nam;
        private string _MaSV;
        private string _PhiDoan;

        public string ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
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

        public string PhiDoan
        {
            get
            {
                return _PhiDoan;
            }

            set
            {
                _PhiDoan = value;
            }
        }
        public tbl_PhiDoanVien PhiDoanVienIDataReader(IDataReader dr)
        {
            tbl_PhiDoanVien obj = new tbl_PhiDoanVien();
            obj.MaSV = (dr["MaSV"] is DBNull) ? string.Empty : dr["MaSV"].ToString();
            obj.Nam = (dr["Nam"] is DBNull) ? string.Empty : dr["Nam"].ToString();
            obj.ID = (dr["ID"] is DBNull) ? string.Empty : dr["ID"].ToString();
            obj.PhiDoan = (dr["PhiDoan"] is DBNull) ? string.Empty : dr["PhiDoan"].ToString();
            return obj;
        }
    }
}
