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
    public partial class Frm_Hoadon_BH : Form
    {
        private HoaDonBH hd;
        public Frm_Hoadon_BH()
        {
            InitializeComponent();
            hd = new HoaDonBH();
            LoadData();
            dataGridView1.CellClick += dataGridView1_CellContentClick;
            LoadNhanVienIntoComboBox();
            LoadSanPhamIntoComboBox();
            cbxMaSp.SelectedIndex = 0;
            cbxNV.SelectedIndex= 0;
        }
        
        private void LoadData()
        {
            dataGridView1.DataSource = hd.GetEmployeeList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtHoadon.Text = row.Cells[0].Value?.ToString() ?? string.Empty;
                cbxMaSp.Text = row.Cells[1].Value?.ToString() ?? string.Empty;
                txtsl.Text = row.Cells[2].Value?.ToString() ?? string.Empty;
                txtdongia.Text = row.Cells[3].Value?.ToString() ?? string.Empty;
                txttongchi.Text = row.Cells[4].Value?.ToString() ?? string.Empty;
                txtSp.Text = row.Cells[5].Value?.ToString() ?? string.Empty;



                if (row.Cells[6].Value != null && DateTime.TryParse(row.Cells[6].Value.ToString(), out DateTime dateValue))
                {
                    datenhap.Text = dateValue.ToString("MM/dd/yyy");
                }
                else
                {
                    datenhap.Text = string.Empty;
                }
                cbxNV.Text = row.Cells[7].Value?.ToString() ?? string.Empty;
                
            }

        }
        bool kt()
        {
            if (string.IsNullOrWhiteSpace(txtHoadon.Text) || string.IsNullOrWhiteSpace(txtsl.Text) || string.IsNullOrWhiteSpace(txtdongia.Text)|| string.IsNullOrWhiteSpace(txttongchi.Text)|| string.IsNullOrWhiteSpace(txtSp.Text)||cbxNV.SelectedIndex==0||cbxMaSp.SelectedIndex==0)
            {
                return false;
            }
            return true;
        }
        bool ktxoa()
        {
            if (string.IsNullOrWhiteSpace(txtHoadon.Text))
            {
                return false;
            }
            return true;
        }
        void Clear()
        {
            txtHoadon.Clear();
            txtsl.Clear();
            txtdongia.Clear();
            txtSp.Clear();
            txttongchi.Clear();
            cbxMaSp.SelectedIndex = 0;
            cbxNV.SelectedIndex = 0;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadNhanVienIntoComboBox()
        {
            try
            {
                var nhanVienList = hd.GetNhanVien();
                cbxNV.Items.Clear();
                cbxNV.Items.Insert(0, "-Chọn-");
                foreach (string nv in nhanVienList)
                {
                    cbxNV.Items.Add(nv);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhà cung cấp vào ComboBox:" + ex.Message);
            }
        }
        
        private void LoadSanPhamIntoComboBox()
        {
            try
            {
                var sanPhamList = hd.GetSanPham();
                cbxMaSp.Items.Clear();
                cbxMaSp.Items.Insert(0, "-Chọn-");
                foreach (string sp in sanPhamList)
                {
                    cbxMaSp.Items.Add(sp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải nhà cung cấp vào ComboBox:" + ex.Message);
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (kt())
            {
                if (!hd.Kt(txtHoadon.Text))
                {
                    hd.AddEmployee(txtHoadon.Text, cbxMaSp.Text, Convert.ToInt32(txtsl.Text), float.Parse(txtdongia.Text), float.Parse(txttongchi.Text), txtSp.Text, datenhap.Value, cbxNV.Text);
                    LoadData();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Đã có mã hoá đơn này trong danh sách", "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Mời nhập đủ thông tin", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void bt_Tim_Click(object sender, EventArgs e)
        {
            if (ktxoa())
            {
                if (hd.Kt(txtHoadon.Text))
                {
                    dataGridView1.DataSource = hd.Search(txtHoadon.Text);

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

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn sửa không", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (kt())
                {
                    if (hd.Kt(txtHoadon.Text))
                    {
                        hd.UpdateEmployee(txtHoadon.Text, cbxMaSp.Text, Convert.ToInt32(txtsl.Text), float.Parse(txtdongia.Text), float.Parse(txttongchi.Text), txtSp.Text, datenhap.Value, cbxNV.Text);
                        LoadData();
                        MessageBox.Show("Sửa hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();

                    }
                    else
                    {
                        MessageBox.Show("Không có hoá đơn có mã như này", "Thông báo", MessageBoxButtons.OK);
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

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xoá không", "Thông báo", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (ktxoa())
                {
                    if (hd.Kt(txtHoadon.Text))
                    {
                        hd.DeleteEmployee(txtHoadon.Text);
                        LoadData();
                        MessageBox.Show("Xoá hoá đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear() ;
                    }
                    else
                    {
                        MessageBox.Show("Không có hoá đơn có mã như này", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Mã hoá đơn không được để trống", "Thông báo", MessageBoxButtons.OK);
                }

            }
            else
            {
                MessageBox.Show("Bạn đã hủy xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

        
}
