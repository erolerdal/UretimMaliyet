    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Data.SqlClient;


namespace MaliyetProgram
{
    public partial class UrunAgaci : Form
    {
        public static string OrtakUrunId = "";
        public static string OrtakUrunKodu = "";
        public static string OrtakRevizyonNo = "";
        public static string OrtakUrunAdi = "";

        public static string KUrunKodu = "";
        public static string KUrunAdi = "";
        public static string KUrunId = "";

        SqlConnection Baglan = new SqlConnection(@"Data Source=SQLSERVER;Initial Catalog=MALIYET;User ID=Sa;Password=Sa2010");
        public UrunAgaci()
        {
            InitializeComponent();
        }
        private void urunAgaciBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Eminmisiniz ?\nKayıt İşlemi Gerçekleşiyor", "Kayıt İşlemi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    this.Validate();
                    this.urunAgaciBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.mALIYETDataSet1);
                    MessageBox.Show("Kayit İşlemi Bitmiştir");
                 //   this.urunAgaciTableAdapter.Fill(this.mALIYETDataSet1.UrunAgaci);
                //    pictureBox1.ImageLocation = urunResmiTextBox.Text;
                //    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                catch
                {
                    MessageBox.Show("Lutfen Kayit Alanlarini Bos Birakmayin");
                }
            }
            else
            {
                {
                    this.urunAgaciTableAdapter.Fill(this.mALIYETDataSet1.UrunAgaci);
                    pictureBox1.ImageLocation = urunResmiTextBox.Text;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    MessageBox.Show("Kayit İşlemi İTAL edilmiştir ");
                }
            }
            
        }
        private void UrunAgaci_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mALIYETDataSet3.Doviz' table. You can move, or remove it, as needed.
            this.dovizTableAdapter.Fill(this.mALIYETDataSet3.Doviz);
            pictureBox1.ImageLocation = urunResmiTextBox.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            // TODO: This line of code loads data into the 'mALIYETDataSet1.UrunAgaci' table. You can move, or remove it, as needed.
            this.urunAgaciTableAdapter.Fill(this.mALIYETDataSet1.UrunAgaci);
            pictureBox1.ImageLocation = urunResmiTextBox.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (Convert.ToInt32(urunIdTextBox.Text) > 0)
                {
                    OrtakUrunId = urunIdTextBox.Text;
                    OrtakUrunKodu = urunKoduTextBox.Text;
                    OrtakRevizyonNo = urunRevizyonNoTextBox.Text;
                    OrtakUrunAdi = urunAdiTextBox.Text;
                    //  sabit degerler aktarılacak ReceteID - UrunId - UrunKodu - RevizyonNo - Urun Adi gibi
                    Uretim newform = new Uretim();
                    newform.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Urun Secmelisiniz !!!! ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //  openFileDialog1.Filter = " (*.jpg)|*.jpg|(*.png)|*.png|(*.dwg)|*.dwg|(*.doc)|*.doc|(*.xls)|*.xls|(*.docx)|*.docx|(*.xlsx)|*.xlsx|(*.pdf)|*.pdf";

            //                        eklemeyi unutma...
            //
            //                        using System.IO;
            //
            openFileDialog1.Reset();
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName.ToString() != "")
            {
                urunResmiTextBox.Text = openFileDialog1.FileName.ToString();
                MessageBox.Show(urunResmiTextBox.Text);

                string name = Path.GetFileName(urunResmiTextBox.Text.ToString());
                string nameKey = Path.GetFileNameWithoutExtension(urunResmiTextBox.Text.ToString());
                string directory = Path.GetDirectoryName(urunResmiTextBox.Text.ToString());
                string fileName = name;
                string sourcePath = @directory;
                //    string targetPath = @"\\192.168.1.180\projedata\PROJE\" + teknikProjeAdiTextBox.Text.ToString();
                string targetPath = @"\\SQLSERVER\MALIYET\URUNLER\RESIMLER\" + urunAnaGrupComboBox.Text.ToString() + @"\";

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
                urunResmiTextBox.Text = destFile;

                //    MessageBox.Show(destFile);
                //   secilen dosya resim ise picture box icerisinde gozukecektir        // 
                //pictureBoxUretimDosyaResim.ImageLocation = openFileDialog1.FileName;
                // pictureBoxUretimDosyaResim.SizeMode = PictureBoxSizeMode.StretchImage;
                ///   BURADAN ITIBAREN DOSYA BIRLIKTE AC ISLEMI YAPILIYOR
                ///   
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                // proc.StartInfo.FileName = Application.StartupPath + teknikDosyaTextBox.Text;
                proc.StartInfo.FileName = urunResmiTextBox.Text.ToString();
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

        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Are you sure?\nThere is no undo once Picture data is deleted", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                //saklama islemi yapiliyor
                try
                {
                    urunResmiTextBox.Text = "";
                    this.Validate();
                    this.urunAgaciBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.mALIYETDataSet1);
                }
                catch
                {
                    MessageBox.Show("Lutfen Kayit Alanlarini Bos Birakmayin");
                }
            }
            else
            {

                this.urunAgaciTableAdapter.Fill(this.mALIYETDataSet1.UrunAgaci);
                pictureBox1.ImageLocation = urunResmiTextBox.Text;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                MessageBox.Show("Deletion Picture Cancelled");
            }
        }

        private void urunResmiTextBox_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = urunResmiTextBox.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            tabControl1.SelectedTab = tabPage1;
            //  this.urunReceteTableAdapter.Fill(this.mALIYETDataSet2.UrunRecete, Convert.ToInt32(this.urunIdTextBox.Text));
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
        }

        private void urunAnaGrupToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunAnaGrup(this.mALIYETDataSet1.UrunAgaci, aUrunAnaGrupToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            aUrunAnaGrupToolStripTextBox.Text = urunAnaGrupComboBox.Text;
            try
            {
                this.urunAgaciTableAdapter.UrunAnaGrup(this.mALIYETDataSet1.UrunAgaci, aUrunAnaGrupToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                this.urunAgaciTableAdapter.UrunAltGrup(this.mALIYETDataSet1.UrunAgaci, urunAltGrupComboBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunTaliGrup(this.mALIYETDataSet1.UrunAgaci, urunTaliGrupComboBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunAdi(this.mALIYETDataSet1.UrunAgaci, urunAdiTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunCinsi(this.mALIYETDataSet1.UrunAgaci, urunCinsiTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunOzelKod1(this.mALIYETDataSet1.UrunAgaci, urunOzelKod1TextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunOzelKod2(this.mALIYETDataSet1.UrunAgaci, urunOzelKod2TextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunOzelKod3(this.mALIYETDataSet1.UrunAgaci, urunOzelKod3TextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunOzelKod4(this.mALIYETDataSet1.UrunAgaci, urunOzelKod4TextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunOzelKod5(this.mALIYETDataSet1.UrunAgaci, urunOzelKod5TextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunUreticiFirma(this.mALIYETDataSet1.UrunAgaci, urunUreticiFirmaTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunOrjinalKodu(this.mALIYETDataSet1.UrunAgaci, urunOrjinalKoduTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunBarkodu(this.mALIYETDataSet1.UrunAgaci, urunBarkoduTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Eminmisiniz ?\nİşlemi İptal ile Sonlandırabilirsiniz", "Ürün Agacı Silme İşlemi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                //saklama islemi yapiliyor
                try
                {
                    this.Validate();
                    this.urunAgaciBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.mALIYETDataSet1);
                }
                catch
                {
                    MessageBox.Show("Silme İşleminde Hata");
                }
            }
            else
            {
                this.urunAgaciTableAdapter.Fill(this.mALIYETDataSet1.UrunAgaci);
                pictureBox1.ImageLocation = urunResmiTextBox.Text;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                MessageBox.Show("Silme İşleminden Vazgeçildi");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.urunAgaciTableAdapter.Fill(this.mALIYETDataSet1.UrunAgaci);
            pictureBox1.ImageLocation = urunResmiTextBox.Text;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            this.urunReceteTableAdapter.Fill(this.mALIYETDataSet2.UrunRecete, Convert.ToInt32(this.urunIdTextBox.Text));
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(urunIdTextBox.Text) > 0)
                {
                    OrtakUrunId = urunIdTextBox.Text;
                    OrtakUrunKodu = urunKoduTextBox.Text;
                    OrtakRevizyonNo = urunRevizyonNoTextBox.Text;
                    OrtakUrunAdi = urunAdiTextBox.Text;
                    //  sabit degerler aktarılacak ReceteID - UrunId - UrunKodu - RevizyonNo - Urun Adi gibi
                    Uretim newform = new Uretim();
                    newform.ShowDialog();
                }
            }
            catch
            {
                MessageBox.Show("Urun Secmelisiniz !!!! ");
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunReceteTableAdapter.Fill(this.mALIYETDataSet2.UrunRecete, ((int)(System.Convert.ChangeType(ortakUrunIdToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage4)
            {
                try
                {
                    this.urunReceteTableAdapter.Fill(this.mALIYETDataSet2.UrunRecete, Convert.ToInt32(this.urunIdTextBox.Text));
                    tabControl1.SelectTab(0);
                    tabControl1.SelectTab(3);
                    hesapla();
                   
                }
                catch
                {
                }
             }
            if (tabControl1.SelectedTab == tabPage3)
            {
                ////   BURASI COMBOBOX İÇİNE SQL DEN VERİ OKUR....   ------------------------------------------------------

                //            // using System.Data.SqlClient;   yerine konacak...
                //            // SqlConnection Baglan = new SqlConnection(@"Data Source=SQLSERVER;Initial Catalog=MALIYET;User ID=Sa;Password=Sa2010");   public formun içine initialin üstüne....

                if (Baglan.State == ConnectionState.Closed) Baglan.Open();
                string sorgu = "select DovizTipi From Doviz";
                SqlCommand komut = new SqlCommand(sorgu, Baglan);
                SqlDataReader oku = komut.ExecuteReader();
                urunDovizCinsiComboBox.Items.Clear();
                while (oku.Read())
                {
                    // malzemeDovizCinsiComboBox.Items.Add(oku.GetString(0) + " " + oku.GetString(1));
                    urunDovizCinsiComboBox.Items.Add(oku.GetString(0));
                }
                //İşlemimiz bittikten sonra ise her zaman baglantımızı kapatıyoruz...
                Baglan.Close();


                // DAHA SONRA COMBOBOX PROPERY KEY PESSS EVENTINE  BASKA VARI GIRILMESIN DIYORSAN

                //    e.Handled = true;     KOYACAKSIN...

            }
        }
        private void urunOlcuBrimi1ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // klavyeden giriş yapılamasın

            e.Handled = true;
        }

        private void urunOlcuBrimi2ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // klavyeden giriş yapılamasın

            e.Handled = true;
        }
        private void urunOlcuBrimi3ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // klavyeden giriş yapılamasın
            e.Handled = true;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            hesapla();
        }
        private void hesapla()
        {
            if (urunReceteDataGridView.RowCount > 0)
            {

                decimal toplamtl = 0;
                decimal tl = 0;
                decimal alisfiyati = 0, Carpan2 = 0, Carpan3 = 0, Bolen2 = 0, Bolen3 = 0, BirimTutar = 0, Kullanilan = 0;
                string OlcuBrim1 = "", OlcuBrim2 = "", OlcuBrim3 = "";
                double yuzde1 = 0;
                double yuzde2 = 0;
                double yuzde3 = 0;
                double yuzde4 = 0;
                double yuzde5 = 0;
                decimal kur = 0;
                decimal ilavebrimtutar = 0;
                decimal ilavebrimolcu = 0;

                for (int i = 0; i < urunReceteDataGridView.RowCount; i++)
                {


                    // her satır için tl bulunacak
                    dovizCinsiTextBox.Text = urunReceteDataGridView.Rows[i].Cells[8].Value.ToString();
                    //  kur bulunur herbir satır için
                    for (int j = 0; j < dovizDataGridView.RowCount; j++)
                    {
                        if (dovizCinsiTextBox.Text.Trim() == dovizDataGridView.Rows[j].Cells[0].Value.ToString())
                        {
                            try
                            {
                                kur = Convert.ToDecimal(dovizDataGridView.Rows[j].Cells[1].Value.ToString());
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
                    if (kur == 0) kur = 1;
                    // aktarmalar   ***************************************************************

                    olcuBirimiTextBox.Text = urunReceteDataGridView.Rows[i].Cells[4].Value.ToString();
                    kullanimMiktariTextBox.Text = urunReceteDataGridView.Rows[i].Cells[5].Value.ToString();

                    //  hatalara karsi 0 yuklenir
                    if (string.IsNullOrEmpty(orjSonAlisFiyatiTextBox.Text) == true) { orjSonAlisFiyatiTextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(orjMalzemeCarpan2TextBox.Text) == true) { orjMalzemeCarpan2TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(orjMalzemeCarpan3TextBox.Text) == true) { orjMalzemeCarpan3TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(orjMalzemeBolen2TextBox.Text) == true) { orjMalzemeBolen2TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(orjMalzemeBolen3TextBox.Text) == true) { orjMalzemeBolen3TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(kullanimMiktariTextBox.Text) == true) { kullanimMiktariTextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(ilavebrimtutaryuzdeTextBox.Text) == true) { ilavebrimtutaryuzdeTextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(ilavebrimolcuyuzdeTextBox.Text) == true) { ilavebrimolcuyuzdeTextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(ilavebrimolcuyuzdeTextBox.Text) == true) { ilavebrimolcuyuzdeTextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(urunGenelToplamTextBox.Text) == true) { urunGenelToplamTextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(urunArtıFiyat1TextBox.Text) == true) { urunArtıFiyat1TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(urunArtıFiyat2TextBox.Text) == true) { urunArtıFiyat2TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(urunArtıFiyat3TextBox.Text) == true) { urunArtıFiyat3TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(urunArtıFiyat4TextBox.Text) == true) { urunArtıFiyat4TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(urunArtıFiyat5TextBox.Text) == true) { urunArtıFiyat5TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(urunSatisFiyatTextBox.Text) == true) { urunSatisFiyatTextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(urunArtıYuzde1TextBox.Text) == true) { urunArtıYuzde1TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(urunArtıYuzde2TextBox.Text) == true) { urunArtıYuzde2TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(urunArtıYuzde3TextBox.Text) == true) { urunArtıYuzde3TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(urunArtıYuzde4TextBox.Text) == true) { urunArtıYuzde4TextBox.Text = "0"; }
                    if (string.IsNullOrEmpty(urunArtıYuzde5TextBox.Text) == true) { urunArtıYuzde5TextBox.Text = "0"; }


                    if (string.IsNullOrEmpty(urunReceteDataGridView.Rows[i].Cells[29].Value.ToString()) == true) { urunReceteDataGridView.Rows[i].Cells[29].Value = "0"; }
                    if (string.IsNullOrEmpty(urunReceteDataGridView.Rows[i].Cells[30].Value.ToString()) == true) { urunReceteDataGridView.Rows[i].Cells[30].Value = "0"; }

                    if (string.IsNullOrEmpty(toplamTutarTextBox.Text) == true) { toplamTutarTextBox.Text = "0"; }
                    ilavebrimtutar = Convert.ToDecimal(urunReceteDataGridView.Rows[i].Cells[29].Value.ToString());
                    ilavebrimolcu = Convert.ToDecimal(urunReceteDataGridView.Rows[i].Cells[30].Value.ToString());
                    //   BURASI sirasi ile SQL DEN VERİ OKUR....   ------------------------------------------------------
                    if (Baglan.State == ConnectionState.Closed) Baglan.Open();
                    string sorgu = "select * From StokKart where MalzemeId = " + Convert.ToInt16(urunReceteDataGridView.Rows[i].Cells[14].Value).ToString();
                    SqlCommand komut = new SqlCommand(sorgu, Baglan);
                    SqlDataReader oku = komut.ExecuteReader();
                    //malzemeDovizCinsiComboBox.Items.Clear();
                    while (oku.Read())
                    {
                        alisfiyati = oku.GetDecimal(22);
                        olcuBirimiTextBox.Text = urunReceteDataGridView.Rows[i].Cells[4].Value.ToString();
                        if (!oku.IsDBNull(9))
                        {
                            OlcuBrim1 = oku.GetString(9);
                        }
                        else
                        {
                            OlcuBrim1 = "";
                        }
                        if (!oku.IsDBNull(10))
                        {
                            OlcuBrim2 = oku.GetString(10);
                        }
                        else
                        {
                            OlcuBrim2 = "";
                        }

                        if (!oku.IsDBNull(11))
                        {
                            OlcuBrim3 = oku.GetString(11);
                        }
                        else
                        {
                            OlcuBrim3 = "";
                        }
                        Carpan2 = oku.GetDecimal(12);
                        Carpan3 = oku.GetDecimal(13);
                        Bolen2 = oku.GetDecimal(14);
                        Bolen3 = oku.GetDecimal(15);
                    }
                    Baglan.Close();
                    orjSonAlisFiyatiTextBox.Text = alisfiyati.ToString();
                    if (olcuBirimiTextBox.Text == OlcuBrim1)
                    {
                        //  olcu brimi orjinal birim ile aynı ise
                        BirimTutar = alisfiyati * kur;
                    }
                    if (olcuBirimiTextBox.Text == OlcuBrim2)
                    {
                        //  olcu brimi 2. brim secildi ise
                        if (Bolen2 > 0)
                        {
                            BirimTutar = alisfiyati * kur / Bolen2;
                        }
                        if (Carpan2 > 0)
                        {
                            BirimTutar = alisfiyati * kur * Carpan2;
                        }
                    }
                    if (olcuBirimiTextBox.Text == OlcuBrim3)
                    {   //  olcu brimi 3. brim secildi ise
                        if (Bolen2 > 0)
                        {
                            BirimTutar = alisfiyati * kur / Bolen2;
                        }
                        if (Carpan3 > 0)
                        {
                            BirimTutar = alisfiyati * kur * Carpan3;
                        }
                    }
                    Kullanilan = Convert.ToDecimal(kullanimMiktariTextBox.Text);
                    //tl = Kullanilan * BirimTutar * (ilavebrimtutar / 100) * (ilavebrimolcu/100);
                    tl = Kullanilan * BirimTutar;

                    toplamtl = toplamtl + tl;
                    toplamtl = toplamtl + (ilavebrimtutar / 100) * tl;
                    toplamtl = toplamtl + (ilavebrimolcu / 100) * tl;
                    //    MessageBox.Show("BEKLE");
                    //   toplamTutarTextBox.Text = (Convert.ToDouble(brimTutariTextBox.Text) * Convert.ToDouble(kullanimMiktariTextBox.Text)).ToString();
                    //   toplamTutarTextBox.Text = (Convert.ToDouble(brimTutariTextBox.Text) * Convert.ToDouble(kullanimMiktariTextBox.Text) * Convert.ToDouble(ilavebrimtutaryuzdeTextBox.Text) / 100 + Convert.ToDouble(toplamTutarTextBox.Text)).ToString();
                    //   toplamTutarTextBox.Text = (Convert.ToDouble(brimTutariTextBox.Text) * Convert.ToDouble(kullanimMiktariTextBox.Text) * Convert.ToDouble(ilavebrimolcuyuzdeTextBox.Text) / 100 + Convert.ToDouble(toplamTutarTextBox.Text)).ToString();
                }
                urunSatisFiyatTextBox.Text = toplamtl.ToString();
                // TOPLAM BULUNACAK....
                urunGenelToplamTextBox.Text = urunSatisFiyatTextBox.Text;
                urunGenelToplamTextBox.Text = (Convert.ToDouble(urunArtıFiyat1TextBox.Text) + Convert.ToDouble(urunGenelToplamTextBox.Text)).ToString();
                urunGenelToplamTextBox.Text = (Convert.ToDouble(urunArtıFiyat2TextBox.Text) + Convert.ToDouble(urunGenelToplamTextBox.Text)).ToString();
                urunGenelToplamTextBox.Text = (Convert.ToDouble(urunArtıFiyat3TextBox.Text) + Convert.ToDouble(urunGenelToplamTextBox.Text)).ToString();
                urunGenelToplamTextBox.Text = (Convert.ToDouble(urunArtıFiyat4TextBox.Text) + Convert.ToDouble(urunGenelToplamTextBox.Text)).ToString();
                urunGenelToplamTextBox.Text = (Convert.ToDouble(urunArtıFiyat5TextBox.Text) + Convert.ToDouble(urunGenelToplamTextBox.Text)).ToString();
                yuzde1 = Convert.ToDouble(urunSatisFiyatTextBox.Text) * Convert.ToDouble(urunArtıYuzde1TextBox.Text) / 100;
                yuzde2 = Convert.ToDouble(urunSatisFiyatTextBox.Text) * Convert.ToDouble(urunArtıYuzde2TextBox.Text) / 100;
                yuzde3 = Convert.ToDouble(urunSatisFiyatTextBox.Text) * Convert.ToDouble(urunArtıYuzde3TextBox.Text) / 100;
                yuzde4 = Convert.ToDouble(urunSatisFiyatTextBox.Text) * Convert.ToDouble(urunArtıYuzde4TextBox.Text) / 100;
                yuzde5 = Convert.ToDouble(urunSatisFiyatTextBox.Text) * Convert.ToDouble(urunArtıYuzde5TextBox.Text) / 100;
                urunGenelToplamTextBox.Text = (Convert.ToDouble(urunGenelToplamTextBox.Text) + (yuzde1 + yuzde2 + yuzde3 + yuzde4 + yuzde5)).ToString();
            }
        }
        private void urunDovizCinsiComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // giriş yapılamasın
            e.Handled = true;
        }
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            KUrunKodu = urunKoduTextBox.Text;
            KUrunAdi = urunAdiTextBox.Text;
            KUrunId = urunIdTextBox.Text;
            MessageBox.Show(KUrunAdi + " Tanımlı ürün Hafızaya Alınmıştır ");
        }
        private void button9_Click(object sender, EventArgs e)
        {
            KUrunKodu = urunKoduTextBox.Text;
            KUrunAdi = urunAdiTextBox.Text;
            KUrunId = urunIdTextBox.Text;
            label6.Text = urunAdiTextBox.Text;     
            MessageBox.Show(KUrunAdi + " Tanımlı ürün Hafızaya Alınmıştır ");
        }
        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Eminmisiniz ?\nBu ürüne Daha önce Kopyaladığınız Recete Yapıştırılacaktır. ", "Kayıt İşlemi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                // GRIDVİEW DEKİ BİLGİLER SQL E KAYIT EDİLİR....
                string YUrunKodu = urunKoduTextBox.Text;
                string YUrunAdi = urunAdiTextBox.Text;
                string YUrunId = urunIdTextBox.Text;
                //    try
                //    {
                this.urunReceteTableAdapter.Fill(this.mALIYETDataSet2.UrunRecete, Convert.ToInt32(KUrunId));
                // MessageBox.Show(    urunReceteDataGridView.RowCount.ToString ());
                if (Convert.ToInt32(urunIdTextBox.Text) > 0)
                {
                    for (int i = 0; i < urunReceteDataGridView.RowCount; i++)
                    {
                        // urun kayit islemi yapilacaktir....
                        if (Baglan.State == ConnectionState.Closed) Baglan.Open();
                        string sorgu = "  ";
                        sorgu = "   INSERT INTO UrunRecete  ( ";
                        sorgu = sorgu + "            UrunId ";
                        sorgu = sorgu + "            ,UrunKodu ";
                        sorgu = sorgu + "            ,UrunAdi ";
                        sorgu = sorgu + "            ,MalzemeId ";
                        sorgu = sorgu + "            ,MalzemeKodu ";
                        sorgu = sorgu + "           ,MalzemeAdi ";
                        sorgu = sorgu + "           ,YariMamulAdi ";
                        sorgu = sorgu + "           ,TaliYariMamulAdi ";
                        
                        sorgu = sorgu + "           ,OlcuBirimi ";
                        sorgu = sorgu + "           ,KullanimMiktari ";
                        sorgu = sorgu + "           ,Aciklama ";
                        sorgu = sorgu + "           ,MalzemeResmi ";
                        sorgu = sorgu + "           ,ilaveadi ";
                        sorgu = sorgu + "           ,ilavebrimtutaryuzde ";
                        sorgu = sorgu + "           ,ilavebrimolcuyuzde";
                        sorgu = sorgu + "           ,ParcaTanimi";
                        sorgu = sorgu + "  ,DovizCinsi)  ";
                        sorgu = sorgu + "    VALUES ( ";
                        sorgu = sorgu + "            " + Convert.ToInt32(YUrunId);
                        sorgu = sorgu + "         ,'" + YUrunKodu + "'";
                        sorgu = sorgu + "        ,'" + YUrunAdi + "'";

                        sorgu = sorgu + "          ," + Convert.ToInt32(urunReceteDataGridView.Rows[i].Cells[14].Value) + " ";
                        sorgu = sorgu + "         ,'" + urunReceteDataGridView.Rows[i].Cells[3].Value.ToString().Replace("'", " ") + "'";
                        sorgu = sorgu + "         ,'" + urunReceteDataGridView.Rows[i].Cells[2].Value.ToString().Replace("'", " ") + "'";
                        sorgu = sorgu + "        ,'" + urunReceteDataGridView.Rows[i].Cells[0].Value.ToString().Replace("'", " ") + "'";
                        sorgu = sorgu + "        ,'" + urunReceteDataGridView.Rows[i].Cells[1].Value.ToString().Replace("'", " ") + "'";
                        sorgu = sorgu + "         ,'" + urunReceteDataGridView.Rows[i].Cells[4].Value.ToString().Replace("'", " ") + "'";
                        sorgu = sorgu + "         ," + Convert.ToDecimal(urunReceteDataGridView.Rows[i].Cells[5].Value).ToString().Replace(',', '.') + "";
                        sorgu = sorgu + "          ,'" + urunReceteDataGridView.Rows[i].Cells[11].Value.ToString().Replace("'", " ") + "'";
                        sorgu = sorgu + "          ,'" + urunReceteDataGridView.Rows[i].Cells[15].Value.ToString().Replace("'", " ") + "'";
                        sorgu = sorgu + "          ,'" + urunReceteDataGridView.Rows[i].Cells[28].Value.ToString().Replace("'", " ") + "'";
                        
                        if (string.IsNullOrEmpty(urunReceteDataGridView.Rows[i].Cells[29].Value.ToString()) == true) { urunReceteDataGridView.Rows[i].Cells[29].Value  = "0"; }
                        if (string.IsNullOrEmpty(urunReceteDataGridView.Rows[i].Cells[30].Value.ToString()) == true) { urunReceteDataGridView.Rows[i].Cells[30].Value  = "0"; }
                        sorgu = sorgu + "         ," + urunReceteDataGridView.Rows[i].Cells[29].Value.ToString().Replace(',', '.') + "";
                        sorgu = sorgu + "        ," + urunReceteDataGridView.Rows[i].Cells[30].Value.ToString().Replace(',', '.') + "";
                        sorgu = sorgu + "        ,'" + urunReceteDataGridView.Rows[i].Cells[31].Value.ToString().Replace("'", " ") + "'";
                        sorgu = sorgu + "        ,'" + urunReceteDataGridView.Rows[i].Cells[8].Value.ToString().Replace("'", " ") + "')";
                        //   MessageBox.Show(sorgu);
                        SqlCommand komut = new SqlCommand(sorgu, Baglan);
                        komut.ExecuteNonQuery();
                        Baglan.Close();
                       
                    }
                }
                this.urunReceteTableAdapter.Fill(this.mALIYETDataSet2.UrunRecete, Convert.ToInt32(this.urunIdTextBox.Text));
                //     }
                //   catch
                //   {
                //  }
                MessageBox.Show("Urun Recetesi Kopyalama KAYDI Yapılmıştır ");

            }
            else
            {
                MessageBox.Show("Seçmiş olduğunuz Yapıştır işlemi İPTAL edilmiştir..");
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(urunIdTextBox.Text) > 0)
                {

                    OrtakUrunId = urunIdTextBox.Text;
                    OrtakUrunKodu = urunKoduTextBox.Text;
                    OrtakRevizyonNo = urunRevizyonNoTextBox.Text;
                    OrtakUrunAdi = urunAdiTextBox.Text;
                    //  sabit degerler aktarılacak ReceteID - UrunId - UrunKodu - RevizyonNo - Urun Adi gibi
                   /* Uretim newform = new Uretim();
                    newform.ShowDialog();*/

                    Uretim UretimFormu = new Uretim();
                    UretimFormu.Show();

                }
            }
            catch
            {
                MessageBox.Show("Urun Secmelisiniz !!!! ");
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {
            //   Ve geldik en önemli kısma arkadaşlar ... Yeniden boyutlandır butonuna aşağıdaki kodları yazın ...
            try
            {
                Bitmap bmpKucuk = new Bitmap(pictureBox1.Image, 100, 120); // Yeniden boyutlandırmak için //Bitmap sınıfı kullanılır.Picturebox da yüklü olan resim 100 e 50 boyutunda yeniden //boyutlandırılıyor.
                pictureBox1.Image = bmpKucuk;
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
            catch
            {
            }
        }
        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunKodu(this.mALIYETDataSet1.UrunAgaci, urunKoduTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunRevizyonNo(this.mALIYETDataSet1.UrunAgaci, urunRevizyonNoTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunAciklama(this.mALIYETDataSet1.UrunAgaci, urunAciklamaRichTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

       

        private void tabPage4_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Yeniden Hesaplanmıştır");
            hesapla();
        }

        private void button26_Click(object sender, EventArgs e)
        {

            OrtakUrunKodu = urunKoduTextBox.Text;
            
            Form1 newform = new Form1();
             newform.ShowDialog();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void urunAnaGrupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void urunAnaGrupComboBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void urunAnaGrupComboBox_Enter(object sender, EventArgs e)
        {
  
        }

        private void urunAnaGrupComboBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void urunAltGrupLabel1_Click(object sender, EventArgs e)
        {
            if (urunAnaGrupComboBox.Text == "APLİK")
            {
                urunAltGrupComboBox.Text = "";
                urunAltGrupComboBox.Items.Clear();
                urunTaliGrupComboBox.Text = "";
                urunTaliGrupComboBox.Items.Clear();
                urunAltGrupComboBox.Items.Add("DIŞ MEKAN APLİK");
                urunAltGrupComboBox.Items.Add("GENEL MEKAN APLİK");
                urunAltGrupComboBox.Items.Add("ODA APLİK");

                //  tali alt grup ana gruba gore degısecek oldugu ıcın burada hazırlanıyor 

                urunTaliGrupComboBox.Items.Add("APLİK");
                urunTaliGrupComboBox.Items.Add("AYNA KENARI APLİK");
                urunTaliGrupComboBox.Items.Add("AYNA ÜSTÜ APLİK");
                urunTaliGrupComboBox.Items.Add("BALKON APLİK");
                urunTaliGrupComboBox.Items.Add("BANYO APLİK");
                urunTaliGrupComboBox.Items.Add("EFEKT APLİK");
                urunTaliGrupComboBox.Items.Add("KAPI NUMARATÖRÜ");
                urunTaliGrupComboBox.Items.Add("OKUMA LAMBALI YATAKBAŞI APLİK");
                urunTaliGrupComboBox.Items.Add("OKUMA LAMBASI");
                urunTaliGrupComboBox.Items.Add("TABLO APLİK");
                urunTaliGrupComboBox.Items.Add("YATAKBAŞI APLİK");


            }
            if (urunAnaGrupComboBox.Text == "BAHÇE AYDINLATMA")
            {
                urunAltGrupComboBox.Text = "";
                urunAltGrupComboBox.Items.Clear();
                urunTaliGrupComboBox.Text = "";
                urunTaliGrupComboBox.Items.Clear();
                urunAltGrupComboBox.Items.Add("DIŞ MEKAN APLİK");
                urunAltGrupComboBox.Items.Add("SET ÜSTÜ AYDINLATMA");
                urunAltGrupComboBox.Items.Add("KISA DİREK (BOLARD) AYDINLATMA");
                urunAltGrupComboBox.Items.Add("UZUN DİREK AYDINLATMA");

                urunTaliGrupComboBox.Items.Add("AĞAÇ VE BİTKİ AYDINLATMA");
                urunTaliGrupComboBox.Items.Add("DIŞ MEKAN APLİK");
                urunTaliGrupComboBox.Items.Add("DIŞ MEKAN SARKIT");
                urunTaliGrupComboBox.Items.Add("FENER");
                urunTaliGrupComboBox.Items.Add("KISA DİREK (BOLARD) AYDINLATMA");
                urunTaliGrupComboBox.Items.Add("SET ÜSTÜ AYDINLATMA");
                urunTaliGrupComboBox.Items.Add("UZUN DİREK AYDINLATMA");
                urunTaliGrupComboBox.Items.Add("SPA & HAMAM SARKIT");
                urunTaliGrupComboBox.Items.Add("YERE GÖMME AYDINLATMA");


            }
            if (urunAnaGrupComboBox.Text == "AVİZE")
            {
                urunAltGrupComboBox.Text = "";
                urunAltGrupComboBox.Items.Clear();
                urunTaliGrupComboBox.Text = "";
                urunTaliGrupComboBox.Items.Clear();
                //  tali alt grup ana gruba gore degısecek oldugu ıcın burada hazırlanıyor 

                urunTaliGrupComboBox.Items.Add("AVİZE");
                urunTaliGrupComboBox.Items.Add("BAR ÜSTÜ SARKIT");
                urunTaliGrupComboBox.Items.Add("BİLARDO SARKIT");
                urunTaliGrupComboBox.Items.Add("GENEL MEKAN AVİZE");
                urunTaliGrupComboBox.Items.Add("GENEL MEKAN SARKIT");
                urunTaliGrupComboBox.Items.Add("OFİS SARKITLARI");
                urunTaliGrupComboBox.Items.Add("RESEPSİYON BANKOSU SARKIT");
                urunTaliGrupComboBox.Items.Add("SPA & HAMAM SARKIT");
                urunTaliGrupComboBox.Items.Add("TOPLANTI SALONU AVİZE");
                urunTaliGrupComboBox.Items.Add("YATAKBAŞI SARKIT");


            }
            if (urunAnaGrupComboBox.Text == "LAMBADER")
            {
                urunAltGrupComboBox.Text = "";
                urunAltGrupComboBox.Items.Clear();
                urunTaliGrupComboBox.Text = "";
                urunTaliGrupComboBox.Items.Clear();
                urunAltGrupComboBox.Items.Add("GENEL MEKAN LAMBADER");
                urunAltGrupComboBox.Items.Add("ODA LAMBADER");

                urunTaliGrupComboBox.Items.Add("GENEL MEKAN LAMBADER");
                urunTaliGrupComboBox.Items.Add("ODA LAMBADER");



            }
            if (urunAnaGrupComboBox.Text == "MASA LAMBASI")
            {
                urunAltGrupComboBox.Text = "";
                urunAltGrupComboBox.Items.Clear();
                urunTaliGrupComboBox.Text = "";
                urunTaliGrupComboBox.Items.Clear();
                urunAltGrupComboBox.Items.Add("GENEL MEKAN MASA LAMBASI");
                urunAltGrupComboBox.Items.Add("ODA MASA LAMBASI");


                urunTaliGrupComboBox.Items.Add("GENEL MEKAN MASA LAMBASI");
                urunTaliGrupComboBox.Items.Add("ODA MASA LAMBASI");
                urunTaliGrupComboBox.Items.Add("ÇALIŞMA MASA LAMBASI");

            }
            if (urunAnaGrupComboBox.Text == "PLAFONYER")
            {
                urunAltGrupComboBox.Text = "";
                urunAltGrupComboBox.Items.Clear();
                urunTaliGrupComboBox.Text = "";
                urunTaliGrupComboBox.Items.Clear();
                urunAltGrupComboBox.Items.Add("BANYO PLAFONYER");
                urunAltGrupComboBox.Items.Add("DIŞ MEKAN PLAFONYER");
                urunAltGrupComboBox.Items.Add("GENEL MEKAN PLAFONYER");
                urunAltGrupComboBox.Items.Add("ODA PLAFONYER");



                //  tali alt grup ana gruba gore degısecek oldugu ıcın burada hazırlanıyor 

                urunTaliGrupComboBox.Items.Add("BALKON PLAFONYER");
                urunTaliGrupComboBox.Items.Add("BANYO PLAFONYER");
                urunTaliGrupComboBox.Items.Add("DIŞ MEKAN PLAFONYER");
                urunTaliGrupComboBox.Items.Add("GENEL MEKAN PLAFONYER");
                urunTaliGrupComboBox.Items.Add("ODA PLAFONYER");


            }
            if (urunAnaGrupComboBox.Text == "SARKIT")
            {
                urunAltGrupComboBox.Text = "";
                urunAltGrupComboBox.Items.Clear();
                urunTaliGrupComboBox.Text = "";
                urunTaliGrupComboBox.Items.Clear();
                //  tali alt grup ana gruba gore degısecek oldugu ıcın burada hazırlanıyor 

                urunTaliGrupComboBox.Items.Add("AVİZE");
                urunTaliGrupComboBox.Items.Add("BAR ÜSTÜ SARKIT");
                urunTaliGrupComboBox.Items.Add("BİLARDO SARKIT");
                urunTaliGrupComboBox.Items.Add("GENEL MEKAN AVİZE");
                urunTaliGrupComboBox.Items.Add("GENEL MEKAN SARKIT");
                urunTaliGrupComboBox.Items.Add("OFİS SARKITLARI");
                urunTaliGrupComboBox.Items.Add("RESEPSİYON BANKOSU SARKIT");
                urunTaliGrupComboBox.Items.Add("SPA & HAMAM SARKIT");
                urunTaliGrupComboBox.Items.Add("TOPLANTI SALONU AVİZE");
                urunTaliGrupComboBox.Items.Add("YATAKBAŞI SARKIT");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
          //  pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            panel1.Visible = false;
            pictureBox2.ImageLocation = "";
        }

        private void urunAgaciDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox2.Visible = true;
            panel1.Visible = true;
            pictureBox2.ImageLocation = urunResmiTextBox.Text;
        }

        private void urunAgaciDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            pictureBox2.Visible = true;
            panel1.Visible = true;
            pictureBox2.ImageLocation = urunResmiTextBox.Text;
        }

        private void urunAgaciDataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            pictureBox2.Visible = true;
            panel1.Visible = true;
            pictureBox2.ImageLocation = urunResmiTextBox.Text;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            panel1.Visible = false;
            pictureBox2.ImageLocation = "";


            string UrunResmiBul = "";
            openFileDialog1.Reset();
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName.ToString() != "")
            {
                UrunResmiBul = openFileDialog1.FileName.ToString();
              //  MessageBox.Show(UrunResmiBul);

                string name = Path.GetFileName(UrunResmiBul.ToString());
                string nameKey = Path.GetFileNameWithoutExtension(UrunResmiBul.ToString());
                string directory = Path.GetDirectoryName(UrunResmiBul.ToString());
                string fileName = name;
                string sourcePath = @directory;
                //    string targetPath = @"\\192.168.1.180\projedata\PROJE\" + teknikProjeAdiTextBox.Text.ToString();
                string targetPath = @"\\SQLSERVER\MALIYET\URUNLER\RESIMLER\" + urunAnaGrupComboBox.Text.ToString() + @"\";

               // MessageBox.Show(targetPath + name);
               // string sourceFile = System.IO.Path.Combine(sourcePath, fileName);

                // bazi sistemlerde ing dosya ismi istiyor alt satir cok onemli   Erdal Erol
                // Dosya isminde turkce karakter var ise iptal ediyor

               string destFile = System.IO.Path.Combine(targetPath,  fileName );
              // MessageBox.Show(destFile);
             //   if (!System.IO.Directory.Exists(targetPath))
             //   {
             //       System.IO.Directory.CreateDirectory(targetPath);
             //   }
             //   System.IO.File.Copy(sourceFile, destFile, true);
                // aha burada turkce karakter problemi oluyor
           //     urunResmiTextBox.Text = destFile;

                //    MessageBox.Show(destFile);
                //   secilen dosya resim ise picture box icerisinde gozukecektir        // 
                //pictureBoxUretimDosyaResim.ImageLocation = openFileDialog1.FileName;
                // pictureBoxUretimDosyaResim.SizeMode = PictureBoxSizeMode.StretchImage;
                ///   BURADAN ITIBAREN DOSYA BIRLIKTE AC ISLEMI YAPILIYOR
                ///   
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                // proc.StartInfo.FileName = Application.StartupPath + teknikDosyaTextBox.Text;
                proc.StartInfo.FileName = destFile.ToString();
                try
                {
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                    UrunResmiBul = destFile;
                  //  this.urunAgaciTableAdapter.Fill(this.mALIYETDataSet1.UrunAgaci);
                //    pictureBox1.ImageLocation = urunResmiTextBox.Text;
                 //   pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                   
                    try
                    {
                     //   this.urunAgaciTableAdapter.UrunAnaGrup(this.mALIYETDataSet1.UrunAgaci, aUrunAnaGrupToolStripTextBox.Text);
                        this.urunAgaciTableAdapter.UrunResmi(this.mALIYETDataSet1.UrunAgaci, UrunResmiBul);
                        pictureBox1.ImageLocation = urunResmiTextBox.Text;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (System.Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
                catch
                {
                    MessageBox.Show(proc.StartInfo.FileName);
                    MessageBox.Show("Şu anda bir dosya bulunmamaktadır.");
                }
            }
        }

      
    }
}
 

 
