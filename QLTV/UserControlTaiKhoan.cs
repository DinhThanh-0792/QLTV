using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class UserControlTaiKhoan : UserControl
    {
        public UserControlTaiKhoan()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel2_Resize(object sender, EventArgs e)
        {
            int h = tableLayoutPanel2.Height;
            tableLayoutPanel2.ColumnStyles[0].Width = h;
        }
    }
}
