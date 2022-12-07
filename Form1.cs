using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;

namespace MaliyetProgram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReportDocument reportDocument = new ReportDocument();
            string filePath = "C:\\MALIYET\\RAPORLAR\\MALIYETRAPORUurunkodu.rpt";
            reportDocument.Load(filePath);
            crystalReportViewer1.ReportSource = reportDocument;
            setSQLParams();
            ViewReport();
            //   crystalReportViewer1.RefreshReport();
        }


        private void setSQLParams()
        {
            ParameterFields pfs = new ParameterFields();
            ParameterField UrunKodu = new ParameterField();
            //   ParameterField UrunAdi = new ParameterField();
            ParameterDiscreteValue pdDeger1 = new ParameterDiscreteValue();
            //  ParameterDiscreteValue pdDeger2 = new ParameterDiscreteValue();
            UrunKodu.ParameterFieldName = "UrunKodu"; //Raporunuzdaki parametreniz.
            //  UrunAdi.ParameterFieldName = "UrunAdi"; ////Raporunuzdaki parametreniz.
       //     MessageBox.Show(UrunAgaci.OrtakUrunKodu.ToString());
            pdDeger1.Value = UrunAgaci.OrtakUrunKodu.ToString(); //Parametreye vermek istediğiniz değer
            //    pdDeger2.Value = "aaa"; //Parametreye vermek istediğiniz değer
            UrunKodu.CurrentValues.Add(pdDeger1);
            //     UrunAdi.CurrentValues.Add(pdDeger2);
            pfs.Add(UrunKodu);
            //    pfs.Add(UrunAdi);
            crystalReportViewer1.ParameterFieldInfo = pfs;


        }
        private void ViewReport()
        {
            ConnectionInfo connInfo = new ConnectionInfo();
            connInfo.ServerName = "SQLSERVER";
            connInfo.DatabaseName = "MALIYET";
            connInfo.UserID = "sa";
            connInfo.Password = "Sa2010";
            crystalReportViewer1.ReportSource = GetReportSource(connInfo);
            crystalReportViewer1.RefreshReport();
        }

        private ReportDocument GetReportSource(ConnectionInfo connInfo)
        {
            ReportDocument document = new ReportDocument();
            document.Load("C:\\MALIYET\\RAPORLAR\\MALIYETRAPORUurunkodu.rpt"); //"C:\\path\\to\\report\\file.rpt";
            TableLogOnInfos logonInfos = new TableLogOnInfos();
            TableLogOnInfo logonInfo = new TableLogOnInfo();
            Tables tables;
            tables = document.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                logonInfo = table.LogOnInfo;
                logonInfo.ConnectionInfo = connInfo;
                table.ApplyLogOnInfo(logonInfo);
            }
            return document;
        }
    }
}
