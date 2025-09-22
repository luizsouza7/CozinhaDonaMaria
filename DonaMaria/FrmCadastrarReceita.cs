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
    public partial class FrmCadastrarReceita : Form
    {
        public FrmCadastrarReceita()
        {
            InitializeComponent();
            btnSalvar.Click += btnSalvar_Click;
            btnAlterar.Click += btnAlterar_Click;
            btnAdicionarIngredientes.Click += btnAdicionarIngredientes_Click;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmCadastrarReceita_Load(object sender, EventArgs e)
        {
            // Carrega tipos de cozinha configuráveis
            comboBox1.Items.Clear();
            var kitchenTypes = KitchenTypeManager.GetKitchenTypes();
            comboBox1.Items.AddRange(kitchenTypes.ToArray());
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            // Cabeçalhos de botões padrão
            if (dataGridView1.Columns["Código"] != null)
            {
                // apenas garantindo que existe
            }
        }

        private void btnAdicionarIngredientes_Click(object? sender, EventArgs e)
        {
            // Adiciona uma linha vazia na grade de ingredientes para edição rápida
            dataGridView2.Rows.Add();
        }

        private void btnSalvar_Click(object? sender, EventArgs e)
        {
            var codigo = textBox1.Text?.Trim();
            var nome = textBox2.Text?.Trim();
            var tipo = Convert.ToString(comboBox1.SelectedItem) ?? string.Empty;
            var tempoHoras = (int)numericUpDown1.Value;
            var tempoMinutos = (int)numericUpDown2.Value;
            var porcoes = (int)numericUpDown3.Value;

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe o nome da receita.");
                return;
            }

            var tempoTotal = (tempoHoras * 60) + tempoMinutos;

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
                dataGridView1.Rows.Add(codigo, nome, tipo, tempoTotal + " min", porcoes);
            }
            else
            {
                rowToUpdate.Cells["Código"].Value = codigo;
                rowToUpdate.Cells["Nome"].Value = nome;
                rowToUpdate.Cells["Cozinha"].Value = tipo;
                rowToUpdate.Cells["Tempo"].Value = tempoTotal + " min";
                rowToUpdate.Cells["Porções"].Value = porcoes;
            }

            // Persistência em memória
            var receita = new Recipe
            {
                Codigo = codigo ?? string.Empty,
                Nome = nome ?? string.Empty,
                TipoCozinha = tipo,
                TempoPreparoMinutos = tempoTotal,
                Porcoes = porcoes,
                ModoPreparo = textBox3.Text?.Trim() ?? string.Empty,
                Observacoes = null,
                Utensilios = null,
                Ingredientes = ColetarIngredientes()
            };
            RecipeRepository.AddOrUpdate(receita);

            // Limpa campos básicos (mantém ingredientes preenchidos)
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            numericUpDown1.Value = numericUpDown1.Minimum;
            numericUpDown2.Value = numericUpDown2.Minimum;
            numericUpDown3.Value = numericUpDown3.Minimum;
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            textBox1.Focus();
        }

        private void btnAlterar_Click(object? sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                return;
            }

            var row = dataGridView1.CurrentRow;
            textBox1.Text = Convert.ToString(row.Cells["Código"].Value);
            textBox2.Text = Convert.ToString(row.Cells["Nome"].Value);
            comboBox1.SelectedItem = Convert.ToString(row.Cells["Cozinha"].Value);

            var tempoStr = Convert.ToString(row.Cells["Tempo"].Value);
            if (tempoStr != null && tempoStr.EndsWith(" min"))
            {
                tempoStr = tempoStr.Replace(" min", "");
                if (int.TryParse(tempoStr, out var tempoTotal))
                {
                    numericUpDown1.Value = tempoTotal / 60;
                    numericUpDown2.Value = tempoTotal % 60;
                }
            }
            var porcoes = Convert.ToDecimal(row.Cells["Porções"].Value ?? numericUpDown3.Minimum);
            numericUpDown3.Value = Math.Max(porcoes, numericUpDown3.Minimum);
        }

        private List<IngredientItem> ColetarIngredientes()
        {
            var lista = new List<IngredientItem>();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;

                // Usa nomes das colunas em vez de índices para evitar ArgumentOutOfRangeException
                var nome = "";
                var qtd = "";
                var obs = "";

                // Tenta acessar as colunas pelos nomes, com fallback para índices
                try
                {
                    if (dataGridView2.Columns.Contains("Ingrediente"))
                        nome = Convert.ToString(row.Cells["Ingrediente"].Value)?.Trim() ?? string.Empty;
                    else if (row.Cells.Count > 0)
                        nome = Convert.ToString(row.Cells[0].Value)?.Trim() ?? string.Empty;

                    if (dataGridView2.Columns.Contains("Quantidade"))
                        qtd = Convert.ToString(row.Cells["Quantidade"].Value)?.Trim() ?? string.Empty;
                    else if (row.Cells.Count > 1)
                        qtd = Convert.ToString(row.Cells[1].Value)?.Trim() ?? string.Empty;

                    if (dataGridView2.Columns.Contains("Observação"))
                        obs = Convert.ToString(row.Cells["Observação"].Value)?.Trim() ?? string.Empty;
                    else if (row.Cells.Count > 2)
                        obs = Convert.ToString(row.Cells[2].Value)?.Trim() ?? string.Empty;
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Se ainda assim der erro, pula esta linha
                    continue;
                }

                if (string.IsNullOrWhiteSpace(nome) && string.IsNullOrWhiteSpace(qtd) && string.IsNullOrWhiteSpace(obs))
                {
                    continue;
                }
                lista.Add(new IngredientItem
                {
                    Nome = nome,
                    Quantidade = qtd,
                    Observacao = obs
                });
            }
            return lista;
        }
    }
}
