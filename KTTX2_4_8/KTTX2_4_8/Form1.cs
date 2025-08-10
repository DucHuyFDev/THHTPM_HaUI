using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTTX2_4_8
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
            List<SinhVien> lst_data = data.getAllData();
            dgvData.DataSource = lst_data;
            if (dgvData.Columns["STT"] == null)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = "STT";
                column.Name = "STT";
                dgvData.Columns.Insert(0, column);
            }
            for (int i = 0; i < lst_data.Count; i++)
            {
                dgvData.Rows[i].Cells["STT"].Value = i + 1;
            }
            dgvData.Columns[1].HeaderText = "Họ tên SV";
            dgvData.Columns[2].HeaderText = "Môn";
            dgvData.Columns[3].HeaderText = "Điểm lần 1";
            dgvData.Columns[4].HeaderText = "Điểm lần 2";
            cbxmonhoc.DataSource = new List<string> { "Lập trình Windows", "Lập trình Java", "Lập trình Python", "Lập trình PHP" };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien add = new SinhVien();
                add.masv = txtmasv.Text;
                add.monhoc = cbxmonhoc.Text;
                add.diemlan1 = double.Parse(txtdiemlan1.Text);
                add.diemlan2 = double.Parse(txtdiemlan2.Text);
                if (data.addSV(add))
                {
                    MessageBox.Show("Thêm thành công !");
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Bị trùng mã SV hoặc mã SV để trống, không thêm được !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            SinhVien sv_choose = (SinhVien)dgvData.CurrentRow.DataBoundItem;
            txtmasv.Text = sv_choose.masv;
            txtdiemlan1.Text = sv_choose.diemlan1.ToString();
            txtdiemlan2.Text = sv_choose.diemlan2.ToString();
            cbxmonhoc.Text = sv_choose.monhoc;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien update = new SinhVien();
                update.masv = txtmasv.Text;
                update.monhoc = cbxmonhoc.Text;
                update.diemlan1 = double.Parse(txtdiemlan1.Text);
                update.diemlan2 = double.Parse(txtdiemlan2.Text);
                if (data.updateSV(update))
                {
                    MessageBox.Show("Cập nhật thành công !");
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Không SV nào trùng mã hoặc mã SV để trống, không cập nhật được !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = txtmasv.Text;
            DialogResult d = MessageBox.Show($"Bạn muốn xóa sinh viên có mã là {id} không ?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                if (data.deleteSV(id))
                {
                    MessageBox.Show("Xóa thành công !");
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Không SV nào trùng mã hoặc mã SV để trống, không xóa được !");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
