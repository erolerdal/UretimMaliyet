using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaliyetProgram
{
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }

        public static string Musteri_CariRowId;
        public static string Musteri_CariKodu;
        public static string Musteri_CariAdi;


        private void cariBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cariBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.musteriDataSet);

        }

        private void Musteri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'musteriDataSet.Cari' table. You can move, or remove it, as needed.
            this.cariTableAdapter.Fill(this.musteriDataSet.Cari);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.cariTableAdapter.CariKodu (this.musteriDataSet.Cari,cariKoduTextBox.Text  );
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

                 Musteri_CariRowId=cariiRowIdTextBox.Text ;
         Musteri_CariKodu=cariKoduTextBox.Text ;
         Musteri_CariAdi=cariAdiTextBox.Text ;
            MustariMaliyetCalisma MusteriMaliyetCalismaFormu = new MustariMaliyetCalisma();
            MusteriMaliyetCalismaFormu.Show();

/*
            UrunAgaci UrunAgciFormu = new UrunAgaci();
            UrunAgciFormu.Show();   */
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            Musteri_CariKodu = cariKoduTextBox.Text;

            Form2 newform = new Form2();
            newform.ShowDialog();


            /*
            
            MusteriVerilenTeklifler MusteriVerilenTekliflerFormu = new MusteriVerilenTeklifler();
            MusteriVerilenTekliflerFormu.Show();   */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.cariTableAdapter.CariAdi(this.musteriDataSet.Cari, cariAdiTextBox.Text );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.cariTableAdapter.Yetkili(this.musteriDataSet.Cari, yetkiliTextBox.Text );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.cariTableAdapter.Aciklama(this.musteriDataSet.Cari, aciklamaRichTextBox.Text );
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.cariTableAdapter.MerkezIl (this.musteriDataSet.Cari,merkezadresTextBox.Text );
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.cariTableAdapter.SantiyeIl (this.musteriDataSet.Cari, santiyeIlTextBox.Text );
        }
    }
}
