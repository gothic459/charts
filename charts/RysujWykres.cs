using System;
using System.Windows.Forms;

namespace charts
{
    public partial class RysujWykres : Form
    {
        DaneWykres form1 = new DaneWykres();
        public RysujWykres()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            //label2.Text = DaneWykres.SetTxTValue;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            form1.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
            form1.Show();
        }

        private void buttonClose_2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
