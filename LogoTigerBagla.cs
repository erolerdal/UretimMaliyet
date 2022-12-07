
/*
 * USE [MALIYET]
GO

/****** Object:  Table [dbo].[LogoItemsBagla]    Script Date: 05/19/2015 21:55:48 ***** 
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LogoItemsBagla](
	[LogoBaglaID] [int] IDENTITY(1,1) NOT NULL,
	[MalzemeId] [int] NOT NULL,
	[LogoLogicalref] [int] NOT NULL,
	[Brim1] [varchar](20) NULL,
	[Brim2] [varchar](20) NULL,
	[Brim3] [varchar](20) NULL,
 CONSTRAINT [PK_LogoItemsBagla] PRIMARY KEY CLUSTERED 
(
	[LogoBaglaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MaliyetProgram
{
    public partial class LogoTigerBagla : Form
    {
        public LogoTigerBagla()
        {
            InitializeComponent();
        }

        private void LogoTigerBagla_Load(object sender, EventArgs e)
        {
            label14.Text = StokKart.MLZid;
            label3.Text = StokKart.baglantiismi;
            islemebasla();
        }

        private void islemebasla()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;

            checkBox8.Checked = false;

            var sorgu = string.Empty;
            var where = string.Empty;
            int i = 0;
           // sorgu = sorgu + "select LOGICALREF,CODE,NAME from LG_001_ITEMS where NAME LIKE ";


            sorgu = sorgu + "     SELECT     ITEMS.LOGICALREF, ITEMS.CODE, ITEMS.NAME, UNITSETF.CODE AS UNITSETF_CODE, UNITSETF.NAME AS UNITSETF_NAME,  ";
            sorgu = sorgu + "                           UNITSETF.SPECODE AS UNITSETF_SPECODE, UNITSETF.CYPHCODE AS UNITSETF_CYPHCODE, UNITSETL.CODE AS UNITSETL_CODE,  ";
            sorgu = sorgu + "                           UNITSETL.NAME AS UNITSETL_NAME,  ";
            sorgu = sorgu + "                           CASE WHEN ITMUNITA_2.CONVFACT2 > 0 and ITMUNITA_2.CONVFACT1 > 0 THEN ITMUNITA_2.CONVFACT2 / ITMUNITA_2.CONVFACT1 ELSE 0 END AS ITMUNITA_2_KATSAYI,  ";
            sorgu = sorgu + "                           UNITSETL_2.CODE AS UNITSETL_2_CODE, UNITSETL_2.NAME AS UNITSETL_2_NAME,  ";
            sorgu = sorgu + "                           CASE WHEN ITMUNITA_3.CONVFACT2 > 0 and ITMUNITA_3.CONVFACT1 > 0 THEN ITMUNITA_3.CONVFACT2 / ITMUNITA_3.CONVFACT1 ELSE 0 END AS ITMUNITA_3_KATSAYI,  ";
            sorgu = sorgu + "                           UNITSETL_3.CODE AS UNITSETL_3_CODE, UNITSETL_3.NAME AS UNITSETL_3_NAME, ITMUNITA_1.LINENR AS ITMUNITA_LINENR,  ";
            sorgu = sorgu + "                           ITMUNITA_1.BARCODE AS ITMUNITA_BARCODE, ITMUNITA_1.WIDTH AS ITMUNITA_WIDTH, UNITSETL1.CODE AS WIDTH_CODE,  ";
            sorgu = sorgu + "                           ITMUNITA_1.LENGTH AS ITMUNITA_LENGTH, UNITSETL2.CODE AS LENGTH_CODE, ITMUNITA_1.HEIGHT AS ITMUNITA_HEIGHT, UNITSETL3.CODE AS HEIGHT_CODE, ";
            sorgu = sorgu + "                            ITMUNITA_1.AREA AS ITMUNITA_AREA, UNITSETL4.CODE AS AREA_CODE, ITMUNITA_1.VOLUME_ AS ITMUNITA_VOLUME_, UNITSETL5.CODE AS VOLUME_CODE, ";
            sorgu = sorgu + "                           ITMUNITA_1.GROSSVOLUME AS ITMUNITA_GROSSVOLUME, UNITSETL6.CODE AS GROSSVOLUME_CODE, ITMUNITA_1.WEIGHT AS ITMUNITA_WEIGHT,  ";
            sorgu = sorgu + "                           UNITSETL7.CODE AS WEIGHT_CODE, ITMUNITA_1.GROSSWEIGHT AS ITMUNITA_GROSSWEIGHT, UNITSETL8.CODE AS GROSSWEIGHT_CODE,  ";
            sorgu = sorgu + "                           ITMUNITA_1.CONVFACT1 AS ITMUNITA_CONVFACT1, ITMUNITA_1.CONVFACT2 AS ITMUNITA_CONVFACT2   ";
            sorgu = sorgu + "     FROM         LOGODB.dbo.LG_001_ITEMS AS ITEMS WITH (NOLOCK) LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_ITMUNITA AS ITMUNITA_1 WITH (NOLOCK) ON ITEMS.LOGICALREF = ITMUNITA_1.ITEMREF AND ITMUNITA_1.LINENR = 1 LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_ITMUNITA AS ITMUNITA_2 WITH (NOLOCK) ON ITEMS.LOGICALREF = ITMUNITA_2.ITEMREF AND ITMUNITA_2.LINENR = 2 LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_ITMUNITA AS ITMUNITA_3 WITH (NOLOCK) ON ITEMS.LOGICALREF = ITMUNITA_3.ITEMREF AND ITMUNITA_3.LINENR = 3 LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETF AS UNITSETF WITH (NOLOCK) ON ITEMS.UNITSETREF = UNITSETF.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL WITH (NOLOCK) ON ITMUNITA_1.UNITLINEREF = UNITSETL.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL_2 WITH (NOLOCK) ON ITMUNITA_2.UNITLINEREF = UNITSETL_2.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL_3 WITH (NOLOCK) ON ITMUNITA_3.UNITLINEREF = UNITSETL_3.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL1 WITH (NOLOCK) ON ITMUNITA_1.WIDTHREF = UNITSETL1.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL2 WITH (NOLOCK) ON ITMUNITA_1.LENGTHREF = UNITSETL2.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL3 WITH (NOLOCK) ON ITMUNITA_1.HEIGHTREF = UNITSETL3.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL4 WITH (NOLOCK) ON ITMUNITA_1.AREAREF = UNITSETL4.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL5 WITH (NOLOCK) ON ITMUNITA_1.VOLUMEREF = UNITSETL5.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL6 WITH (NOLOCK) ON ITMUNITA_1.GROSSVOLREF = UNITSETL6.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL7 WITH (NOLOCK) ON ITMUNITA_1.WEIGHTREF = UNITSETL7.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL8 WITH (NOLOCK) ON ITMUNITA_1.GROSSWGHTREF = UNITSETL8.LOGICALREF ";
            sorgu = sorgu + "     WHERE     (ITEMS.CARDTYPE <> 22) AND ITEMS.NAME LIKE  ";
        //    sorgu = sorgu + "AND   ITEMS.NAME LIKE  '%" + textBox10.Text + "%'";
         //   sorgu = sorgu + "     order by  ITEMS.CODE ";
            string Metin = "";
            Metin = StokKart.baglantiismi;

            //   MessageBox.Show(Metin);
            char[] ayraclar = { '/', '#', '.', ',', '-', '_', ' ', ':', ';', '(', ')' };
            string[] kelimeler = Metin.Split(ayraclar);
            foreach (string okunan in kelimeler)
            {
                where = where + " '%" + okunan + "%' AND  ITEMS.NAME LIKE ";
                i = i + 1;
                if (i == 1) textBox1.Text = okunan;
                if (i == 2)
                {
                    textBox2.Text = okunan;
                }
                if (i == 3)
                {
                    textBox3.Text = okunan;
                }
                if (i == 4)
                {
                    textBox4.Text = okunan;
                }
                if (i == 5) textBox5.Text = okunan;
            }

            where = where + "'%" + Metin.Substring(0, 2) + "%'";
            //    MessageBox.Show(sorgu+where );
            sorgu = sorgu + where;
            griddoldurlOGOITEMS(sorgu);
            if (textBox1.Text != "") checkBox1.Checked = true;
            if (textBox2.Text != "") checkBox2.Checked = true;
            if (textBox3.Text != "") checkBox3.Checked = true;
            if (textBox4.Text != "") checkBox4.Checked = true;
            if (textBox5.Text != "") checkBox5.Checked = true;
        }

        private void griddoldurlOGOITEMS(string sqlCumle)
        {
            Cursor.Current = Cursors.WaitCursor;
            // Cursor.Current = Cursors.Default;
           // calısmayınca asagı satır kondu   var conn = new SqlConnection("Data Source=BAHARSRV;Initial Catalog=LOGODB;User ID=bahar;Password=!123456789Aa!");
        //  SqlConnection conn = new SqlConnection(@"Data Source=BAHARSRV;Initial Catalog=LOGODB;User ID=bahar;Password=!123456789Aa!");
            SqlConnection conn = new SqlConnection(@"Data Source=SQLSERVER;Initial Catalog=LOGODB;User ID=sa;Password=Sa2010");
            var komut = new SqlCommand(sqlCumle+"   order by  ITEMS.CODE", conn);
            var da = new SqlDataAdapter(komut);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            conn.Close();
            //  dataGridView2.Columns[0].Visible = false;
            Cursor.Current = Cursors.Default;
            label11.Text = dataGridView2.RowCount.ToString();

            dataGridView2.Columns[0].Width = 70;
            dataGridView2.Columns[1].Width = 70;
            dataGridView2.Columns[2].Width = 100;
            dataGridView2.Columns[3].Width = 200;

            dataGridView2.Columns[1].ReadOnly = true;
            dataGridView2.Columns[2].ReadOnly = true;
            dataGridView2.Columns[3].ReadOnly = true;


            dataGridView2.Columns[1].HeaderText = "REFERANS";
            dataGridView2.Columns[2].HeaderText = "MALZEME KODU";

            dataGridView2.Columns[3].HeaderText = "MALZEME AÇIKLAMA";


            dataGridView2.Columns[0].Visible  = true;
            dataGridView2.Columns[1].Visible = true;
            dataGridView2.Columns[2].Visible = true;

            dataGridView2.Columns[3].Visible = true;
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[6].Visible = false;
            dataGridView2.Columns[7].Visible = false;

            dataGridView2.Columns[8].Visible = false;

            dataGridView2.Columns[10].Visible = false;
            dataGridView2.Columns[11].Visible = false;
            dataGridView2.Columns[12].Visible = false;
            dataGridView2.Columns[9].Visible = true;
           
            dataGridView2.Columns[10].Visible = true  ;
            dataGridView2.Columns[13].Visible = true ;


            dataGridView2.Columns[14].Visible = false;
            
            dataGridView2.Columns[12].Visible = true;


            dataGridView2.Columns[15].Visible = false;
            dataGridView2.Columns[16].Visible = false;
            dataGridView2.Columns[17].Visible = false;
            dataGridView2.Columns[18].Visible = false;
            dataGridView2.Columns[19].Visible = false;
            dataGridView2.Columns[20].Visible = false;
            dataGridView2.Columns[21].Visible = false;
            dataGridView2.Columns[22].Visible = false;
            dataGridView2.Columns[23].Visible = false;
            dataGridView2.Columns[24].Visible = false;
            dataGridView2.Columns[25].Visible = false;
            dataGridView2.Columns[26].Visible = false;
            dataGridView2.Columns[27].Visible = false;
            dataGridView2.Columns[28].Visible = false;
            dataGridView2.Columns[29].Visible = false;
            dataGridView2.Columns[30].Visible = false;
            dataGridView2.Columns[31].Visible = false;
            dataGridView2.Columns[32].Visible = false;
            dataGridView2.Columns[33].Visible = false;
            dataGridView2.Columns[34].Visible = false ;
            dataGridView2.Columns[35].Visible =false ;
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sorgu = string.Empty;
            int flag = 0;

            sorgu = sorgu + "     SELECT     ITEMS.LOGICALREF, ITEMS.CODE, ITEMS.NAME, UNITSETF.CODE AS UNITSETF_CODE, UNITSETF.NAME AS UNITSETF_NAME,  ";
            sorgu = sorgu + "                           UNITSETF.SPECODE AS UNITSETF_SPECODE, UNITSETF.CYPHCODE AS UNITSETF_CYPHCODE, UNITSETL.CODE AS UNITSETL_CODE,  ";
            sorgu = sorgu + "                           UNITSETL.NAME AS UNITSETL_NAME,  ";
            sorgu = sorgu + "                           CASE WHEN ITMUNITA_2.CONVFACT2 > 0 and ITMUNITA_2.CONVFACT1 > 0 THEN ITMUNITA_2.CONVFACT2 / ITMUNITA_2.CONVFACT1 ELSE 0 END AS ITMUNITA_2_KATSAYI,  ";
            sorgu = sorgu + "                           UNITSETL_2.CODE AS UNITSETL_2_CODE, UNITSETL_2.NAME AS UNITSETL_2_NAME,  ";
            sorgu = sorgu + "                           CASE WHEN ITMUNITA_3.CONVFACT2 > 0 and ITMUNITA_3.CONVFACT1 > 0 THEN ITMUNITA_3.CONVFACT2 / ITMUNITA_3.CONVFACT1 ELSE 0 END AS ITMUNITA_3_KATSAYI,  ";
            sorgu = sorgu + "                           UNITSETL_3.CODE AS UNITSETL_3_CODE, UNITSETL_3.NAME AS UNITSETL_3_NAME, ITMUNITA_1.LINENR AS ITMUNITA_LINENR,  ";
            sorgu = sorgu + "                           ITMUNITA_1.BARCODE AS ITMUNITA_BARCODE, ITMUNITA_1.WIDTH AS ITMUNITA_WIDTH, UNITSETL1.CODE AS WIDTH_CODE,  ";
            sorgu = sorgu + "                           ITMUNITA_1.LENGTH AS ITMUNITA_LENGTH, UNITSETL2.CODE AS LENGTH_CODE, ITMUNITA_1.HEIGHT AS ITMUNITA_HEIGHT, UNITSETL3.CODE AS HEIGHT_CODE, ";
            sorgu = sorgu + "                            ITMUNITA_1.AREA AS ITMUNITA_AREA, UNITSETL4.CODE AS AREA_CODE, ITMUNITA_1.VOLUME_ AS ITMUNITA_VOLUME_, UNITSETL5.CODE AS VOLUME_CODE, ";
            sorgu = sorgu + "                           ITMUNITA_1.GROSSVOLUME AS ITMUNITA_GROSSVOLUME, UNITSETL6.CODE AS GROSSVOLUME_CODE, ITMUNITA_1.WEIGHT AS ITMUNITA_WEIGHT,  ";
            sorgu = sorgu + "                           UNITSETL7.CODE AS WEIGHT_CODE, ITMUNITA_1.GROSSWEIGHT AS ITMUNITA_GROSSWEIGHT, UNITSETL8.CODE AS GROSSWEIGHT_CODE,  ";
            sorgu = sorgu + "                           ITMUNITA_1.CONVFACT1 AS ITMUNITA_CONVFACT1, ITMUNITA_1.CONVFACT2 AS ITMUNITA_CONVFACT2   ";
            sorgu = sorgu + "     FROM         LOGODB.dbo.LG_001_ITEMS AS ITEMS WITH (NOLOCK) LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_ITMUNITA AS ITMUNITA_1 WITH (NOLOCK) ON ITEMS.LOGICALREF = ITMUNITA_1.ITEMREF AND ITMUNITA_1.LINENR = 1 LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_ITMUNITA AS ITMUNITA_2 WITH (NOLOCK) ON ITEMS.LOGICALREF = ITMUNITA_2.ITEMREF AND ITMUNITA_2.LINENR = 2 LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_ITMUNITA AS ITMUNITA_3 WITH (NOLOCK) ON ITEMS.LOGICALREF = ITMUNITA_3.ITEMREF AND ITMUNITA_3.LINENR = 3 LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETF AS UNITSETF WITH (NOLOCK) ON ITEMS.UNITSETREF = UNITSETF.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL WITH (NOLOCK) ON ITMUNITA_1.UNITLINEREF = UNITSETL.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL_2 WITH (NOLOCK) ON ITMUNITA_2.UNITLINEREF = UNITSETL_2.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL_3 WITH (NOLOCK) ON ITMUNITA_3.UNITLINEREF = UNITSETL_3.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL1 WITH (NOLOCK) ON ITMUNITA_1.WIDTHREF = UNITSETL1.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL2 WITH (NOLOCK) ON ITMUNITA_1.LENGTHREF = UNITSETL2.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL3 WITH (NOLOCK) ON ITMUNITA_1.HEIGHTREF = UNITSETL3.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL4 WITH (NOLOCK) ON ITMUNITA_1.AREAREF = UNITSETL4.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL5 WITH (NOLOCK) ON ITMUNITA_1.VOLUMEREF = UNITSETL5.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL6 WITH (NOLOCK) ON ITMUNITA_1.GROSSVOLREF = UNITSETL6.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL7 WITH (NOLOCK) ON ITMUNITA_1.WEIGHTREF = UNITSETL7.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL8 WITH (NOLOCK) ON ITMUNITA_1.GROSSWGHTREF = UNITSETL8.LOGICALREF ";
            sorgu = sorgu + "     WHERE     (ITEMS.CARDTYPE <> 22) AND ITEMS.NAME LIKE  ";
            if (checkBox1.Checked == true)
            {
                sorgu = sorgu + "'%" + textBox1.Text + "%'";
                flag = 1;
            }
            if (checkBox2.Checked == true)
            {
                if (flag == 1) sorgu = sorgu + " AND ITEMS.NAME LIKE ";
                sorgu = sorgu + "'%" + textBox2.Text + "%'";
                flag = 1;

            }
            if (checkBox3.Checked == true)
            {
                if (flag == 1) sorgu = sorgu + " AND ITEMS.NAME LIKE ";
                sorgu = sorgu + "'%" + textBox3.Text + "%'";
                flag = 1;
            }
            if (checkBox4.Checked == true)
            {
                if (flag == 1) sorgu = sorgu + " AND ITEMS.NAME LIKE ";
                sorgu = sorgu + "'%" + textBox4.Text + "%'";
                flag = 1;
            }
            if (checkBox5.Checked == true)
            {
                if (flag == 1) sorgu = sorgu + " AND ITEMS.NAME LIKE ";
                sorgu = sorgu + "'%" + textBox5.Text + "%'";
                flag = 1;
            }
            if (checkBox6.Checked == true)
            {
                if (flag == 1) sorgu = sorgu + " AND ITEMS.NAME LIKE ";
                sorgu = sorgu + "'%" + textBox6.Text + "%'";
                flag = 1;
            }
             
            if (flag == 1) griddoldurlOGOITEMS(sorgu);  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sorgu = string.Empty;
            int flag = 0;

            sorgu = sorgu + "     SELECT     ITEMS.LOGICALREF, ITEMS.CODE, ITEMS.NAME, UNITSETF.CODE AS UNITSETF_CODE, UNITSETF.NAME AS UNITSETF_NAME,  ";
            sorgu = sorgu + "                           UNITSETF.SPECODE AS UNITSETF_SPECODE, UNITSETF.CYPHCODE AS UNITSETF_CYPHCODE, UNITSETL.CODE AS UNITSETL_CODE,  ";
            sorgu = sorgu + "                           UNITSETL.NAME AS UNITSETL_NAME,  ";
            sorgu = sorgu + "                           CASE WHEN ITMUNITA_2.CONVFACT2 > 0 and ITMUNITA_2.CONVFACT1 > 0 THEN ITMUNITA_2.CONVFACT2 / ITMUNITA_2.CONVFACT1 ELSE 0 END AS ITMUNITA_2_KATSAYI,  ";
            sorgu = sorgu + "                           UNITSETL_2.CODE AS UNITSETL_2_CODE, UNITSETL_2.NAME AS UNITSETL_2_NAME,  ";
            sorgu = sorgu + "                           CASE WHEN ITMUNITA_3.CONVFACT2 > 0 and ITMUNITA_3.CONVFACT1 > 0 THEN ITMUNITA_3.CONVFACT2 / ITMUNITA_3.CONVFACT1 ELSE 0 END AS ITMUNITA_3_KATSAYI,  ";
            sorgu = sorgu + "                           UNITSETL_3.CODE AS UNITSETL_3_CODE, UNITSETL_3.NAME AS UNITSETL_3_NAME, ITMUNITA_1.LINENR AS ITMUNITA_LINENR,  ";
            sorgu = sorgu + "                           ITMUNITA_1.BARCODE AS ITMUNITA_BARCODE, ITMUNITA_1.WIDTH AS ITMUNITA_WIDTH, UNITSETL1.CODE AS WIDTH_CODE,  ";
            sorgu = sorgu + "                           ITMUNITA_1.LENGTH AS ITMUNITA_LENGTH, UNITSETL2.CODE AS LENGTH_CODE, ITMUNITA_1.HEIGHT AS ITMUNITA_HEIGHT, UNITSETL3.CODE AS HEIGHT_CODE, ";
            sorgu = sorgu + "                            ITMUNITA_1.AREA AS ITMUNITA_AREA, UNITSETL4.CODE AS AREA_CODE, ITMUNITA_1.VOLUME_ AS ITMUNITA_VOLUME_, UNITSETL5.CODE AS VOLUME_CODE, ";
            sorgu = sorgu + "                           ITMUNITA_1.GROSSVOLUME AS ITMUNITA_GROSSVOLUME, UNITSETL6.CODE AS GROSSVOLUME_CODE, ITMUNITA_1.WEIGHT AS ITMUNITA_WEIGHT,  ";
            sorgu = sorgu + "                           UNITSETL7.CODE AS WEIGHT_CODE, ITMUNITA_1.GROSSWEIGHT AS ITMUNITA_GROSSWEIGHT, UNITSETL8.CODE AS GROSSWEIGHT_CODE,  ";
            sorgu = sorgu + "                           ITMUNITA_1.CONVFACT1 AS ITMUNITA_CONVFACT1, ITMUNITA_1.CONVFACT2 AS ITMUNITA_CONVFACT2   ";
            sorgu = sorgu + "     FROM         LOGODB.dbo.LG_001_ITEMS AS ITEMS WITH (NOLOCK) LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_ITMUNITA AS ITMUNITA_1 WITH (NOLOCK) ON ITEMS.LOGICALREF = ITMUNITA_1.ITEMREF AND ITMUNITA_1.LINENR = 1 LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_ITMUNITA AS ITMUNITA_2 WITH (NOLOCK) ON ITEMS.LOGICALREF = ITMUNITA_2.ITEMREF AND ITMUNITA_2.LINENR = 2 LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_ITMUNITA AS ITMUNITA_3 WITH (NOLOCK) ON ITEMS.LOGICALREF = ITMUNITA_3.ITEMREF AND ITMUNITA_3.LINENR = 3 LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETF AS UNITSETF WITH (NOLOCK) ON ITEMS.UNITSETREF = UNITSETF.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL WITH (NOLOCK) ON ITMUNITA_1.UNITLINEREF = UNITSETL.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL_2 WITH (NOLOCK) ON ITMUNITA_2.UNITLINEREF = UNITSETL_2.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL_3 WITH (NOLOCK) ON ITMUNITA_3.UNITLINEREF = UNITSETL_3.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL1 WITH (NOLOCK) ON ITMUNITA_1.WIDTHREF = UNITSETL1.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL2 WITH (NOLOCK) ON ITMUNITA_1.LENGTHREF = UNITSETL2.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL3 WITH (NOLOCK) ON ITMUNITA_1.HEIGHTREF = UNITSETL3.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL4 WITH (NOLOCK) ON ITMUNITA_1.AREAREF = UNITSETL4.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL5 WITH (NOLOCK) ON ITMUNITA_1.VOLUMEREF = UNITSETL5.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL6 WITH (NOLOCK) ON ITMUNITA_1.GROSSVOLREF = UNITSETL6.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL7 WITH (NOLOCK) ON ITMUNITA_1.WEIGHTREF = UNITSETL7.LOGICALREF LEFT OUTER JOIN ";
            sorgu = sorgu + "                           LOGODB.dbo.LG_001_UNITSETL AS UNITSETL8 WITH (NOLOCK) ON ITMUNITA_1.GROSSWGHTREF = UNITSETL8.LOGICALREF ";
            sorgu = sorgu + "     WHERE     (ITEMS.CARDTYPE <> 22) AND ITEMS.NAME LIKE  ";
            if (checkBox1.Checked == true)
            {
                sorgu = sorgu + "'%" + textBox1.Text + "%'";
                flag = 1;
            }
            if (checkBox2.Checked == true)
            {
                if (flag == 1) sorgu = sorgu + " OR ITEMS.NAME LIKE ";
                sorgu = sorgu + "'%" + textBox2.Text + "%'";
                flag = 1;

            }
            if (checkBox3.Checked == true)
            {
                if (flag == 1) sorgu = sorgu + " OR ITEMS.NAME LIKE ";
                sorgu = sorgu + "'%" + textBox3.Text + "%'";
                flag = 1;
            }
            if (checkBox4.Checked == true)
            {
                if (flag == 1) sorgu = sorgu + " OR ITEMS.NAME LIKE ";
                sorgu = sorgu + "'%" + textBox4.Text + "%'";
                flag = 1;
            }
            if (checkBox5.Checked == true)
            {
                if (flag == 1) sorgu = sorgu + " OR ITEMS.NAME LIKE ";
                sorgu = sorgu + "'%" + textBox5.Text + "%'";
                flag = 1;
            }
            if (checkBox6.Checked == true)
            {
                if (flag == 1) sorgu = sorgu + " OR ITEMS.NAME LIKE ";
                sorgu = sorgu + "'%" + textBox6.Text + "%'";
                flag = 1;
            }
            
            if (flag == 1) griddoldurlOGOITEMS(sorgu);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            //   data grid taranacak seçilenler iptal edilecek
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                dataGridView2.Rows[i].Cells[0].Value = checkBox8.Checked.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int LogicalrefGonder = -1;
            MessageBox.Show(dataGridView2.RowCount.ToString());
            for (int i = 0; i < dataGridView2.RowCount ; i++)
            {

                if ((Convert.ToBoolean(dataGridView2.Rows[i].Cells[0].Value) == true))
                {
                    LogicalrefGonder = Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value.ToString());
                    logostoklarinabagla_SIL(LogicalrefGonder);
                   logostoklarinabagla_YAZ(LogicalrefGonder);
                }
            }

           
        }

        private void logostoklarinabagla_SIL(int Logicalref )
        {
            using (SqlConnection connection = new SqlConnection("Data Source=SQLSERVER;Initial Catalog=LOGODB;User ID=bahar;Password=sA2010"))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;            // <== lacking
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE   MALIYET.dbo.LogoItemsBagla WHERE  MalzemeId = '" + Convert.ToInt32(label14.Text) + "' AND LogoLogicalref = '" + Logicalref + "'   ";
 
                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        // error here
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void logostoklarinabagla_YAZ(object Logicalref)
        {       //    BAHAR ICIN    "Data Source=SQLSERVER;Initial Catalog=MALIYET;User ID=Sa;Password=Sa2010"
            using (SqlConnection connection = new SqlConnection("Data Source=SQLSERVER;Initial Catalog=MALIYET;User ID=Sa;Password=Sa2010"))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;            // <== lacking
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO  MALIYET.dbo.LogoItemsBagla (MalzemeId,LogoLogicalref ,Brim1,Brim2,Brim3)  VALUES (@MalzemeId, @LogoLogicalref, @Brim1, @Brim2, @Brim3)";
                    command.Parameters.AddWithValue("@MalzemeId", Convert.ToInt32(label14.Text));
                    command.Parameters.AddWithValue("@LogoLogicalref", Logicalref);
                    command.Parameters.AddWithValue("@Brim1", malzemeOlcuBrimi1ComboBox.Text);
                    command.Parameters.AddWithValue("@Brim2", malzemeOlcuBrimi2ComboBox.Text);
                    command.Parameters.AddWithValue("@Brim3", malzemeOlcuBrimi3ComboBox.Text);
                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        // error here
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=SQLSERVER;Initial Catalog=MALIYET;User ID=Sa;Password=Sa2010"))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;            // <== lacking
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE   MALIYET.dbo.LogoItemsBagla WHERE  MalzemeId = '" + Convert.ToInt32(label14.Text) + "'   ";

                    try
                    {
                        connection.Open();
                        int recordsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException)
                    {
                        // error here
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

       
    }

}
/*      MALZEME SON ALIS FIYATLARI SORGUSU           *************************
SELECT     I.LOGICALREF, I.CODE, I.NAME, S.DATE_, S.AMOUNT, LOGODB.LOGODB.dbo.LG_001_UNITSETF.CODE AS BRIM, S.PRICE, S.TOTAL, 
                      LOGODB.LOGODB.dbo.LG_001_CLCARD.LOGICALREF AS Expr1, LOGODB.LOGODB.dbo.LG_001_CLCARD.CODE AS Expr2, LOGODB.LOGODB.dbo.LG_001_CLCARD.DEFINITION_
FROM         LOGODB.LOGODB.dbo.LG_001_ITEMS AS I INNER JOIN
                      LOGODB.LOGODB.dbo.LG_001_01_STLINE AS S ON I.LOGICALREF = S.STOCKREF INNER JOIN
                      LOGODB.LOGODB.dbo.LG_001_CLCARD ON S.CLIENTREF = LOGODB.LOGODB.dbo.LG_001_CLCARD.LOGICALREF INNER JOIN
                      LOGODB.LOGODB.dbo.LG_001_UNITSETF ON S.USREF = LOGODB.LOGODB.dbo.LG_001_UNITSETF.LOGICALREF FULL OUTER JOIN
                      LOGODB.LOGODB.dbo.L_CURRENCYLIST ON S.PRCURR = LOGODB.LOGODB.dbo.L_CURRENCYLIST.CURTYPE
WHERE     (S.LINETYPE = 0) AND (S.CANCELLED = 0) AND (S.TRCODE = 1) AND (S.DATE_ =
                          (SELECT     MAX(DATE_) AS Expr1
                            FROM          LOGODB.LOGODB.dbo.LG_001_01_STLINE
                            WHERE      (STOCKREF = I.LOGICALREF) AND (LINETYPE = 0) AND (CANCELLED = 0) AND (TRCODE = 1)))


*/

