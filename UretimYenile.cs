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
    public partial class UretimYenile : Form
    {
        public UretimYenile()
        {
            InitializeComponent();
        }

        private void UretimYenile_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mALIYETDataSet3.Doviz' table. You can move, or remove it, as needed.
            this.dovizTableAdapter.Fill(this.mALIYETDataSet3.Doviz);
            MlzmId.Text = StokKart.MLZid;
            Kodu.Text = StokKart.kodu;
            Adi.Text = StokKart.adi;
            Fiyati.Text = StokKart.birimfiyati;
            DovizFiyati.Text = StokKart.DovizFiyati;
            malzemeOlcuBrimi1ComboBox.Text = StokKart.Olcu1;
            malzemeOlcuBrimi2ComboBox.Text = StokKart.Olcu2;
            malzemeOlcuBrimi3ComboBox.Text = StokKart.Olcu3;
            malzemeCarpan2TextBox.Text = StokKart.Carpan2;
            malzemeCarpan3TextBox.Text = StokKart.Carpan3;
            malzemeBolen2TextBox.Text = StokKart.Bolen2;
            malzemeBolen3TextBox.Text = StokKart.Bolen3;
            StokKartDovizTipi.Text  = StokKart.DovizTipi;

            this.urunReceteBindingSource.MoveNext();

            try
            {
                this.urunReceteTableAdapter.MalzemeUpdate(this.mALIYETDataSet2.UrunRecete, ((int)(System.Convert.ChangeType(MlzmId.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void urunReceteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.urunReceteBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.mALIYETDataSet2);

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
        private void malzemeUpdateToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.urunReceteTableAdapter.MalzemeUpdate(this.mALIYETDataSet2.UrunRecete, ((int)(System.Convert.ChangeType(mMalzemeIdToolStripTextBox.Text, typeof(int)))));
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            

            
         //      this.urunReceteBindingSource.MoveFirst();

               Kodu.Text = StokKart.kodu;  //  Kodu değişmiş olabilie
               malzemeKoduTextBox.Text = StokKart.kodu;
               malzemeAdiTextBox.Text = Adi.Text; // adi değişmiş olabilir
               malzemeResmiTextBox.Text = StokKart.SMalzemeResmi;

               this.Validate();
               this.urunReceteBindingSource.EndEdit();
               this.tableAdapterManager.UpdateAll(this.mALIYETDataSet2);

            //   if (urunReceteBindingSource.Position + 1 < urunReceteBindingSource.Count)
                   urunReceteBindingSource.MoveNext();
           
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // ilk kayda ulaşır 
            this.urunReceteBindingSource.MoveFirst();
          //  recete datagrid tamamini tarar   
            for (int i = 0; i < urunReceteBindingSource.Count; i++)
            {
                Kodu.Text = StokKart.kodu;  //  Kodu değişmiş olabilie
                malzemeKoduTextBox.Text = StokKart.kodu;
                malzemeAdiTextBox.Text = Adi.Text; // adi değişmiş olabilir
                malzemeResmiTextBox.Text = StokKart.SMalzemeResmi;
                // Bulunduğun kaydı Kaydet
                this.Validate();
                this.urunReceteBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.mALIYETDataSet2);
                //   bir sonraki kayda gec

                if (urunReceteBindingSource.Position + 1 < urunReceteBindingSource.Count)
                    urunReceteBindingSource.MoveNext();
                // this.urunReceteBindingSource.MoveNext();
            }
            MessageBox.Show("Bu Malzeme kullanıldığı tüm Ürünlerde değişikliği yapılmıştır :");
        }

        private void urunReceteDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
