using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grade_calculation
{
    public partial class frmOgrenciGiris : Form
    {
        public frmOgrenciGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmogrencidetay fr = new frmogrencidetay();
            fr.numara = maskedTextBox1.Text;
            fr.Show();
            this.Hide();
        }



        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text == "1111")
            {
                frmogretmendetay frm = new frmogretmendetay();
                frm.Show();
                this.Hide();
            }

        }

        private void frmOgrenciGiris_Load(object sender, EventArgs e)
        {

        }
    }
}
