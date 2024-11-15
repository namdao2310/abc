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
    public partial class Frm_QlNhacc : Form
    {
        NhaCungCap b = new NhaCungCap();
        public Frm_QlNhacc()
        {
            InitializeComponent();
            LoadMaSanPhamIntoComboBox();
            cb_msp.SelectedIndex = 0;
        }
        void hienthi()
        {
            dataGridView1.DataSource = b.getAllNhaCungCap();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            b.CreateNhaCungCap(txt_manhacc.Text, txt_tennhacc.Text, txt_diachi.Text, txt_sdt.Text, cb_msp.Text);
            hienthi();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            b.UpdateNhaCungCap(txt_manhacc.Text, txt_tennhacc.Text, txt_diachi.Text, txt_sdt.Text,cb_msp.Text);
            hienthi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            b.DeleteNhaCungCap(txt_manhacc.Text);
            hienthi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void LoadMaSanPhamIntoComboBox()
        {
            try
            {
                var nhaCungCapList = b.GetMaSanPham();
                cb_msp.Items.Clear();
                cb_msp.Items.Insert(0, "-Chọn-");
                foreach (string ncc in nhaCungCapList)
                {
                    cb_msp.Items.Add(ncc);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhà cung cấp vào ComboBox: " + ex.Message);
            }
        }
        private void Frm_QlNhacc_Load(object sender, EventArgs e)
        {
            hienthi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows.Count >= 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txt_manhacc.Text = row.Cells[0].Value.ToString();
                txt_tennhacc.Text = row.Cells[1].Value.ToString();
                txt_diachi.Text = row.Cells[2].Value.ToString();
                txt_sdt.Text = row.Cells[3].Value.ToString();
                cb_msp.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= b.TimKiemNhaCungCap(txt_manhacc.Text);
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
