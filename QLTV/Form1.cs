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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void LoadControl(UserControl uc)
        {
            panelMain.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelMain.Controls.Add(uc);
        }

        private void btnTk_Click(object sender, EventArgs e)
        {
            LoadControl(new UserControlTaiKhoan());
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            LoadControl(new UserControlSach());
        }

        private void btnDocGia_Click(object sender, EventArgs e)
        {
            LoadControl(new UserControlDocGia());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            LoadControl(new UserControlNhanVien());
        }

        private void btnMuon_Click(object sender, EventArgs e)
        {
            LoadControl(new UserControlMuon());
        }
    }
}
