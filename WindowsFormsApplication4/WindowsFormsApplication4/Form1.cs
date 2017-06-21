using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adres = "http://meb.gov.tr";
            WebRequest istek = HttpWebRequest.Create(adres);
            WebResponse cevap;
            cevap = istek.GetResponse();
            StreamReader donenBilgiler = new StreamReader(cevap.GetResponseStream());
            string gelen = donenBilgiler.ReadToEnd();
            int baslikBaslangic = gelen.IndexOf("<title>") + 7;
            int baslikbitis = gelen.Substring(baslikBaslangic).IndexOf("</title>");

            string baslik = gelen.Substring(baslikBaslangic, baslikbitis);
            MessageBox.Show(baslik);
        
        }
    }
}
