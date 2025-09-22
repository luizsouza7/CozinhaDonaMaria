namespace DonaMaria
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Configure button columns to show text
            if (dataGridView1.Columns["btnAlterar"] is DataGridViewButtonColumn alterarCol)
            {
                alterarCol.Text = "Alterar";
                alterarCol.UseColumnTextForButtonValue = true;
            }
            if (dataGridView1.Columns["btnExcluir"] is DataGridViewButtonColumn excluirCol)
            {
                excluirCol.Text = "Excluir";
                excluirCol.UseColumnTextForButtonValue = true;
            }

            btnSalvar.Click += btnSalvar_Click;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            // Carrega os tipos de cozinha existentes
            CarregarTiposCozinha();
        }

        private void CarregarTiposCozinha()
        {
            dataGridView1.Rows.Clear();
            var tiposCozinha = KitchenTypeManager.GetKitchenTypes();

            foreach (var tipo in tiposCozinha)
            {
                dataGridView1.Rows.Add(tipo.Codigo, tipo.Nome, tipo.Descricao);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var grid = dataGridView1;
            if (grid.Columns[e.ColumnIndex].Name == "btnAlterar")
            {
                textBox1.Text = Convert.ToString(grid.Rows[e.RowIndex].Cells["Código"].Value);
                textBox2.Text = Convert.ToString(grid.Rows[e.RowIndex].Cells["Nome"].Value);
                textBox3.Text = Convert.ToString(grid.Rows[e.RowIndex].Cells["Descrição"].Value);
            }
            else if (grid.Columns[e.ColumnIndex].Name == "btnExcluir")
            {
                var nomeTipo = Convert.ToString(grid.Rows[e.RowIndex].Cells["Nome"].Value);
                if (!string.IsNullOrEmpty(nomeTipo))
                {
                    KitchenTypeManager.RemoveKitchenType(nomeTipo);
                }
                grid.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnSalvar_Click(object? sender, EventArgs e)
        {
            var codigo = textBox1.Text?.Trim();
            var nome = textBox2.Text?.Trim();
            var descricao = textBox3.Text?.Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe o nome do tipo de cozinha.");
                return;
            }

            // Se existir linha com mesmo código, atualiza; senão, adiciona
            DataGridViewRow? rowToUpdate = null;
            if (!string.IsNullOrWhiteSpace(codigo))
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow && Convert.ToString(row.Cells["Código"].Value) == codigo)
                    {
                        rowToUpdate = row;
                        break;
                    }
                }
            }

            if (rowToUpdate == null)
            {
                dataGridView1.Rows.Add(codigo, nome, descricao);
                // Adiciona o tipo de cozinha ao sistema
                var kitchenType = new KitchenType 
                { 
                    Codigo = codigo ?? string.Empty, 
                    Nome = nome, 
                    Descricao = descricao ?? string.Empty 
                };
                KitchenTypeManager.AddKitchenType(kitchenType);
            }
            else
            {
                var nomeAntigo = Convert.ToString(rowToUpdate.Cells["Nome"].Value);
                rowToUpdate.Cells["Código"].Value = codigo;
                rowToUpdate.Cells["Nome"].Value = nome;
                rowToUpdate.Cells["Descrição"].Value = descricao;

                // Remove o tipo antigo e adiciona o novo
                if (!string.IsNullOrEmpty(nomeAntigo))
                {
                    KitchenTypeManager.RemoveKitchenType(nomeAntigo);
                }
                var kitchenType = new KitchenType 
                { 
                    Codigo = codigo ?? string.Empty, 
                    Nome = nome, 
                    Descricao = descricao ?? string.Empty 
                };
                KitchenTypeManager.AddKitchenType(kitchenType);
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }
    }
}
