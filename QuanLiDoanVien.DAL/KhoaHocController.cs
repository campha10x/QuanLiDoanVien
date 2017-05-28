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
   public class KhoaHocDAL:SqlDataProvider
    {
        public List<tbl_KhoaHoc> KhoaHocGetByTop(string Top, string Where, string Order)
        {
            List<tbl_KhoaHoc> list = new List<tbl_KhoaHoc>();
            using (SqlCommand dbCmd = new SqlCommand("sp_KhoaHoc_getByTop", GetConection()))
            {
                tbl_KhoaHoc obj = new tbl_KhoaHoc();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.KhoaHocIDataReader(dr));
                    }
                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        public bool KhoaHoc_Insert(tbl_KhoaHoc data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_KhoaHoc_Insert", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@ThoiGianDaoTao", data.ThoiGianDaoTao);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool KhoaHoc_Update(tbl_KhoaHoc data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_KhoaHoc_Update", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@MaKhoaHoc", data.MaKhoaHoc);
                    dbCmd.Parameters.Add("@ThoiGianDaoTao", data.ThoiGianDaoTao);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool KhoaHoc_Delete(tbl_KhoaHoc data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_KhoaHoc_Delete", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@MaKhoaHoc", data.MaKhoaHoc);
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
