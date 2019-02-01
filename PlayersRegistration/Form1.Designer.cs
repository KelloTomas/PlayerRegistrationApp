namespace WindowsFormsApplication1
{
    partial class Form1
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
			this.button1 = new System.Windows.Forms.Button();
			this.priezvisko = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.menoLabel = new System.Windows.Forms.Label();
			this.meno = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.klub = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.rocnik = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cislo = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.numOfRegistered = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.priezviskoView = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MenoView = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.RocnikView = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.KlubView = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.KategoriaView = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.kategoria = new System.Windows.Forms.ComboBox();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(651, 208);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "Pridaj";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// priezvisko
			// 
			this.priezvisko.Location = new System.Drawing.Point(11, 28);
			this.priezvisko.Name = "priezvisko";
			this.priezvisko.Size = new System.Drawing.Size(100, 20);
			this.priezvisko.TabIndex = 0;
			this.priezvisko.TextChanged += new System.EventHandler(this.Priezvisko_TextChanged);
			this.priezvisko.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Priezvisko_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Priezvisko";
			// 
			// menoLabel
			// 
			this.menoLabel.AutoSize = true;
			this.menoLabel.Location = new System.Drawing.Point(118, 9);
			this.menoLabel.Name = "menoLabel";
			this.menoLabel.Size = new System.Drawing.Size(34, 13);
			this.menoLabel.TabIndex = 0;
			this.menoLabel.Text = "Meno";
			// 
			// meno
			// 
			this.meno.Location = new System.Drawing.Point(117, 28);
			this.meno.Name = "meno";
			this.meno.Size = new System.Drawing.Size(100, 20);
			this.meno.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(331, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(28, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Klub";
			// 
			// klub
			// 
			this.klub.Location = new System.Drawing.Point(330, 28);
			this.klub.Name = "klub";
			this.klub.Size = new System.Drawing.Size(100, 20);
			this.klub.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(435, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(52, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Kategoria";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(224, 9);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Rocnik";
			// 
			// rocnik
			// 
			this.rocnik.Location = new System.Drawing.Point(223, 28);
			this.rocnik.Name = "rocnik";
			this.rocnik.Size = new System.Drawing.Size(100, 20);
			this.rocnik.TabIndex = 2;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(648, 161);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(29, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Cislo";
			// 
			// cislo
			// 
			this.cislo.Location = new System.Drawing.Point(647, 177);
			this.cislo.Name = "cislo";
			this.cislo.Size = new System.Drawing.Size(79, 20);
			this.cislo.TabIndex = 5;
			this.cislo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cislo_KeyPress);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(629, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(97, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Pocet prihlasenych";
			// 
			// numOfRegistered
			// 
			this.numOfRegistered.Location = new System.Drawing.Point(629, 31);
			this.numOfRegistered.Name = "numOfRegistered";
			this.numOfRegistered.Size = new System.Drawing.Size(97, 13);
			this.numOfRegistered.TabIndex = 0;
			this.numOfRegistered.Text = "0";
			this.numOfRegistered.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(651, 237);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 8;
			this.button2.TabStop = false;
			this.button2.Text = "Uloz XLSX";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.btn_SaveXLSX);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.priezviskoView,
            this.MenoView,
            this.RocnikView,
            this.KlubView,
            this.KategoriaView,
            this.Email});
			this.dataGridView1.Location = new System.Drawing.Point(11, 68);
			this.dataGridView1.MultiSelect = false;
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridView1.ShowCellToolTips = false;
			this.dataGridView1.ShowEditingIcon = false;
			this.dataGridView1.Size = new System.Drawing.Size(618, 220);
			this.dataGridView1.TabIndex = 0;
			this.dataGridView1.TabStop = false;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellClick);
			this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView1_KeyDown);
			this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataGridView1_KeyPress);
			this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.DataGridView1_KeyUp);
			// 
			// priezviskoView
			// 
			this.priezviskoView.FillWeight = 107.1589F;
			this.priezviskoView.HeaderText = "Priezvisko";
			this.priezviskoView.Name = "priezviskoView";
			this.priezviskoView.ReadOnly = true;
			// 
			// MenoView
			// 
			this.MenoView.FillWeight = 107.1589F;
			this.MenoView.HeaderText = "Meno";
			this.MenoView.Name = "MenoView";
			this.MenoView.ReadOnly = true;
			// 
			// RocnikView
			// 
			this.RocnikView.FillWeight = 101.5228F;
			this.RocnikView.HeaderText = "Rocnik";
			this.RocnikView.Name = "RocnikView";
			this.RocnikView.ReadOnly = true;
			// 
			// KlubView
			// 
			this.KlubView.FillWeight = 107.1589F;
			this.KlubView.HeaderText = "Klub";
			this.KlubView.Name = "KlubView";
			this.KlubView.ReadOnly = true;
			// 
			// KategoriaView
			// 
			this.KategoriaView.FillWeight = 77.00042F;
			this.KategoriaView.HeaderText = "Kategoria";
			this.KategoriaView.Name = "KategoriaView";
			this.KategoriaView.ReadOnly = true;
			// 
			// Email
			// 
			this.Email.HeaderText = "Email";
			this.Email.Name = "Email";
			this.Email.ReadOnly = true;
			// 
			// kategoria
			// 
			this.kategoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.kategoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.kategoria.FormattingEnabled = true;
			this.kategoria.Location = new System.Drawing.Point(436, 28);
			this.kategoria.Name = "kategoria";
			this.kategoria.Size = new System.Drawing.Size(121, 21);
			this.kategoria.TabIndex = 4;
			this.kategoria.Text = "MA";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(651, 265);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 11;
			this.button3.TabStop = false;
			this.button3.Text = "Uloz csv";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Btn_SaveCSV);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(739, 300);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.kategoria);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.numOfRegistered);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.cislo);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.rocnik);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.klub);
			this.Controls.Add(this.menoLabel);
			this.Controls.Add(this.meno);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.priezvisko);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }



        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox priezvisko;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label menoLabel;
        private System.Windows.Forms.TextBox meno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox klub;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox rocnik;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox cislo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label numOfRegistered;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ComboBox kategoria;
		private System.Windows.Forms.DataGridViewTextBoxColumn priezviskoView;
		private System.Windows.Forms.DataGridViewTextBoxColumn MenoView;
		private System.Windows.Forms.DataGridViewTextBoxColumn RocnikView;
		private System.Windows.Forms.DataGridViewTextBoxColumn KlubView;
		private System.Windows.Forms.DataGridViewTextBoxColumn KategoriaView;
		private System.Windows.Forms.DataGridViewTextBoxColumn Email;
		private System.Windows.Forms.Button button3;
	}
}

