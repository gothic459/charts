using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace charts
{
    public partial class DodajPoprzednika : Form
    {


        public DodajPoprzednika()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Close();

        }


        public DataGridViewRow curRow;
        private void button1_Click(object sender, EventArgs e)
        {
            List<int> getmax = new List<int>();
            var max = 0;

            foreach (DataGridViewRow row in dataGridView1_pop.Rows)
            {

                if ((Convert.ToBoolean(row.Cells[2].Value)))
                {
                    getmax.Add(Convert.ToInt32(row.Cells[1].Value));
                    MessageBox.Show("dodano: " + row.Cells[0].Value.ToString());
                }


            }

            int val = Convert.ToInt32(curRow.Cells[5].Value);
            if (getmax.Count == 0)
            {
                max = 0;
                MessageBox.Show("brak poprzednika!");
            }
            else
            {
                max = getmax.Max();
            }



            curRow.Cells[3].Value = max.ToString();
            curRow.Cells[5].Value = val + max;

            this.Close();

        }


        private void DodajPoprzednika_Load(object sender, EventArgs e)
        {

            dlakogo.Text = "Poprzednik dla\n" + curRow.Cells[1].Value.ToString();

        }

        private void DodajPoprzednika_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }

}
