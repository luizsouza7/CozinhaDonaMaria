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
                MessageBox.Show("Informe o nome.");
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
            }
            else
            {
                rowToUpdate.Cells["Código"].Value = codigo;
                rowToUpdate.Cells["Nome"].Value = nome;
                rowToUpdate.Cells["Descrição"].Value = descricao;
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }
    }
}
