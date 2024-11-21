using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_ly_ban_quanao
{
    internal class Report2
    {
        public int MaBaoCao { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public int? TongSoSanPhamBanRa { get; set; }
        public decimal? TongDoanhThu { get; set; }
        public decimal? TongChiPhi { get; set; }
        public decimal? TongLoiNhuan { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
