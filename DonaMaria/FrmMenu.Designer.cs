namespace DonaMaria
{
	partial class FrmMenu
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            menuItemMenu = new ToolStripMenuItem();
            menuItemTipos = new ToolStripMenuItem();
            menuItemIngredientes = new ToolStripMenuItem();
            menuItemReceitas = new ToolStripMenuItem();
            menuItemConsultar = new ToolStripMenuItem();
            menuItemSugestao = new ToolStripMenuItem();
            toolStripMenuItemSeparator = new ToolStripSeparator();
            menuItemSair = new ToolStripMenuItem();
            btnTiposCozinha = new Button();
            btnIngredientes = new Button();
            btnReceitas = new Button();
            btnConsultar = new Button();
            label1 = new Label();
            btnSugestaoReceita = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuItemMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(935, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuItemMenu
            // 
            menuItemMenu.DropDownItems.AddRange(new ToolStripItem[] { menuItemTipos, menuItemIngredientes, menuItemReceitas, menuItemConsultar, menuItemSugestao, toolStripMenuItemSeparator, menuItemSair });
            menuItemMenu.Name = "menuItemMenu";
            menuItemMenu.Size = new Size(50, 20);
            menuItemMenu.Text = "Menu";
            // 
            // menuItemTipos
            // 
            menuItemTipos.Name = "menuItemTipos";
            menuItemTipos.Size = new Size(179, 22);
            menuItemTipos.Text = "Tipos de Cozinha";
            menuItemTipos.Click += btnTiposCozinha_Click;
            // 
            // menuItemIngredientes
            // 
            menuItemIngredientes.Name = "menuItemIngredientes";
            menuItemIngredientes.Size = new Size(179, 22);
            menuItemIngredientes.Text = "Ingredientes";
            menuItemIngredientes.Click += btnIngredientes_Click;
            // 
            // menuItemReceitas
            // 
            menuItemReceitas.Name = "menuItemReceitas";
            menuItemReceitas.Size = new Size(179, 22);
            menuItemReceitas.Text = "Receitas";
            menuItemReceitas.Click += btnReceitas_Click;
            // 
            // menuItemConsultar
            // 
            menuItemConsultar.Name = "menuItemConsultar";
            menuItemConsultar.Size = new Size(179, 22);
            menuItemConsultar.Text = "Consultar Receitas";
            menuItemConsultar.Click += btnConsultar_Click;
            // 
            // menuItemSugestao
            // 
            menuItemSugestao.Name = "menuItemSugestao";
            menuItemSugestao.Size = new Size(179, 22);
            menuItemSugestao.Text = "Sugestão de Receita";
            menuItemSugestao.Click += menuItemSugestao_Click;
            // 
            // toolStripMenuItemSeparator
            // 
            toolStripMenuItemSeparator.Name = "toolStripMenuItemSeparator";
            toolStripMenuItemSeparator.Size = new Size(176, 6);
            // 
            // menuItemSair
            // 
            menuItemSair.Name = "menuItemSair";
            menuItemSair.Size = new Size(179, 22);
            menuItemSair.Text = "Sair";
            menuItemSair.Click += menuItemSair_Click;
            // 
            // btnTiposCozinha
            // 
            btnTiposCozinha.Location = new Point(45, 57);
            btnTiposCozinha.Name = "btnTiposCozinha";
            btnTiposCozinha.Size = new Size(180, 60);
            btnTiposCozinha.TabIndex = 0;
            btnTiposCozinha.Text = "Tipos de Cozinha";
            btnTiposCozinha.UseVisualStyleBackColor = true;
            btnTiposCozinha.Click += btnTiposCozinha_Click;
            // 
            // btnIngredientes
            // 
            btnIngredientes.Location = new Point(264, 57);
            btnIngredientes.Name = "btnIngredientes";
            btnIngredientes.Size = new Size(180, 60);
            btnIngredientes.TabIndex = 1;
            btnIngredientes.Text = "Ingredientes";
            btnIngredientes.UseVisualStyleBackColor = true;
            btnIngredientes.Click += btnIngredientes_Click;
            // 
            // btnReceitas
            // 
            btnReceitas.Location = new Point(479, 57);
            btnReceitas.Name = "btnReceitas";
            btnReceitas.Size = new Size(180, 60);
            btnReceitas.TabIndex = 2;
            btnReceitas.Text = "Receitas";
            btnReceitas.UseVisualStyleBackColor = true;
            btnReceitas.Click += btnReceitas_Click;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(725, 57);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(180, 60);
            btnConsultar.TabIndex = 3;
            btnConsultar.Text = "Consultar Receitas";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(379, 9);
            label1.Name = "label1";
            label1.Size = new Size(205, 25);
            label1.TabIndex = 4;
            label1.Text = "Dona Maria - Receitas";
            // 
            // btnSugestaoReceita
            // 
            btnSugestaoReceita.Location = new Point(369, 153);
            btnSugestaoReceita.Name = "btnSugestaoReceita";
            btnSugestaoReceita.Size = new Size(180, 60);
            btnSugestaoReceita.TabIndex = 6;
            btnSugestaoReceita.Text = "Sugestão de Receita";
            btnSugestaoReceita.UseVisualStyleBackColor = true;
            btnSugestaoReceita.Click += btnSugestaoReceita_Click;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 294);
            Controls.Add(btnSugestaoReceita);
            Controls.Add(menuStrip1);
            Controls.Add(label1);
            Controls.Add(btnConsultar);
            Controls.Add(btnReceitas);
            Controls.Add(btnIngredientes);
            Controls.Add(btnTiposCozinha);
            MainMenuStrip = menuStrip1;
            Name = "FrmMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
		private ToolStripMenuItem menuItemMenu;
		private ToolStripMenuItem menuItemTipos;
		private ToolStripMenuItem menuItemIngredientes;
		private ToolStripMenuItem menuItemReceitas;
		private ToolStripMenuItem menuItemConsultar;
		private ToolStripMenuItem menuItemSugestao;
		private ToolStripSeparator toolStripMenuItemSeparator;
		private ToolStripMenuItem menuItemSair;
		private Button btnTiposCozinha;
		private Button btnIngredientes;
		private Button btnReceitas;
		private Button btnConsultar;
		private Label label1;
        private Button btnSugestaoReceita;
    }
}

