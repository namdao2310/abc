using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_ly_ban_quanao
{
    internal class HoaDon
    {
        Ketnoi kn;


        public HoaDon()
        {
            kn = new Ketnoi();
        }

        public DataTable GetEmployeeList()
        {
            string sql = "SELECT * FROM ChiTietHoaDonNhapHang ";

            return kn.readData(sql);

        }
        public void AddEmployee(string maHoaDon, string maNhanVien, string tenSanPham, string maNhaCC, float tongChi, float donGia, DateTime Ngaynhap, string MaSanPham, int SoLuong)
        {

            string sql = "INSERT INTO ChiTietHoaDonNhapHang(MaHoaDon, MaNhanVien, TenSanPham, MaNhaCungCap, TongChi, DonGia, NgayNhap,MaSanPham,SoLuong) VALUES (@MaHoaDon, @MaNhanVien, @TenSanPham, @MaNhaCungCap, @TongChi, @DonGia, @NgayNhap,@MaSanPham,@SoLuong)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaHoaDon", maHoaDon),
            new SqlParameter("@MaNhanVien", maNhanVien),
            new SqlParameter("@TenSanPham", tenSanPham),
            new SqlParameter("@MaNhaCungCap", maNhaCC),
            new SqlParameter("@TongChi",tongChi),
            new SqlParameter("@DonGia", donGia),
            new SqlParameter("@NgayNhap", Ngaynhap),
            new SqlParameter("@MaSanPham", MaSanPham),
            new SqlParameter("@SoLuong", SoLuong),

            };
            kn.IUD(sql, parameters);
        }
        public void UpdateEmployee(string maHoaDon, string maNhanVien, string tenSanPham, string maNhaCC, float tongChi, float donGia, DateTime Ngaynhap, string MaSanPham, int SoLuong)
        {

            string sql = "UPDATE ChiTietHoaDonNhapHang SET MaNhanVien=@MaNhanVien, TenSanPham=@TenSanPham, MaNhaCungCap=@MaNhaCungCap,TongChi=@TongChi, DonGia=@DonGia, NgayNhap=@NgayNhap,MaSanPham=@MaSanPham,SoLuong=@SoLuong WHERE MaHoaDon=@MaHoaDon";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaHoaDon", maHoaDon),
            new SqlParameter("@MaNhanVien", maNhanVien),
            new SqlParameter("@TenSanPham", tenSanPham),
            new SqlParameter("@MaNhaCungCap", maNhaCC),
            new SqlParameter("@TongChi",tongChi),
            new SqlParameter("@DonGia", donGia),
            new SqlParameter("@NgayNhap", Ngaynhap),
            new SqlParameter("@MaSanPham", MaSanPham),
            new SqlParameter("@SoLuong", SoLuong),

            };
            kn.IUD(sql, parameters);
        }
        public void DeleteEmployee(string maHoaDon)
        {
            string sql = "DELETE FROM ChiTietHoaDonNhapHang WHERE MaHoaDon=@MaHoaDon";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaHoaDon", maHoaDon)
            };
            kn.IUD(sql, parameters);
        }

        public List<string> GetNhanVien()
        {
            string sql = "SELECT MaNhanVien FROM BangNhanVien";
            DataTable dt = kn.readData(sql);
            List<string> listnv = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                listnv.Add(row["MaNhanVien"].ToString());
            }
            return listnv;
        }
        public List<string> GetNhacc()
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
        public List<string> GetSanPham()
        {
            string sql = "SELECT MaSanPham FROM SanPham";
            DataTable dt = kn.readData(sql);
            List<string> listsp = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                listsp.Add(row["MaSanPham"].ToString());
            }
            return listsp;
        }
        public bool Kt(string maHoaDon)
        {
            string sql = "select * from ChiTietHoaDonNhapHang where MaHoaDon = @maHoaDon";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@MaHoaDon", maHoaDon)
            };
            return kn.Kttontai(sql, sqlParameter);
        }
    }
}
