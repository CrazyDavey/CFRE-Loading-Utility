using System;
using System.Collections.Generic;
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


namespace CFRE_Loading_Utility
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
        
    public static string ExtractTextFromPdf(string path)
    {
        using (PdfReader reader = new PdfReader(path))
        {
            StringBuilder text = new StringBuilder();

            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
            }

            return text.ToString();
        }
    }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string selectedFile;
            OpenFileDialog PDFpicker = new OpenFileDialog();
            PDFpicker.Filter = "PDF Files (*.pdf)|*.pdf";
            PDFpicker.FilterIndex = 1;
            PDFpicker.Multiselect = false;

            if (PDFpicker.ShowDialog() == true)
                selectedFile = PDFpicker.FileName;
            else
                selectedFile = string.Empty;
            string text = ExtractTextFromPdf(selectedFile);
            MessageBox.Show(text);
        }
    }

}
