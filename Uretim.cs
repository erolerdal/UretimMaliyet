    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
/*  textbox boş ise 0 değeri atamak

                int toplam=0;
                toplam+=int.Parse(string.IsNullOrEmpty(textBox1.text)?"0":textBox1.Text);
 * 
 *  textbox boş ise
 * 
 *              if (string.IsNullOrEmpty(textbox1.text) == true)
 *              { textbox1.text="0";}

*/

namespace MaliyetProgram
    {
    public partial class Uretim : Form
    {
        public Uretim()
        {
            InitializeComponent();
        }
            public int OUId=0;
            public int kopyala = -1;
            public int yapistir= -1;
        private void Uretim_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mALIYETDataSet3.Doviz' table. You can move, or remove it, as needed.
            this.dovizTableAdapter.Fill(this.mALIYETDataSet3.Doviz);
            

        //    MessageBox.Show(UrunAgaci.OrtakUrunAdi);
            
            urunIdTextBox.Text =UrunAgaci. OrtakUrunId  ;
            urunKoduTextBox.Text =   UrunAgaci.  OrtakUrunKodu  ;
            revizyonNoTextBox.Text =UrunAgaci.  OrtakRevizyonNo  ;
            urunAdiTextBox.Text = UrunAgaci. OrtakUrunAdi ;
            OUId = Convert.ToInt32(this.urunIdTextBox.Text);

            // TODO: This line of code loads data into the 'mALIYETDataSet.StokKart' table. You can move, or remove it, as needed.
            this.stokKartTableAdapter.Fill(this.mALIYETDataSet.StokKart);
            // TODO: This line of code loads data into the 'mALIYETDataSet2.UrunRecete' table. You can move, or remove it, as needed.
            this.urunReceteTableAdapter.Fill(this.mALIYETDataSet2.UrunRecete,  OUId );
       

        }

        private void urunReceteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {


            DialogResult dr;
            dr = MessageBox.Show("Eminmisiniz ?\nKayıt İşlemi Gerçekleşiyor", "Kayıt İşlemi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {


                try
                {

                    this.Validate();
                    this.urunReceteBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.mALIYETDataSet2);

                }
                catch
                {
                    MessageBox.Show("Lutfen Kayit Alanlarini Bos Birakmayin");
                }

            }
            else
            {
                {

                    this.urunReceteTableAdapter.Fill(this.mALIYETDataSet2.UrunRecete, OUId);

                    pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
            }

        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DialogResult dr;
            dr = MessageBox.Show("Eminmisiniz ?\nBu Malzeme Ürün Ağacına İşleniyor", " Kayıt Aktarma İşlemi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {

                try
                {
                        olcuBirimiComboBox.Items.Clear();
                        olcuBirimiComboBox.Items.Add(MalzemeGridView2.CurrentRow.Cells[9].Value.ToString());
                        olcuBirimiComboBox.Items.Add(MalzemeGridView2.CurrentRow.Cells[10].Value.ToString());
                        olcuBirimiComboBox.Items.Add(MalzemeGridView2.CurrentRow.Cells[11].Value.ToString());
                        orjMalzemeOlcuBrim1TextBox.Text=    MalzemeGridView2.CurrentRow.Cells[9].Value.ToString();
                        orjMalzemeOlcuBrim2TextBox.Text=   MalzemeGridView2.CurrentRow.Cells[10].Value.ToString();
                        orjMalzemeOlcuBrim3TextBox.Text=   MalzemeGridView2.CurrentRow.Cells[11].Value.ToString();

                        orjMalzemeCarpan2TextBox.Text = MalzemeGridView2.CurrentRow.Cells[12].Value.ToString();
                        orjMalzemeCarpan3TextBox.Text = MalzemeGridView2.CurrentRow.Cells[13].Value.ToString();
                        orjMalzemeBolen2TextBox.Text = MalzemeGridView2.CurrentRow.Cells[14].Value.ToString();
                        orjMalzemeBolen3TextBox.Text = MalzemeGridView2.CurrentRow.Cells[15].Value.ToString();
                        orjSonAlisFiyatiTextBox.Text  = MalzemeGridView2.CurrentRow.Cells[22].Value.ToString();

                        dovizCinsiTextBox.Text = MalzemeGridView2.CurrentRow.Cells[23].Value.ToString();
                        orjSonDovizAlisFiyatiTextBox.Text    = MalzemeGridView2.CurrentRow.Cells[24].Value.ToString();

                    
                        malzemeIdTextBox.Text = MalzemeGridView2.CurrentRow.Cells[0].Value.ToString();
                        malzemeKoduTextBox.Text = MalzemeGridView2.CurrentRow.Cells[1].Value.ToString();
                        malzemeAdiTextBox.Text = MalzemeGridView2.CurrentRow.Cells[2].Value.ToString();
                        malzemeResmiTextBox.Text = MalzemeGridView2.CurrentRow.Cells[8].Value.ToString();


                        pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                catch
                {
                    MessageBox.Show("Aktarma İşlemi Gerçekleşmedi ");
                }

            }
            else
            {
                {

                }
            } 
            

        //     olcuBirimiTextBox.Text = MalzemeGridView2.CurrentRow.Cells[9].Value.ToString();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            urunIdTextBox.Text = UrunAgaci.OrtakUrunId;
            urunKoduTextBox.Text = UrunAgaci.OrtakUrunKodu;
            revizyonNoTextBox.Text = UrunAgaci.OrtakRevizyonNo;
            urunAdiTextBox.Text = UrunAgaci.OrtakUrunAdi;
            ilavebrimtutaryuzdeTextBox.Text = "0";
            ilavebrimolcuyuzdeTextBox.Text = "0";
            yapiştırToolStripMenuItem.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            aMalzemeKoduToolStripTextBox.Text = textBox5.Text;
            textBox6.Text = "";
            try
            {
                this.stokKartTableAdapter.FillBy(this.mALIYETDataSet.StokKart, aMalzemeKoduToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void fillBy11ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.stokKartTableAdapter.FillBy11(this.mALIYETDataSet.StokKart, aMalzemeKoduToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            aMalzemeKoduToolStripTextBox.Text = textBox6.Text;
            textBox5.Text = "";
            try
            {
                this.stokKartTableAdapter.MalzemeAdiAramak(this.mALIYETDataSet.StokKart, aMalzemeKoduToolStripTextBox.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void malzemeResmiTextBox_TextChanged(object sender, EventArgs e)
        {
    /*
            malzemeOlcuBrimi1TextBox.Text = "";
            malzemeOlcuBrimi2TextBox.Text = "";
            malzemeOlcuBrimi3TextBox.Text = "";
            malzemeBolen2TextBox.Text = "";
            malzemeBolen3TextBox.Text = "";
            malzemeCarpan2TextBox.Text = "";
            malzemeCarpan3TextBox.Text = "";
   */
            /*
            try
            {
                pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                if (Convert.ToDecimal(brimTutariTextBox.Text) == 0)
                {
                    brimTutariTextBox.BackColor = Color.Yellow;

                }
                else
                {
                    brimTutariTextBox.BackColor = Color.White;

                }
            }
            catch
            {
            }

*/
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Eminmisiniz ?\nİşlemi İptal ile Sonlandırabilirsiniz", "Silme İşlemi", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                //saklama islemi yapiliyor
                try
                {
                    this.Validate();
                    this.urunReceteBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.mALIYETDataSet2);
                }
                catch
                {
                    MessageBox.Show("Silme İşleminde Hata");
                }
            }
            else
            {
                OUId = Convert.ToInt32(this.urunIdTextBox.Text);
                this.urunReceteTableAdapter.Fill(this.mALIYETDataSet2.UrunRecete, OUId);
                pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                MessageBox.Show("Deletion Cancelled");
            }
        }

        private void malzemeKoduTextBox_TextChanged(object sender, EventArgs e)
        {
           
        /*    
            malzemeOlcuBrimi1TextBox.Text = "";
            malzemeOlcuBrimi2TextBox.Text = "";
            malzemeOlcuBrimi3TextBox.Text = "";
            malzemeBolen2TextBox.Text = "";
            malzemeBolen3TextBox.Text = "";
            malzemeCarpan2TextBox.Text = "";
            malzemeCarpan3TextBox.Text = "";
            * */

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.stokKartTableAdapter.Tekmalzeme (this.mALIYETDataSet.StokKart, malzemeKoduTextBox.Text );
        }

        private void olcuBirimiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                brimTutariTextBox.Text = "0";
                birimDovizTutarTextBox.Text = "0";

                // orj son aliş fiyatı tl ye cevrilecekdir .....
                //

                //
                double kur = 0;

                for (int i = 0; i < dovizDataGridView.RowCount; i++)
                {
                    if (dovizCinsiTextBox.Text.Trim() == dovizDataGridView.Rows[i].Cells[0].Value.ToString())
                    {

                        //        try
                        //           {

                        kur = Convert.ToDouble(dovizDataGridView.Rows[i].Cells[1].Value.ToString());
                        // MessageBox.Show(dovizDataGridView.Rows[i].Cells[1].Value.ToString());
                        //         }
                        //        catch
                        //         {
                        //         }
                    }
                    else
                    {
                    }
                }
                if (kur == 0) kur = 1;
                //  MessageBox.Show(olcuBirimiComboBox.Text );
                //    olcu biririmi ve kullanım kiktarı hesaplama işlemi   
                if (olcuBirimiComboBox.Text == orjMalzemeOlcuBrim1TextBox.Text)
                {   //  olcu brimi orjinal birim ile aynı ise
                    brimTutariTextBox.Text = (Convert.ToDouble(orjSonAlisFiyatiTextBox.Text) * kur).ToString();
                }
                if (olcuBirimiComboBox.Text == orjMalzemeOlcuBrim2TextBox.Text)
                {   //  olcu brimi 2. brim secildi ise
                    if (Convert.ToDouble(orjMalzemeBolen2TextBox.Text) > 0)
                    {
                        brimTutariTextBox.Text = (Convert.ToDouble((Convert.ToDouble(orjSonAlisFiyatiTextBox.Text) * kur).ToString()) / Convert.ToDouble(orjMalzemeBolen2TextBox.Text)).ToString();
                    }
                    else
                    {
                        if (Convert.ToDouble(orjMalzemeCarpan2TextBox.Text) > 0)
                        {
                            brimTutariTextBox.Text = (Convert.ToDouble((Convert.ToDouble(orjSonAlisFiyatiTextBox.Text) * kur).ToString()) * Convert.ToDouble(orjMalzemeCarpan2TextBox.Text)).ToString();
                        }
                        else
                        {
                        }
                    }
                }
                if (olcuBirimiComboBox.Text == orjMalzemeOlcuBrim3TextBox.Text)
                {   //  olcu brimi 3. brim secildi ise
                    if (Convert.ToDouble(orjMalzemeBolen3TextBox.Text) > 0)
                    {
                        brimTutariTextBox.Text = (Convert.ToDouble((Convert.ToDouble(orjSonAlisFiyatiTextBox.Text) * kur).ToString()) / Convert.ToDouble(orjMalzemeBolen3TextBox.Text)).ToString();
                    }
                    if (Convert.ToDouble(orjMalzemeCarpan3TextBox.Text) > 0)
                    {
                        brimTutariTextBox.Text = (Convert.ToDouble((Convert.ToDouble(orjSonAlisFiyatiTextBox.Text) * kur).ToString()) * Convert.ToDouble(orjMalzemeCarpan3TextBox.Text)).ToString();
                    }
                }
            }
            catch
            {
            }

        }
        private void kullanimMiktariTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(brimTutariTextBox.Text) > 0 || Convert.ToDouble(kullanimMiktariTextBox.Text) > 0)
                {
                    toplamTutarTextBox.Text = (Convert.ToDouble(brimTutariTextBox.Text) * Convert.ToDouble(kullanimMiktariTextBox.Text)).ToString();        
                    toplamTutarTextBox.Text = (Convert.ToDouble(brimTutariTextBox.Text) * Convert.ToDouble(kullanimMiktariTextBox.Text) * Convert.ToDouble(ilavebrimtutaryuzdeTextBox.Text) / 100 + Convert.ToDouble(toplamTutarTextBox.Text)).ToString();
                    toplamTutarTextBox.Text = (Convert.ToDouble(brimTutariTextBox.Text) * Convert.ToDouble(kullanimMiktariTextBox.Text) * Convert.ToDouble(ilavebrimolcuyuzdeTextBox.Text) / 100 + Convert.ToDouble(toplamTutarTextBox.Text)).ToString();
               
                }
            }
            catch
            {
                //  MessageBox.Show (" Kullanilan malzeme ve Brim tutar girisinde HATA var !! ");
            }
        }
        public void Hesapla()
        {

            try
            {

    
            olcuBirimiComboBox.Items.Clear();
            olcuBirimiComboBox.Items.Add(MalzemeGridView2.CurrentRow.Cells[9].Value.ToString());
            olcuBirimiComboBox.Items.Add(MalzemeGridView2.CurrentRow.Cells[10].Value.ToString());
            olcuBirimiComboBox.Items.Add(MalzemeGridView2.CurrentRow.Cells[11].Value.ToString());
            orjMalzemeOlcuBrim1TextBox.Text = MalzemeGridView2.CurrentRow.Cells[9].Value.ToString();
            orjMalzemeOlcuBrim2TextBox.Text = MalzemeGridView2.CurrentRow.Cells[10].Value.ToString();
            orjMalzemeOlcuBrim3TextBox.Text = MalzemeGridView2.CurrentRow.Cells[11].Value.ToString();

            orjMalzemeCarpan2TextBox.Text = MalzemeGridView2.CurrentRow.Cells[12].Value.ToString();
            orjMalzemeCarpan3TextBox.Text = MalzemeGridView2.CurrentRow.Cells[13].Value.ToString();
            orjMalzemeBolen2TextBox.Text = MalzemeGridView2.CurrentRow.Cells[14].Value.ToString();
            orjMalzemeBolen3TextBox.Text = MalzemeGridView2.CurrentRow.Cells[15].Value.ToString();
            orjSonAlisFiyatiTextBox.Text = MalzemeGridView2.CurrentRow.Cells[22].Value.ToString();

            dovizCinsiTextBox.Text = MalzemeGridView2.CurrentRow.Cells[23].Value.ToString();
            orjSonDovizAlisFiyatiTextBox.Text = MalzemeGridView2.CurrentRow.Cells[24].Value.ToString();


            malzemeIdTextBox.Text = MalzemeGridView2.CurrentRow.Cells[0].Value.ToString();
            malzemeKoduTextBox.Text = MalzemeGridView2.CurrentRow.Cells[1].Value.ToString();
            malzemeAdiTextBox.Text = MalzemeGridView2.CurrentRow.Cells[2].Value.ToString();
            malzemeResmiTextBox.Text = MalzemeGridView2.CurrentRow.Cells[8].Value.ToString();


            if (string.IsNullOrEmpty(ilavebrimtutaryuzdeTextBox.Text) == true) { ilavebrimtutaryuzdeTextBox.Text = "0"; }
            if (string.IsNullOrEmpty(ilavebrimolcuyuzdeTextBox.Text) == true) { ilavebrimolcuyuzdeTextBox.Text = "0"; }
            if (string.IsNullOrEmpty(toplamTutarTextBox.Text) == true) { toplamTutarTextBox.Text = "0"; }
        


            brimTutariTextBox.Text = "0";
                

                // orj son aliş fiyatı tl ye cevrilecekdir .....
                //

                //
                double kur = 0;

                for (int i = 0; i < dovizDataGridView.RowCount; i++)
                {
                    if (dovizCinsiTextBox.Text.Trim() == dovizDataGridView.Rows[i].Cells[0].Value.ToString())
                    {

                        try
                        {

                            kur = Convert.ToDouble(dovizDataGridView.Rows[i].Cells[1].Value.ToString());
                            // MessageBox.Show(dovizDataGridView.Rows[i].Cells[1].Value.ToString());
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
                //  MessageBox.Show(olcuBirimiComboBox.Text );
                //    olcu biririmi ve kullanım kiktarı hesaplama işlemi   
                if (olcuBirimiComboBox.Text == orjMalzemeOlcuBrim1TextBox.Text)
                {   //  olcu brimi orjinal birim ile aynı ise
                    brimTutariTextBox.Text = (Convert.ToDouble(orjSonAlisFiyatiTextBox.Text) * kur).ToString();
                }
                if (olcuBirimiComboBox.Text == orjMalzemeOlcuBrim2TextBox.Text)
                {   //  olcu brimi 2. brim secildi ise
                    if (Convert.ToDouble(orjMalzemeBolen2TextBox.Text) > 0)
                    {
                        brimTutariTextBox.Text = (Convert.ToDouble((Convert.ToDouble(orjSonAlisFiyatiTextBox.Text) * kur).ToString()) / Convert.ToDouble(orjMalzemeBolen2TextBox.Text)).ToString();
                    }
                    else
                    {
                        if (Convert.ToDouble(orjMalzemeCarpan2TextBox.Text) > 0)
                        {
                            brimTutariTextBox.Text = (Convert.ToDouble((Convert.ToDouble(orjSonAlisFiyatiTextBox.Text) * kur).ToString()) * Convert.ToDouble(orjMalzemeCarpan2TextBox.Text)).ToString();
                        }
                        else
                        {
                        }
                    }
                }
                if (olcuBirimiComboBox.Text == orjMalzemeOlcuBrim3TextBox.Text)
                {   //  olcu brimi 3. brim secildi ise
                    if (Convert.ToDouble(orjMalzemeBolen3TextBox.Text) > 0)
                    {
                        brimTutariTextBox.Text = (Convert.ToDouble((Convert.ToDouble(orjSonAlisFiyatiTextBox.Text) * kur).ToString()) / Convert.ToDouble(orjMalzemeBolen3TextBox.Text)).ToString();
                    }
                    if (Convert.ToDouble(orjMalzemeCarpan3TextBox.Text) > 0)
                    {
                        brimTutariTextBox.Text = (Convert.ToDouble((Convert.ToDouble(orjSonAlisFiyatiTextBox.Text) * kur).ToString()) * Convert.ToDouble(orjMalzemeCarpan3TextBox.Text)).ToString();
                    }
                }

                if (Convert.ToDouble(brimTutariTextBox.Text) > 0 || Convert.ToDouble(kullanimMiktariTextBox.Text) > 0)
                {
                    toplamTutarTextBox.Text = (Convert.ToDouble(brimTutariTextBox.Text) * Convert.ToDouble(kullanimMiktariTextBox.Text)).ToString();
                    toplamTutarTextBox.Text = (Convert.ToDouble(brimTutariTextBox.Text) * Convert.ToDouble(kullanimMiktariTextBox.Text) * Convert.ToDouble(ilavebrimtutaryuzdeTextBox.Text) / 100 + Convert.ToDouble(toplamTutarTextBox.Text)).ToString();
                    toplamTutarTextBox.Text = (Convert.ToDouble(brimTutariTextBox.Text) * Convert.ToDouble(kullanimMiktariTextBox.Text) * Convert.ToDouble(ilavebrimolcuyuzdeTextBox.Text) / 100 + Convert.ToDouble(toplamTutarTextBox.Text)).ToString();

                }

          }
     
            catch
            {
                MessageBox.Show("Birim Fiyat Hesaplanamadi ! (Hesapla Yordami) ");
            }

           
        }

        private void ilaveadiTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void olcuBirimiComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            // klavyeden giriş yapılamasın

            e.Handled = true;
        }

        private void urunReceteDataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
       for (int i = 0; i < urunReceteDataGridView.RowCount; i++)
                {
            
            // datagrid teke düşürülecek....
            int AMalzemeId;
            AMalzemeId = Convert.ToInt16(urunReceteDataGridView.CurrentRow.Cells[17].Value);

            try
            {
                this.stokKartTableAdapter.MalzemeId(this.mALIYETDataSet.StokKart, AMalzemeId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }



                Hesapla();
             }
        }

        private void urunReceteDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int AMalzemeId;
            AMalzemeId =Convert.ToInt16( urunReceteDataGridView.CurrentRow.Cells[17].Value);       
                
            try
            {
                this.stokKartTableAdapter.MalzemeId(this.mALIYETDataSet.StokKart, AMalzemeId);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void parcaTanimiTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void yariMamulAdiComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (yariMamulAdiComboBox.Text == "BAŞLIK")
            {
                taliYariMamulAdiComboBox.Items.Clear();
                taliYariMamulAdiComboBox.Items.Add("CAM");
                taliYariMamulAdiComboBox.Items.Add("KUMAŞ");
                taliYariMamulAdiComboBox.Items.Add("BİYE");
                taliYariMamulAdiComboBox.Items.Add("HARÇ");
                taliYariMamulAdiComboBox.Items.Add("ELKAMET");
                taliYariMamulAdiComboBox.Items.Add("TEL");
                taliYariMamulAdiComboBox.Items.Add("GRİF");
                taliYariMamulAdiComboBox.Items.Add("LAMA");
                taliYariMamulAdiComboBox.Items.Add("DESEN");
                taliYariMamulAdiComboBox.Items.Add("BOYA");
                taliYariMamulAdiComboBox.Items.Add("PLEKSİ");
                taliYariMamulAdiComboBox.Items.Add("POLİPROPİLEN");
                taliYariMamulAdiComboBox.Items.Add("SIVAMA");
                taliYariMamulAdiComboBox.Items.Add("KENAR BANT");
                taliYariMamulAdiComboBox.Items.Add("BAŞLIK METALİ");
                taliYariMamulAdiComboBox.Items.Add("DİREK");

            }
            if (yariMamulAdiComboBox.Text == "GÖVDE")
            {
                taliYariMamulAdiComboBox.Items.Clear();
                taliYariMamulAdiComboBox.Items.Add("AĞIRLIK");
                taliYariMamulAdiComboBox.Items.Add("ALT PLAKA");
                taliYariMamulAdiComboBox.Items.Add("ALT TABAN");
                taliYariMamulAdiComboBox.Items.Add("ALT TABLA");
                taliYariMamulAdiComboBox.Items.Add("ARKA PLAKA");
                taliYariMamulAdiComboBox.Items.Add("BAŞLIK MODÜLÜ");
                taliYariMamulAdiComboBox.Items.Add("CAM");
                taliYariMamulAdiComboBox.Items.Add("CAM TUTUCU");
                taliYariMamulAdiComboBox.Items.Add("ÇEMBER");
                taliYariMamulAdiComboBox.Items.Add("ÇERÇEVE");
                taliYariMamulAdiComboBox.Items.Add("DESEN");
                taliYariMamulAdiComboBox.Items.Add("DESEN");
                taliYariMamulAdiComboBox.Items.Add("DİFÜZÖR");
                taliYariMamulAdiComboBox.Items.Add("DUY ALTI");
                taliYariMamulAdiComboBox.Items.Add("DUY LALESİ");
                taliYariMamulAdiComboBox.Items.Add("DUY TUTUCU");
                taliYariMamulAdiComboBox.Items.Add("GÖVDE");
                taliYariMamulAdiComboBox.Items.Add("HALAT");
                taliYariMamulAdiComboBox.Items.Add("HALAT TUTUCU");
                taliYariMamulAdiComboBox.Items.Add("KARKAS");
                taliYariMamulAdiComboBox.Items.Add("KOL");
                taliYariMamulAdiComboBox.Items.Add("KRİSTAL");
                taliYariMamulAdiComboBox.Items.Add("LED BAŞLIK");
                taliYariMamulAdiComboBox.Items.Add("LENS");
                taliYariMamulAdiComboBox.Items.Add("MAFSAL");
                taliYariMamulAdiComboBox.Items.Add("MAPA");
                taliYariMamulAdiComboBox.Items.Add("MEME");
                taliYariMamulAdiComboBox.Items.Add("MONTAJ ELEMANI");
                taliYariMamulAdiComboBox.Items.Add("ÖN PLAKA");
                taliYariMamulAdiComboBox.Items.Add("PİM");
                taliYariMamulAdiComboBox.Items.Add("PLEKSİ");
                taliYariMamulAdiComboBox.Items.Add("PUL");
                taliYariMamulAdiComboBox.Items.Add("PUL");
                taliYariMamulAdiComboBox.Items.Add("ROZANS");
                taliYariMamulAdiComboBox.Items.Add("SAÇAK");
                taliYariMamulAdiComboBox.Items.Add("TABAN");
                taliYariMamulAdiComboBox.Items.Add("TİJ");
                taliYariMamulAdiComboBox.Items.Add("ÜST PLAKA");
                taliYariMamulAdiComboBox.Items.Add("ÜST PROFİL");
                taliYariMamulAdiComboBox.Items.Add("ÜST TABLA");
                taliYariMamulAdiComboBox.Items.Add("YAN KAPAK");
                taliYariMamulAdiComboBox.Items.Add("ZİNCİR");
            }
            if (yariMamulAdiComboBox.Text == "ELEKTRİKSEL AKSAM")
            {
                taliYariMamulAdiComboBox.Items.Clear();
                taliYariMamulAdiComboBox.Items.Add("DUY");
                taliYariMamulAdiComboBox.Items.Add("LED");
                taliYariMamulAdiComboBox.Items.Add("DRIVER");
                taliYariMamulAdiComboBox.Items.Add("BALAST");
                taliYariMamulAdiComboBox.Items.Add("TRAFO");
                taliYariMamulAdiComboBox.Items.Add("AMPUL");
                taliYariMamulAdiComboBox.Items.Add("KABLO");
            }
            if (yariMamulAdiComboBox.Text == "LAZER")
            {
                taliYariMamulAdiComboBox.Items.Clear();
                taliYariMamulAdiComboBox.Items.Add("DESEN");
                taliYariMamulAdiComboBox.Items.Add("ÜST TABLA");
                taliYariMamulAdiComboBox.Items.Add("ALT TABLA");
                taliYariMamulAdiComboBox.Items.Add("ÜST PLAKA");
                taliYariMamulAdiComboBox.Items.Add("ALT PLAKA");
                taliYariMamulAdiComboBox.Items.Add("ÇERÇEVE");
                taliYariMamulAdiComboBox.Items.Add("ÇEMBER");
                taliYariMamulAdiComboBox.Items.Add("ÖN PLAKA");
                taliYariMamulAdiComboBox.Items.Add("ARKA PLAKA");
                taliYariMamulAdiComboBox.Items.Add("TABAN");
                taliYariMamulAdiComboBox.Items.Add("KARKAS");
            }

        }

        private void MalzemeGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // MessageBox.Show(MalzemeGridView2.CurrentRow.Cells[8].Value.ToString());
                panel1.Visible = true;
                //   pictureBox1.Image =Image.FromFile("resimklasoru/ustresim1.jpg"); ;
                pictureBox2.Image = Image.FromFile(MalzemeGridView2.CurrentRow.Cells[8].Value.ToString());
                //   pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
                //  pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
                panel1.Visible = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void MalzemeGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            // MessageBox.Show(MalzemeGridView2.CurrentRow.Cells[8].Value.ToString());
            panel1.Visible = true;
            //   pictureBox1.Image =Image.FromFile("resimklasoru/ustresim1.jpg"); ;
            pictureBox2.Image = Image.FromFile(MalzemeGridView2.CurrentRow.Cells[8].Value.ToString());
            //   pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
            //  pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void MalzemeGridView2_KeyUp(object sender, KeyEventArgs e)
        {
            // MessageBox.Show(MalzemeGridView2.CurrentRow.Cells[8].Value.ToString());
            panel1.Visible = true;
            //   pictureBox1.Image =Image.FromFile("resimklasoru/ustresim1.jpg"); ;
            pictureBox2.Image = Image.FromFile(MalzemeGridView2.CurrentRow.Cells[8].Value.ToString());
            //   pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
            //  pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            kopyala = urunReceteDataGridView.CurrentCell.RowIndex;
            MessageBox.Show(kopyala.ToString());
            yapiştırToolStripMenuItem.Visible = false;
            
        }

        private void yapiştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            yapistir = urunReceteDataGridView.CurrentCell.RowIndex;
            MessageBox.Show(yapistir.ToString());
            if (kopyala > -1 && yapistir > -1)
            {
                //     CopyRows(urunReceteDataGridView, kopyala, yapistir);
                //   }
                for (int j = 0; j < urunReceteDataGridView.Rows[kopyala].Cells.Count; j++)
                {
                    if (j != 12) // recete id kopyalanmasin
                    {
                        urunReceteDataGridView.Rows[yapistir].Cells[j].Value = urunReceteDataGridView.Rows[kopyala].Cells[j].Value;
                    }
                }
            }
              kopyala = -1;
            yapiştırToolStripMenuItem.Visible = false;

           

        }
        private void CopyRows(DataGridView DGVGrid, int SourceRowID, int DestinationRowID)
        {
            /*
            for (int j = 0; j < DGVGrid.Rows[SourceRowID].Cells.Count; j++)
                DGVGrid.Rows[DestinationRowID].Cells[j].Value = DGVGrid.Rows[SourceRowID].Cells[j].Value;

            */


        }

        private void brimTutariTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.ImageLocation = malzemeResmiTextBox.Text;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                if (Convert.ToDecimal(brimTutariTextBox.Text) == 0)
                {
                    brimTutariTextBox.BackColor = Color.Yellow;

                }
                else
                {
                    brimTutariTextBox.BackColor = Color.White;

                }
            }
            catch
            {
            }
        }

        private void urunReceteDataGridView_Paint(object sender, PaintEventArgs e)
        {

            try
            {
            for (int I = 0; I < urunReceteDataGridView.Rows.Count; I++)
            {

                if ( Convert.ToDecimal(   urunReceteDataGridView.Rows[I].Cells[6].Value.ToString()) == 0)
                {

                    urunReceteDataGridView.Rows[I].DefaultCellStyle.BackColor = Color.Yellow;

                    urunReceteDataGridView.Rows [I].DefaultCellStyle.ForeColor = Color.Black;

                }

                else
                {

                    urunReceteDataGridView.Rows [I].DefaultCellStyle.BackColor = Color.White ;

                    urunReceteDataGridView.Rows [I].DefaultCellStyle.ForeColor = Color.Black;

                }

            }


             }
            catch
            {
            }





        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
            for (int j = 0; j < DGVGrid.Rows[SourceRowID].Cells.Count; j++)
            DGVGrid.Rows[DestinationRowID].Cells[j].Value = DGVGrid.Rows[SourceRowID].Cells[j].Value;
}
             */

        }
    }
    }
  
