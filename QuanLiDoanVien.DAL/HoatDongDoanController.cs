using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QuanLiDoanVien.Entity;
namespace QuanLiDoanVien.DAL
{
    public class HoatDongDoanDAL:SqlDataProvider
    {
        public List<tbl_HoatDongDoan> HoatDongDoan_GetByTop(string Top, string Where, string Order)
        {
            List<tbl_HoatDongDoan> list = new List<tbl_HoatDongDoan>();
            using (SqlCommand dbCmd = new SqlCommand("sp_HoatDongDoan_getByTop", GetConection()))
            {
                tbl_HoatDongDoan obj = new tbl_HoatDongDoan();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.HoatDongDoanIDataReader(dr));
                    }
                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        public bool HoatDongDoan_Insert(tbl_HoatDongDoan data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_HoatDongDoan_Insert", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@TenHoatDong", data.TenHoatDong);
                    dbCmd.Parameters.Add("@ThoiGian", data.ThoiGian);
                    dbCmd.Parameters.Add("@MaCB", data.MaCB);
                    dbCmd.Parameters.Add("@KetQua", data.KetQua);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool HoatDongDoan_Update(tbl_HoatDongDoan data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_HoatDongDoan_Update", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@Id", data.Id);
                    dbCmd.Parameters.Add("@TenHoatDong", data.TenHoatDong);
                    dbCmd.Parameters.Add("@ThoiGian", data.ThoiGian);
                    dbCmd.Parameters.Add("@MaCB", data.MaCB);
                    dbCmd.Parameters.Add("@KetQua", data.KetQua);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool HoatDongDoan_Delete(tbl_HoatDongDoan data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_HoatDongDoan_Delete", GetConection()))
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
