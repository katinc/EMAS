using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRBussinessLayer.ErrorLogging;

namespace eMAS.Forms.Employment
{
    public partial class PDFReader : Form
    {
        public PDFReader()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        public PDFReader(string Path)
        {
            try
            {
                InitializeComponent();
                axAcroPDF2.src = Path;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }
    }
}
