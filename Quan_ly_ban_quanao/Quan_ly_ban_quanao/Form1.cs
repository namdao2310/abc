using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_ban_quanao
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void quảnLýSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_QLsanpham frm_QLsanpham = new Frm_QLsanpham();
            frm_QLsanpham.MdiParent = this;
            frm_QLsanpham.Width = 920;               // Đặt chiều rộng Form con
            frm_QLsanpham.Height = 600;
            frm_QLsanpham.Show();
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Frm_QlNhacc frm_QlNhacc = new Frm_QlNhacc();
                frm_QlNhacc.MdiParent = this;
                frm_QlNhacc.Show();

        }

        private void hoáĐơnBánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Hoadon_BH frm_Hoadon_BH = new Frm_Hoadon_BH();
            frm_Hoadon_BH.MdiParent = this;
            frm_Hoadon_BH.Show();
        }

        private void hoáĐơnMuaHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon_Nhap hoaDon_Nhap = new HoaDon_Nhap();
            hoaDon_Nhap.MdiParent = this;
            hoaDon_Nhap.Show();
        }
    }
}
