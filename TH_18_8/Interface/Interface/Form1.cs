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
            client.BaseAddress = new Uri("http://192.168.51.100/apiqlsv/api/");
        }
        
        private async void Form1_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = await client.GetAsync("getall");
            string js = await response.Content.ReadAsStringAsync();
            List<SanPham> data = JsonConvert.DeserializeObject<List<SanPham>>(js);
            dgvData.DataSource = data;
        }
    }
}
