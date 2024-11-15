using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_ly_ban_quanao
{
    internal class NhaCungCap
    {
        Ketnoi kn;
        public NhaCungCap()
        {
            kn = new Ketnoi();
        }
        public DataTable getAllNhaCungCap()
        {
            string sql = "SELECT * FROM NhaCc";
            return kn.readData(sql);
        }
        public void CreateNhaCungCap(string MaNhaCungCap, string TenNhaCungCap, string DiaChi, string SoDienThoai, string MaSanPham)
        {
            string sql = "insert into NhaCc(MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai, MaSanPham) values (@manhacc, @tennhacc, @diachi, @sdt, @masp)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@manhacc", MaNhaCungCap),
                new SqlParameter("@tennhacc", TenNhaCungCap),
                new SqlParameter("@diachi", DiaChi),
                new SqlParameter("@sdt", SoDienThoai),
                new SqlParameter("@masp", MaSanPham),
            };
            kn.IUD(sql, sqlParameters);
        }
        public DataTable TimKiemNhaCungCap(string MaNhaCungCap)
        {
            string sql = "SELECT * FROM NhaCc where MaNhaCungCap Like @manhacc";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@manhacc", "%" + MaNhaCungCap+ "%")
            };
            return kn.Loc(sql, sqlParameters);
        }
        
        public void DeleteNhaCungCap(string MaNhaCungCap)
        {
            string sql = "delete from NhaCc where MaNhaCungCap =@manhacc";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@manhacc", MaNhaCungCap),
            };
            kn.IUD(sql, sqlParameters);
        }
        public void UpdateNhaCungCap(string MaNhaCungCap, string TenNhaCungCap, string DiaChi, string SoDienThoai, string MaSanPham)
        {
            string sql = "update NhaCc set TenNhaCungCap=@tennhacc, DiaChi=@diachi, SoDienThoai=@sdt, MaSanPham=@masp where MaNhaCungCap = @manhacc";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@manhacc", MaNhaCungCap),
                new SqlParameter("@tennhacc", TenNhaCungCap),
                new SqlParameter("@diachi", DiaChi),
                new SqlParameter("@sdt", SoDienThoai),
                new SqlParameter("@masp", MaSanPham),
            };
            kn.IUD(sql, sqlParameters);
        }
        public List<string> GetMaSanPham()
        {
            string sql = "SELECT MaSanPham FROM SanPham";
            DataTable dt = kn.readData(sql);

            List<string> listncc = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                listncc.Add(row["MaSanpHam"].ToString());
            }

            return listncc;
        }
    }
}
