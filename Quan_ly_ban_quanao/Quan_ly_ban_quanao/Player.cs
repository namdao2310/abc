using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_ban_quanao
{
    internal class Player
    {
        Ketnoi kn;
        public Player()
        {
            kn = new Ketnoi();
        }
        public List<Report2> GetReports(int thang,int nam)
        {
            List<Report2> reportList = new List<Report2>();
            try
            { 
                string sql = "SELECT * FROM thong_ke_bao_cao WHERE thang = @thang AND nam = @nam";
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@thang", thang),
                    new SqlParameter("@nam", nam)
                };
                DataTable dataTable = kn.Loc(sql, parameters);
                foreach (DataRow row in dataTable.Rows)
                {
                    Report2 report = new Report2
                    {
                        MaBaoCao = row["ma_bao_cao"] != DBNull.Value ? Convert.ToInt32(row["ma_bao_cao"]) : 0,
                        Thang = row["thang"] != DBNull.Value ? Convert.ToInt32(row["thang"]) : 0,
                        Nam = row["nam"] != DBNull.Value ? Convert.ToInt32(row["nam"]) : 0,
                        TongSoSanPhamBanRa = row["tong_so_san_pham_ban_ra"] != DBNull.Value ? (int?)Convert.ToInt32(row["tong_so_san_pham_ban_ra"]) : null,
                        TongDoanhThu = row["tong_doanh_thu"] != DBNull.Value ? (decimal?)Convert.ToDecimal(row["tong_doanh_thu"]) : null,
                        TongChiPhi = row["tong_chi_phi"] != DBNull.Value ? (decimal?)Convert.ToDecimal(row["tong_chi_phi"]) : null,
                        TongLoiNhuan = row["tong_loi_nhuan"] != DBNull.Value ? (decimal?)Convert.ToDecimal(row["tong_loi_nhuan"]) : null,
                        NgayTao = row["ngay_tao"] != DBNull.Value ? Convert.ToDateTime(row["ngay_tao"]) : DateTime.MinValue
                    };
                    reportList.Add(report);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return reportList;
        }

    }
}