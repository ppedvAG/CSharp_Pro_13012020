using Newtonsoft.Json;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Xml.Serialization;

namespace GoogleBooksClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Suchen(object sender, RoutedEventArgs e)
        {

            var url = $"https://www.googleapis.com/books/v1/volumes?q={tb1.Text}";

            using (var wc = new WebClient())
            {
                wc.Encoding = Encoding.UTF8;
                var json = wc.DownloadString(url);
                //MessageBox.Show(json);

                var books = JsonConvert.DeserializeObject<BookResult>(json);

                //var volInfo = new List<Volumeinfo>();
                //foreach (var item in books.items)
                //{
                //    volInfo.Add(item.volumeInfo);
                //}
                //myGrid.ItemsSource = volInfo;
                myGrid.ItemsSource = books.items.Select(x => x.volumeInfo).ToList();
            }
        }

        private void ExportXml(object sender, RoutedEventArgs e)
        {
            var fileName = "books.xml";

            using (var sw = new StreamWriter(fileName))
            {
                var serial = new XmlSerializer(typeof(List<Volumeinfo>));
                serial.Serialize(sw, myGrid.ItemsSource);
            }

            MessageBox.Show("Export erfolgreich");
        }

        private void ImportXml(object sender, RoutedEventArgs e)
        {
            var fileName = "books.xml";

            using (var sr = new StreamReader(fileName))
            {
                var serial = new XmlSerializer(typeof(List<Volumeinfo>));
                myGrid.ItemsSource = (List<Volumeinfo>)serial.Deserialize(sr);
            }

        }

        private void ExportExcel(object sender, RoutedEventArgs e)
        {
            var data = (List<Volumeinfo>)myGrid.ItemsSource;
            var fi = new FileInfo("book.xlsx");

            using (var pack = new ExcelPackage(fi))
            {
                var ws = pack.Workbook.Worksheets.FirstOrDefault();
                if (ws == null)
                    ws = pack.Workbook.Worksheets.Add("Books");


                var pCount = ws.Cells["B3:B10"].Sum(x => int.Parse(x.Value.ToString()));

                MessageBox.Show(pCount.ToString());
                return;
                ws.Cells[1, 1].Value = "Bücher";
                ws.Cells["A2"].Value = $"Anzahl: {data.Count}";

                int row = 3;
                foreach (var item in data)
                {
                    ws.Cells[row, 1].Value = item.title;
                    ws.Cells[row++, 2].Value = item.pageCount;

                }
                ws.Column(1).AutoFit();
                ws.Column(2).AutoFit();


                pack.Save();
            }
            Process.Start(fi.FullName);
        }
    }
}
