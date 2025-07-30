using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace KTTX2_28_7
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
            dgvData.Columns[1].Width = 100;
            dgvData.Columns[2].Width = 100;
            dgvData.Columns[3].Width = 100;
            dgvData.Columns[4].Width = 100;
            dgvData.Columns[0].HeaderText = "Mã sách";
            dgvData.Columns[1].HeaderText = "Tên sách";
            dgvData.Columns[2].HeaderText = "Số trang";
            dgvData.Columns[3].HeaderText = "Tên TG";
            dgvData.Columns[4].HeaderText = "Địa chỉ TG";
            dgvData.ReadOnly = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Sach add = new Sach();
            add.masach = txtmasach.Text;
            add.tensach = txttensach.Text;
            add.sotrang = int.Parse(txtsotrang.Text);
            add.tentacgia = txttentacgia.Text;
            add.diachitgia = txtdiachitacgia.Text;
            if (data.addSach(add))
            {
                MessageBox.Show("Đã thêm thành công !", "Thông báo");
                DisplayData();
            }
            else
            {
                MessageBox.Show("Thêm không thành công do có sách trùng mã!", "Thông báo");
            }
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            Sach choose = (Sach)dgvData.CurrentRow.DataBoundItem;
            txtmasach.Text = choose.masach;
            txttensach.Text = choose.tensach;
            txtsotrang.Text = choose.sotrang.ToString();
            txttentacgia.Text = choose.tentacgia;
            txtdiachitacgia.Text = choose.diachitgia;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Sach update = new Sach();
            update.masach = txtmasach.Text;
            update.tensach = txttensach.Text;
            update.sotrang = int.Parse(txtsotrang.Text);
            update.tentacgia = txttentacgia.Text;
            update.diachitgia = txtdiachitacgia.Text;
            if (data.updateSach(update))
            {
                MessageBox.Show("Đã cập nhật thành công !", "Thông báo");
                DisplayData();
            }
            else
            {
                MessageBox.Show("Cập nhật không thành công do không tìm được sách trùng mã!", "Thông báo");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string hotentg = txttentacgia.Text;
            List<Sach> search_result = data.searchSach(hotentg);
            if (search_result.Count == 0)
            {
                MessageBox.Show($"Không tìm thấy sách có tên tác giả là {hotentg}", "Thông báo");
            }
            else
            {
                MessageBox.Show($"Tìm thấy {search_result.Count} sách có tên tác giả là {hotentg}", "Thông báo");
                dgvData.DataSource = search_result;
                dgvData.Columns[0].Width = 50;
                dgvData.Columns[1].Width = 100;
                dgvData.Columns[2].Width = 100;
                dgvData.Columns[3].Width = 100;
                dgvData.Columns[4].Width = 100;
                dgvData.Columns[0].HeaderText = "Mã sách";
                dgvData.Columns[1].HeaderText = "Tên sách";
                dgvData.Columns[2].HeaderText = "Số trang";
                dgvData.Columns[3].HeaderText = "Tên TG";
                dgvData.Columns[4].HeaderText = "Địa chỉ TG";
                dgvData.ReadOnly = true;
            }
        }

        private void btnGetAllData_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnDeleteform_Click(object sender, EventArgs e)
        {
            txtmasach.Text = "";
            txttensach.Text = "";
            txtsotrang.Text = "";
            txttentacgia.Text = "";
            txtdiachitacgia.Text = "";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtmasach.Text;
            DialogResult d = MessageBox.Show($"Bạn chắc chắn muốn xóa sách có mã là {id} không !", "Thông báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                if (data.deleteSach(id))
                {
                    MessageBox.Show($"Xóa sách thành công", "Thông báo");
                    DisplayData();
                }
                else
                {
                    MessageBox.Show($"Xóa sách không thành công do không có sách trùng mã cần xóa", "Thông báo");
                }
            }
        }
    }
}
