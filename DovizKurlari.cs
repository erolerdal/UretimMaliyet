using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace MaliyetProgram
{
    public partial class DovizKurlari : Form
    {

          SqlConnection Baglan = new SqlConnection(@"Data Source=SQLSERVER;Initial Catalog=MALIYET;User ID=Sa;Password=Sa2010");
        public DovizKurlari()
        {
            InitializeComponent();
        }

        private void dovizBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dovizBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mALIYETDataSet3);

        }

        private void DovizKurlari_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mALIYETDataSet3.Doviz' table. You can move, or remove it, as needed.
            this.dovizTableAdapter.Fill(this.mALIYETDataSet3.Doviz);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string today = "http://www.tcmb.gov.tr/kurlar/today.xml";
                var xmlDoc = new XmlDocument();
                xmlDoc.Load(today);
                // Xml içinden tarihi alma - gerekli olabilir
                DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
                string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/ForexSelling").InnerXml;
                string EURO = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/ForexSelling").InnerXml;
                textBox1.Text = " MERKEZ BANKASI DOVİZ KURLARI " + exchangeDate.ToShortDateString();
                textBox2.Text = string.Format("{0}    USD   ", USD);
                textBox3.Text = string.Format("{0}     EURO ", EURO);
                if (Baglan.State == ConnectionState.Closed) Baglan.Open();
                string sorgu = " UPDATE [MALIYET].[dbo].[Doviz] SET  [DovizKuru] =  '" + USD + "' WHERE DovizTipi='USD'";
                SqlCommand komut = new SqlCommand(sorgu, Baglan);
                SqlDataReader oku = komut.ExecuteReader();
                Baglan.Close();
                euroyaz(EURO);
                this.Validate();
                this.dovizBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.mALIYETDataSet3);
                this.dovizTableAdapter.Fill(this.mALIYETDataSet3.Doviz);
            }
            catch
            {

                MessageBox.Show("Internet Kapali Olabilir Kontrol Ediniz ");
            }
        }
        private void euroyaz(string euro)
        {
            if (Baglan.State == ConnectionState.Closed) Baglan.Open();
            string sorgu = " UPDATE [MALIYET].[dbo].[Doviz] SET  [DovizKuru] = '" + euro + "' WHERE DovizTipi='EURO'";
            SqlCommand komut = new SqlCommand(sorgu, Baglan);
            SqlDataReader oku = komut.ExecuteReader();
            Baglan.Close();
            //   UPDATE [MALIYET].[dbo].[Doviz] SET  [DovizKuru] =  '2' WHERE DovizTipi='USD'
            //   UPDATE [MALIYET].[dbo].[Doviz] SET  [DovizKuru] =  '2' WHERE DovizTipi='EURO'
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
    
        }
    }
}
