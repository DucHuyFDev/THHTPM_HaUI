using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace LeDucHuy_2022600377_call
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://192.168.51.102/apisinhvien/api/");
        }

        public async Task getalldata()
        {
            HttpResponseMessage response = await client.GetAsync("getall");
            string json = await response.Content.ReadAsStringAsync();
            Console.WriteLine(json);
            List<SinhVien> data = JsonConvert.DeserializeObject<List<SinhVien>>(json);
            dgvData.DataSource = data;
            List<string> lop_list = data.Select(x => x.lop).Distinct().ToList();
            cbxlop.DataSource = lop_list;
            List<int> ngay = new List<int>();
            List<int> thang = new List<int>();
            List<int> nam = new List<int>();
            for (int i = 1; i <= 12; i++)
            {
                ngay.Add(i);
                thang.Add(i);
            }
            for (int i = 13; i <= 31; i++)
            {
                ngay.Add(i);
            }
            for (int i = 2006; i >= 1990; i--)
            {
                nam.Add(i);
            }
            cbxday.DataSource = ngay;
            cbxmonth.DataSource = thang;
            cbxyear.DataSource = nam;
            dgvData.ReadOnly = true;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await getalldata();
        }

        private async void btngetall_Click(object sender, EventArgs e)
        {
            await getalldata();
        }

        private async void btngetbyclass_Click(object sender, EventArgs e)
        {
            string find_class = cbxlop.Text;
            HttpResponseMessage response = await client.GetAsync($"getbyclass/{find_class}");
            string json = await response.Content.ReadAsStringAsync();
            List<SinhVien> data = JsonConvert.DeserializeObject<List<SinhVien>>(json);
            MessageBox.Show($"Tìm được {data.Count} sinh viên học tại lớp {find_class}");
            dgvData.DataSource = data;

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            int dob = int.Parse(cbxday.Text);
            int mob = int.Parse(cbxmonth.Text);
            int yob = int.Parse(cbxyear.Text);
            SinhVien new_sv = new SinhVien
            {
                masv = txtmasv.Text,
                hoten = txttensv.Text,
                lop = cbxlop.Text,
                diemtb = float.Parse(txtdiem.Text),
                ngaysinh = new DateTime(yob, mob, dob)
            };
            string json = JsonConvert.SerializeObject(new_sv);
            var string_send = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage request = await client.PostAsync("post", string_send);
            MessageBox.Show(await request.Content.ReadAsStringAsync());
            await getalldata();
            deleteform();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            int dob = int.Parse(cbxday.Text);
            int mob = int.Parse(cbxmonth.Text);
            int yob = int.Parse(cbxyear.Text);
            SinhVien new_sv = new SinhVien
            {
                masv = txtmasv.Text,
                hoten = txttensv.Text,
                lop = cbxlop.Text,
                diemtb = float.Parse(txtdiem.Text),
                ngaysinh = new DateTime(yob, mob, dob)
            };
            string json = JsonConvert.SerializeObject(new_sv);
            var string_send = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage request = await client.PutAsync("put", string_send);
            MessageBox.Show(await request.Content.ReadAsStringAsync());
            await getalldata();
            deleteform();
        }

        private void CeilClick(object sender, DataGridViewCellEventArgs e)
        {
            SinhVien choose = (SinhVien)dgvData.CurrentRow.DataBoundItem;
            txtmasv.Text = choose.masv;
            txttensv.Text = choose.hoten;
            cbxlop.Text = choose.lop;
            cbxday.Text = choose.ngaysinh.Day.ToString();
            cbxmonth.Text = choose.ngaysinh.Month.ToString();
            cbxyear.Text = choose.ngaysinh.Year.ToString();
            txtdiem.Text = choose.diemtb.ToString();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            
            string id_choose = txtmasv.Text;
            DialogResult d = MessageBox.Show($"Bạn có chắc chắn muốn xóa sinh viên có mã là {id_choose} không ?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                HttpResponseMessage request = await client.DeleteAsync($"delete/{id_choose}");
                MessageBox.Show(await request.Content.ReadAsStringAsync());
                await getalldata();
                deleteform();
            }
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void deleteform()
        {
            txtmasv.Text = "";
            txttensv.Text = "";

            txtdiem.Text = "";
        }

        private void btndeleteform_Click(object sender, EventArgs e)
        {
            deleteform();
        }
    }
}
