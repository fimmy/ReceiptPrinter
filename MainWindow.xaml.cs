using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReceiptPrinter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ChoseFile(object sender, RoutedEventArgs e)
        {
            // TODO: Add event handler implementation here.
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "Excel Files (*.xlsx)|*.xlsx"
            };
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                var filename = openFileDialog.FileName;
                var list = new List<PrintInfo>();

                using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    var workbook = new XSSFWorkbook(file);
                    var ws = workbook.GetSheetAt(0);
                    for (int i = 1; i < ws.LastRowNum + 1; i++)
                    {
                        var row = ws.GetRow(i);
                        var std = new PrintInfo();
                        std.Name = row.GetCell(0).StringCellValue ?? "";
                        std.Cls = row.GetCell(1).StringCellValue ?? "";
                        std.Year = row.GetCell(2).NumericCellValue.ToString();
                        std.Month = row.GetCell(3).NumericCellValue.ToString();
                        std.Day = row.GetCell(4).NumericCellValue.ToString();
                        std.Fee1 = row.GetCell(5).NumericCellValue.ToString();
                        std.Fee2 = row.GetCell(6).NumericCellValue.ToString();
                        std.Fee3 = row.GetCell(7).NumericCellValue.ToString();
                        std.Price = Convert.ToDecimal(row.GetCell(8).NumericCellValue);
                        std.User = row.GetCell(9).StringCellValue ?? "";
                        if (!string.IsNullOrEmpty(std.Name))
                        {
                            list.Add(std);
                        }
                    }
                }


                PrintPreview window = new PrintPreview();//调用显示容器
                var xps = new XPSHelper(window.docViewer);

                xps.SetPrint(list);
                window.Show();
            }


        }
    }
}
