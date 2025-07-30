using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace KTTX2_29_7
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int from = int.Parse(txtFrom.Text);
            int to = int.Parse(txtTo.Text);
            List<Sach> find = data.searchSach(from, to);
            if (find.Count > 0)
            {
                MessageBox.Show($"Có {find.Count} sách có từ {from} đến {to} trang !", "Kết quả !");
                dgvData2.DataSource = find;
                dgvData2.Columns[0].Width = 50;
                dgvData2.Columns[1].Width = 150;
                dgvData2.Columns[2].Width = 80;
                dgvData2.Columns[3].Width = 150;
                dgvData2.Columns[4].Width = 150;
                dgvData2.Columns[0].HeaderText = "Mã sách";
                dgvData2.Columns[1].HeaderText = "Tên sách";
                dgvData2.Columns[2].HeaderText = "Số trang";
                dgvData2.Columns[3].HeaderText = "Tên tác giả";
                dgvData2.Columns[4].HeaderText = "Địa chỉ tác giả";
                dgvData2.ReadOnly = true;
            }
            
            else
            {
                MessageBox.Show($"Không có sách nào có từ {from} đến {to} trang !", "Kết quả !");
                dgvData2.DataSource = null;
            }
            


        }
    }
}
