
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_ban_quanao
{
    public partial class Baocao : Form
    {
        private ThongKeBaoCaoBLL thongKeBaoCaoBLL;
        public Baocao()
        {
            InitializeComponent();
            thongKeBaoCaoBLL = new ThongKeBaoCaoBLL();
        }



        private void Baocao_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                List<Report2> reports = thongKeBaoCaoBLL.GetAllReports(dateTimePicker1.Value.Month,dateTimePicker1.Value.Year);

                if (reports == null || reports.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị trong báo cáo.");
                    return;
                }
                ReportDataSource reportDataSource = new ReportDataSource("NamDao", reports);
                reportViewer1.LocalReport.ReportEmbeddedResource = "Quan_ly_ban_quanao.Report3.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                reportViewer1.RefreshReport();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Không tìm thấy tệp báo cáo: " + ex.Message);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Lỗi tham chiếu null: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
