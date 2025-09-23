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
            dataGridView1.Location = new Point(12, 200);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 200);
            dataGridView1.TabIndex = 14;
            // 
            // Ingredientes
            // 
            Ingredientes.HeaderText = "Ingredientes";
            Ingredientes.Name = "Ingredientes";
            Ingredientes.Width = 250;
            // 
            // Qtd
            // 
            Qtd.HeaderText = "Quantidade";
            Qtd.Name = "Qtd";
            Qtd.Width = 150;
            // 
            // Observação
            // 
            Observação.HeaderText = "Observação";
            Observação.Name = "Observação";
            Observação.Width = 300;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 80);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.Size = new Size(400, 100);
            textBox3.TabIndex = 13;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 30);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(400, 23);
            textBox2.TabIndex = 12;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 62);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 10;
            label3.Text = "Modo de Preparo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 12);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 9;
            label2.Text = "Nome:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(430, 12);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 15;
            label4.Text = "Imagem:";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(430, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(358, 150);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.Location = new Point(713, 410);
            button1.Name = "button1";
            button1.Size = new Size(75, 30);
            button1.TabIndex = 17;
            button1.Text = "Fechar";
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
            Text = "Detalhes da Receita";
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