namespace DonaMaria
{
    partial class FrmDetalheConsulta
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
            dataGridView1 = new DataGridView();
            Ingredientes = new DataGridViewTextBoxColumn();
            Qtd = new DataGridViewTextBoxColumn();
            Observação = new DataGridViewTextBoxColumn();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Ingredientes, Qtd, Observação });
            dataGridView1.Location = new Point(0, 282);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(800, 164);
            dataGridView1.TabIndex = 14;
            // 
            // Ingredientes
            // 
            Ingredientes.HeaderText = "Ingredientes";
            Ingredientes.Name = "Ingredientes";
            // 
            // Qtd
            // 
            Qtd.HeaderText = "Qtd";
            Qtd.Name = "Qtd";
            Qtd.Width = 175;
            // 
            // Observação
            // 
            Observação.HeaderText = "Observação";
            Observação.Name = "Observação";
            Observação.Width = 275;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(11, 75);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.Size = new Size(408, 178);
            textBox3.TabIndex = 13;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(11, 24);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(487, 28);
            textBox2.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 57);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 10;
            label3.Text = "Receita";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 5);
            label2.Name = "label2";
            label2.Size = new Size(161, 15);
            label2.TabIndex = 9;
            label2.Text = "Critérios para buscar receitas:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(447, 57);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 15;
            label4.Text = "Imagem";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(447, 75);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(350, 178);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(518, 17);
            button1.Name = "button1";
            button1.Size = new Size(75, 35);
            button1.TabIndex = 17;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmDetalheConsulta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(dataGridView1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "FrmDetalheConsulta";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Consultar Receita";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label3;
        private Label label2;
        private Label label4;
        private PictureBox pictureBox1;
        private DataGridViewTextBoxColumn Ingredientes;
        private DataGridViewTextBoxColumn Qtd;
        private DataGridViewTextBoxColumn Observação;
        private Button button1;
    }
}