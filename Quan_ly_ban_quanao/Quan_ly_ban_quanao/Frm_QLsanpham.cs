using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_ban_quanao
{
    public partial class Frm_QLsanpham : Form
    {
        public Frm_QLsanpham()
        {
            InitializeComponent();
            LoadNhaCungCapIntoComboBox();
            cb_mua.Items.Insert(0, "-Chọn-");
            cb_mua.Items.Insert(1, "Hè");
            cb_mua.Items.Insert(2, "Đông");
            cb_mua.Items.Insert(3, "H-Đ");
            cb_loc.Items.Insert(0, "-Chọn-");
            cb_loc.Items.Insert(1, "Hè");
            cb_loc.Items.Insert(2, "Đông");
            cb_loc.Items.Insert(3, "H-Đ");
            cb_loc.SelectedIndex = 0;
            cb_mua.SelectedIndex = 0;
            cb_ncc.SelectedIndex = 0;
            pic_sp.BorderStyle = BorderStyle.FixedSingle;
            
        }
        Sanpham sp = new Sanpham();
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Hienthi()
        {
            dt_sp.DataSource = sp.getAllSP();
        }
        void Clear()
        {
            txt_ma.Clear();
            txt_ten.Clear();
            txt_gia.Clear();
            cb_ncc.SelectedIndex = 0;
            txt_sl.Clear();
            cb_mua.SelectedIndex = 0;
        }
        bool ktxoa()
        {
            if (string.IsNullOrWhiteSpace(txt_ma.Text))
            {
                return false;
            }
            return true;
        }
        bool kt()
        {

            if (string.IsNullOrWhiteSpace(txt_ma.Text) || string.IsNullOrWhiteSpace(txt_ten.Text) || string.IsNullOrWhiteSpace(txt_gia.Text) || string.IsNullOrWhiteSpace(txt_sl.Text) || cb_ncc.SelectedIndex == 0 || cb_mua.SelectedIndex == 0)
            {
                return false;
            }
            return true;
        }
        private void Frm_QLsanpham_Load(object sender, EventArgs e)
        {
            
            Hienthi();
        }

        private void dt_sp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dt_sp.Rows.Count;
            if (vt >= 0)
            {
                DataGridViewRow r = dt_sp.SelectedRows[0];
                txt_ma.Text = r.Cells[0].Value.ToString();
                txt_ten.Text = r.Cells[1].Value.ToString();
                txt_gia.Text = r.Cells[2].Value.ToString();
                cb_ncc.Text = r.Cells[3].Value.ToString();
                txt_sl.Text = r.Cells[4].Value.ToString();
                cb_mua.Text = r.Cells[5].Value.ToString();
                DisplayImage(txt_ma.Text);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn sửa không", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (kt())
                {
                    if (sp.Kt(txt_ma.Text))
                    {
                        sp.Update(txt_ma.Text, txt_ten.Text, Convert.ToInt32(txt_gia.Text), cb_ncc.Text, Convert.ToInt32(txt_sl.Text), cb_mua.Text);
                        MessageBox.Show("Sửa sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Không có sản phẩm có mã như này", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Mời nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("Bạn đã hủy sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void LoadNhaCungCapIntoComboBox()
        {
            try
            {
                var nhaCungCapList = sp.GetNhaCungCap();
                cb_ncc.Items.Clear();
                cb_ncc.Items.Insert(0, "-Chọn-");
                foreach (string ncc in nhaCungCapList)
                {
                    cb_ncc.Items.Add(ncc);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhà cung cấp vào ComboBox: " + ex.Message);
            }
        }
        private void DisplayImage(string maSanPham)
        {
            byte[] imageData = sp.GetImageByMaSanPham(maSanPham);

            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pic_sp.Image = Image.FromStream(ms);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy ảnh cho sản phẩm này.");
            }
        }
        
        private void btn_them_Click(object sender, EventArgs e)
        {
            
            frm_ThemSP  add = new frm_ThemSP();
            add.FormClosed += Frm_QLsanpham_FormClosed;
            add.Show();
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xoá không", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (ktxoa())
                {
                    if (sp.Kt(txt_ma.Text))
                    {
                        sp.Delete(txt_ma.Text);
                        MessageBox.Show("Xoá sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Không có sản phẩm có mã như này", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("Bạn đã hủy xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Frm_QLsanpham_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hienthi();
        }

        private void cb_loc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_loc.SelectedIndex == 0)
            {
                Hienthi();
            }
            if (cb_loc.SelectedIndex == 1)
            {
                string selectedValue = cb_loc.SelectedItem.ToString();
                dt_sp.DataSource=   sp.LocHe(selectedValue);
            }
            else
            {
                if (cb_loc.SelectedIndex == 2)
                {
                    string selectedValue = cb_loc.SelectedItem.ToString();
                    dt_sp.DataSource = sp.LocHe(selectedValue);
                }
                else
                {
                    if (cb_loc.SelectedIndex == 3)
                    {
                        string selectedValue = cb_loc.SelectedItem.ToString();
                        dt_sp.DataSource = sp.LocHe(selectedValue);
                    }
                }
            }
        }

        private void btn_tim_Click(object sender, EventArgs e)
        {
            if (ktxoa())
            {
                if (sp.Kt(txt_ma.Text))
                {
                    dt_sp.DataSource =  sp.Tim(txt_ma.Text);

                }
                else
                {
                    MessageBox.Show("Không có sản phẩm có mã như này", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Mã sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK);
            }
        }
    }
}
