using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace QuanLiDoanVien.Entity
{
    public class tbl_DanToc
    {
        private string _MaDT;
        private string _TenDT;

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

        public string TenDT
        {
            get
            {
                return _TenDT;
            }

            set
            {
                _TenDT = value;
            }
        }
        public tbl_DanToc tbl_DanTocIDataReader(IDataReader dr)
        {
            tbl_DanToc obj = new tbl_DanToc();
            obj.MaDT = (dr["MaDT"] is DBNull) ? string.Empty : dr["MaDT"].ToString();
            obj.TenDT = (dr["TenDT"] is DBNull) ? string.Empty : dr["TenDT"].ToString();
            return obj;
        }
    }
}
