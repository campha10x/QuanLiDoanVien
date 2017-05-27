using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLiDoanVien.Entity;
using System.Data;
using System.Data.SqlClient;
namespace QuanLiDoanVien.DAL
{
   public class NguoiDungDAL:SqlDataProvider
    {
        public List<tbl_NguoiDung> NguoiDung_GetByTop(string Top, string Where, string Order)
        {
            List<tbl_NguoiDung> list = new List<tbl_NguoiDung>();
            using (SqlCommand dbCmd = new SqlCommand("sp_tbl_NGUOIDUNG_getByTop", GetConection()))
            {
                tbl_NguoiDung obj = new tbl_NguoiDung();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.NguoiDungIDataReader(dr));
                    }
                }
                dr.Close();
                obj = null;

            }
            return list;
        }
        public bool NguoiDung_Update(tbl_NguoiDung data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_NguoiDung_Update", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@Id", data.Id);
                    dbCmd.Parameters.Add("@TenDangNhap", data.TenDangNhap);
                    dbCmd.Parameters.Add("@IdQuyen", data.IdQuyen);
                    dbCmd.Parameters.Add("@MatKhau", data.MatKhau);
                    dbCmd.Parameters.Add("@MaCB", data.MaCB);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
