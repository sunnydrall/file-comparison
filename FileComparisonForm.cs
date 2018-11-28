using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileComparisonIgnou
{
    public partial class FileComparisonForm : Form
    {
        public RichTextBox textboxAOutput;
        public RichTextBox textboxBOutput;
        public FileComparisonForm()
        {
            InitializeComponent();

            textboxAOutput = fileAOutputTextbox;
            textboxBOutput = fileBOutputTextbox;
        }
    }
}
