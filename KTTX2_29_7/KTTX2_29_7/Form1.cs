using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTTX2_29_7
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
            List<Sach> lst_data = data.getAllData();
            dgvData.DataSource = lst_data;
            dgvData.Columns[0].Width = 50;
            dgvData.Columns[1].Width = 150;
            dgvData.Columns[2].Width = 80;
            dgvData.Columns[3].Width = 150;
            dgvData.Columns[4].Width = 150;
            dgvData.Columns[0].HeaderText = "Mã sách";
            dgvData.Columns[1].HeaderText = "Tên sách";
            dgvData.Columns[2].HeaderText = "Số trang";
            dgvData.Columns[3].HeaderText = "Tên tác giả";
            dgvData.Columns[4].HeaderText = "Địa chỉ tác giả";
            dgvData.ReadOnly = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Sach add_s = new Sach();
                add_s.masach = txtmasach.Text;
                add_s.tensach = txttensach.Text;
                add_s.sotrang = int.Parse(txtsotrang.Text);
                add_s.hotentg = txttentacgia.Text;
                add_s.diachitg = txtdctg.Text;
                if (data.addSach(add_s))
                {
                    MessageBox.Show("Đã thêm sách thành công", "Thông báo");
                    DisplayData();
                   
                }
                else
                {
                    MessageBox.Show("Không thêm được do đã có sách trùng mã !", "Thông báo");
                }
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}");
            }
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            Sach choose_s = (Sach)dgvData.CurrentRow.DataBoundItem;
            txtmasach.Text = choose_s.masach;
            txttensach.Text = choose_s.tensach;
            txtsotrang.Text = choose_s.sotrang.ToString();
            txttentacgia.Text = choose_s.hotentg;
            txtdctg.Text = choose_s.diachitg;
        }

        private void ClearForm()
        {
            txtmasach.Text = "";
            txttensach.Text = "";
            txtsotrang.Text = "";
            txttentacgia.Text = "";
            txtdctg.Text = "";
        }
        private void btnClearform_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string ma_delete = txtmasach.Text;
                DialogResult d = MessageBox.Show($"Bạn có muốn xóa sách có id = {ma_delete} không ?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    if (data.deleteSach(ma_delete))
                    {
                        MessageBox.Show("Xóa thành công !", "Thông báo");
                        DisplayData();
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được do không có sách trùng mã cần xóa !", "Thông báo");
                    }
                }
                ClearForm();
            }
            catch (Exception ex) {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Sach add_s = new Sach();
                add_s.masach = txtmasach.Text;
                add_s.tensach = txttensach.Text;
                add_s.sotrang = int.Parse(txtsotrang.Text);
                add_s.hotentg = txttentacgia.Text;
                add_s.diachitg = txtdctg.Text;
                if (data.updateSach(add_s))
                {
                    MessageBox.Show("Đã cập nhật sách thành công", "Thông báo");
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Không cập nhật được do không có sách trùng mã !", "Thông báo");
                }
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã có lỗi xảy ra: {ex.Message}");
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
