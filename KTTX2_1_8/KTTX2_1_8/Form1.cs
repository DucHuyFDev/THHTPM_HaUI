using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace KTTX2_1_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataUtil data = new DataUtil();

        private void DisplayData(List<SinhVien> data_src)
        {
            dgvdata.DataSource = data_src;
            if (dgvdata.Columns["STT"] == null)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = "STT";
                column.HeaderText = "STT";
                dgvdata.Columns.Insert(0, column);
            }
            for (int i = 0; i < dgvdata.Rows.Count; i++)
            {
                dgvdata.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                
            }
            List<string> heading = new List<string> { "Mã SV", "Họ tên", "Địa chỉ", "Tuổi", "Môn học", "Điểm" };
            for (int i = 0; i < dgvdata.Columns.Count; i++)
            {
                if (i != 0)
                {
                    dgvdata.Columns[i].HeaderText = heading[i - 1];
                }
                dgvdata.Columns[i].Width = 80;
            }
            dgvdata.ReadOnly = true;
        }

        private void ClearForm()
        {
            txtmasv.Text = "";
            txttensv.Text = "";
            txtdiachi.Text = "";
            txttuoi.Text = "";
            txtmonhoc.Text = "";
            txtdiem.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            DisplayData(data.getAllData());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien new_sv = new SinhVien();
                new_sv.MaSV = txtmasv.Text;
                new_sv.HoTen = txttensv.Text;
                new_sv.DiaChi = txtdiachi.Text;
                new_sv.Tuoi = int.Parse(txttuoi.Text);
                new_sv.TenMonHoc = txtmonhoc.Text;
                new_sv.Diem = double.Parse(txtdiem.Text);
                if (data.addSV(new_sv))
                {
                    MessageBox.Show("Đã thêm thành công !", "Thông báo");
                    DisplayData(data.getAllData());
                }
                else
                {
                    MessageBox.Show("Không thêm được do đã có SV trùng mã !", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Thông báo");
            }
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SinhVien new_sv = new SinhVien();
                new_sv.MaSV = txtmasv.Text;
                new_sv.HoTen = txttensv.Text;
                new_sv.DiaChi = txtdiachi.Text;
                new_sv.Tuoi = int.Parse(txttuoi.Text);
                new_sv.TenMonHoc = txtmonhoc.Text;
                new_sv.Diem = double.Parse(txtdiem.Text);
                if (data.updateSV(new_sv))
                {
                    MessageBox.Show("Đã cập nhật thành công !", "Thông báo");
                    DisplayData(data.getAllData());
                }
                else
                {
                    MessageBox.Show("Không cập nhật được do không có SV trùng mã !", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Thông báo");
            }
            ClearForm();
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            SinhVien choose = (SinhVien)dgvdata.CurrentRow.DataBoundItem;
            txtmasv.Text = choose.MaSV;
            txttensv.Text = choose.HoTen;
            txtdiachi.Text = choose.DiaChi;
            txttuoi.Text = choose.Tuoi.ToString();
            txtmonhoc.Text = choose.TenMonHoc;
            txtdiem.Text = choose.Diem.ToString();
        }

        private void btnClearform_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtmasv.Text;
                if (id == "")
                {
                    MessageBox.Show("Trường id không được để trống ! Xóa thất bại", "Thông báo");
                }
                else
                {
                    DialogResult d = MessageBox.Show($"Bạn có muốn xóa sinh viên có mã là {id} không ?", "Xác nhận", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (d == DialogResult.Yes)
                    {
                        if (data.deleteSV(id))
                        {
                            MessageBox.Show("Đã xóa thành công !", "Thông báo");
                            DisplayData(data.getAllData());
                        }
                        else
                        {
                            MessageBox.Show("Không xóa được do không có SV trùng mã !", "Thông báo");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Thông báo");
            }
            ClearForm();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            double from = double.Parse(txtFrom.Text);
            double to = double.Parse(txtTo.Text);
            List<SinhVien> find = data.findSVbyMark(from, to);
            if (find.Count == 0)
            {
                MessageBox.Show($"Không tìm thấy sinh viên có điểm trong khoảng {from} đến {to} !", "Thông báo");
            }
            else
            {
                MessageBox.Show($"Có {find.Count} sinh viên có điểm trong khoảng {from} đến {to} !", "Thông báo");
                dgvdata.DataSource = find;
                DisplayData(find);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayData(data.getAllData());
        }
    }
}
