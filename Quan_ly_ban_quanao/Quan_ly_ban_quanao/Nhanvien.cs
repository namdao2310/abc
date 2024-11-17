using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_ly_ban_quanao
{
    internal class Nhanvien
    {
        Ketnoi kn;
        public Nhanvien() 
        {
            kn = new Ketnoi();
        }
        public DataTable getAllNV()
        {
            string sql = "Select * from BangNhanVien";
            return kn.readData(sql);
        }
        public void Insert(string ma, string ten, string sdt, string gt, string cv, string cccd, float luong, byte[] anh)
        {
            string sql = "INSERT INTO BangNhanVien (MaNhanVien, TenNhanVien, SoDienThoai, GioiTinh, ChucVu, Cancuoccd,HsLuong, Anh) " +
                  "VALUES (@ma, @ten, @sdt, @gt, @cv, @cccd,@luong, @anh)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("ma",ma),
                new SqlParameter("ten",ten),
                new SqlParameter("sdt",sdt),
                new SqlParameter("gt",gt),
                new SqlParameter("cv",cv),
                new SqlParameter("cccd",cccd),
                new SqlParameter("luong",luong),
                new SqlParameter("@anh", SqlDbType.VarBinary)
                {
                    Value = anh ?? (object)DBNull.Value
                }
            };

            kn.IUD(sql, parameters);
        }
        public void Delete(string ma)
        {
            string sql = "Delete from BangNhanVien where MaNhanVien  = @ma";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("ma",ma)
            };
            kn.IUD(sql, parameters);
        }
        public void Update(string ma, string ten, string sdt, string gt, string cv, string cccd,float luong)
        {
            string sql = "Update BangNhanVien set TenNhanVien= @ten,SoDienThoai=@sdt,GioiTinh=@gt,ChucVu=@cv,Cancuoccd=@cccd,HsLuong = @luong where MaNhanVien = @ma";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("ma",ma),
                new SqlParameter("ten",ten),
                new SqlParameter("sdt",sdt),
                new SqlParameter("gt",gt),
                new SqlParameter("cv",cv),
                new SqlParameter("cccd",cccd),
                new SqlParameter("luong",luong)
            };
            kn.IUD(sql, parameters);
        }
        public bool Kt(string ma)
        {
            string sql = "select * from BangNhanVien where MaNhanVien = @ma";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@ma",ma)
            };
            return kn.Kttontai(sql, sqlParameter);
        }
        public DataTable Tim(string ma)
        {
            string sql = "select * from BangNhanVien where MaNhanVien Like @ma";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@ma","%" + ma + "%")
            };
            return kn.Loc(sql, sqlParameter);
        }
        public byte[] GetImageByMaNhanVien(string manv)
        {
            string sql = $"SELECT Anh FROM BangNhanVien WHERE MaNhanVien = '{manv}'";
            DataTable dt = kn.readData(sql);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Anh"] as byte[];
            }
            return null;
        }
    }
}
