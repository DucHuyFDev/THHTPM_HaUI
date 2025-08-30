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

namespace Interface
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("http://192.168.51.100/apitesttime/api/");
        }

        private async Task getAllData()
        {
            HttpResponseMessage response =await client.GetAsync("thoigian");
            string json = await response.Content.ReadAsStringAsync();
            List<ThoiGian> data = JsonConvert.DeserializeObject<List<ThoiGian>>(json);
            dgvTime.DataSource = data;
            dgvTime.Columns["Time"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await getAllData();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DateTime new_time = DateTime.Parse(dtptime.Text);
            string content = new_time.ToString("yyyy-MM-ddTHH:mm:ss");
            HttpResponseMessage response = await client.PostAsync($"post?new_time={content}", null);
            MessageBox.Show(await response.Content.ReadAsStringAsync());
            await getAllData();
            

        }
    }
}
