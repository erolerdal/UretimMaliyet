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
    public partial class MustariMaliyetCalisma : Form
    {
        public MustariMaliyetCalisma()
        {
            InitializeComponent();
        }
        public static string Musteri_CariRowId;
        public static string Musteri_CariKodu;
        public static string Musteri_CariAdi;
        public static string Musteri_Cari_Referans;


        private void MustariMaliyetCalisma_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mALIYETDataSet1.UrunAgaci' table. You can move, or remove it, as needed.
            this.urunAgaciTableAdapter.Fill(this.mALIYETDataSet1.UrunAgaci);
            textBox1.Text = Musteri.Musteri_CariRowId;
            textBox2.Text = Musteri.Musteri_CariKodu;
            textBox3.Text = Musteri.Musteri_CariAdi;
            // TODO: This line of code loads data into the 'musteriMaliyetBaslik.CariMaliyetCalismaBaslik' table. You can move, or remove it, as needed.
            this.cariMaliyetCalismaBaslikTableAdapter.Fill(this.musteriMaliyetBaslik.CariMaliyetCalismaBaslik, Convert.ToInt32(   textBox1.Text));
            // TODO: This line of code loads data into the 'musteriMaliyetSatir.CariMaliyetCalismaSatir' table. You can move, or remove it, as needed.
            this.cariMaliyetCalismaSatirTableAdapter.Fill(this.musteriMaliyetSatir.CariMaliyetCalismaSatir,Convert.ToInt32( cariMaliyetCalismaBaslikRowIdTextBox.Text));
        }
        private void cariMaliyetCalismaBaslikBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            cariiRowIdTextBox.Text = textBox1.Text;
            this.Validate();
            this.cariMaliyetCalismaBaslikBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.musteriMaliyetBaslik);
        }
        private void cariMaliyetCalismaSatirBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            cariMaliyetCalismaBaslikIdTextBox.Text = cariMaliyetCalismaBaslikRowIdTextBox.Text.ToString();
            this.Validate();
            this.cariMaliyetCalismaSatirBindingSource.EndEdit();
            this.tableAdapterManager1.UpdateAll(this.musteriMaliyetSatir);
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
        //    MessageBox.Show(cariMaliyetCalismaBaslikRowIdTextBox.Text + " yeni kayıt yapiliyor");
            cariMaliyetCalismaBaslikIdTextBox.Text  = cariMaliyetCalismaBaslikRowIdTextBox.Text.ToString();
        //    MessageBox.Show(cariMaliyetCalismaBaslikIdTextBox.Text + " yeni kayıt yapiliyor");
        }
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            cariiRowIdTextBox.Text = textBox1.Text;
        }
        private void cariMaliyetCalismaBaslikRowIdTextBox_TextChanged(object sender, EventArgs e)
        {
            this.cariMaliyetCalismaSatirTableAdapter.Fill(this.musteriMaliyetSatir.CariMaliyetCalismaSatir, Convert.ToInt32(cariMaliyetCalismaBaslikRowIdTextBox.Text));
        }
        private void urunIdTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunId(this.mALIYETDataSet1.UrunAgaci, Convert.ToInt32(urunIdTextBox.Text));
                pictureBox1.Image = Image.FromFile(dataGridView1.CurrentRow.Cells[10].Value.ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(dataGridView1.CurrentRow.Cells[10].Value.ToString());
          pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            urunIdTextBox.Text=     dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        private void urunIdToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunId(this.mALIYETDataSet1.UrunAgaci, ((int)(System.Convert.ChangeType(urunIdTextBox.Text , typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

      

     

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunAgaciTableAdapter.UrunKodu(this.mALIYETDataSet1.UrunAgaci,textBox5.Text);
                pictureBox1.Image = Image.FromFile(dataGridView1.CurrentRow.Cells[10].Value.ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
             
                this.urunAgaciTableAdapter.UrunAdi(this.mALIYETDataSet1.UrunAgaci, textBox6.Text);
                pictureBox1.Image = Image.FromFile(dataGridView1.CurrentRow.Cells[10].Value.ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                pictureBox1.Image = Image.FromFile(dataGridView1.CurrentRow.Cells[10].Value.ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch
            {
            }

        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
             try
            {
            pictureBox1.Image = Image.FromFile(dataGridView1.CurrentRow.Cells[10].Value.ToString());
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
             catch
             {
             }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Musteri_CariKodu = textBox2.Text;
            Musteri_Cari_Referans=cariMaliyetCalismaBaslikDataGridView.CurrentRow.Cells[0].Value.ToString();
           
            MusteriVerilenTekliflerTarih newform = new MusteriVerilenTekliflerTarih();
            newform.ShowDialog();

        }
    }
}
