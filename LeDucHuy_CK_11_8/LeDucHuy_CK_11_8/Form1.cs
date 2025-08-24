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

namespace LeDucHuy_CK_11_8
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://192.168.51.101/apinhanvien/api/nhanvien/");
        }
        private async Task getAllData()
        {
            HttpResponseMessage response = await client.GetAsync("getall");
            string json = await response.Content.ReadAsStringAsync();
            List<NhanVien> data = JsonConvert.DeserializeObject<List<NhanVien>>(json);
            dgvData.DataSource = data;

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await getAllData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtmanv.Text;
            HttpResponseMessage response = await client.DeleteAsync($"delete/{id}");
            MessageBox.Show(await response.Content.ReadAsStringAsync());
            await getAllData();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            NhanVien nv_new = new NhanVien
            {
                manv = txtmanv.Text,
                tennv = txttennv.Text,
                trinhdo = txttrinhdo.Text,
                luong = decimal.Parse(txtluong.Text)
            };
            var json = JsonConvert.SerializeObject(nv_new, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("post", content);
            MessageBox.Show(await response.Content.ReadAsStringAsync());
            await getAllData();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
             Close();
        }

        private async void btnGetData_Click(object sender, EventArgs e)
        {
            await getAllData();
        }
    }
}
