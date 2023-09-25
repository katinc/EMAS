using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop;
using System.IO;

namespace eMAS.Forms.Employment
{
    public partial class DocForm : Form
    {
        //private DocBrowser reader;
        delegate void ConvertDocumentDelegate(string fileName, string extension);
        public DocForm()
        {
            InitializeComponent();
           
           // reader.Size = new System.Drawing.Size(0, 23);
          // reader.Dock = DockStyle.Fill;
            //Container.Add(reader);           
            //reader.LoadDocument(@"C:\Users\Stevkkys\Downloads\Akwapim Rural Bank mobile app ver5.docx");

            // set up an event handler to delete our temp file when we're done with it. 
            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;

        }

        private void DocForm_Load(object sender, EventArgs e)
        {

        }

        string tempFileName = null;

        public void LoadDocument(string fileName, string extension)
        {
            // Call ConvertDocument asynchronously. 
            ConvertDocumentDelegate del = new ConvertDocumentDelegate(ConvertDocument);

            // Call DocumentConversionComplete when the method has completed. 
            del.BeginInvoke(fileName,extension, DocumentConversionComplete, null);
        }

        void ConvertDocument(string fileName, string extension)
        {
           switch(extension)
           {
               case "xls":
               case "xlsx":
                   ExcelConverter(fileName);
                   break;
               case "doc":
               case "docx":
                   case "txt":
                   wordConverter(fileName);
                   break;
               default:
                   webBrowser1.Navigate(new Uri(string.Format(fileName)),false);
            
                   break;

           }              

        }

        private void wordConverter(string fileName)
        {
            object m = System.Reflection.Missing.Value;
            object oldFileName = (object)fileName;
            object readOnly = (object)false;
            Microsoft.Office.Interop.Word.ApplicationClass ac = null;

            try
            {
                // First, create a new Microsoft.Office.Interop.Word.ApplicationClass.
                ac = new Microsoft.Office.Interop.Word.ApplicationClass();

                // Now we open the document.
                Microsoft.Office.Interop.Word.Document doc = ac.Documents.Open(ref oldFileName, ref m, ref readOnly,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m,
                     ref m, ref m, ref m, ref m, ref m, ref m);

                // Create a temp file to save the HTML file to. 
                tempFileName = GetTempFile("html");

                // Cast these items to object.  The methods we're calling 
                // only take object types in their method parameters. 
                object newFileName = (object)tempFileName;

                // We will be saving this file as HTML format. 
                object fileType = (object)Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatHTML;

                // Save the file. 
                doc.SaveAs(ref newFileName, ref fileType,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m);

                //webBrowser1.Navigate(tempFileName);
            }
            finally
            {
                // Make sure we close the application class. 
                if (ac != null)
                    ac.Quit(ref readOnly, ref m, ref m);
            }
        }

        private void ExcelConverter(string fileName)
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            try
            {
               
                excel.Visible = false;
                object missing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = excel.Workbooks.Open(fileName);

                Microsoft.Office.Interop.Excel.Worksheet xlWorksheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkbook.Sheets[1];

                tempFileName = GetTempFile("html");
               
                object newFileName = (object)tempFileName;
                object fileType = (object)Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml;

                xlWorkbook.SaveAs(tempFileName, fileType, missing, missing, missing, missing,
                      Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                      missing, missing, missing, missing, missing);
            }
            finally
            {
                // Make sure we close the application class. 
                if (excel != null)
                    excel.Quit();
            }
        }

        void DocumentConversionComplete(IAsyncResult result)
        {
            // navigate to our temp file. 
            if (null != tempFileName)
            {
                webBrowser1.Navigate(tempFileName);
            }
        }

        void webBrowser1_DocumentCompleted(object sender,
            WebBrowserDocumentCompletedEventArgs e)
        {
            if (tempFileName != string.Empty || tempFileName != null)
            {
                // delete the temp file we created. 
                File.Delete(tempFileName);

                // set the tempFileName to an empty string. 
                tempFileName = string.Empty;
            }
        }

        string GetTempFile(string extension)
        {
            // Uses the Combine, GetTempPath, ChangeExtension, 
            // and GetRandomFile methods of Path to 
            // create a temp file of the extension we're looking for. 
            return Path.Combine(Path.GetTempPath(),
                Path.ChangeExtension(Path.GetRandomFileName(), extension));
        }
    }
}
