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
    public partial class frmogretmendetay : Form
    {
        public frmogretmendetay()
        {
            InitializeComponent();
        }

        private void frmogretmendetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBOGRENCINOTDataSet.TBLDERS' table. You can move, or remove it, as needed.
            this.tBLDERSTableAdapter.Fill(this.dBOGRENCINOTDataSet.TBLDERS);

        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=OSMAN\SQLEXPRESS;Initial Catalog=DBOGRENCINOT;Integrated Security=True");
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("inster into TBLDERS (OGRNUMARA,OGRAD,OGRSOYAD) values (@p1,@p2,@p3)",baglanti);
            komut.Parameters.AddWithValue("@p1",mskdTxt.Text);
            komut.Parameters.AddWithValue("@p2",txtAd.Text);
            komut.Parameters.AddWithValue("@p3", txtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci sisteme Eklendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            mskdTxt.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            txtsinav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsinav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtsinav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            string durum;
            double ortalama, s1,s2,s3;
            s1 = Convert.ToDouble(txtsinav1.Text);
            s2 = Convert.ToDouble(txtsinav2.Text);
            s3 = Convert.ToDouble(txtsinav3.Text);
            ortalama = (s1+s2+s3)/3;
            lblortalama.Text = ortalama.ToString();

            if (ortalama >= 50)
            {
                durum = "True";
            }
            else { durum = "False"; }




            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update TBLDERS set OGRS1=@P1, OGRS2=@P2, OGRS3=@P3,ORTALAMA=@P4,DURUM=@P5 where OGRNUMARA=@P6",baglanti);
            komut.Parameters.AddWithValue("@P1",txtsinav1.Text);
            komut.Parameters.AddWithValue("@P2", txtsinav2.Text);
            komut.Parameters.AddWithValue("@P3", txtsinav3.Text);
            komut.Parameters.AddWithValue("@P4",decimal.Parse(lblortalama.Text));
            komut.Parameters.AddWithValue("@P5",durum);
            komut.Parameters.AddWithValue("@P6",mskdTxt.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme işlemi gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.tBLDERSTableAdapter.Fill(this.dBOGRENCINOTDataSet.TBLDERS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmOgrenciGiris fr = new frmOgrenciGiris();
            fr.Show();
            this.Hide();
        }
    }
}
