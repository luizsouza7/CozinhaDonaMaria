using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonaMaria
{
    public partial class FrmCadastrarIngredientes : Form
    {
        public FrmCadastrarIngredientes()
        {
            InitializeComponent();
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

            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            btnSalvar.Click += btnSalvar_Click;
        }

        private void FrmCadastrarIngredientes_Load(object sender, EventArgs e)
        {
            // Carrega ingredientes existentes no DataGridView
            CarregarIngredientes();
        }

        private void btnSalvar_Click(object? sender, EventArgs e)
        {
            var codigo = textBox1.Text?.Trim();
            var nome = textBox2.Text?.Trim();
            var descricao = textBox3.Text?.Trim();

            // Validações obrigatórias
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe o nome do ingrediente.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            // Validação de código único (se informado)
            if (!string.IsNullOrWhiteSpace(codigo))
            {
                var ingredientesExistentes = IngredientRepository.GetAll();
                var ingredienteExistente = ingredientesExistentes.FirstOrDefault(i =>
                    i.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(i.Nome, nome, StringComparison.OrdinalIgnoreCase));

                if (ingredienteExistente != null)
                {
                    MessageBox.Show($"Já existe um ingrediente com o código '{codigo}': '{ingredienteExistente.Nome}'.",
                        "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }
            }

            // Persistência no repositório
            var ingrediente = new Ingredient
            {
                Codigo = codigo ?? string.Empty,
                Nome = nome ?? string.Empty,
                Descricao = descricao ?? string.Empty
            };
            IngredientRepository.AddOrUpdate(ingrediente);

            // Mensagem de sucesso
            MessageBox.Show($"Ingrediente '{nome}' salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Recarrega a lista de ingredientes
            CarregarIngredientes();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox1.Focus();
        }


        private void CarregarIngredientes()
        {
            try
            {
                dataGridView1.Rows.Clear();
                var ingredientes = IngredientRepository.GetAll();
                
                foreach (var ingrediente in ingredientes)
                {
                    dataGridView1.Rows.Add(
                        ingrediente.Codigo,
                        ingrediente.Nome,
                        ingrediente.Descricao
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar ingredientes: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];
            var codigo = Convert.ToString(row.Cells["Código"].Value);
            var nome = Convert.ToString(row.Cells["Nome"].Value);

            if (e.ColumnIndex == dataGridView1.Columns["btnAlterar"].Index)
            {
                // Carrega os dados do ingrediente para edição
                if (!string.IsNullOrEmpty(codigo))
                    CarregarIngredienteParaEdicao(codigo);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["btnExcluir"].Index)
            {
                // Confirma exclusão
                var resultado = MessageBox.Show(
                    $"Deseja realmente excluir o ingrediente '{nome}'?",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes && !string.IsNullOrEmpty(codigo))
                {
                    ExcluirIngrediente(codigo);
                }
            }
        }

        private void CarregarIngredienteParaEdicao(string codigo)
        {
            var ingredientes = IngredientRepository.GetAll();
            var ingrediente = ingredientes.FirstOrDefault(i => i.Codigo == codigo);
            
            if (ingrediente != null)
            {
                // Preenche os campos com os dados do ingrediente
                textBox1.Text = ingrediente.Codigo;
                textBox2.Text = ingrediente.Nome;
                textBox3.Text = ingrediente.Descricao;
            }
        }

        private void ExcluirIngrediente(string codigo)
        {
            try
            {
                // Remove do repositório
                bool removido = IngredientRepository.Remove(codigo);
                
                if (removido)
                {
                    // Recarrega a lista
                    CarregarIngredientes();
                    MessageBox.Show("Ingrediente excluído com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ingrediente não encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir ingrediente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
