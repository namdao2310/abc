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
    public partial class Them_nv : Form
    {
        public Them_nv()
        {
            InitializeComponent();
            cb_gt.Items.Insert(0, "-Chọn-");
            cb_gt.Items.Insert(1, "Nam");
            cb_gt.Items.Insert(2, "Nữ");
            cb_gt.SelectedIndex = 0;
            pic_nv2.BorderStyle = BorderStyle.FixedSingle;
        }
        Nhanvien nv = new Nhanvien();
        bool kt()
        {

            if (string.IsNullOrWhiteSpace(txt_ma.Text) || string.IsNullOrWhiteSpace(txt_ten.Text) || string.IsNullOrWhiteSpace(txt_sdt.Text) || cb_gt.SelectedIndex == 0 || string.IsNullOrWhiteSpace(txt_cv.Text) || string.IsNullOrWhiteSpace(txt_cccd.Text) || string.IsNullOrWhiteSpace(txt_luong.Text))
            {
                return false;
            }
            return true;
        }
        private void pic_nv2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dl = new OpenFileDialog();
            DialogResult kq = dl.ShowDialog();
            dl.Filter = "Image Files|*.jpg;*.png;*.jfif";
            if (kq == DialogResult.OK)
            {
                pic_nv2.Image = new Bitmap(dl.FileName);

            }
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
            pic_nv2.Image= null;

        }
        private void bt_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            if (kt())
            {

                if (!nv.Kt(txt_ma.Text))
                {
                    byte[] imageData = null;
                    if (pic_nv2.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pic_nv2.Image.Save(ms, pic_nv2.Image.RawFormat);
                            imageData = ms.ToArray();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa có ảnh nhân viên", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    try
                    {
                        nv.Insert(txt_ma.Text, txt_ten.Text, txt_sdt.Text, cb_gt.Text, txt_cv.Text, txt_cccd.Text, float.Parse(txt_luong.Text), imageData);
                        MessageBox.Show("Thêm thành công", "Chúc mừng", MessageBoxButtons.OK);
                        Clear();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm sản phẩm: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Đã có mã sản phẩm này trong phần mềm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mời nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
