using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
namespace MaliyetProgram
{
    public partial class StokKart : Form
    {
        string KmalzemeAdiTextBox = "";
        string KmalzemeCinsiTextBox = "";
        string KmalzemeUreticiFirmaTextBox = "";
        string KmalzemeOrjinalKoduTextBox = "";
        string KmalzemeBarkoduTextBox = "";
        string KmalzemeResmiTextBox = "";
        string KmalzemeCarpan2TextBox = "";
        string KmalzemeCarpan3TextBox = "";
        string KmalzemeBolen2TextBox = "";
        string KmalzemeBolen3TextBox = "";
        string KmalzemeEniTextBox = "";
        string KmalzemeBoyuTextBox = "";
        string KmalzemeYuksekligiTextBox = "";
        string KmalzemeÇapı1TextBox = "";
        string KmalzemeÇapı2TextBox = "";
        string KmalzemeAlinFirmaTextBox = "";
        string KmalzemeAlimFiyatTextBox = "";
        string KmalzemeDovizTutariTextBox = "";
        string KmalzemeAlimTarihiDateTimePicker = "";
        string KmalzemeOzelKod1TextBox = "";
        string KmalzemeOzelKod2TextBox = "";
        string KmalzemeOzelKod3TextBox = "";
        string KmalzemeOzelKod4TextBox = "";
        string KmalzemeOzelKod5TextBox = "";
        string KmalzemeAnaGrupComboBox1 = "";
        string KmalzemeOlcuBrimi3ComboBox = "";
        string KmalzemeOlcuBrimi2ComboBox = "";
        string KmalzemeOlcuBrimi1ComboBox = "";
        string KaltRenkTextBox = "";
        string KanaRenkTextBox = "";
        SqlConnection Baglan = new SqlConnection(@"Data Source=SQLSERVER;Initial Catalog=MALIYET;User ID=Sa;Password=Sa2010");
        public StokKart()
        {
            InitializeComponent();
        }
        public static string baglantiismi = "";
        public static string MLZid;
        public static string kodu;
        public static string adi;
        public static string birimfiyati;
        public static string DovizFiyati;
        public static string Olcu1;
        public static string Olcu2;
        public static string Olcu3;
        public static string Carpan2;
        public static string Carpan3;
        public static string Bolen2;
        public static string Bolen3;
        public static string DovizTipi;
        public static string SMalzemeResmi;
        private void stokKartBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(malzemeCarpan2TextBox.Text) == true) { malzemeCarpan2TextBox.Text = "0"; }
            if (string.IsNullOrEmpty(malzemeCarpan3TextBox.Text) == true) { malzemeCarpan3TextBox.Text = "0"; }
            if (string.IsNullOrEmpty(malzemeBolen2TextBox.Text) == true) { malzemeBolen2TextBox.Text = "0"; }
            if (string.IsNullOrEmpty(malzemeBolen3TextBox.Text) == true) { malzemeBolen3TextBox.Text = "0"; }

            if (string.IsNullOrEmpty(malzemeEniTextBox.Text) == true) { malzemeEniTextBox.Text = "0"; }
            if (string.IsNullOrEmpty(malzemeBoyuTextBox.Text) == true) { malzemeBoyuTextBox.Text = "0"; }
            if (string.IsNullOrEmpty(malzemeYuksekligiTextBox.Text) == true) { malzemeYuksekligiTextBox.Text = "0"; }
            if (string.IsNullOrEmpty(malzemeÇapı1TextBox.Text) == true) { malzemeÇapı1TextBox.Text = "0"; }
            if (string.IsNullOrEmpty(malzemeÇapı2TextBox.Text) == true) { malzemeÇapı2TextBox.Text = "0"; }
            if (string.IsNullOrEmpty(malzemeDovizTutariTextBox.Text) == true) { malzemeDovizTutariTextBox.Text = "0"; }
            if (string.IsNullOrEmpty(malzemeAlimFiyatTextBox.Text) == true) { malzemeAlimFiyatTextBox.Text = "0"; }

