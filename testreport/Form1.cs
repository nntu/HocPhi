
using DevExpress.XtraReports.UI;
using Fluid;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.Layout.Font;
using System;
using System.IO;
using System.Windows.Forms;

namespace testreport
{
    public partial class Form1 : Form
    {
        string fontDir = "fonts";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XtraReport1 xrp = new XtraReport1();
            xrp.CreateDocument();
            xrp.ShowPreview();
        }
    }
}
