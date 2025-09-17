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
			btnTiposCozinha = new Button();
			btnIngredientes = new Button();
			btnReceitas = new Button();
			btnConsultar = new Button();
			label1 = new Label();
			SuspendLayout();
			// 
			// btnTiposCozinha
			// 
			btnTiposCozinha.Location = new Point(12, 57);
			btnTiposCozinha.Name = "btnTiposCozinha";
			btnTiposCozinha.Size = new Size(180, 60);
			btnTiposCozinha.TabIndex = 0;
			btnTiposCozinha.Text = "Tipos de Cozinha";
			btnTiposCozinha.UseVisualStyleBackColor = true;
			btnTiposCozinha.Click += btnTiposCozinha_Click;
			// 
			// btnIngredientes
			// 
			btnIngredientes.Location = new Point(208, 57);
			btnIngredientes.Name = "btnIngredientes";
			btnIngredientes.Size = new Size(180, 60);
			btnIngredientes.TabIndex = 1;
			btnIngredientes.Text = "Ingredientes";
			btnIngredientes.UseVisualStyleBackColor = true;
			btnIngredientes.Click += btnIngredientes_Click;
			// 
			// btnReceitas
			// 
			btnReceitas.Location = new Point(404, 57);
			btnReceitas.Name = "btnReceitas";
			btnReceitas.Size = new Size(180, 60);
			btnReceitas.TabIndex = 2;
			btnReceitas.Text = "Receitas";
			btnReceitas.UseVisualStyleBackColor = true;
			btnReceitas.Click += btnReceitas_Click;
			// 
			// btnConsultar
			// 
			btnConsultar.Location = new Point(600, 57);
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
			label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(228, 25);
			label1.TabIndex = 4;
			label1.Text = "Dona Maria - Receitas";
			// 
			// FrmMenu
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 150);
			Controls.Add(label1);
			Controls.Add(btnConsultar);
			Controls.Add(btnReceitas);
			Controls.Add(btnIngredientes);
			Controls.Add(btnTiposCozinha);
			Name = "FrmMenu";
			Text = "Menu";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnTiposCozinha;
		private Button btnIngredientes;
		private Button btnReceitas;
		private Button btnConsultar;
		private Label label1;
	}
}

