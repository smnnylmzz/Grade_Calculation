using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace grade_calculation
{
    public partial class frmOgrenciGiris : Form
    {
        public frmOgrenciGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=OSMAN\SQLEXPRESS;Initial Catalog=DBOGRENCINOT;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("Lütfen bilgilerinizi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                baglanti.Open();

                SqlCommand komut = new SqlCommand("SELECT * FROM TBLDERS WHERE OGRNUMARA = @p1", baglanti);
                komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
                SqlDataReader dr = komut.ExecuteReader();

                if (dr.Read())
                {
                    frmogrencidetay fr = new frmogrencidetay();
                    fr.numara = maskedTextBox1.Text;
                    fr.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Okul numaranız veya şifrenizi yanlış girdiniz. Lütfen bilgilerinizi kontrol edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
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

