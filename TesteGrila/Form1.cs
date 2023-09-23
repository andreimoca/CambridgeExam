using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CambridgeExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection conn;
        private void button1_Click(object sender, EventArgs e)
        {
            Checker bdg = new Checker();
            bdg.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string parola = textBox2.Text;
            if (user != "" && parola != "")
            {
                string up = "SELECT * FROM users WHERE User='" + user + "' AND Parola='" + parola + "'";
                OleDbCommand cmd = new OleDbCommand(up, conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label3.Text = "Bun venit, " + dr[1] + "!\n\nEsti gata sa incepi testul Cambridge CAE?\nAcest test consta in 10 intrebari grila.\nIntrebarile sunt selectate dintr-o vasta baza de date.\nAstfel, testele nu se vor repeta.\nIn functie de scorul obtinut vei primi certificat C2, C1 sau B2.\n\nSucces!";
                    groupBox1.Visible = false;
                    groupBox2.Visible = true;
                    groupBox2.Left = groupBox1.Left;
                    groupBox2.Top = groupBox1.Top;
                    
                }
                else MessageBox.Show("Date de conectare gresite!");
                dr.Close();
            }
            else MessageBox.Show("Nu ati completat datele de conectare!");
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=teste_grila.accdb;");
            conn.Open();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
