using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace QLTV
{
    public partial class FormThemSach : Form
    {
        public CTPhieu SachDuocChon { get; set; }
        
        public FormThemSach()
        {
            InitializeComponent();
        }
    }
}
