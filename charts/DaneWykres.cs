using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Media.Animation;
using Color = System.Drawing.Color;

namespace charts
{
    public partial class DaneWykres : Form
    {

        public DaneWykres()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView2.Columns["dodaj_pop"].Visible = false;
        }

        Chart chart = new Chart();
        ChartArea chartArea = new ChartArea();
        Series series1 = new Series();
        List<string> poprzednikKoniec = new List<string>();
        public List<string> czas_t = new List<string>();
        public List<string> nazwy = new List<string>();
        public static string SetTxTValue = "";
        private string fname;
        public List<int> max_val = new List<int>();

        List<int> latestart = new List<int>();

        List<string> critical = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new RysujWykres();
            var form3 = new DodajPoprzednika();


            foreach (DataGridViewRow item in dataGridView2.Rows)
            {

                item.ReadOnly = true;
                if (item.Cells[5].Value != null)
                {
                    czas_t.Add(item.Cells[5].Value.ToString());
                }
                if (item.Cells[1].Value != null)
                {
                    nazwy.Add(item.Cells[1].Value.ToString());
                }

                if (item.Cells[3].Value != null)
                {
                    if (string.IsNullOrEmpty(item.Cells[3].Value.ToString()))
                    {
                        poprzednikKoniec.Add("0");
                    }
                    else
                    {
                        poprzednikKoniec.Add(item.Cells[3].Value.ToString());
                    }

                }

            }

            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Size = new Size(1008, 500);
            chart.Location = new Point(100, 50);
            chart.BackColor = System.Drawing.Color.LightBlue;
            chart.BorderlineColor = System.Drawing.Color.Black;
            chart.ChartAreas.Add(chartArea);
            chartArea.Position.X = 0;
            chartArea.Position.Width = 100;
            chartArea.Position.Height = 100;
            chartArea.Position.Y = 0;
            chartArea.AxisX.IsReversed = true;
            series1.ChartType = SeriesChartType.RangeBar;
            series1.Name = "wykres";
            chart.Series.Add(series1);
            chart.Dock = DockStyle.Top;
            chart.Series["wykres"]["PixelPointWidth"] = "20";
            chartArea.AxisX.LabelStyle.Format = "{ }";

            var kolorki = new List<Color>
            {
                Color.Red,
                Color.Green,
                Color.Gray,
                Color.BlueViolet,
                Color.Beige,
                Color.Brown,
                Color.Orange,
                Color.Yellow
            };
            List<int> indeksy = new List<int>();

            List<int> ttip = new List<int>();

            int ile_row_count = (dataGridView2.Rows.Count);

