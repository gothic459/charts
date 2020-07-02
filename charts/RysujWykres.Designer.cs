namespace charts
{
    partial class RysujWykres
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonClose_2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.critBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(240, 542);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(479, 74);
            this.label2.TabIndex = 0;
            this.label2.Text = "sc";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(15, 542);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 53);
            this.label3.TabIndex = 2;
            this.label3.Text = "Całkowity czas:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 649);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(556, 68);
            this.button2.TabIndex = 3;
            this.button2.Text = "nowy wykres";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonClose_2
            // 
            this.buttonClose_2.Location = new System.Drawing.Point(850, 649);
            this.buttonClose_2.Name = "buttonClose_2";
            this.buttonClose_2.Size = new System.Drawing.Size(146, 68);
            this.buttonClose_2.TabIndex = 4;
            this.buttonClose_2.Text = "Zakończ";
            this.buttonClose_2.UseVisualStyleBackColor = true;
            this.buttonClose_2.Click += new System.EventHandler(this.buttonClose_2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15F);
            this.label1.Location = new System.Drawing.Point(18, 605);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Droga krytyczna: ";
            // 
            // critBox
            // 
            this.critBox.BackColor = System.Drawing.SystemColors.Control;
            this.critBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.critBox.Font = new System.Drawing.Font("Tahoma", 15F);
            this.critBox.Location = new System.Drawing.Point(173, 605);
            this.critBox.Name = "critBox";
            this.critBox.Size = new System.Drawing.Size(791, 25);
            this.critBox.TabIndex = 7;
            // 
            // RysujWykres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.critBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClose_2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Name = "RysujWykres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wykres";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonClose_2;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox critBox;
    }
}