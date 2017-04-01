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
    public class ChiDoanDAL:SqlDataProvider
    {
        public List<tbl_ChiDoan> ChiDoanGetByTop(string Top, string Where, string Order)
        {
            List<tbl_ChiDoan> list = new List<tbl_ChiDoan>();
            using (SqlCommand dbCmd = new SqlCommand("sp_ChiDoan_getByTop", GetConection()))
            {
                tbl_ChiDoan obj = new tbl_ChiDoan();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ChiDoanIDataReader(dr));
                    }
                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        public bool ChiDoan_Insert(tbl_ChiDoan data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_ChiDoan_Insert", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@TenChiDoan", data.TenChiDoan);
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
        public bool ChiDoan_Update(tbl_ChiDoan data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_ChiDoan_Update", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@MaChiDoan", data.MaChiDoan);
                    dbCmd.Parameters.Add("@TenChiDoan", data.TenChiDoan);
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

        public bool ChiDoan_Delete(tbl_ChiDoan data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_ChiDoan_Delete", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@MaChiDoan", data.MaChiDoan);
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
