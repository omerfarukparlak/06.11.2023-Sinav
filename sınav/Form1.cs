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
namespace sınav
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class SqlBaglan
        {
            public static SqlConnection baglan()
            {
                SqlConnection bag = new SqlConnection("Data Source=DESKTOP-S8V0CDH\\SQLEXPRESS;Initial Catalog=sınav;Integrated Security=True");
                bag.Open();
                return bag;
            }
        }

        void Listele()
        {
            SqlCommand cmd = new SqlCommand("Select * from kisiler", SqlBaglan.baglan());
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert into kisiler(telNo,ad,soyad,gsm,grup)values('"+txtTel.Text+"','"+txtAd.Text+"','"+txtSoyad.Text+"','"+txtGsm.Text+"','"+txtGrup.Text+"')",SqlBaglan.baglan());
            cmd.ExecuteNonQuery();
            Listele();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from kisiler where='" + txtTel.Text + "'", SqlBaglan.baglan()); ;
            cmd.ExecuteNonQuery();
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Update kisiler set ad='"+txtAd.Text+"' where'" + dataGridView1.SelectedRows.ToString()+"'",SqlBaglan.baglan());
            cmd.ExecuteNonQuery();
            Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTel.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtGsm.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtGrup.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
