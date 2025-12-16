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
    public partial class UserControlSach : UserControl
    {
        TacGia_BUS tgBUS = new TacGia_BUS();
        public UserControlSach()
        {
            InitializeComponent();
        }
        void LoadGridViewTacGia()
        {
            DataGridViewTG.DataSource = tgBUS.LoadTacGia();
        }

        private void UserControlSach_Load(object sender, EventArgs e)
        {
            LoadGridViewTacGia();
        }

        private void DataGridViewTG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridViewTG.Rows.Count>0)
            {
                txtMaTG.Text = DataGridViewTG.CurrentRow.Cells[0].Value.ToString();
                txtTenTG.Text = DataGridViewTG.CurrentRow.Cells[1].Value.ToString();
                txtQue.Text = DataGridViewTG.CurrentRow.Cells[2].Value.ToString();

            }
           
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            TacGia tg = new TacGia
            {
                MaTG = txtMaTG.Text,
                TenTG = txtTenTG.Text,
                QuocGia = txtQue.Text
            };
            tgBUS.InsertTacGia(tg);
            LoadGridViewTacGia();
        }
    }
}
