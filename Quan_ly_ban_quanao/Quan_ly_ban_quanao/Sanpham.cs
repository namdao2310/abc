using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_ly_ban_quanao
{
    internal class Sanpham
    {
        Ketnoi kn;
        public Sanpham()
        {
            kn = new Ketnoi();
        }
        public DataTable getAllSP()
        {
            string sql = "Select * from SanPham";
            return kn.readData(sql);
        }
        public void Insert(string ma, string ten, float gia, string ncc, int sl, string mua, byte[] anh)
        {
            string sql = "INSERT INTO SanPham (MaSanPham, TenSanPham, DonGia, MaNhaCungCap, SoLuong, Mua, Anh) " +
                  "VALUES (@ma, @ten, @dg, @ncc, @sl, @mua, @anh)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ma", ma),
                new SqlParameter("@ten", ten),
                new SqlParameter("@dg", gia),
                new SqlParameter("@ncc", ncc),
                new SqlParameter("@sl", sl),
                new SqlParameter("@mua", mua),
                new SqlParameter("@anh", anh ?? (object)DBNull.Value) // Truyền ảnh dạng byte[] hoặc NULL nếu không có ảnh
            };

            kn.IUD(sql, parameters);
        }
        public void Delete(string ma)
        {
            string sql = "Delete from SanPham where MaSanPham  = @ma";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("ma",ma)
            };
            kn.IUD(sql, parameters);
        }
        public void Update(string ma, string ten, float gia,string ncc,int sl,string mua)
        {
            string sql = "Update SanPham set TenSanPham= @ten,DonGia=@dg,MaNhaCungCap=@ncc,SoLuong=@sl,Mua=@mua where MaSanPham = @ma";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("ma",ma),
                new SqlParameter("ten",ten),
                new SqlParameter("dg",gia),
                new SqlParameter("ncc",ncc),
                new SqlParameter("sl",sl),
                new SqlParameter("mua",mua)
            };
            kn.IUD(sql, parameters);
        }
        public List<string> GetNhaCungCap()
        {
            string sql = "SELECT MaNhaCungCap FROM NhaCc";
            DataTable dt = kn.readData(sql);

            List<string> listncc = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                listncc.Add(row["MaNhaCungCap"].ToString());
            }

            return listncc;
        }
        public string GetImagePath(string maSanPham)
        {
            string imagePath = string.Empty;
            string sql = $"SELECT Anh FROM SanPham WHERE MaSanPham = '{maSanPham}'";
            DataTable dt = kn.readData(sql);
            if (dt.Rows.Count > 0)
            {
                imagePath = dt.Rows[0]["Anh"].ToString();
            }
            return imagePath;
        }
        public bool Kt(string ma)
        {
            string sql = "select * from SanPham where MaSanPham = @ma";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@ma",ma)
            };
            return kn.Kttontai(sql, sqlParameter);
        }
        public DataTable LocHe(string mua)
        {
            string sql = "select * from SanPham where Mua Like @mua";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@mua","%" + mua + "%")
            };
            return kn.Loc(sql, sqlParameter);
        }
        public DataTable Tim(string ma)
        {
            string sql = "select * from SanPham where MaSanPham Like @ma";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@ma","%" + ma + "%")
            };
            return kn.Loc(sql, sqlParameter);
        }
        public byte[] GetImageByMaSanPham(string maSanPham)
        {
            string sql = $"SELECT Anh FROM SanPham WHERE MaSanPham = '{maSanPham}'";
            DataTable dt = kn.readData(sql);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Anh"] as byte[];
            }
            return null;
        }
    }
}
