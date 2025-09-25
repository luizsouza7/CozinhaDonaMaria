namespace DonaMaria
{
    partial class FrmSugestaoReceita
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
            txtNome = new TextBox();
            label2 = new Label();
            txtTipo = new TextBox();
            label3 = new Label();
            gridIngredientes = new DataGridView();
            colIng = new DataGridViewTextBoxColumn();
            colQtd = new DataGridViewTextBoxColumn();
            colObs = new DataGridViewTextBoxColumn();
            label4 = new Label();
            txtModoPreparo = new TextBox();
            label5 = new Label();
            txtUtensilios = new TextBox();
            label6 = new Label();
            txtObservacoes = new TextBox();
            btnGerar = new Button();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)gridIngredientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome da Receita";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 27);
            txtNome.Name = "txtNome";
            txtNome.ReadOnly = true;
            txtNome.Size = new Size(370, 23);
            txtNome.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(531, 9);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 2;
            label2.Text = "Tipo de Cozinha";
            // 
            // txtTipo
            // 
            txtTipo.Location = new Point(531, 27);
            txtTipo.Name = "txtTipo";
            txtTipo.ReadOnly = true;
            txtTipo.Size = new Size(388, 23);
            txtTipo.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 63);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 4;
            label3.Text = "Ingredientes";
            // 
            // gridIngredientes
            // 
            gridIngredientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridIngredientes.Columns.AddRange(new DataGridViewColumn[] { colIng, colQtd, colObs });
            gridIngredientes.Location = new Point(12, 81);
            gridIngredientes.Name = "gridIngredientes";
            gridIngredientes.ReadOnly = true;
            gridIngredientes.Size = new Size(776, 120);
            gridIngredientes.TabIndex = 5;
            // 
            // colIng
            // 
            colIng.HeaderText = "Ingrediente";
            colIng.Name = "colIng";
            colIng.ReadOnly = true;
            // 
            // colQtd
            // 
            colQtd.HeaderText = "Quantidade";
            colQtd.Name = "colQtd";
            colQtd.ReadOnly = true;
            colQtd.Width = 175;
            // 
            // colObs
            // 
            colObs.HeaderText = "Observação";
            colObs.Name = "colObs";
            colObs.ReadOnly = true;
            colObs.Width = 275;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 214);
            label4.Name = "label4";
            label4.Size = new Size(99, 15);
            label4.TabIndex = 6;
            label4.Text = "Modo de Preparo";
            // 
            // txtModoPreparo
            // 
            txtModoPreparo.Location = new Point(12, 232);
            txtModoPreparo.Multiline = true;
            txtModoPreparo.Name = "txtModoPreparo";
            txtModoPreparo.ReadOnly = true;
            txtModoPreparo.ScrollBars = ScrollBars.Vertical;
            txtModoPreparo.Size = new Size(370, 90);
            txtModoPreparo.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(400, 214);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 8;
            label5.Text = "Utensílios";
            // 
            // txtUtensilios
            // 
            txtUtensilios.Location = new Point(400, 232);
            txtUtensilios.Multiline = true;
            txtUtensilios.Name = "txtUtensilios";
            txtUtensilios.ReadOnly = true;
            txtUtensilios.ScrollBars = ScrollBars.Vertical;
            txtUtensilios.Size = new Size(388, 90);
            txtUtensilios.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 335);
            label6.Name = "label6";
            label6.Size = new Size(74, 15);
            label6.TabIndex = 10;
            label6.Text = "Observações";
            // 
            // txtObservacoes
            // 
            txtObservacoes.Location = new Point(12, 353);
            txtObservacoes.Multiline = true;
            txtObservacoes.Name = "txtObservacoes";
            txtObservacoes.ReadOnly = true;
            txtObservacoes.ScrollBars = ScrollBars.Vertical;
            txtObservacoes.Size = new Size(776, 85);
            txtObservacoes.TabIndex = 11;
            // 
            // btnGerar
            // 
            btnGerar.Location = new Point(825, 373);
            btnGerar.Name = "btnGerar";
            btnGerar.Size = new Size(94, 55);
            btnGerar.TabIndex = 12;
            btnGerar.Text = "Gerar outra";
            btnGerar.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(800, 27);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(800, 9);
            label7.Name = "label7";
            label7.Size = new Size(51, 15);
            label7.TabIndex = 14;
            label7.Text = "Foto:";
            // 
            // FrmSugestaoReceita
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(931, 450);
            Controls.Add(label7);
            Controls.Add(pictureBox1);
            Controls.Add(btnGerar);
            Controls.Add(txtObservacoes);
            Controls.Add(label6);
            Controls.Add(txtUtensilios);
            Controls.Add(label5);
            Controls.Add(txtModoPreparo);
            Controls.Add(label4);
            Controls.Add(gridIngredientes);
            Controls.Add(label3);
            Controls.Add(txtTipo);
            Controls.Add(label2);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Name = "FrmSugestaoReceita";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sugestão de Receita";
            ((System.ComponentModel.ISupportInitialize)gridIngredientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNome;
        private Label label2;
        private TextBox txtTipo;
        private Label label3;
        private DataGridView gridIngredientes;
        private DataGridViewTextBoxColumn colIng;
        private DataGridViewTextBoxColumn colQtd;
        private DataGridViewTextBoxColumn colObs;
        private Label label4;
        private TextBox txtModoPreparo;
        private Label label5;
        private TextBox txtUtensilios;
        private Label label6;
        private TextBox txtObservacoes;
        private Button btnGerar;
        private PictureBox pictureBox1;
        private Label label7;
    }
}


