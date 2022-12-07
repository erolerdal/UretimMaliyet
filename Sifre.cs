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
    public partial class Sifre: Form
    {
        public Sifre()
        {
            InitializeComponent();
        }
        private void Sifre_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
           string Kullanici;
            string sifre;
            Kullanici = textBox1.Text ;
            sifre = textBox2.Text ;
            textBox2.Text="";
             if (Kullanici == "Hulya" && sifre == "9529885")
            {
                // this.Hide(); 
            
                         StokKart  form = new StokKart();
                         form.Show();
          }
          else
          {
            this.Close();
           }
    
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Sifre_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }  
}
