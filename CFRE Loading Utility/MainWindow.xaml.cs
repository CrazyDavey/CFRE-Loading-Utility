using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.Win32;
using System.Configuration;
using CFRE_Loading_Utility.Models;


namespace CFRE_Loading_Utility
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly ObservableCollection<PDFRow> PDFtext;

        public MainWindow()
        {
            InitializeComponent();
            PDFtext = new ObservableCollection<PDFRow>();
            PDFDataGrid.ItemsSource = PDFtext;
        }
        
        private void ExtractTextFromPdf(string path)
        {
            if (path == string.Empty) return;
            PDFtext.Clear();     
            using (PdfReader reader = new PdfReader(path))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    PDFtext.Add(new PDFRow {Row = PdfTextExtractor.GetTextFromPage(reader, i)});
                }
            }
        }

        private void LoadPDF_Click(object sender, RoutedEventArgs e)
        {
            string selectedFile;
            OpenFileDialog PDFpicker = new OpenFileDialog();
            PDFpicker.Filter = "PDF Files (*.pdf)|*.pdf";
            PDFpicker.FilterIndex = 1;
            PDFpicker.Multiselect = false;
            PDFpicker.InitialDirectory = ConfigurationManager.AppSettings.Get("StringPDFPath");

            if (PDFpicker.ShowDialog() == true)
                selectedFile = PDFpicker.FileName;
            else
                selectedFile = string.Empty;
            ExtractTextFromPdf(selectedFile);           
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            this.Title = e.GetPosition(this).ToString();
        }
    }

}
