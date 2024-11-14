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
            string sql = "insert into tbNhaCungCap(MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai, MaSanPham) values (@manhacc, @tennhacc, @diachi, @sdt, @masp)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@manhacc", MaNhaCungCap),
                new SqlParameter("@tennhacc", TenNhaCungCap),
                new SqlParameter("@diachi", DiaChi),
                new SqlParameter("@sdt", SoDienThoai),
                new SqlParameter("@masp", MaSanPham),
            };
            kn.Create (sql, sqlParameters);
        }
        public void TimKiemNhaCungCap(string MaNhaCungCap)
        {
            string sql = "SELECT * FROM NhaCc where MaNhaCungCap =@manhacc";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@manhacc", MaNhaCungCap),
            };
            kn.Create (sql, sqlParameters);
        }
        public void SuaNhaCungCap(string MaNhaCungCap, string TenNhaCungCap, string DiaChi, string SoDienThoai, string MaSanPham)
        {
            string sql = "insert into tbNhaCungCap(MaNhaCungCap, TenNhaCungCap, DiaChi, SoDienThoai, MaSanPham) values (@manhacc, @tennhacc, @diachi, @sdt, @masp)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@manhacc", MaNhaCungCap),
                new SqlParameter("@tennhacc", TenNhaCungCap),
                new SqlParameter("@diachi", DiaChi),
                new SqlParameter("@sdt", SoDienThoai),
                new SqlParameter("@masp", MaSanPham),
            };
            kn.Create (sql, sqlParameters);
        }
        public void DeleteNhaCungCap(string MaNhaCungCap)
        {
            string sql = "delete from NhaCc where MaNhaCungCap =@manhacc";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@manhacc", MaNhaCungCap),
            };
            kn.Create (sql, sqlParameters);
        }
        public void UpdateNhaCungCap(string MaNhaCungCap, string TenNhaCungCap, string DiaChi, string SoDienThoai, string MaSanPham)
        {
            string sql = "update NhaCc set MaNhaCungCap=@manhacc, TenNhaCungCap=@tennhacc, DiaChi=@diachi, SoDienThoai=@sdt, MaSanPham=@masp";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@manhacc", MaNhaCungCap),
                new SqlParameter("@tennhacc", TenNhaCungCap),
                new SqlParameter("@diachi", DiaChi),
                new SqlParameter("@sdt", SoDienThoai),
                new SqlParameter("@masp", MaSanPham),
            };
            kn.Create(sql, sqlParameters);
        }

    }
}
