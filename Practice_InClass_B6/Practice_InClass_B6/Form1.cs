using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_InClass_B6
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
            List<thongtincuocgoi> lst = data.GetAllCall().ToList();
            dgvData.DataSource = lst;
            cbxChiNhanh.DataSource = new List<string> { "Đống Đa", "Hoàn Kiếm", "Thanh Xuân"};
            cbxSoGoiDi.DataSource = new List<string> {"19001590", "19001886", "19001789"};
            dgvData.ReadOnly = true;
            dgvData.Columns[0].Width = 100;
            dgvData.Columns[1].Width = 100;
            dgvData.Columns[2].Width = 100;
            dgvData.Columns[3].Width = 100;
            dgvData.Columns[4].Width = 100;
            dgvData.Columns[0].HeaderText = "Chi nhánh";
            dgvData.Columns[1].HeaderText = "Số gọi đi";
            dgvData.Columns[2].HeaderText = "Số gọi đến";
            dgvData.Columns[3].HeaderText = "Ngày gọi";
            dgvData.Columns[4].HeaderText = "Số phút";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            thongtincuocgoi add_call = new thongtincuocgoi();
            add_call.chinhanh = cbxChiNhanh.Text;
            add_call.sogoidi = cbxSoGoiDi.Text;
            add_call.sogoiden = txtSoGoiDen.Text;
            add_call.ngaygoi = txtNgayGoi.Text;
            add_call.sophut = txtsoPhut.Text;
            data.AddCall(add_call);
            MessageBox.Show("Đã thêm cuộc gọi thành công !", "Thông báo");
            DisplayData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            thongtincuocgoi choose_call = (thongtincuocgoi)dgvData.CurrentRow.DataBoundItem;
            cbxChiNhanh.Text = choose_call.chinhanh;
            cbxSoGoiDi.Text = choose_call.sogoidi;
            txtSoGoiDen.Text = choose_call.sogoiden ;
            txtNgayGoi.Text = choose_call.ngaygoi;
            txtsoPhut.Text = choose_call.sophut;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string sogoiden = txtSoGoiDen.Text;
            if (data.deleteCall(sogoiden))
            {
                MessageBox.Show($"Đã xóa các cuộc gọi có số gọi đến là {sogoiden} !", "Thông báo");
                DisplayData();
            }
            else
            {
                MessageBox.Show($"Không xóa được do không tồn tại mã hoặc hủy quá trình!", "Thông báo");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            thongtincuocgoi update_call = new thongtincuocgoi();
            update_call.chinhanh = cbxChiNhanh.Text;
            update_call.sogoidi = cbxSoGoiDi.Text;
            update_call.sogoiden = txtSoGoiDen.Text;
            update_call.ngaygoi = txtNgayGoi.Text;
            update_call.sophut = txtsoPhut.Text;
            
            if (data.updateCall(update_call))
            {
                MessageBox.Show("Đã sửa cuộc gọi thành công !", "Thông báo");
                DisplayData();
            }
            else
            {
                MessageBox.Show($"Không sửa được do không tìm được cuộc gọi nào có số gọi đến là {update_call.sogoiden}");
            }
            
            
        }
    }
}
