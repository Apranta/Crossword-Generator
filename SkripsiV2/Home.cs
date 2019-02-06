using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkripsiV2
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rows.Text == "" || columns.Text == "")
            {
                MessageBox.Show("Silahkan isi data dengan lengkap terlebih dahulu", "Warning",
                   MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                int row = Convert.ToInt32(rows.Text);
                int col = Convert.ToInt32(columns.Text);
                if (row < 5 && col < 5) {

                    MessageBox.Show("Silahkan masukan kolom dan baris lebih dari 5", "Warning",
                       MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    Form1 frm2 = new Form1(row, col);
                    frm2.Show();
                    this.Hide();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
