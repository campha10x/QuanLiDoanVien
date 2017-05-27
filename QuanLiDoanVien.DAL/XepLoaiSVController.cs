using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiDoanVien.Entity;
using System.Data;
using System.Data.SqlClient;
namespace QuanLiDoanVien.DAL
{
    public class XepLoaiSVDAL:SqlDataProvider
    {
        public List<tbl_XepLoaiSV> XepLoaiSV_GetByTop(string Top, string Where, string Order)
        {
            List<tbl_XepLoaiSV> list = new List<tbl_XepLoaiSV>();
            using (SqlCommand dbCmd = new SqlCommand("sp_XepLoaiSV_getByTop", GetConection()))
            {
                tbl_XepLoaiSV obj = new tbl_XepLoaiSV();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.XepLoaiSVIDataReader(dr));
                    }
                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        public bool XepLoaiSV_Insert(tbl_XepLoaiSV data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_XepLoaiSV_Insert", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@Nam", data.Nam);
                    dbCmd.Parameters.Add("@XepLoai", data.XepLoai);
                    dbCmd.Parameters.Add("@MaSV", data.MaSV);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool XepLoaiSV_Update(tbl_XepLoaiSV data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_XepLoaiSV_Update", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@Id", data.Id);
                    dbCmd.Parameters.Add("@Nam", data.Nam);
                    dbCmd.Parameters.Add("@XepLoai", data.XepLoai);
                    dbCmd.Parameters.Add("@MaSV", data.MaSV);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool XepLoaiSV_Delete(tbl_XepLoaiSV data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_XepLoaiSV_Delete", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@Id", data.Id);
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
