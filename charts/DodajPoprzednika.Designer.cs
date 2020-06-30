﻿namespace charts
{
    partial class DodajPoprzednika
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1_pop = new System.Windows.Forms.DataGridView();
            this.Nazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pop_col = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.operacjeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new charts.DataSet1();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_pop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operacjeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Dodaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(427, 214);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Anuluj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1_pop
            // 
            this.dataGridView1_pop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1_pop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1_pop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazwa,
            this.wart,
            this.pop_col});
            this.dataGridView1_pop.Location = new System.Drawing.Point(143, 12);
            this.dataGridView1_pop.Name = "dataGridView1_pop";
            this.dataGridView1_pop.Size = new System.Drawing.Size(359, 165);
            this.dataGridView1_pop.TabIndex = 7;
            // 
            // Nazwa
            // 
            this.Nazwa.DataPropertyName = "Nazwa";
            this.Nazwa.HeaderText = "Nazwa";
            this.Nazwa.Name = "Nazwa";
            this.Nazwa.ReadOnly = true;
            // 
            // wart
            // 
            this.wart.HeaderText = "Wartosc";
            this.wart.Name = "wart";
            // 
            // pop_col
            // 
            this.pop_col.HeaderText = "poprzednik";
            this.pop_col.Name = "pop_col";
            // 
            // operacjeBindingSource
            // 
            this.operacjeBindingSource.DataMember = "Operacje";
            this.operacjeBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DodajPoprzednika
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 258);
            this.Controls.Add(this.dataGridView1_pop);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "DodajPoprzednika";
            this.Text = "dodawanie poprzednika";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DodajPoprzednika_FormClosing);
            this.Load += new System.EventHandler(this.DodajPoprzednika_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_pop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operacjeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource operacjeBindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.DataGridView dataGridView1_pop;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa;
        private System.Windows.Forms.DataGridViewTextBoxColumn wart;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pop_col;
    }
}