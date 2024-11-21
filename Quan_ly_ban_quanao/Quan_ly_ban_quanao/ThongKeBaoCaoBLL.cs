using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_ly_ban_quanao
{
    internal class ThongKeBaoCaoBLL
    {
        private Player thongKeBaoCaoDAL;

        public ThongKeBaoCaoBLL()
        {
            thongKeBaoCaoDAL = new Player();
        }

        public List<Report2> GetAllReports(int month,int year)
        {
            return thongKeBaoCaoDAL.GetReports(month,year);
        }

        
    }
}
