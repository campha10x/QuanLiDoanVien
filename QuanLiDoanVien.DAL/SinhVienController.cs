using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLiDoanVien.Entity;
using System.Data.SqlClient;
namespace QuanLiDoanVien.DAL
{
    public class SinhVienDAL:SqlDataProvider
    {
        public List<tbl_SinhVien> SinhVien_GetByTop(string Top, string Where, string Order)
        {
            List<tbl_SinhVien> list = new List<tbl_SinhVien>();
            using (SqlCommand dbCmd = new SqlCommand("sp_SinhVien_getByTop", GetConection()))
            {
                tbl_SinhVien obj = new tbl_SinhVien();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.SinhVienIDataReader(dr));
                    }
                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        public bool SinhVien_Insert(tbl_SinhVien data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_SinhVien_Insert", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@HoTenSV", data.HoTenSV);
                    dbCmd.Parameters.Add("@NgaySinh", data.NgaySinh);
                    dbCmd.Parameters.Add("@DiaChi", data.DiaChi);
                    dbCmd.Parameters.Add("@DienThoai", data.DienThoai);
                    dbCmd.Parameters.Add("@MaChiDoan", data.MaChiDoan);
                    dbCmd.Parameters.Add("@NgayVaoDoan", data.NgayVaoDoan);
                    dbCmd.Parameters.Add("@TinhTrang", data.TinhTrang);
                    dbCmd.Parameters.Add("@MaDT", data.MaDT);
                    dbCmd.ExecuteNonQuery();

                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public bool SinhVien_Update(tbl_SinhVien data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_SinhVien_Update", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
                    dbCmd.Parameters.Add("@MaSV", data.MaSV);
                    dbCmd.Parameters.Add("@HoTenSV", data.HoTenSV);
                    dbCmd.Parameters.Add("@NgaySinh", data.NgaySinh);
                    dbCmd.Parameters.Add("@DiaChi", data.DiaChi);
                    dbCmd.Parameters.Add("@DienThoai", data.DienThoai);
                    dbCmd.Parameters.Add("@MaChiDoan", data.MaChiDoan);
                    dbCmd.Parameters.Add("@NgayVaoDoan", data.NgayVaoDoan);
                    dbCmd.Parameters.Add("@TinhTrang", data.TinhTrang);
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

        public bool SinhVien_Delete(tbl_SinhVien data)
        {
            try
            {
                using (SqlCommand dbCmd = new SqlCommand("sp_SinhVien_Delete", GetConection()))
                {
                    dbCmd.CommandType = CommandType.StoredProcedure;
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
    }
}
