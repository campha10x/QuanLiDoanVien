using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuanLiDoanVien.Entity;
using System.Data;
using System.Data.SqlClient;
namespace QuanLiDoanVien.DAL
{
   public class CanBoDoanDAL:SqlDataProvider
    {
        public List<tbl_CanBoDoan> CanBoDoan_GetByTop(string Top, string Where, string Order)
        {
            List<tbl_CanBoDoan> list = new List<tbl_CanBoDoan>();
            using (SqlCommand dbCmd = new SqlCommand("sp_CanBoDoan_getByTop", GetConection()))
            {
                tbl_CanBoDoan obj = new tbl_CanBoDoan();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.CanBoDoanIDataReader(dr));
                    }
                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        public bool CanBoDoan_Insert(tbl_CanBoDoan data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_CanBoDoan_Insert", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@HoTenSV", data.HoTen);
                    dbCmd.Parameters.Add("@GioiTinh", data.GioiTinh);
                    dbCmd.Parameters.Add("@ChucVu", data.ChucVu);
                    dbCmd.Parameters.Add("@DiaChi", data.DiaChi);
                    dbCmd.Parameters.Add("@DienThoai", data.DienThoai);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool CanBoDoan_Update(tbl_CanBoDoan data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_CanBoDoan_Update", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@MaCB", data.MaCB);
                    dbCmd.Parameters.Add("@HoTen", data.HoTen);
                    dbCmd.Parameters.Add("@GioiTinh", data.GioiTinh);
                    dbCmd.Parameters.Add("@ChucVu", data.ChucVu);
                    dbCmd.Parameters.Add("@DiaChi", data.DiaChi);
                    dbCmd.Parameters.Add("@DienThoai", data.DienThoai);

                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CanBoDoan_Delete(tbl_CanBoDoan data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_CanBoDoan_Delete", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@MaCB", data.MaCB);
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
