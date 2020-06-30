﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace charts
{
    public partial class DodajPoprzednika : Form
    {

        DaneWykres form1 = new DaneWykres();

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

            foreach (DataGridViewRow row in dataGridView1_pop.Rows)
            {

                if ((Convert.ToBoolean(row.Cells[2].Value)))
                {
                    getmax.Add(Convert.ToInt32(row.Cells[1].Value));
                }

                else
                {
                    getmax.Add(0);
                }

            }

            int val = Convert.ToInt32(curRow.Cells[2].Value);
            int max = getmax.Max();


            curRow.Cells[3].Value = max.ToString();
            curRow.Cells[2].Value = val + max;


            //this.Close();

        }

        //to-do
        // push the max value to current row in which the button has been pressed and add that value to cell[3], treat is as poprzednikKoniec


        private void DodajPoprzednika_Load(object sender, EventArgs e)
        {



        }

        private void DodajPoprzednika_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }

}
