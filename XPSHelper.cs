using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Xps.Packaging;
using System.Windows;
using System.Reflection.Metadata;

namespace ReceiptPrinter
{
    public class XPSHelper
    {
        DocumentViewer docView;
        public XPSHelper(DocumentViewer documentViewer)
        {
            docView = documentViewer;
        }

        private double getPxByCm(double cm)
        {
            return 96 / 2.54 * cm;
        }
        public void SetPrint(List<PrintInfo> list)
        {
            FixedDocument fixedDoc = new FixedDocument();
            foreach (var item in list)
            {
                PageContent pageContent = new PageContent();
                FixedPage fixedPage = new FixedPage();

                fixedPage.HorizontalAlignment = HorizontalAlignment.Left;
                fixedPage.VerticalAlignment = VerticalAlignment.Top;

                //由于要横向展示，所以高度和宽度进行调换
                fixedPage.Width = getPxByCm(18.6);
                fixedPage.Height = getPxByCm(10.15);

                Canvas containCanvas = new Canvas
                {
                    Width = fixedPage.Width,
                    Height = fixedPage.Height,
                    Background = Brushes.Transparent
                };
                var name = GetTextBlock(getPxByCm(3.7), getPxByCm(2.3), 11, item.Name);
                var cls = GetTextBlock(getPxByCm(3.7), getPxByCm(2.6), 11, item.Cls);
                var year = GetTextBlock(getPxByCm(12.8), getPxByCm(2.6), 11, item.Year);
                var month = GetTextBlock(getPxByCm(14.2), getPxByCm(2.6), 11, item.Month);
                var day = GetTextBlock(getPxByCm(15.7), getPxByCm(2.6), 11, item.Day);
                var fee1 = GetTextBlock(getPxByCm(8.6), getPxByCm(4.2), 11, item.Fee1);
                var fee2 = GetTextBlock(getPxByCm(8.6), getPxByCm(5), 11, item.Fee2);
                var fee3 = GetTextBlock(getPxByCm(8.6), getPxByCm(5.8), 11, item.Fee3);
                var fee3n = GetTextBlock(getPxByCm(4), getPxByCm(5.8), 11, "伙食费");



                var wan = GetTextBlock(getPxByCm(7.3), getPxByCm(7.5), 11, item.Wan);
                var qian = GetTextBlock(getPxByCm(8.3), getPxByCm(7.5), 11, item.Qian);
                var bai = GetTextBlock(getPxByCm(9.3), getPxByCm(7.5), 11, item.Bai);
                var shi = GetTextBlock(getPxByCm(10.3), getPxByCm(7.5), 11, item.Shi);
                var yuan = GetTextBlock(getPxByCm(11.3), getPxByCm(7.5), 11, item.Yuan);
                var jiao = GetTextBlock(getPxByCm(12.3), getPxByCm(7.5), 11, item.Jiao);
                var fen = GetTextBlock(getPxByCm(13.3), getPxByCm(7.5), 11, item.Fen);
                var price = GetTextBlock(getPxByCm(14.3), getPxByCm(7.5), 11, item.Price.ToString());
                var user = GetTextBlock(getPxByCm(8.3), getPxByCm(8.4), 11, item.User);

                containCanvas.Children.Add(name);
                containCanvas.Children.Add(cls);
                containCanvas.Children.Add(year);
                containCanvas.Children.Add(month);
                containCanvas.Children.Add(day);
                containCanvas.Children.Add(fee1);
                containCanvas.Children.Add(fee2);
                containCanvas.Children.Add(fee3);
                containCanvas.Children.Add(fee3n);
                containCanvas.Children.Add(wan);
                containCanvas.Children.Add(qian);
                containCanvas.Children.Add(bai);
                containCanvas.Children.Add(shi);
                containCanvas.Children.Add(yuan);
                containCanvas.Children.Add(jiao);
                containCanvas.Children.Add(fen);
                containCanvas.Children.Add(price);
                containCanvas.Children.Add(user);

                fixedPage.Children.Add(containCanvas);
                ((IAddChild)pageContent).AddChild(fixedPage);
                fixedDoc.Pages.Add(pageContent);
            }
            docView.Document = fixedDoc;
        }


        private TextBlock GetTextBlock(double x, double y, double fontSize, string content)
        {
            TextBlock label = new TextBlock();
            Canvas.SetLeft(label, x);
            Canvas.SetTop(label, y - fontSize);
            Canvas.SetZIndex(label, 99);
            label.Foreground = Brushes.Black;
            label.FontFamily = new FontFamily("宋体");
            label.FontSize = fontSize;
            label.Text = content;
            return label;
        }

    }
}
