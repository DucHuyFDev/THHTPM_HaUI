using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTTX2_30_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataUtil data = new DataUtil();

        private void DisplayData()
        {
            cbxChiNhanh.DataSource = new List<string> { "Hà Nội", "Hải Phòng", "Đà Nẵng", "TPHCM" };
            List<KhachHang> data_kh = data.getAllData();
            dgvData.DataSource = data_kh;
            if (dgvData.Columns["STT"] == null)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = "STT";
                column.HeaderText = "STT";
                dgvData.Columns.Insert(0, column);
            }
            for (int i = 0; i < data_kh.Count; i++)
            {
                dgvData.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
            dgvData.ReadOnly = true;
            List<string> header_text = new List<string> { "Mã KH", "Chi nhánh", "Họ tên", "Địa chỉ", "Số điện thoại" };
            for (int i = 0; i < dgvData.ColumnCount; i++)
            {
                dgvData.Columns[i].Width = 90;
                if (i != 0)
                {
                    dgvData.Columns[i].HeaderText = header_text[i - 1];
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                KhachHang new_kh = new KhachHang();
                new_kh.makh = txtMakh.Text;
                new_kh.hoten = txtHoTen.Text;
                new_kh.diachi = txtDiaChi.Text;
                new_kh.sodt = txtSoDT.Text;
                new_kh.chinhanh = cbxChiNhanh.Text;
                if (data.AddKH(new_kh))
                {
                    MessageBox.Show("Thêm thành công !", "Thông báo");
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Không thêm được do trùng mã KH", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Thông báo");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                KhachHang new_kh = new KhachHang();
                new_kh.makh = txtMakh.Text;
                new_kh.hoten = txtHoTen.Text;
                new_kh.diachi = txtDiaChi.Text;
                new_kh.sodt = txtSoDT.Text;
                new_kh.chinhanh = cbxChiNhanh.Text;
                if (data.updateKH(new_kh))
                {
                    MessageBox.Show("Cập nhật thành công !", "Thông báo");
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Không cập nhật được do không có KH trùng mã", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Thông báo");
            }
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            KhachHang choose = (KhachHang)dgvData.CurrentRow.DataBoundItem;
            txtMakh.Text = choose.makh;
            txtHoTen.Text = choose.hoten;
            txtDiaChi.Text = choose.diachi;
            txtSoDT.Text = choose.sodt;
            cbxChiNhanh.Text = choose.chinhanh;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string makh_delete = txtMakh.Text;
            if (makh_delete == "")
            {
                MessageBox.Show("Mã khách hàng không được để trống !", "Thông báo");
            }
            else
            {
                DialogResult d = MessageBox.Show($"Bạn có chắc chắn muốn xóa KH có mã KH là {makh_delete} không !", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    if (data.deleteKH(makh_delete))
                    {
                        MessageBox.Show("Xóa thành công !", "Thông báo");
                        DisplayData();
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được do không có KH trùng mã", "Thông báo");
                    }
                }
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
