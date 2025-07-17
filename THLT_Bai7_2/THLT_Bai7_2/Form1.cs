using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THLT_Bai7_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            DisplayData();
        }

        private void DisplayData()
        {
            dataGridView1.DataSource = data.GetAllSV();
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            lblSumSV.Text = dataGridView1.Rows.Count + " ";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SinhVien s = new SinhVien();
            s.id = txtId.Text;
            s.name= txtName.Text;
            s.age = txtAge.Text;
            s.city = txtCity.Text;
            if (data.AddSV(s))
            {
                MessageBox.Show("Đã thêm sinh viên thành công !");
            }
            else
            {
                MessageBox.Show("Có sinh viên trùng mã bạn đã nhập!");
            }
                ClearTextBox();
            DisplayData();
        }

        private void ClearTextBox()
        {
            txtId.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtCity.Clear();
            ActiveControl = txtId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SinhVien s = new SinhVien();
            s.id = txtId.Text;
            s.name = txtName.Text;
            s.age = txtAge.Text;
            s.city = txtCity.Text;
            bool kt = data.UpdateStudent_check(s);
            if (!kt)
            {
                MessageBox.Show("Không tìm thấy sinh viên !");
                return;
            }
            DisplayData();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GetAStudent(object sender, DataGridViewCellEventArgs e)
        {
            SinhVien s = (SinhVien)dataGridView1.CurrentRow.DataBoundItem;
            txtId.Text = s.id;
            txtName.Text = s.name;
            txtAge.Text = s.age;
            txtCity.Text = s.city;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show($"Bạn có chắc muốn xóa sinh viên có mã là {txtId.Text} không ?", "Thông báo",
                MessageBoxButtons.YesNo);
            if ( d == DialogResult.Yes)
            {
                bool kt = data.deleteSinhVien(txtId.Text);
                if (!kt)
                {
                    MessageBox.Show("Không xóa được !");
                }
                else
                {
                    MessageBox.Show("Đã xóa thành công !");
                    DisplayData();
                }
            }
        }

        private void btnFindByID_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            List<SinhVien> lst = new List<SinhVien>();
            SinhVien s = data.findbySVID(id);
            if (s != null)
            {
                lst.Add(s);
                dataGridView1.DataSource = lst;
                lblSumSV.Text = lst.Count + "";
                txtId.Text = s.id;
                txtName.Text = s.name;
                txtAge.Text = s.age;
                txtCity.Text = s.city;
            }
        }
    }
}
