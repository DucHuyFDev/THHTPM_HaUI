using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTTX2_24_7
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
            List<SinhVien> data_sv = data.getAllSinhVien();
            dgvdata.DataSource = null;
            dgvdata.DataSource = data_sv;
            // Thêm cột só thứ tự
            if (dgvdata.Columns["STT"] ==  null)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = "STT";
                column.HeaderText = "STT";
                dgvdata.Columns.Insert(0, column); // insert vào cột đầu tiên
            }
            for (int i = 0; i < data_sv.Count; i++) // dùng vòng lặp đánh số tự động
            {
                dgvdata.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
            dgvdata.Columns[0].Width = 50;
            dgvdata.Columns[1].Width = 150;
            dgvdata.Columns[2].Width = 100;
            dgvdata.Columns[3].Width = 100;
            dgvdata.Columns[4].Width = 100;
            dgvdata.Columns[0].HeaderText = "STT";
            dgvdata.Columns[1].HeaderText = "Mã sinh viên";
            dgvdata.Columns[2].HeaderText = "Môn học";
            dgvdata.Columns[3].HeaderText = "Điểm lần 1";
            dgvdata.Columns[4].HeaderText = "Điểm lần 2";
            cbxmonhoc.DataSource = new List<string> { "Lập trình Windows", "Lập trình Java", "Lập trình Python", "Lập trình PHP" };
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien add_sv = new SinhVien();
                add_sv.masv = txtmasv.Text;
                add_sv.diemlan1 = double.Parse(txtdiem1.Text);
                add_sv.diemlan2 = double.Parse(txtdiem2.Text);
                add_sv.monhoc = cbxmonhoc.Text;
                if (data.addSV(add_sv))
                {
                    MessageBox.Show("Thêm thành công !", "Thông báo !");
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Không thêm được do đã có sinh viên trùng mã !", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi nhập dữ liệu ! {ex.Message} !", "Lỗi !");
            }
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            SinhVien sv_choose = (SinhVien)dgvdata.CurrentRow.DataBoundItem;
            if (sv_choose != null)
            {
                txtmasv.Text = sv_choose.masv;
                cbxmonhoc.Text = sv_choose.monhoc.ToString();
                txtdiem1.Text = sv_choose.diemlan1.ToString();
                txtdiem2.Text = sv_choose.diemlan2.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien update_sv = new SinhVien();
                update_sv.masv = txtmasv.Text;
                update_sv.diemlan1 = double.Parse(txtdiem1.Text);
                update_sv.diemlan2 = double.Parse(txtdiem2.Text);
                update_sv.monhoc = cbxmonhoc.Text;
                if (data.UpdateSV(update_sv))
                {
                    MessageBox.Show("Sửa thành công !", "Thông báo !");
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Không sửa được do không có sinh viên trùng mã !", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra khi nhạp dữ liệu ! {ex.Message} !", "Lỗi !");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string masv = txtmasv.Text;
            DialogResult d = MessageBox.Show($"Bạn muốn xóa sinh viên có mã là {masv} ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                if (data.DeleteSV(masv))
                {
                    MessageBox.Show("Đã xóa thành công !", "Thông báo !");
                    DisplayData();
                }
                else
                {
                    MessageBox.Show($"Không có sinh viên có mã là {masv} !", "Thông báo !");
                }
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