            DialogResult dr;
            dr = MessageBox.Show("Eminmisiniz ?\nKayıt İşlemi Gerçekleşiyor", "Kayıt İşlemi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    this.Validate();
                    this.stokKartBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.mALIYETDataSet);
                }
                catch
                {
                    MessageBox.Show("Lutfen Kayit Alanlarini Bos Birakmayin");
                }
            }
            else
            {
                {
                    this.stokKartTableAdapter.Fill(this.mALIYETDataSet.StokKart);
                    pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    MessageBox.Show("Kayit İşlemi İptal Edilmiştir");
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mALIYETDataSet3.Doviz' table. You can move, or remove it, as needed.
            this.dovizTableAdapter.Fill(this.mALIYETDataSet3.Doviz);
            // TODO: This line of code loads data into the 'mALIYETDataSet3.Doviz' table. You can move, or remove it, as needed.
            pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
            //pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            // TODO: This line of code loads data into the 'mALIYETDataSet.StokKart' table. You can move, or remove it, as needed.
            this.stokKartTableAdapter.Fill(this.mALIYETDataSet.StokKart);
            //   BURASI COMBOBOX İÇİNE SQL DEN VERİ OKUR....   ------------------------------------------------------
            // using System.Data.SqlClient;   yerine konacak...
            // SqlConnection Baglan = new SqlConnection(@"Data Source=SQLSERVER;Initial Catalog=MALIYET;User ID=Sa;Password=Sa2010");   public formun içine initialin üstüne....

            try
            {
                if (Baglan.State == ConnectionState.Closed) Baglan.Open();
                string sorgu = "select DovizTipi,DovizKuru From Doviz";
                SqlCommand komut = new SqlCommand(sorgu, Baglan);
                SqlDataReader oku = komut.ExecuteReader();
                malzemeDovizCinsiComboBox.Items.Clear();

                while (oku.Read())
                {
                    // malzemeDovizCinsiComboBox.Items.Add(oku.GetString(0) + " " + oku.GetString(1));
                    malzemeDovizCinsiComboBox.Items.Add(oku.GetString(0));
                }
                //İşlemimiz bittikten sonra ise her zaman baglantımızı kapatıyoruz...
                Baglan.Close();
                // DAHA SONRA COMBOBOX PROPERY KEY PESSS EVENTINE  BASKA VARI GIRILMESIN DIYORSAN
                //    e.Handled = true;     KOYACAKSIN...
                //  BURAYA KADAR         ----------------------------------------------------------------------------------
                dolaryaz();
                this.dovizTableAdapter.Fill(this.mALIYETDataSet3.Doviz);
            }
            catch
            {
                MessageBox.Show("Internet Kapalı Olabilir.. Doviz Kurları Alınamıyor ");
            }
            string  SQLCUMLE = "";
            SQLCUMLE = SQLCUMLE + "SELECT  LogoBaglaID,MalzemeId ,LogoLogicalref,Brim1,Brim2 ,Brim3 FROM MALIYET.dbo.LogoItemsBagla";
            SQLCUMLE = SQLCUMLE + " WHERE MalzemeId = '" + malzemeIdTextBox.Text + "'";
            SbulgriddoldurLOGOITEMS(SQLCUMLE);
        }
        private void SbulgriddoldurLOGOITEMS(string sqlCumle)
        {
           string ConStr = "Data Source=SQLSERVER;Initial Catalog=MALIYET;User ID=Sa;Password=Sa2010";
          //   string ConStr = "Data Source=BAHARSRV;Initial Catalog=LOGODB;User ID=bahar;Password=!123456789Aa!";
            // string ConStr = "Data Source="+VeriTabani.SunucuServer  +";Initial Catalog="+VeriTabani.VeriTabani +";User ID=Sa;Password=Sa2010";
            SqlConnection conn = new SqlConnection(ConStr);
            string sql = sqlCumle; // sql cümlemiz fonksiyonumuzdan değişken bir biçimde geliyor. 
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  openFileDialog1.Filter = " (*.jpg)|*.jpg|(*.png)|*.png|(*.dwg)|*.dwg|(*.doc)|*.doc|(*.xls)|*.xls|(*.docx)|*.docx|(*.xlsx)|*.xlsx|(*.pdf)|*.pdf";
            openFileDialog1.Reset();
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName.ToString() != "")
            {
                malzemeResmiTextBox.Text = openFileDialog1.FileName.ToString();
                MessageBox.Show(malzemeResmiTextBox.Text);

                string name = Path.GetFileName(malzemeResmiTextBox.Text.ToString());
                string nameKey = Path.GetFileNameWithoutExtension(malzemeResmiTextBox.Text.ToString());
                string directory = Path.GetDirectoryName(malzemeResmiTextBox.Text.ToString());
                string fileName = name;
                string sourcePath = @directory;
                //    string targetPath = @"\\192.168.1.180\projedata\PROJE\" + teknikProjeAdiTextBox.Text.ToString();
                string targetPath = @"\\SQLSERVER\MALIYET\STOKLAR\RESIMLER\" + malzemeAnaGrupComboBox1.Text.ToString() + @"\";

                //     MessageBox.Show(targetPath);
                string sourceFile = System.IO.Path.Combine(sourcePath, fileName);

                // bazi sistemlerde ing dosya ismi istiyor alt satir cok onemli   Erdal Erol
                // Dosya isminde turkce karakter var ise iptal ediyor

                string destFile = System.IO.Path.Combine(targetPath, karakeriDuzelt(fileName));
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }
                System.IO.File.Copy(sourceFile, destFile, true);
                // aha burada turkce karakter problemi oluyor
                malzemeResmiTextBox.Text = destFile;

                //       MessageBox.Show(destFile);
                //   secilen dosya resim ise picture box icerisinde gozukecektir        // 
                //pictureBoxUretimDosyaResim.ImageLocation = openFileDialog1.FileName;
                // pictureBoxUretimDosyaResim.SizeMode = PictureBoxSizeMode.StretchImage;
                ///   BURADAN ITIBAREN DOSYA BIRLIKTE AC ISLEMI YAPILIYOR
                ///   
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                // proc.StartInfo.FileName = Application.StartupPath + teknikDosyaTextBox.Text;
                proc.StartInfo.FileName = malzemeResmiTextBox.Text.ToString();
                try
                {
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                }
                catch
                {
                    MessageBox.Show(proc.StartInfo.FileName);
                    MessageBox.Show("Şu anda bir dosya bulunmamaktadır.");
                }
            }

            //    pictureBox1.ImageLocation =  malzemeResmiTextBox.Text;
            //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private string karakeriDuzelt(string yazi)
        {
            //    MessageBox.Show(yazi);
            yazi = yazi.Replace("ş", "s");
            yazi = yazi.Replace("ğ", "g");
            yazi = yazi.Replace("ü", "u");
            yazi = yazi.Replace("ı", "i");
            yazi = yazi.Replace("ö", "o");
            yazi = yazi.Replace("ç", "c");
            yazi = yazi.Replace("Ş", "S");
            yazi = yazi.Replace("Ğ", "G");
            yazi = yazi.Replace("İ", "I");
            yazi = yazi.Replace("Ö", "O");
            yazi = yazi.Replace("Ç", "C");
            yazi = yazi.Replace("Ü", "U");

            yazi = yazi.Replace("/", "");
            yazi = yazi.Replace("|", "");
            yazi = yazi.Replace(",", "");
            yazi = yazi.Replace(";", "");

            //     MessageBox.Show(yazi.ToString());
            return yazi;
        }
        private void malzemeResmiTextBox_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
            //  pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //   pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            //  pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Eminmisiniz ?\nStok Kartı silinecek", "Stok Kartı Silme İşlemi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                //saklama islemi yapiliyor
                try
                {
                    this.Validate();
                    this.stokKartBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.mALIYETDataSet);
                }
                catch
                {
                    MessageBox.Show("Lutfen Kayit Alanlarini Bos Birakmayin");
                }
            }
            else
            {

                this.stokKartTableAdapter.Fill(this.mALIYETDataSet.StokKart);
                pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
                //      pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                MessageBox.Show("Deletion Cancelled");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {

            DialogResult dr;
            dr = MessageBox.Show("Eminmisiniz?\nStok Kartı Resim kaldırma işlemi", "Resim Silme", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                //saklama islemi yapiliyor
                try
                {
                    malzemeResmiTextBox.Text = "";
                    this.Validate();
                    this.stokKartBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.mALIYETDataSet);
                }
                catch
                {
                    MessageBox.Show("Lutfen Kayit Alanlarini Bos Birakmayin");
                }
            }
            else
            {

                this.stokKartTableAdapter.Fill(this.mALIYETDataSet.StokKart);
                pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
                //       pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                MessageBox.Show("Deletion Picture Cancelled");
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            aMalzemeKoduToolStripTextBox.Text = malzemeKoduTextBox.Text;

            try
            {
                this.stokKartTableAdapter.FillBy(this.mALIYETDataSet.StokKart, aMalzemeKoduToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  once datagridvew sag ok ile yeni sql query yaratılmış ve toolstrip olusmustur 
            //       private void fillByToolStripButton_Click(object sender, EventArgs e)

            //  içerisindekiler ara butonuna tasınmıştır

            // dahasonra fillBy visable yapılmıştır.


            aMalzemeKoduToolStripTextBox.Text = malzemeKoduTextBox.Text;
            // degiskene atanacak deger belirtilmiştir
            try
            {
                this.stokKartTableAdapter.FillBy(this.mALIYETDataSet.StokKart, aMalzemeKoduToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            aMalzemeAdiToolStripTextBox.Text = malzemeAdiTextBox.Text;
            try
            {
                this.stokKartTableAdapter.MalzemeAdiAramak(this.mALIYETDataSet.StokKart, aMalzemeAdiToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void malzemeAdiAramakToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.MalzemeAdiAramak(this.mALIYETDataSet.StokKart, aMalzemeAdiToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void malzemeAnaGrupAraToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.MalzemeAnaGrupAra(this.mALIYETDataSet.StokKart, aMalzemeAnaGrupToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            aMalzemeAnaGrupToolStripTextBox.Text = malzemeAnaGrupComboBox1.Text;

            try
            {
                this.stokKartTableAdapter.MalzemeAnaGrupAra(this.mALIYETDataSet.StokKart, aMalzemeAnaGrupToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {

            aMalzemeCinsiToolStripTextBox.Text = malzemeCinsiTextBox.Text;
            try
            {
                this.stokKartTableAdapter.FillBy1(this.mALIYETDataSet.StokKart, aMalzemeCinsiToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.FillBy1(this.mALIYETDataSet.StokKart, aMalzemeCinsiToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.FillBy2(this.mALIYETDataSet.StokKart, aMalzemeUreticiFirmaToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void button15_Click(object sender, EventArgs e)
        {
            aMalzemeUreticiFirmaToolStripTextBox.Text = malzemeUreticiFirmaTextBox.Text;
            try
            {
                this.stokKartTableAdapter.FillBy2(this.mALIYETDataSet.StokKart, aMalzemeUreticiFirmaToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void fillBy3ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.FillBy3(this.mALIYETDataSet.StokKart, aMalzemeOrjinalKoduToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            aMalzemeOrjinalKoduToolStripTextBox.Text = malzemeOrjinalKoduTextBox.Text;
            try
            {
                this.stokKartTableAdapter.FillBy3(this.mALIYETDataSet.StokKart, aMalzemeOrjinalKoduToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void fillBy4ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.FillBy4(this.mALIYETDataSet.StokKart, aMalzemeBarkoduToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            aMalzemeBarkoduToolStripTextBox.Text = malzemeBarkoduTextBox.Text;
            try
            {
                this.stokKartTableAdapter.FillBy4(this.mALIYETDataSet.StokKart, aMalzemeBarkoduToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void fillBy5ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.FillBy5(this.mALIYETDataSet.StokKart, aMalzemeOzelKod1ToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button13_Click(object sender, EventArgs e)
        {

            aMalzemeOzelKod1ToolStripTextBox.Text = malzemeOzelKod1TextBox.Text;
            try
            {
                this.stokKartTableAdapter.FillBy5(this.mALIYETDataSet.StokKart, aMalzemeOzelKod1ToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void fillBy6ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.FillBy6(this.mALIYETDataSet.StokKart, aMalzemeOzelKod2ToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            aMalzemeOzelKod2ToolStripTextBox.Text = malzemeOzelKod2TextBox.Text;
            try
            {
                this.stokKartTableAdapter.FillBy6(this.mALIYETDataSet.StokKart, aMalzemeOzelKod2ToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void fillBy7ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.FillBy7(this.mALIYETDataSet.StokKart, aMalzemeOzelKod3ToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            aMalzemeOzelKod3ToolStripTextBox.Text = malzemeOzelKod3TextBox.Text;
            try
            {
                this.stokKartTableAdapter.FillBy7(this.mALIYETDataSet.StokKart, aMalzemeOzelKod3ToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void fillBy8ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.FillBy8(this.mALIYETDataSet.StokKart, aMalzemeOzelKod4ToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            aMalzemeOzelKod4ToolStripTextBox.Text = malzemeOzelKod4TextBox.Text;

            try
            {
                this.stokKartTableAdapter.FillBy8(this.mALIYETDataSet.StokKart, aMalzemeOzelKod4ToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        private void fillBy9ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.FillBy9(this.mALIYETDataSet.StokKart, aMalzemeOzelKod5ToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        private void button8_Click(object sender, EventArgs e)
        {
            aMalzemeOzelKod5ToolStripTextBox.Text = malzemeOzelKod5TextBox.Text;
            try
            {
                this.stokKartTableAdapter.FillBy9(this.mALIYETDataSet.StokKart, aMalzemeOzelKod5ToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void fillBy10ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.FillBy10(this.mALIYETDataSet.StokKart, aMalzemeAlinFirmaToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        private void button9_Click(object sender, EventArgs e)
        {
            aMalzemeAlinFirmaToolStripTextBox.Text = malzemeAlinFirmaTextBox.Text;

            try
            {
                this.stokKartTableAdapter.FillBy10(this.mALIYETDataSet.StokKart, aMalzemeAlinFirmaToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            aMalzemeKoduToolStripTextBox.Text = "";
            //      aMalzemeKoduToolStripTextBox.Text = malzemeKoduTextBox.Text;
            // degiskene atanacak deger belirtilmiştir
            try
            {
                this.stokKartTableAdapter.FillBy(this.mALIYETDataSet.StokKart, aMalzemeKoduToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            KmalzemeAdiTextBox = malzemeAdiTextBox.Text;
            KmalzemeCinsiTextBox = malzemeCinsiTextBox.Text;
            KmalzemeUreticiFirmaTextBox = malzemeUreticiFirmaTextBox.Text;
            KmalzemeOrjinalKoduTextBox = malzemeOrjinalKoduTextBox.Text;
            KmalzemeBarkoduTextBox = malzemeBarkoduTextBox.Text;
            KmalzemeResmiTextBox = malzemeResmiTextBox.Text;
            KmalzemeCarpan2TextBox = malzemeCarpan2TextBox.Text;
            KmalzemeCarpan3TextBox = malzemeCarpan3TextBox.Text;
            KmalzemeBolen2TextBox = malzemeBolen2TextBox.Text;
            KmalzemeBolen3TextBox = malzemeBolen3TextBox.Text;
            KmalzemeEniTextBox = malzemeEniTextBox.Text;
            KmalzemeBoyuTextBox = malzemeBoyuTextBox.Text;
            KmalzemeYuksekligiTextBox = malzemeYuksekligiTextBox.Text;
            KmalzemeÇapı1TextBox = malzemeÇapı1TextBox.Text;
            KmalzemeÇapı2TextBox = malzemeÇapı2TextBox.Text;
            KmalzemeAlinFirmaTextBox = malzemeAlinFirmaTextBox.Text;
            KmalzemeAlimFiyatTextBox = malzemeAlimFiyatTextBox.Text;
            KmalzemeDovizTutariTextBox = malzemeDovizTutariTextBox.Text;
            KmalzemeAlimTarihiDateTimePicker = malzemeAlimTarihiDateTimePicker.Text;
            KmalzemeOzelKod1TextBox = malzemeOzelKod1TextBox.Text;
            KmalzemeOzelKod2TextBox = malzemeOzelKod2TextBox.Text;
            KmalzemeOzelKod3TextBox = malzemeOzelKod3TextBox.Text;
            KmalzemeOzelKod4TextBox = malzemeOzelKod4TextBox.Text;
            KmalzemeOzelKod5TextBox = malzemeOzelKod5TextBox.Text;
            KmalzemeAnaGrupComboBox1 = malzemeAnaGrupComboBox1.Text;
            KmalzemeOlcuBrimi3ComboBox = malzemeOlcuBrimi3ComboBox.Text;
            KmalzemeOlcuBrimi2ComboBox = malzemeOlcuBrimi2ComboBox.Text;
            KmalzemeOlcuBrimi1ComboBox = malzemeOlcuBrimi1ComboBox.Text;
            KaltRenkTextBox = altRenkTextBox.Text;
            KanaRenkTextBox = anaRenkTextBox.Text;
            toolStripButton2.Enabled = false;
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stok kartı MALZEME KODU Hariç Kopyalanmıştır. Lütfen Malzeme Kodu Giriniz ");
            malzemeAdiTextBox.Text = KmalzemeAdiTextBox;
            malzemeCinsiTextBox.Text = KmalzemeCinsiTextBox;
            malzemeUreticiFirmaTextBox.Text = KmalzemeUreticiFirmaTextBox;
            malzemeOrjinalKoduTextBox.Text = KmalzemeOrjinalKoduTextBox;
            malzemeBarkoduTextBox.Text = KmalzemeBarkoduTextBox;
            malzemeResmiTextBox.Text = KmalzemeResmiTextBox;
            malzemeCarpan2TextBox.Text = KmalzemeCarpan2TextBox;
            malzemeCarpan3TextBox.Text = KmalzemeCarpan3TextBox;
            malzemeBolen2TextBox.Text = KmalzemeBolen2TextBox;
            malzemeBolen3TextBox.Text = KmalzemeBolen3TextBox;
            malzemeEniTextBox.Text = KmalzemeEniTextBox;
            malzemeBoyuTextBox.Text = KmalzemeBoyuTextBox;
            malzemeYuksekligiTextBox.Text = KmalzemeYuksekligiTextBox;
            malzemeÇapı1TextBox.Text = KmalzemeÇapı1TextBox;
            malzemeÇapı2TextBox.Text = KmalzemeÇapı2TextBox;
            malzemeAlinFirmaTextBox.Text = KmalzemeAlinFirmaTextBox;
            malzemeAlimFiyatTextBox.Text = KmalzemeAlimFiyatTextBox;
            malzemeDovizTutariTextBox.Text = KmalzemeDovizTutariTextBox;
            malzemeAlimTarihiDateTimePicker.Text = KmalzemeAlimTarihiDateTimePicker;
            malzemeOzelKod1TextBox.Text = KmalzemeOzelKod1TextBox;
            malzemeOzelKod2TextBox.Text = KmalzemeOzelKod2TextBox;
            malzemeOzelKod3TextBox.Text = KmalzemeOzelKod3TextBox;
            malzemeOzelKod4TextBox.Text = KmalzemeOzelKod4TextBox;
            malzemeOzelKod5TextBox.Text = KmalzemeOzelKod5TextBox;
            malzemeAnaGrupComboBox1.Text = KmalzemeAnaGrupComboBox1;
            malzemeOlcuBrimi3ComboBox.Text = KmalzemeOlcuBrimi3ComboBox;
            malzemeOlcuBrimi2ComboBox.Text = KmalzemeOlcuBrimi2ComboBox;
            malzemeOlcuBrimi1ComboBox.Text = KmalzemeOlcuBrimi1ComboBox;
            altRenkTextBox.Text = KaltRenkTextBox;
            anaRenkTextBox.Text = KanaRenkTextBox;
            toolStripButton2.Enabled = false;
        }
        private void button17_Click(object sender, EventArgs e)
        {
            UrunAgaci UrunAgciFormu = new UrunAgaci();
            UrunAgciFormu.Show();
        }
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

            UrunAgaci UrunAgciFormu = new UrunAgaci();
            UrunAgciFormu.Show();
        }
        private void button17_Click_1(object sender, EventArgs e)
        {
            //   secili satırı hızlı silme işlemi
            if (this.stokKartDataGridView.SelectedRows.Count > 0)
            {
                stokKartDataGridView.Rows.RemoveAt(this.stokKartDataGridView.SelectedRows[0].Index);
            }
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            toolStripButton2.Enabled = true;
        }
        private void button18_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Eminmisiniz ?\nKayıt İşlemi Gerçekleşiyor", "Kayıt İşlemi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    this.Validate();
                    this.stokKartBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.mALIYETDataSet);
                }
                catch
                {
                    MessageBox.Show("Lutfen Kayit Alanlarini Bos Birakmayin");
                }
            }
            else
            {
                {
                    this.stokKartTableAdapter.Fill(this.mALIYETDataSet.StokKart);
                    pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
                    //   pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    MessageBox.Show("Kayit İşlemi İptal Edilmiştir");
                }
            }
        }
        private void button17_Click_2(object sender, EventArgs e)
        {
            MLZid = malzemeIdTextBox.Text;
            kodu = malzemeKoduTextBox.Text;
            adi = malzemeAdiTextBox.Text;
            SMalzemeResmi = malzemeResmiTextBox.Text;
            birimfiyati = malzemeAlimFiyatTextBox.Text;
            DovizFiyati = malzemeDovizTutariTextBox.Text;
            Olcu1 = malzemeOlcuBrimi1ComboBox.Text;
            Olcu2 = malzemeOlcuBrimi2ComboBox.Text;
            Olcu3 = malzemeOlcuBrimi3ComboBox.Text;
            Carpan2 = malzemeCarpan2TextBox.Text;
            Carpan3 = malzemeCarpan3TextBox.Text;
            Bolen2 = malzemeBolen2TextBox.Text;
            Bolen3 = malzemeBolen3TextBox.Text;
            DovizTipi = malzemeDovizCinsiComboBox.Text;
            UretimYenile newform = new UretimYenile();
            newform.ShowDialog();
        }
        private void malzemeOlcuBrimi1ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            //  klavyeden giriş yapılamasın
            e.Handled = true;
        }
        private void malzemeOlcuBrimi2ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  klavyeden giriş yapılamasın
            e.Handled = true;
        }
        private void malzemeOlcuBrimi3ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  klavyeden giriş yapılamasın
            e.Handled = true;
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
         /*   DovizKurlari newform = new DovizKurlari();
            newform.ShowDialog();*/

            DovizKurlari DovizKurlariFormu = new DovizKurlari();
            DovizKurlariFormu.Show();

            this.dovizTableAdapter.Fill(this.mALIYETDataSet3.Doviz);


        }
        private void malzemeDovizCinsiComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //  klavyeden giriş yapılamasın
            e.Handled = true;
        }
        private void button18_Click_1(object sender, EventArgs e)
        {
            //   Ve geldik en önemli kısma arkadaşlar ... Yeniden boyutlandır butonuna aşağıdaki kodları yazın ...
            Bitmap bmpKucuk = new Bitmap(pictureBox1.Image, 100, 120); // Yeniden boyutlandırmak için //Bitmap sınıfı kullanılır.Picturebox da yüklü olan resim 100 e 50 boyutunda yeniden //boyutlandırılıyor.
            pictureBox1.Image = bmpKucuk;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }
        private void stokKartDataGridView_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                for (int I = 0; I < stokKartDataGridView.Rows.Count; I++)
                {

                    if (Convert.ToDecimal(stokKartDataGridView.Rows[I].Cells[22].Value.ToString()) == 0)
                    {

                        stokKartDataGridView.Rows[I].DefaultCellStyle.BackColor = Color.Yellow;

                        stokKartDataGridView.Rows[I].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        stokKartDataGridView.Rows[I].DefaultCellStyle.BackColor = Color.White;

                        stokKartDataGridView.Rows[I].DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
            catch
            {
            }
        }
        private void button18_Click_2(object sender, EventArgs e)
        {
            this.stokKartTableAdapter.MalzemeAlimFiyat(this.mALIYETDataSet.StokKart, Convert.ToDecimal(malzemeAlimFiyatTextBox.Text));
        }
        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void malzemeDovizCinsiComboBox_TextChanged(object sender, EventArgs e)
        {
            //  var count = malzemeDovizCinsiComboBox.Items.Count;
            //  MessageBox.Show(count.ToString());
            //  comboBox1.SelectedIndex = count-1;
            //  comboBox1.SelectedValue = count;
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            string  Dovizkur="1";
            Brim1Fiyat.Text = malzemeAlimFiyatTextBox.Text;

            //  kur bulunur herbir satır için
            for (int j = 0; j < dovizDataGridView.RowCount; j++)
            {
                if (malzemeDovizCinsiComboBox.Text.Trim() == dovizDataGridView.Rows[j].Cells[0].Value.ToString())
                {
                    try
                    {
                        Dovizkur =  dovizDataGridView.Rows[j].Cells[1].Value.ToString();
                        //   MessageBox.Show(dovizDataGridView.Rows[i].Cells[1].Value.ToString());
                    }
                    catch
                    {
                    }
                }
                else
                {
                }
            }
           

            if (Convert.ToDecimal(Dovizkur) == 0) Dovizkur = "1";
            Brim1Fiyat.Text = (Convert.ToDecimal(Dovizkur) * Convert.ToDecimal(Brim1Fiyat.Text)).ToString();
            Brim1Tutar.Text = (Convert.ToDecimal(Brim1Fiyat.Text) * Convert.ToDecimal(Brim1Miktar.Text)).ToString();
            Brim1Tutar.Text = string.Format("{0:#####.00}", Convert.ToDecimal(Brim1Tutar.Text));

            if (Convert.ToDecimal(malzemeCarpan2TextBox.Text) > 0)
            {

                Brim2Fiyat.Text = (Convert.ToDecimal(Brim1Fiyat.Text) * Convert.ToDecimal(malzemeCarpan2TextBox.Text)).ToString();
            }
            if (Convert.ToDecimal(malzemeCarpan3TextBox.Text) > 0)
            {

                Brim3Fiyat.Text = (Convert.ToDecimal(Brim1Fiyat.Text) * Convert.ToDecimal(malzemeCarpan3TextBox.Text)).ToString();
            }
                       if (Convert.ToDecimal(malzemeBolen2TextBox.Text) > 0)
            {

                Brim2Fiyat.Text = (Convert.ToDecimal(Brim1Fiyat.Text) / Convert.ToDecimal(malzemeBolen2TextBox.Text)).ToString();
            }

            if (Convert.ToDecimal(malzemeBolen3TextBox.Text) > 0)
            {

                Brim3Fiyat.Text = (Convert.ToDecimal(Brim1Fiyat.Text) / Convert.ToDecimal(malzemeBolen3TextBox.Text)).ToString();
            }

            Brim2Tutar.Text = (Convert.ToDecimal(Brim2Fiyat.Text) * Convert.ToDecimal(Brim2Miktar.Text)).ToString();
            Brim3Tutar.Text = (Convert.ToDecimal(Brim3Fiyat.Text) * Convert.ToDecimal(Brim3Miktar.Text)).ToString();
            Brim2Tutar.Text = string.Format("{0:#####.00}", Convert.ToDecimal(Brim2Tutar.Text));
            Brim3Tutar.Text = string.Format("{0:#####.00}", Convert.ToDecimal(Brim3Tutar.Text));

            Brim1Fiyat.Text = string.Format("{0:#####.00}", Convert.ToDecimal(Brim1Fiyat.Text));
            Brim2Fiyat.Text = string.Format("{0:#####.00}", Convert.ToDecimal(Brim2Fiyat.Text));
            Brim3Fiyat.Text = string.Format("{0:#####.00}", Convert.ToDecimal(Brim3Fiyat.Text));
        }

        private void malzemeIdTextBox_TextChanged(object sender, EventArgs e)
        {
            Brim1Fiyat.Text="0";
            Brim1Tutar.Text="0";
            Brim1Miktar.Text = "0";
            Brim2Fiyat.Text = "0";
            Brim2Tutar.Text = "0";
            Brim2Miktar.Text = "0";
            Brim3Fiyat.Text = "0";
            Brim3Tutar.Text = "0";
            Brim3Miktar.Text = "0";
            string SQLCUMLE = "";
            SQLCUMLE = SQLCUMLE + "SELECT  LogoBaglaID,MalzemeId ,LogoLogicalref,Brim1,Brim2 ,Brim3 FROM MALIYET.dbo.LogoItemsBagla";
            SQLCUMLE = SQLCUMLE + " WHERE MalzemeId = '" + malzemeIdTextBox.Text + "'";
            SbulgriddoldurLOGOITEMS(SQLCUMLE);
        }
         private void dolaryaz()
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
            //    textBox1.Text = " MERKEZ BANKASI DOVİZ KURLARI " + exchangeDate.ToShortDateString();
          //      textBox2.Text = string.Format("{0}    USD   ", USD);
           //     textBox3.Text = string.Format("{0}     EURO ", EURO);
                if (Baglan.State == ConnectionState.Closed) Baglan.Open();
                string sorgu = " UPDATE [MALIYET].[dbo].[Doviz] SET  [DovizKuru] =  '" + USD + "' WHERE DovizTipi='USD'";
                SqlCommand komut = new SqlCommand(sorgu, Baglan);
                SqlDataReader oku = komut.ExecuteReader();
                Baglan.Close();
                euroyaz(EURO);
                this.Validate();
                this.dovizBindingSource.EndEdit();
               
                this.dovizTableAdapter.Fill(this.mALIYETDataSet3.Doviz);
            }
            catch
            {

                MessageBox.Show("MERKEZ BANKASI DOVIZ KURLARI İÇİN : Internet Kapali Olabilir Kontrol Ediniz ");
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

         private void toolStripLabel3_Click(object sender, EventArgs e)
         {
          Musteri MusteriFormu = new Musteri();
            MusteriFormu.Show();
    /*        Baslik BaslikFormu = new Baslik();
             BaslikFormu.Show();
             Satir SatirFormu = new Satir();
                 SatirFormu.Show();
             */
            }

         private void button20_Click(object sender, EventArgs e)
         {
             MLZid = malzemeIdTextBox.Text;
             baglantiismi = malzemeAdiTextBox.Text + " " + malzemeCinsiTextBox.Text;
             LogoTigerBagla newform = new LogoTigerBagla();
             newform.ShowDialog();
         }

         private void stokKartDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
         {

         }
    }
}
/*
******************************             DECİMAL ALANI KARSILASTIRMAK 
this.stokKartTableAdapter.MalzemeAlimFiyat(this.mALIYETDataSet.StokKart,Convert.ToDecimal(malzemeAlimFiyatTextBox.Text));
******************************             SQL QUERYSİ
SELECT MalzemeId, MalzemeKodu, MalzemeAdi, MalzemeAnaGrup, MalzemeCinsi, MalzemeUreticiFirma, MalzemeOrjinalKodu, MalzemeBarkodu, MalzemeResmi, MalzemeOlcuBrimi1, MalzemeOlcuBrimi2, MalzemeOlcuBrimi3, MalzemeCarpan2, MalzemeCarpan3, MalzemeBolen2, MalzemeBolen3, MalzemeEni, MalzemeBoyu, MalzemeYuksekligi, MalzemeÇapı1, MalzemeÇapı2, MalzemeAlinFirma, MalzemeAlimFiyat, MalzemeDovizCinsi, MalzemeDovizTutari, MalzemeAlimTarihi, MalzemeOzelKod1, MalzemeOzelKod2, MalzemeOzelKod3, MalzemeOzelKod4, MalzemeOzelKod5, AltRenk, AnaRenk FROM StokKart
WHERE ( MalzemeAlimFiyat =  (CONVERT (numeric(18,4), @AMalzemeAlimFiyat)) ) 
STRING KARSILASTIRILACAKSA (CONVERT (     VARCHAR(22),@AMalzemeAlimFiyat.text.replace(
yazacagız
 dıgerlerı icin rulo agırlık bakabılırız...
*/

/*
// Bugün (en son iş gününe) e ait döviz kurları için
string today = "http://www.tcmb.gov.tr/kurlar/today.xml";
 
// 14 Şubat 2013 e ait döviz kurları için
string anyDays = "http://www.tcmb.gov.tr/kurlar/201302/14022013.xml";
 
var xmlDoc = new XmlDocument();
xmlDoc.Load(today);
 
// Xml içinden tarihi alma - gerekli olabilir
DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);
 
string USD =xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
string EURO = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
string POUND = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
 
Console.WriteLine(string.Format("Tarih {0} USD   : {1}", exchangeDate.ToShortDateString(), USD));
Console.WriteLine(string.Format("Tarih {0} EURO  : {1}", exchangeDate.ToShortDateString(), EURO));
Console.WriteLine(string.Format("Tarih {0} POUND : {1}", exchangeDate.ToShortDateString(), POUND));
*/