            int index_wykres = 0;






            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                var ct = czas_t.ConvertAll(int.Parse);
                ttip.Add(ct[i]);




            }
            int y = 0;
            int z = 0;
            //czas t == koniec
            //poprzednikkoniec == start
            while (y < dataGridView2.Rows.Count - 1 || z < dataGridView2.Rows.Count - 1)
            {
                var ct = czas_t.ConvertAll(int.Parse);
                var pk = poprzednikKoniec.ConvertAll(int.Parse);

                if (pk[y + 1] == ct[z])
                {

                    critical.Add(nazwy[z]);
                    critical.Add(nazwy[y + 1]);
                    y++;
                    z = y;
                }
                else
                {
                    y++;
                }

            }



            List<string> critical_no_dupes = critical.Distinct().ToList();
            form2.crit.DataSource = critical_no_dupes;

            string czas = "Czas wykonywania: ";
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {

                chart.Series["wykres"].Points.AddXY(i, poprzednikKoniec[i].ToString(), czas_t[i].ToString());
                index_wykres = chart.Series["wykres"].Points.AddXY(i, poprzednikKoniec[i].ToString(), czas_t[i].ToString());

                chart.Series["wykres"].Points[index_wykres].Label = nazwy[i];
                chart.Series["wykres"].Points[index_wykres].AxisLabel = nazwy[i];

                indeksy.Add(chart.Series["wykres"].Points.AddXY(i, poprzednikKoniec[i].ToString(), czas_t[i].ToString()));

                chart.Series["wykres"].Points[indeksy[i]].ToolTip = czas + ttip[i].ToString();
                chart.Series["wykres"].Points[indeksy[i]].Color = kolorki[i % kolorki.Count];
            }

            label1.Text = ttip.ToString();
            SetTxTValue = label1.Text;

            int calk = czas_t.Max(x => int.Parse(x));


            form2.label2.Text = calk.ToString();

            form2.Controls.Add(chart);

            form2.Show();

            fname = Environment.CurrentDirectory + "\\wykres.png";
            this.chart.SaveImage(fname, ChartImageFormat.Png);
            //Hide();

        }
        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (dataGridView2.Rows[e.RowIndex].IsNewRow) { return; }

            //error handler dla ujemnych i  nie int w poprzednikKoniec i czas_t
            if (e.ColumnIndex == 2)
            {
                int i;
                dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || i < 0)
                {
                    dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "tylko dodatnie liczby całkowite byczq";
                    DialogResult x = new DialogResult();

                    x = MessageBox.Show("tylko dodanie byczq");
                    if (x == DialogResult.OK)
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridView2.BeginEdit(true);
                        dataGridView2.EditingControl.Text = string.Empty;
                        dataGridView2.CancelEdit();
                    }
                    e.Cancel = true;

                }

            }
            //error handler dla znakow specjalnych w nazie
            if (e.ColumnIndex == 1)
            {
                var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

                if (!regexItem.IsMatch(Convert.ToString(e.FormattedValue)))
                {
                    DialogResult x = new DialogResult();
                    x = MessageBox.Show("Bez znakow specjalnych");
                    if (x == DialogResult.OK)
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridView2.EditingControl.Text = string.Empty;
                        dataGridView2.BeginEdit(true);
                    }
                    e.Cancel = true;


                }


            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*   if (e.ColumnIndex == 4)
               {
                   Form form3 = new DodajPoprzednika();
                   form3.MdiParent = this.MdiParent;

                   //form3.checkedListBox1.Items.Add(dataGridView2.Rows[0].Cells[1].Value);
                   form3.ShowDialog();
               }
            */
        }



        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Columns["dodaj_pop"].Visible = false;

            this.dataGridView2.AllowUserToAddRows = true;


        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow cur = dataGridView2.CurrentRow;
            DodajPoprzednika form3 = new DodajPoprzednika();

            form3.curRow = cur;
            if (e.RowIndex != 0)
            {

                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    if (((row.Cells[1].Value != null) && (row.Cells[1].Value.ToString() != dataGridView2.CurrentRow.Cells[1].Value.ToString()) && !(row.IsNewRow)))
                    {
                        int n = form3.dataGridView1_pop.Rows.Add();
                        form3.dataGridView1_pop.Rows[n].Cells[0].Value = row.Cells[1].Value.ToString(); // dodaj nazwy
                        form3.dataGridView1_pop.Rows[n].Cells[1].Value = row.Cells[5].Value.ToString(); // dodaj wartosci
                    }

                }

            }

            form3.Show();
        }

        private void endEdit_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns["dodaj_pop"].Visible = true;
            dataGridView2.AllowUserToAddRows = false;


            foreach (DataGridViewRow row in dataGridView2.Rows)
            {

                row.Cells[5].Value = row.Cells[2].Value.ToString();

            }

        }







        //critical path = calkowita dlugosc - czastrwania_koniec dla kazdego PO KOLEI, pozniej if wynik tego == poprzednik_start  wtedy nazwa idzie do critical path else dawaj dalej
    }
}
/*                //jesli nie jest new row ani nie jest == current row wtedy dodaj pozostale
                DataGridViewCell cur_row = dataGridView2.CurrentRow.Cells[4];
                string current = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                string cur_value = dataGridView2.CurrentRow.Cells[3].Value.ToString();

                foreach (DataGridViewRow item in dataGridView2.Rows)
                {
                    if ((item.Cells[1].Value != null) && (item.Cells[1].Value.ToString() != current) && !(item.IsNewRow))
                    {

                        
                        
                    }

                }

*/
