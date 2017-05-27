using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien.DAL
{
    public class PhiDoanVienDAL:SqlDataProvider
    {
        public List<tbl_PhiDoanVien> PhiDoanVien_GetByTop(string Top, string Where, string Order)
        {
            List<tbl_PhiDoanVien> list = new List<tbl_PhiDoanVien>();
            using (SqlCommand dbCmd = new SqlCommand("sp_PhiDoan_getByTop", GetConection()))
            {
                tbl_PhiDoanVien obj = new tbl_PhiDoanVien();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.PhiDoanVienIDataReader(dr));
                    }
                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        public bool PhiDoanVien_Insert(tbl_PhiDoanVien data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_PhiDoan_Insert", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@MaSV", data.MaSV);
                    dbCmd.Parameters.Add("@Nam", data.Nam);
                    dbCmd.Parameters.Add("@PhiDoan", data.PhiDoan);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool PhiDoanVien_Update(tbl_PhiDoanVien data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_PhiDoan_Update", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@ID", data.ID);
                    dbCmd.Parameters.Add("@MaSV", data.MaSV);
                    dbCmd.Parameters.Add("@Nam", data.Nam);
                    dbCmd.Parameters.Add("@PhiDoan", data.PhiDoan);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool PhiDoanVien_Delete(tbl_PhiDoanVien data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_PhiDoanVien_Delete", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@ID", data.ID);
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
