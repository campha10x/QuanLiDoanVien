using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien.DAL
{
   public class DanTocDAL:SqlDataProvider
    {
        public List<tbl_DanToc> tbl_DanToc_GetByTop(string Top, string Where, string Order)
        {
            List<tbl_DanToc> list = new List<tbl_DanToc>();
            using (SqlCommand dbCmd = new SqlCommand("sp_DanToc_getByTop", GetConection()))
            {
                tbl_DanToc obj = new tbl_DanToc();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.tbl_DanTocIDataReader(dr));
                    }
                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        public bool tbl_DanToc_Insert(tbl_DanToc data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_DanToc_Insert", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@TenDT", data.TenDT);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool tbl_DanToc_Update(tbl_DanToc data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_DanToc_Update", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@MaDT", data.MaDT);
                    dbCmd.Parameters.Add("@TenDT", data.TenDT);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool tbl_DanToc_Delete(tbl_DanToc data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_DanToc_Delete", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@MaDT", data.MaDT);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
