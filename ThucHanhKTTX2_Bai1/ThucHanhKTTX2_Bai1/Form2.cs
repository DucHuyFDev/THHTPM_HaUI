using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThucHanhKTTX2_Bai1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        DataUtil data = new DataUtil();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<sanpham> sp = data.getAllData();
            comboBox1.DataSource = sp.Select(x => x.loai).Distinct().ToList();
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            string loai = comboBox1.Text;
            List<sanpham> find = data.findWithType(loai);
            dgvdata2.DataSource = find;
            dgvdata2.ReadOnly = true;
            if (find.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm nào có đơn giá > 500000", "Thông báo !");
            }
            else
            {
                MessageBox.Show($"Có {find.Count} sản phẩm thuộc loại {loai}", "Thông báo !");
                dgvdata2.Columns[0].Width = 50;
                dgvdata2.Columns[1].Width = 150;
                dgvdata2.Columns[2].Width = 100;
                dgvdata2.Columns[3].Width = 100;
                dgvdata2.Columns[4].Width = 100;

            }
        }
    }
}
