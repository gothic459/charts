using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Color = System.Drawing.Color;

namespace charts
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        Chart chart = new Chart();
        ChartArea chartArea = new ChartArea();
        Legend legend1 = new Legend();
        Series series1 = new Series();
        List<string> start = new List<string>();
        List<string> koniec = new List<string>();
        List<string> nazwy = new List<string>();
        public static string SetTxTValue = "";


        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();

            foreach (DataGridViewRow item in dataGridView2.Rows)
            {
                item.ReadOnly = true;

                if (item.Cells[2].Value != null)
                {
                    start.Add(item.Cells[2].Value.ToString());

                }
                if (item.Cells[3].Value != null)
                {
                    koniec.Add(item.Cells[3].Value.ToString());

                }

                if (item.Cells[1].Value != null)
                {
                    nazwy.Add(item.Cells[1].Value.ToString());
                }

            }


            chart.Series.Clear();
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
                Color.AliceBlue,
                Color.Beige,
                Color.Brown,
                Color.Orange,
                Color.Yellow
            };
            List<int> indeksy = new List<int>();
            List<int> ttip = new List<int>();
            int ile_row_count = (dataGridView2.Rows.Count - 1);
            for (int i = 0; i < ile_row_count; i++)
            {
                ttip.Add(Int32.Parse(koniec[i]) - Int32.Parse(start[i]));

            }


            int index_wykres = 0;
            string czas = "Czas wykonywania: ";
            for (int i = 0; i < ile_row_count; i++)
            {
                index_wykres = chart.Series["wykres"].Points.AddXY(i, start[i], koniec[i]);
                chart.Series["wykres"].Points.AddXY(i, start[i], koniec[i]);
                chart.Series["wykres"].Points[index_wykres].Label = nazwy[i];
                chart.Series["wykres"].Points[index_wykres].AxisLabel = nazwy[i];

                indeksy.Add(chart.Series["wykres"].Points.AddXY(i, start[i], koniec[i]));
                chart.Series["wykres"].Points[indeksy[i]].ToolTip = czas + ttip[i].ToString();
                chart.Series["wykres"].Points[indeksy[i]].Color = kolorki[i % kolorki.Count];
            }

            int laczne = ttip.Sum(x => (x));
            label1.Text = laczne.ToString();
            SetTxTValue = label1.Text;
            form2.Controls.Add(chart);

            form2.Show();
            this.Hide();

        }
        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (dataGridView2.Rows[e.RowIndex].IsNewRow) { return; }




            //error handler dla ujemnych i  nie int w start i koniec
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                int i;
                this.dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "";

                if (!int.TryParse(Convert.ToString(e.FormattedValue), out i) || i < 0)
                {
                    this.dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "tylko dodatnie liczby całkowite";
                    DialogResult x = new DialogResult();
                    x = MessageBox.Show("tylko dodanie byczq");
                    if (x == DialogResult.OK)
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
                        dataGridView2.EditingControl.Text = string.Empty;
                        dataGridView2.BeginEdit(true);
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

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
        }


    }
}
