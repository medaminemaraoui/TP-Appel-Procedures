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

namespace TestProj
{
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=IBIZA\SQLEXPRESS;Initial Catalog=TestProc;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn.Open();
            cmd.Connection= cn; 
            ChargeDGV();
        }

        private void ChargeDGV()
        {
            cmd.CommandText = "Affichage";
           // SqlCommand cmd1 = new SqlCommand("Affichage", cn);
         //   cmd1.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr1 = cmd.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt1;
        }

        private void Ajouter_Click(object sender, EventArgs e)
        {
            if (existe() == true)
            {
                return ;
            }
            else
            {
                cmd.CommandText = "Insertion " + textBox_CIN.Text + "," + textBox_NOM.Text + "," + textBox_PRENOM.Text + "," + textBox_AGE.Text + "";
            };
          //cmd.CommandText = "Insertion " + textBox_CIN.Text + "," + textBox_NOM.Text + "," + textBox_PRENOM.Text + "," + int.Parse(textBox_AGE.Text) +";";
            cmd.ExecuteNonQuery();
            ChargeDGV();
        }
        bool existe()
        {
            cmd.CommandText = "cin" + textBox_CIN.Text + ";";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                MessageBox.Show("cin existe");
                return true;
                dr.Close();
            }
            else
            { MessageBox.Show("cin not existe"); return false; }
        }
        private void Modifier_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "Modifier " + textBox_CIN.Text + "," + textBox_NOM.Text + "," + textBox_PRENOM.Text + "," + int.Parse(textBox_AGE.Text) + ";";
            cmd.ExecuteNonQuery();
            ChargeDGV();
        }

        private void Supprimer_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "supprimer " + textBox_CIN.Text + ";";
            cmd.ExecuteNonQuery();
            ChargeDGV();
        }
   
        private void Rechercher_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "Rechercher " + textBox_CIN.Text + ";";
            SqlDataReader dr= cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                textBox_CIN.Text = dr[0].ToString();
                textBox_NOM.Text = dr[1].ToString();
                textBox_PRENOM.Text = dr[2].ToString();
                textBox_AGE.Text = dr[3].ToString();
                dr.Close();
            } else MessageBox.Show("nexiste");
        }

        private void Nouveau_Click(object sender, EventArgs e)
        {
            textBox_CIN.Text = textBox_NOM.Text = textBox_PRENOM.Text = textBox_AGE.Text = "";
        }
    }
}
