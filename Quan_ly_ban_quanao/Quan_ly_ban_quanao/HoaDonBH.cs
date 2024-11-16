using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_ly_ban_quanao
{
    internal class HoaDonBH
    {
        private Ketnoi kn;


        public HoaDonBH()
        {
            kn = new Ketnoi();
        }

        public DataTable GetEmployeeList()
        {
            string sql = "SELECT * FROM ChiTietHoaDonBanHang ";

            return kn.readData(sql);

        }
        public void AddEmployee(string maHoaDon, string MaSanPham, int SoLuong, float donGia, float tongChi,string tenSanPham, DateTime Ngaynhap, string maNhanVien)
        {

            string sql = "INSERT INTO ChiTietHoaDonBanHang(MaHoaDon, MaSanPham, SoLuong, DonGia, TongTien, TenSanPham, NgayLapHoaDon,MaNhanVien) VALUES (@MaHoaDon, @MaSanPham, @SL, @DonGia, @TongChi, @TenSanPham, @NgayNhap,@MaNhanVien)";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaHoaDon", maHoaDon),
            new SqlParameter("@MaSanPham", MaSanPham),
            new SqlParameter("@SL", SoLuong),
            new SqlParameter("@DonGia", donGia),
            new SqlParameter("@TongChi",tongChi),
            new SqlParameter("@TenSanPham", tenSanPham),
            new SqlParameter("@NgayNhap", Ngaynhap),
            new SqlParameter("@MaNhanVien", maNhanVien),
           
            };
            kn.IUD(sql, parameters);
        }
        public void UpdateEmployee(string maHoaDon, string MaSanPham, int SoLuong, float donGia, float tongChi, string tenSanPham, DateTime Ngaynhap, string maNhanVien)
        {

            string sql = "UPDATE ChiTietHoaDonBanHang SET MaSanPham=@MaSanPham, SoLuong=@SL, DonGia=@DonGia,TongTien=@TongChi, TenSanPham=@TenSanPham, NgayLapHoaDon=@NgayNhap,MaNhanVien=@MaNhanVien WHERE MaHoaDon=@MaHoaDon";

            SqlParameter[] parameters = new SqlParameter[]
            {
             new SqlParameter("@MaHoaDon", maHoaDon),
            new SqlParameter("@MaSanPham", MaSanPham),
            new SqlParameter("@SL", SoLuong),
            new SqlParameter("@DonGia", donGia),
            new SqlParameter("@TongChi",tongChi),
            new SqlParameter("@TenSanPham", tenSanPham),
            new SqlParameter("@NgayNhap", Ngaynhap),
            new SqlParameter("@MaNhanVien", maNhanVien),


            };
            kn.IUD(sql, parameters);
        }
        public void DeleteEmployee(string maHoaDon)
        {
            string sql = "DELETE FROM ChiTietHoaDonBanHang WHERE MaHoaDon=@MaHoaDon";
            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@MaHoaDon", maHoaDon)
            };
            kn.IUD(sql, parameters);
        }
        public DataTable Search(string maHoaDon)
        {
            string sql = "Select * from ChiTietHoaDonBanHang where MaHoaDon Like @MaHoaDon";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("MaHoaDon","%"+maHoaDon+"%")
            };
            return kn.Loc(sql, parameters);
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
        public bool Kt(string ma)
        {
            string sql = "select * from ChiTietHoaDonBanHang where MaHoaDon = @ma";
            SqlParameter[] sqlParameter = new SqlParameter[]
            {
                new SqlParameter("@ma",ma)
            };
            return kn.Kttontai(sql, sqlParameter);
        }
    }
}
