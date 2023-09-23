using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;

namespace CambridgeExam
{
    public partial class Checker : Form
    {
        public Checker()
        {
            InitializeComponent();
        }
     
        List<question> Li;
        int poz = -1;

        private void Testare_Shown(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=teste_grila.accdb;");
            conn.Open();
            var Laux = new List<question>();
            string q = "SELECT * FROM questions";
            OleDbCommand cmd = new OleDbCommand(q, conn);
            OleDbDataReader curr = cmd.ExecuteReader();
            while (curr.Read())
            {
                question i = new question(int.Parse(curr[0].ToString()), curr[1].ToString(), curr[2].ToString(), curr[3].ToString(), curr[5].ToString(), curr[4].ToString(), curr[6].ToString());
                i.raspuns = "";
                Laux.Add(i);
            }
            Li = Laux.OrderBy(it => Guid.NewGuid()).Take(10).ToList(); 
            curr.Close();
            radioButton1.Checked = false;
            poz = 0;
            Query(0);
        }
        
        void Query(int i)
        {
            label1.Text = Li[i].enunt;
            radioButton1.Text = Li[i].a; radioButton1.Checked = false;
            radioButton2.Text = Li[i].b; radioButton2.Checked = false;
            radioButton3.Text = Li[i].c; radioButton3.Checked = false;
            radioButton4.Text = Li[i].d; radioButton4.Checked = false;

            if (Li[i].raspuns == "A") radioButton1.Checked = true;
            if (Li[i].raspuns == "B") radioButton2.Checked = true;
            if (Li[i].raspuns == "C") radioButton3.Checked = true;
            if (Li[i].raspuns == "D") radioButton4.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int cnt = 0;
            for (int i = 0; i < Li.Count; i++)
                if (Li[i].corect == Li[i].raspuns) cnt++;
            string certificat = "";
            if (cnt <= 4) certificat = "Din pacate, nu ai primit niciun certficiat.";
            else if (cnt <= 6) certificat = "Ai obtinut certificatul B2.";
            else if (cnt <= 8) certificat = "Felicitari! Ai obtinut certificatul C1.";
            else certificat = "Felicitari! Ai obtinut certificatul C2.";
            MessageBox.Show("Scor: " + cnt + "/10\n" + certificat);
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            if (poz > 0)
                Query(--poz);
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            if (poz < Li.Count - 1)
                Query(++poz);
       
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (poz >= 0 && radioButton1.Checked) 
                Li[poz].raspuns = "A";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (poz >= 0 && radioButton2.Checked)
                Li[poz].raspuns = "B";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (poz >= 0 && radioButton3.Checked) 
                Li[poz].raspuns = "C";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (poz >= 0 && radioButton4.Checked) 
                Li[poz].raspuns = "D";
        }

        private void Checker_Load(object sender, EventArgs e)
        {

        }
    }
}
