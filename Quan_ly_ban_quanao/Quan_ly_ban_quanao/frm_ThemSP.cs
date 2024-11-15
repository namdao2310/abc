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
    public partial class frm_ThemSP : Form
    {
        Sanpham sp = new Sanpham();
        public frm_ThemSP()
        {
            InitializeComponent();
            pic_sp2.BorderStyle = BorderStyle.FixedSingle;
            LoadNhaCungCapIntoComboBox();
            cb_mua.Items.Insert(0, "-Chọn-");
            cb_mua.Items.Insert(1, "Hè");
            cb_mua.Items.Insert(2, "Đông");
            cb_mua.Items.Insert(3, "H-Đ");
            cb_mua.SelectedIndex = 0;
            cb_ncc.SelectedIndex = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        bool kt()
        {
            
            if (string.IsNullOrWhiteSpace(txt_ma.Text)|| string.IsNullOrWhiteSpace(txt_ten.Text)|| string.IsNullOrWhiteSpace(txt_gia.Text)|| string.IsNullOrWhiteSpace(txt_sl.Text)|| cb_ncc.SelectedIndex == 0 || cb_mua.SelectedIndex == 0)
            {
                return false;
            }
            return true;
        }
       
        private void bt_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void pic_sp2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dl = new OpenFileDialog();
            DialogResult kq = dl.ShowDialog();
            dl.Filter = "Image Files|*.jpg;*.png;*.jfif";
            if (kq == DialogResult.OK)
            {
                pic_sp2.Image = new Bitmap(dl.FileName);
                
            }
            
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
        private void bt_Them_Click(object sender, EventArgs e)
        {
            if (kt())
            {
                
                if (!sp.Kt(txt_ma.Text))
                {
                    byte[] imageData = null;
                    if (pic_sp2.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pic_sp2.Image.Save(ms, pic_sp2.Image.RawFormat);
                            imageData = ms.ToArray();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa có ảnh sản phẩm","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }

                    try
                    {
                        sp.Insert(txt_ma.Text, txt_ten.Text, Convert.ToInt32(txt_gia.Text), cb_ncc.Text, Convert.ToInt32(txt_sl.Text), cb_mua.Text, imageData);
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
