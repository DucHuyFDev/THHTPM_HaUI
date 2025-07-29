using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeDucHuy_2022600377_De1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataUtil data = new DataUtil();
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ClearForm()
        {
            txtmasv.Text = "";
            txtdiemlan1.Text = "";
            txtdiemlan2.Text = "";
        }

        private void DisplayData()
        {
            List<SinhVien> data_sv = data.getAllData();
            dgvData.DataSource = data_sv;
            if (dgvData.Columns["STT"] == null)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = "STT";
                column.HeaderText = "STT";
                dgvData.Columns.Insert(0, column);
            }
            for (int i = 0; i < data_sv.Count; i++)
            {
                dgvData.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
            dgvData.Columns[0].Width = 50;
            dgvData.Columns[1].Width = 100;
            dgvData.Columns[2].Width = 150;
            dgvData.Columns[3].Width = 100;
            dgvData.Columns[4].Width = 100;
            dgvData.Columns[0].HeaderText = "STT";
            dgvData.Columns[1].HeaderText = "Mã SV";
            dgvData.Columns[2].HeaderText = "Môn";
            dgvData.Columns[3].HeaderText = "Điểm 1";
            dgvData.Columns[4].HeaderText = "Điểm 2";
            dgvData.ReadOnly = true;
            cbxMonHoc.DataSource = new List<string>{ "Lập trình Java", "Phân tích dũ liệu", "Lập trình .NET", "Lập trình game" };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien add = new SinhVien();
                add.masv = txtmasv.Text;
                add.diemlan1 = double.Parse(txtdiemlan1.Text);
                add.diemlan2 = double.Parse(txtdiemlan2.Text);
                add.monhoc = cbxMonHoc.Text;
                if (data.addSV(add) && add.masv != "")
                {
                    MessageBox.Show("Thêm thành công !", "Thông báo");
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Không thêm được do có sinh viên trùng mã hoặc mã để trống !", "Thông báo");
                }
                ClearForm();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Thông báo");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien add = new SinhVien();
                add.masv = txtmasv.Text;
                add.diemlan1 = double.Parse(txtdiemlan1.Text);
                add.diemlan2 = double.Parse(txtdiemlan2.Text);
                add.monhoc = cbxMonHoc.Text;
                if (data.updateSV(add) && add.masv != "")
                {
                    MessageBox.Show("Cập nhật thành công !", "Thông báo");
                    DisplayData();
                }
                else
                {
                    MessageBox.Show("Không cập nhật được do không có sinh viên trùng mã hoặc mã để trống !", "Thông báo");
                }
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Thông báo");
            }
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            SinhVien choose = (SinhVien)dgvData.CurrentRow.DataBoundItem;
            txtmasv.Text = choose.masv;
            cbxMonHoc.Text = choose.monhoc;
            txtdiemlan1.Text = choose.diemlan1.ToString();
            txtdiemlan2.Text = choose.diemlan2.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtmasv.Text;
            if (id == "")
            {
                MessageBox.Show("Mã sinh viên không được để trống khi dùng chức năng này", "Thông báo");
            }
            else
            {
                DialogResult d = MessageBox.Show($"Bạn chắc chắn muốn xóa sinh viên có mã là {id} không ?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    if (data.deleteSV(id) && id != "")
                    {
                        MessageBox.Show("Xóa thành công", "Thông báo");
                        DisplayData();
                    }
                    else
                    {
                        MessageBox.Show("Không xóa được do không tim được sinh viên");
                    }
                }
                ClearForm();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
