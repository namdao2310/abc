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
    public partial class Frm_NhanVien : Form
    {
        Nhanvien nv = new Nhanvien();
        public Frm_NhanVien()
        {
            InitializeComponent();
            cb_gt.Items.Insert(0, "-Chọn-");
            cb_gt.Items.Insert(1, "Nam");
            cb_gt.Items.Insert(2, "Nữ");
            cb_gt.SelectedIndex = 0;
            pic_nv.BorderStyle = BorderStyle.FixedSingle;
        }

        private void bt_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void Hienthi()
        {
            dt_nv.DataSource = nv.getAllNV();
        }
        void Clear()
        {
            txt_ma.Clear();
            txt_ten.Clear();
            txt_sdt.Clear();
            cb_gt.SelectedIndex = 0;
            txt_cv.Clear();
            txt_cccd.Clear();
            txt_luong.Clear();
            pic_nv.Image = null;
            
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

            if (string.IsNullOrWhiteSpace(txt_ma.Text) || string.IsNullOrWhiteSpace(txt_ten.Text) || string.IsNullOrWhiteSpace(txt_sdt.Text) || cb_gt.SelectedIndex == 0 || string.IsNullOrWhiteSpace(txt_cv.Text) || string.IsNullOrWhiteSpace(txt_cccd.Text) || string.IsNullOrWhiteSpace(txt_luong.Text))
            {
                return false;
            }
            return true;
        }
        private void Frm_NhanVien_Load(object sender, EventArgs e)
        {
            Hienthi();
        }

        private void DisplayImage(string manv)
        {
            byte[] imageData = nv.GetImageByMaNhanVien(manv);

            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    pic_nv.Image = Image.FromStream(ms);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy ảnh cho sản phẩm này.");
            }
        }

        private void dt_nv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int vt = dt_nv.Rows.Count;
            if (vt >= 0)
            {
                DataGridViewRow r = dt_nv.SelectedRows[0];
                txt_ma.Text = r.Cells[0].Value.ToString();
                txt_ten.Text = r.Cells[1].Value.ToString();
                txt_sdt.Text = r.Cells[2].Value.ToString();
                cb_gt.Text = r.Cells[3].Value.ToString();
                txt_cv.Text = r.Cells[4].Value.ToString();
                txt_cccd.Text = r.Cells[5].Value.ToString();
                txt_luong.Text = r.Cells[6].Value.ToString();
                DisplayImage(txt_ma.Text);
            }
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            Them_nv add = new Them_nv();
            add.FormClosed += Frm_NhanVien_FormClosed;
            add.Show();
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn sửa không", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (kt())
                {
                    if (nv.Kt(txt_ma.Text))
                    {
                        nv.Update(txt_ma.Text, txt_ten.Text,txt_sdt.Text,cb_gt.Text,txt_cv.Text,txt_cccd.Text,float.Parse(txt_luong.Text));
                        MessageBox.Show("Sửa thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Không có nhân viên có mã như này", "Thông báo", MessageBoxButtons.OK);
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

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xoá không", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (ktxoa())
                {
                    if (nv.Kt(txt_ma.Text))
                    {
                        nv.Delete(txt_ma.Text);
                        MessageBox.Show("Xoá nhân viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hienthi();
                    }
                    else
                    {
                        MessageBox.Show("Không có nhân viên có mã như này", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Mã nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("Bạn đã hủy xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bt_tim_Click(object sender, EventArgs e)
        {
            if (ktxoa())
            {
                if (nv.Kt(txt_ma.Text))
                {
                    dt_nv.DataSource = nv.Tim(txt_ma.Text);

                }
                else
                {
                    MessageBox.Show("Không có nhân viên có mã như này", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Mã nhân viên không được để trống", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void Frm_NhanVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Hienthi();
        }
    }
}