/*             MALZEME OLCU BIRIMLERI  PROGRAM SORGUSU     *******************************

    SELECT     ITEMS.LOGICALREF, ITEMS.CODE, ITEMS.NAME, UNITSETF.CODE AS UNITSETF_CODE, UNITSETF.NAME AS UNITSETF_NAME,   
                                     UNITSETF.SPECODE AS UNITSETF_SPECODE, UNITSETF.CYPHCODE AS UNITSETF_CYPHCODE, UNITSETL.CODE AS UNITSETL_CODE,   
                                     UNITSETL.NAME AS UNITSETL_NAME,   
                                     CASE WHEN ITMUNITA_2.CONVFACT2 > 0 and ITMUNITA_2.CONVFACT1 > 0 THEN ITMUNITA_2.CONVFACT2 / ITMUNITA_2.CONVFACT1 ELSE 0 END AS ITMUNITA_2_KATSAYI,   
                                     UNITSETL_2.CODE AS UNITSETL_2_CODE, UNITSETL_2.NAME AS UNITSETL_2_NAME,   
                                     CASE WHEN ITMUNITA_3.CONVFACT2 > 0 and ITMUNITA_2.CONVFACT1 > 0 THEN ITMUNITA_3.CONVFACT2 / ITMUNITA_3.CONVFACT1 ELSE 0 END AS ITMUNITA_3_KATSAYI,   
                                     UNITSETL_3.CODE AS UNITSETL_3_CODE, UNITSETL_3.NAME AS UNITSETL_3_NAME, ITMUNITA_1.LINENR AS ITMUNITA_LINENR,   
                                     ITMUNITA_1.BARCODE AS ITMUNITA_BARCODE, ITMUNITA_1.WIDTH AS ITMUNITA_WIDTH, UNITSETL1.CODE AS WIDTH_CODE,   
                                     ITMUNITA_1.LENGTH AS ITMUNITA_LENGTH, UNITSETL2.CODE AS LENGTH_CODE, ITMUNITA_1.HEIGHT AS ITMUNITA_HEIGHT, UNITSETL3.CODE AS HEIGHT_CODE,  
                                      ITMUNITA_1.AREA AS ITMUNITA_AREA, UNITSETL4.CODE AS AREA_CODE, ITMUNITA_1.VOLUME_ AS ITMUNITA_VOLUME_, UNITSETL5.CODE AS VOLUME_CODE,  
                                     ITMUNITA_1.GROSSVOLUME AS ITMUNITA_GROSSVOLUME, UNITSETL6.CODE AS GROSSVOLUME_CODE, ITMUNITA_1.WEIGHT AS ITMUNITA_WEIGHT,   
                                     UNITSETL7.CODE AS WEIGHT_CODE, ITMUNITA_1.GROSSWEIGHT AS ITMUNITA_GROSSWEIGHT, UNITSETL8.CODE AS GROSSWEIGHT_CODE,   
                                     ITMUNITA_1.CONVFACT1 AS ITMUNITA_CONVFACT1, ITMUNITA_1.CONVFACT2 AS ITMUNITA_CONVFACT2    
               FROM         LOGODB.dbo.LG_001_ITEMS AS ITEMS WITH (NOLOCK) LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_ITMUNITA AS ITMUNITA_1 WITH (NOLOCK) ON ITEMS.LOGICALREF = ITMUNITA_1.ITEMREF AND ITMUNITA_1.LINENR = 1 LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_ITMUNITA AS ITMUNITA_2 WITH (NOLOCK) ON ITEMS.LOGICALREF = ITMUNITA_2.ITEMREF AND ITMUNITA_2.LINENR = 2 LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_ITMUNITA AS ITMUNITA_3 WITH (NOLOCK) ON ITEMS.LOGICALREF = ITMUNITA_3.ITEMREF AND ITMUNITA_3.LINENR = 3 LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_UNITSETF AS UNITSETF WITH (NOLOCK) ON ITEMS.UNITSETREF = UNITSETF.LOGICALREF LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_UNITSETL AS UNITSETL WITH (NOLOCK) ON ITMUNITA_1.UNITLINEREF = UNITSETL.LOGICALREF LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_UNITSETL AS UNITSETL_2 WITH (NOLOCK) ON ITMUNITA_2.UNITLINEREF = UNITSETL_2.LOGICALREF LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_UNITSETL AS UNITSETL_3 WITH (NOLOCK) ON ITMUNITA_3.UNITLINEREF = UNITSETL_3.LOGICALREF LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_UNITSETL AS UNITSETL1 WITH (NOLOCK) ON ITMUNITA_1.WIDTHREF = UNITSETL1.LOGICALREF LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_UNITSETL AS UNITSETL2 WITH (NOLOCK) ON ITMUNITA_1.LENGTHREF = UNITSETL2.LOGICALREF LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_UNITSETL AS UNITSETL3 WITH (NOLOCK) ON ITMUNITA_1.HEIGHTREF = UNITSETL3.LOGICALREF LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_UNITSETL AS UNITSETL4 WITH (NOLOCK) ON ITMUNITA_1.AREAREF = UNITSETL4.LOGICALREF LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_UNITSETL AS UNITSETL5 WITH (NOLOCK) ON ITMUNITA_1.VOLUMEREF = UNITSETL5.LOGICALREF LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_UNITSETL AS UNITSETL6 WITH (NOLOCK) ON ITMUNITA_1.GROSSVOLREF = UNITSETL6.LOGICALREF LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_UNITSETL AS UNITSETL7 WITH (NOLOCK) ON ITMUNITA_1.WEIGHTREF = UNITSETL7.LOGICALREF LEFT OUTER JOIN  
                                     LOGODB.dbo.LG_001_UNITSETL AS UNITSETL8 WITH (NOLOCK) ON ITMUNITA_1.GROSSWGHTREF = UNITSETL8.LOGICALREF  
               WHERE     (ITEMS.CARDTYPE <> 22)   
   --  AND   ITEMS.NAME LIKE  '%" + textBox10.Text + "%' 
               order by  ITEMS.CODE  


*/

/*

            textBox9.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox8.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox10.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();

            textBox4.Text = dataGridView2.CurrentRow.Cells[8].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[11].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[14].Value.ToString();

            textBox13.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
            textBox11.Text = dataGridView2.CurrentRow.Cells[12].Value.ToString();


*/