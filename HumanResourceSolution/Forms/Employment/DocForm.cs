using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace eMAS.Forms.Employment
{
    public partial class DocForm : Form
    {
        private DocBrowser reader;
        public DocForm()
        {
            InitializeComponent();
            reader = new DocBrowser();
            reader.LoadDocument("C:/Users/User/Downloads/sample.docx");
        }
    }
}
