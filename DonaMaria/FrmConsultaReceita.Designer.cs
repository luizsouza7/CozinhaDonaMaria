namespace DonaMaria
{
    partial class FrmConsultaReceita
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
            label1 = new Label();
            textBox1 = new TextBox();
            btnLocalizar = new Button();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewImageColumn();
            Nome = new DataGridViewTextBoxColumn();
            Receita = new DataGridViewTextBoxColumn();
            btnAbrir = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(192, 15);
            label1.TabIndex = 0;
            label1.Text = "Critérios para localização da receita";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(786, 23);
            textBox1.TabIndex = 1;
            // 
            // btnLocalizar
            // 
            btnLocalizar.Location = new Point(12, 65);
            btnLocalizar.Name = "btnLocalizar";
            btnLocalizar.Size = new Size(790, 29);
            btnLocalizar.TabIndex = 2;
            btnLocalizar.Text = "Localizar Receita";
            btnLocalizar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Nome, Receita, btnAbrir });
            dataGridView1.Location = new Point(12, 120);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(786, 275);
            dataGridView1.TabIndex = 3;
            // 
            // Column1
            // 
            Column1.HeaderText = "Foto";
            Column1.Name = "Column1";
            // 
            // Nome
            // 
            Nome.HeaderText = "Nome da Receita";
            Nome.Name = "Nome";
            Nome.Width = 175;
            // 
            // Receita
            // 
            Receita.HeaderText = "Descrição";
            Receita.Name = "Receita";
            Receita.Width = 350;
            // 
            // btnAbrir
            // 
            btnAbrir.HeaderText = "Abrir";
            btnAbrir.Name = "btnAbrir";
            // 
            // FrmConsultaReceita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            StartPosition = FormStartPosition.CenterParent;
            Controls.Add(dataGridView1);
            Controls.Add(btnLocalizar);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "FrmConsultaReceita";
            Text = "Consultar Receitas";
            AcceptButton = btnLocalizar;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button btnLocalizar;
        private DataGridView dataGridView1;
        private DataGridViewImageColumn Column1;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn Receita;
        private DataGridViewButtonColumn btnAbrir;
    }
}