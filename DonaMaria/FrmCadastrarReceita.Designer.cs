namespace DonaMaria
{
    partial class FrmCadastrarReceita
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
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            dataGridView2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            btnAdicionarIngredientes = new Button();
            label5 = new Label();
            comboBox1 = new ComboBox();
            textBox3 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            numericUpDown3 = new NumericUpDown();
            dataGridView1 = new DataGridView();
            Código = new DataGridViewTextBoxColumn();
            Nome = new DataGridViewTextBoxColumn();
            Cozinha = new DataGridViewTextBoxColumn();
            Tempo = new DataGridViewTextBoxColumn();
            Porções = new DataGridViewTextBoxColumn();
            btnSalvar = new Button();
            btnAlterar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // textBox2
            // 
            textBox2.Location = new Point(102, 27);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(681, 23);
            textBox2.TabIndex = 20;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(66, 23);
            textBox1.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 9);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 17;
            label2.Text = "Nome da Receita";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 16;
            label1.Text = "Código";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 60);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 24;
            label3.Text = "Tipo de Cozinha";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 90);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 25;
            label4.Text = "Ingredientes";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            dataGridView2.Location = new Point(12, 108);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(596, 57);
            dataGridView2.TabIndex = 26;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Ingrediente";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Quantidade";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 175;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Unidade de Medida";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 275;
            // 
            // btnAdicionarIngredientes
            // 
            btnAdicionarIngredientes.Location = new Point(624, 108);
            btnAdicionarIngredientes.Name = "btnAdicionarIngredientes";
            btnAdicionarIngredientes.Size = new Size(99, 46);
            btnAdicionarIngredientes.TabIndex = 27;
            btnAdicionarIngredientes.Text = "Adicionar Ingredientes";
            btnAdicionarIngredientes.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 178);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 28;
            label5.Text = "Modo de Preparo";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(111, 57);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(88, 23);
            comboBox1.TabIndex = 29;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 196);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.Size = new Size(596, 84);
            textBox3.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 307);
            label6.Name = "label6";
            label6.Size = new Size(104, 15);
            label6.TabIndex = 31;
            label6.Text = "Tempo de Preparo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(230, 307);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 32;
            label7.Text = "Minutos";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 346);
            label8.Name = "label8";
            label8.Size = new Size(49, 15);
            label8.TabIndex = 33;
            label8.Text = "Porções";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(122, 305);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(70, 23);
            numericUpDown1.TabIndex = 34;
            // 
            // numericUpDown2
            // 
            numericUpDown2.Location = new Point(287, 305);
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(70, 23);
            numericUpDown2.TabIndex = 35;
            // 
            // numericUpDown3
            // 
            numericUpDown3.Location = new Point(67, 344);
            numericUpDown3.Name = "numericUpDown3";
            numericUpDown3.Size = new Size(70, 23);
            numericUpDown3.TabIndex = 36;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Código, Nome, Cozinha, Tempo, Porções });
            dataGridView1.Location = new Point(-2, 385);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(805, 67);
            dataGridView1.TabIndex = 37;
            // 
            // Código
            // 
            Código.HeaderText = "Código";
            Código.Name = "Código";
            // 
            // Nome
            // 
            Nome.HeaderText = "Nome da Receita";
            Nome.Name = "Nome";
            Nome.Width = 200;
            // 
            // Cozinha
            // 
            Cozinha.HeaderText = "Tipo de Cozinha";
            Cozinha.Name = "Cozinha";
            Cozinha.Width = 150;
            // 
            // Tempo
            // 
            Tempo.HeaderText = "Tempo de Preparo";
            Tempo.Name = "Tempo";
            Tempo.Width = 150;
            // 
            // Porções
            // 
            Porções.HeaderText = "Porções";
            Porções.Name = "Porções";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(287, 346);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(70, 33);
            btnSalvar.TabIndex = 38;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnAlterar
            // 
            btnAlterar.Location = new Point(363, 346);
            btnAlterar.Name = "btnAlterar";
            btnAlterar.Size = new Size(70, 33);
            btnAlterar.TabIndex = 39;
            btnAlterar.Text = "Alterar";
            btnAlterar.UseVisualStyleBackColor = true;
            // 
            // FrmCadastrarReceita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAlterar);
            Controls.Add(btnSalvar);
            Controls.Add(dataGridView1);
            Controls.Add(numericUpDown3);
            Controls.Add(numericUpDown2);
            Controls.Add(numericUpDown1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(textBox3);
            Controls.Add(comboBox1);
            Controls.Add(label5);
            Controls.Add(btnAdicionarIngredientes);
            Controls.Add(dataGridView2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmCadastrarReceita";
            Text = "Cadastrar Receitas";
            Load += FrmCadastrarReceita_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Button btnAdicionarIngredientes;
        private Label label5;
        private ComboBox comboBox1;
        private TextBox textBox3;
        private Label label6;
        private Label label7;
        private Label label8;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Código;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Cozinha;
        private DataGridViewTextBoxColumn Tempo;
        private DataGridViewTextBoxColumn Porções;
        private Button btnSalvar;
        private Button btnAlterar;
    }
}