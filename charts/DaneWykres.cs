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
using System.Windows.Controls;
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
            //dataGridView2.Columns["CzasTrwania_koniec"].DefaultCellStyle.NullValue = "0";
            dataGridView2.Columns["Poprzednik_start"].DefaultCellStyle.NullValue = "0";
            dataGridView2.Columns["test_combi"].DefaultCellStyle.NullValue = "0";
        }

        public Chart chart = new Chart();
        private readonly ChartArea chartArea = new ChartArea();
        readonly Series series1 = new Series();
        readonly List<string> poprzednikKoniec = new List<string>();
        public List<string> czas_t = new List<string>();
        public List<string> nazwy = new List<string>();
        readonly List<string> critical = new List<string>();
        public static string SetTxTValue = "";
        private string fname;
        List<Obiekt> operacja = new List<Obiekt>();


        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new RysujWykres();
            var form3 = new DodajPoprzednika();
            List<string> ttip = new List<string>();
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


            foreach (DataGridViewRow item in dataGridView2.Rows)
            {

                item.ReadOnly = true;
                if (item.Cells[5].Value == null || string.IsNullOrEmpty(item.Cells[5].Value.ToString()) || item.Cells[5].Value == DBNull.Value)
                {
                    czas_t.Add("0");


                }
                else if (item.Cells[5].Value != null)
                {
                    czas_t.Add(item.Cells[5].Value.ToString());

                }



                if (item.Cells[1].Value == null || string.IsNullOrEmpty(item.Cells[1].Value.ToString()) || item.Cells[1].Value == DBNull.Value)
                {
                    nazwy.Add("0");
                }
                else if (item.Cells[1].Value != null)
                {
                    nazwy.Add(item.Cells[1].Value.ToString());
                }

                if (item.Cells[3].Value == null || string.IsNullOrEmpty(item.Cells[3].Value.ToString()) || item.Cells[3].Value == DBNull.Value)
                {

                    poprzednikKoniec.Add("0");
                    ttip.Add("0");

                }
                else if (item.Cells[3].Value != null)
                {
                    poprzednikKoniec.Add(item.Cells[3].Value.ToString());
                    ttip.Add(item.Cells[3].Value.ToString());
                }




            }


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
            int index_wykres = 0;


            var ct = czas_t.ConvertAll(int.Parse);
            var pk = poprzednikKoniec.ConvertAll(int.Parse);
            //czas t == koniec
            //poprzednikkoniec == start
            if (nazwy.Count > 0)
            {
                critical.Add(nazwy[0]);
            }
            else
            {
                critical.Add("0");
            }
            int i = 1;
            int j = 0;

            while (i < dataGridView2.Rows.Count)
            {
                if (pk[i] - ct[j] == 0)
                {
                    critical.Add(nazwy[i]);
                    j = i;
                    i++;
                }
                else if (pk[i] - ct[j] != 0)
                {
                    i++;
                }

            }





            /*
                        try
                        {
                            critical.Add(nazwy[0]);
                            for (int i = 1; i < dataGridView2.Rows.Count-1; i++)
                            {

                                for (int j = 0; j < dataGridView2.Rows.Count-1; j++)
                                {

                                    if (ct[i]==pk[j])
                                    {

                                        critical.Add(nazwy[i]);
                                        j = i;
                                        break;
                                    }

                                }

                            }
                        }

                        catch (ArgumentOutOfRangeException ex)
                        {

                            string error = ex.Message;
                            var result = MessageBox.Show("o ty psujo najgorsza", "Błąd indeksowania", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (result == DialogResult.Yes)
                            {
                                MessageBox.Show("haha ale psuja zepsuł");
                                this.Close();
                            }

                        }
            */

            List<string> critical_no_dupes = critical.Distinct().ToList();

            var crit_no_dupesSep = String.Join("->", critical_no_dupes.ToList());

            form2.critBox.Text = crit_no_dupesSep;



            string czas = "Najwcześniejszy początek: ";
            for (int k = 0; k < dataGridView2.Rows.Count; k++)
            {

                chart.Series["wykres"].Points.AddXY(k, poprzednikKoniec[k].ToString(), czas_t[k].ToString());
                index_wykres = chart.Series["wykres"].Points.AddXY(k, poprzednikKoniec[k].ToString(), czas_t[k].ToString());


                chart.Series["wykres"].Points[index_wykres].AxisLabel = nazwy[k];
                chart.Series["wykres"].Points[index_wykres].Label = nazwy[k];

                indeksy.Add(chart.Series["wykres"].Points.AddXY(k, poprzednikKoniec[k].ToString(), czas_t[k].ToString()));

                chart.Series["wykres"].Points[indeksy[k]].ToolTip = czas + ttip[k];
                chart.Series["wykres"].Points[indeksy[k]].Color = kolorki[k % kolorki.Count];
            }

            //label1.Text = ttip.ToString();
            // SetTxTValue = label1.Text;

            int calk;
            if (czas_t.Any())
            {
                calk = czas_t.Max(x => int.Parse(x));

            }
            else
            {
                calk = 0;
            }

            form2.label2.Text = calk.ToString();


            form2.Controls.Add(chart);

            form2.Show();


            fname = Environment.CurrentDirectory + "\\wykres.png";
            this.chart.SaveImage(fname, ChartImageFormat.Png);

            Hide();

        }


        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            DataGridView view = (DataGridView)sender;
            view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "wprowadz prawidlowe wartosci";

        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void buttonExit_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            chart.Series.Remove(series1);
            chart.ChartAreas.Clear();
            dataGridView2.DataSource = null;
            dataGridView2.Columns["dodaj_pop"].Visible = false;
            this.dataGridView2.AllowUserToAddRows = true;


        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow cur = dataGridView2.CurrentRow;
                DodajPoprzednika form3 = new DodajPoprzednika
                {
                    curRow = cur
                };





                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    if (((row.Cells[1].Value != null) && (row.Cells[1].Value.ToString() != dataGridView2.CurrentRow.Cells[1].Value.ToString()) && !(row.IsNewRow)))
                    {
                        int n = form3.dataGridView1_pop.Rows.Add();
                        form3.dataGridView1_pop.Rows[n].Cells[0].Value = row.Cells[1].Value.ToString(); // dodaj nazwy
                        form3.dataGridView1_pop.Rows[n].Cells[1].Value = row.Cells[5].Value.ToString(); // dodaj wartosci
                    }

                }
                form3.Show();

                cur.Cells[4].Style.BackColor = Color.Chartreuse;
                cur.Cells[4].Style.ForeColor = Color.Green;

                cur.Cells[4].Value = "dodano!";


            }



        }
        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
            row.ErrorText = "";


            if (dataGridView2.Rows[e.RowIndex].IsNewRow) { return; }


            if (e.ColumnIndex == 2)
            {
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out int i) || i < 0)
                {
                    e.Cancel = true;
                    row.ErrorText = "Wprowadź prawidłowe DODATNIE LICZBY całkowite w polu czas trwania";

                    dataGridView2.Rows[e.RowIndex].Cells[2].Value = "0";
                    dataGridView2.BeginEdit(true);
                }
                else
                {
                    row.ErrorText = string.Empty;
                }

                if (e.ColumnIndex == 1)
                {
                    var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

                    if (!regexItem.IsMatch(Convert.ToString(e.FormattedValue)))
                    {

                        e.Cancel = true;
                        row.ErrorText = "Wprowadź prawidłowe ZNAKI w polu nazwa";

                        dataGridView2.Rows[e.RowIndex].Cells[1].Value = "0";
                        dataGridView2.BeginEdit(true);
                    }
                    else
                    {
                        row.ErrorText = string.Empty;
                    }

                }
            }
        }


        private void endEdit_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns["dodaj_pop"].Visible = true;
            dataGridView2.Rows[0].Cells[4].Value = "dodano!";
            dataGridView2.Rows[0].Cells[4].Style.BackColor = Color.Chartreuse;
            dataGridView2.AllowUserToAddRows = false;


            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.Cells[2].Value == null || string.IsNullOrEmpty(row.Cells[2].Value.ToString()) || row.Cells[2].Value == DBNull.Value)
                {
                    row.Cells[5].Value = "0";

                }
                else
                {
                    row.Cells[5].Value = row.Cells[2].Value.ToString();

                }

                if (row.Cells[1].Value == null || string.IsNullOrEmpty(row.Cells[1].Value.ToString()) || row.Cells[1].Value == DBNull.Value)
                {
                    row.Cells[1].Value = "0";
                }

            }

        }

        private void dataGridview2_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["Poprzednik_start"].Value = "0";
            e.Row.Cells["test_combi"].Value = "0";
        }

        private void instrukcjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string howto = "1.Należy uzupełnić kolumny Nazwa oraz Czas Trwania\n\n2.Należy wcisnąć przycisk 'zatwierdź dane', przez co tabela " +
                "powinna rozszerzyć się o kolejną kolumnę.\n\n3.Należy dodawać poprzedników(idąc od góry do dołu) w odpowiednich rzędach, klikając na przycisk w kolumnie 'dodaj poprzednika'\n\n" +
                "4. Po dodaniu poprzedników, należy wcisnąć przycisk 'Rysuj'.\n ";
            MessageBox.Show(howto, "Instrukcja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void autorzyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aut = new Autorzy();
            aut.Show();
        }
    }
}

