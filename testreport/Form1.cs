 
using System;
 
using System.Windows.Forms;

using System.IO;
 
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.Layout.Font;
using Fluid;
using Scriban;

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
            TemplateOptions.Default.MemberAccessStrategy = new UnsafeMemberAccessStrategy();

            var tienNop = new TienNop() {
                Hoten_HocSinh = "nguyen van a",
                Phong_gd ="phong qn",
                Tai_khoan_nop = "trường tiểu học Ngô Quyền"
            };



            var fileName = "templates\\Report.tpl";
            var data = File.ReadAllText(fileName);
            var parser = new FluidParser();


            var context = new Fluid.TemplateContext();
            context.SetValue("tienNop", tienNop);
            var template = parser.Parse(data);

            var result = template.Render(context);


            using (FileStream pdfDest = File.Open("output.pdf", FileMode.Create))
            {
                ConverterProperties converterProperties = new ConverterProperties();
                FontProvider fontProvider = new DefaultFontProvider();
               
                fontProvider.AddDirectory(fontDir);

                converterProperties.SetFontProvider(fontProvider);
                HtmlConverter.ConvertToPdf(result, pdfDest, converterProperties);
            }
        }
    }
}
