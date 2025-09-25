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
        private string? caminhoFoto = null;
        public FrmCadastrarReceita()
        {
            InitializeComponent();
            btnSalvar.Click += btnSalvar_Click;
            btnAlterar.Click += btnAlterar_Click;
            btnAdicionarIngredientes.Click += btnAdicionarIngredientes_Click;
            btnCarregarFoto.Click += btnCarregarFoto_Click;
        }


        private void FrmCadastrarReceita_Load(object sender, EventArgs e)
        {
            // Carrega tipos de cozinha configuráveis
            comboBox1.Items.Clear();
            var kitchenTypes = KitchenTypeManager.GetKitchenTypeNames();
            comboBox1.Items.AddRange(kitchenTypes.ToArray());
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            // Carrega receitas existentes no DataGridView
            CarregarReceitas();

            // Configura eventos do DataGridView
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
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
            var modoPreparo = textBox3.Text?.Trim() ?? string.Empty;

            // Validações obrigatórias
            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe o nome da receita.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tipo))
            {
                MessageBox.Show("Selecione o tipo de cozinha.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(modoPreparo))
            {
                MessageBox.Show("Informe o modo de preparo da receita.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox3.Focus();
                return;
            }

            var tempoTotal = (tempoHoras * 60) + tempoMinutos;
            if (tempoTotal <= 0)
            {
                MessageBox.Show("O tempo de preparo deve ser maior que zero.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown1.Focus();
                return;
            }

            if (porcoes <= 0)
            {
                MessageBox.Show("O número de porções deve ser maior que zero.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numericUpDown3.Focus();
                return;
            }

            // Validação de código único (se informado)
            if (!string.IsNullOrWhiteSpace(codigo))
            {
                var todasReceitas = RecipeRepository.GetAll();
                var receitaExistente = todasReceitas.FirstOrDefault(r =>
                    r.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase) &&
                    !string.Equals(r.Nome, nome, StringComparison.OrdinalIgnoreCase));

                if (receitaExistente != null)
                {
                    MessageBox.Show($"Já existe uma receita com o código '{codigo}': '{receitaExistente.Nome}'.",
                        "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Focus();
                    return;
                }
            }

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

            // Validação de ingredientes
            var ingredientes = ColetarIngredientes();
            if (ingredientes.Count == 0)
            {
                var resultado = MessageBox.Show("Nenhum ingrediente foi informado. Deseja continuar mesmo assim?",
                    "Ingredientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                {
                    return;
                }
            }

            // Persistência em memória
            var receita = new Recipe
            {
                Codigo = codigo ?? string.Empty,
                Nome = nome ?? string.Empty,
                TipoCozinha = tipo,
                TempoPreparoMinutos = tempoTotal,
                Porcoes = porcoes,
                ModoPreparo = modoPreparo,
                Observacoes = null,
                Utensilios = null,
                CaminhoImagem = caminhoFoto,
                Ingredientes = ingredientes
            };
            RecipeRepository.AddOrUpdate(receita);

            // Mensagem de sucesso
            MessageBox.Show($"Receita '{nome}' salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Recarrega a lista de receitas
            CarregarReceitas();

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

        private void CarregarReceitas()
        {
            try
            {
                dataGridView1.Rows.Clear();
                var receitas = RecipeRepository.GetAll();

                foreach (var receita in receitas)
                {
                    dataGridView1.Rows.Add(
                        receita.Codigo,
                        receita.Nome,
                        receita.TipoCozinha,
                        receita.TempoPreparoMinutos + " min",
                        receita.Porcoes
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar receitas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dataGridView1.Rows[e.RowIndex];
            var codigo = Convert.ToString(row.Cells["Código"].Value);
            var nome = Convert.ToString(row.Cells["Nome"].Value);

            if (e.ColumnIndex == dataGridView1.Columns["btnEditar"].Index)
            {
                // Carrega os dados da receita para edição
                if (!string.IsNullOrEmpty(codigo))
                    CarregarReceitaParaEdicao(codigo);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["btnExcluir"].Index)
            {
                // Confirma exclusão
                var resultado = MessageBox.Show(
                    $"Deseja realmente excluir a receita '{nome}'?",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes && !string.IsNullOrEmpty(codigo))
                {
                    ExcluirReceita(codigo);
                }
            }
        }

        private void CarregarReceitaParaEdicao(string codigo)
        {
            var receitas = RecipeRepository.GetAll();
            var receita = receitas.FirstOrDefault(r => r.Codigo == codigo);

            if (receita != null)
            {
                // Preenche os campos com os dados da receita
                textBox1.Text = receita.Codigo;
                textBox2.Text = receita.Nome;
                comboBox1.SelectedItem = receita.TipoCozinha;
                textBox3.Text = receita.ModoPreparo;

                // Converte tempo de minutos para horas e minutos
                numericUpDown1.Value = receita.TempoPreparoMinutos / 60;
                numericUpDown2.Value = receita.TempoPreparoMinutos % 60;
                numericUpDown3.Value = receita.Porcoes;

                // Carrega ingredientes
                dataGridView2.Rows.Clear();
                foreach (var ingrediente in receita.Ingredientes)
                {
                    dataGridView2.Rows.Add(
                        ingrediente.Nome,
                        ingrediente.Quantidade,
                        ingrediente.Observacao
                    );
                }

                // Carrega a imagem se existir
                if (!string.IsNullOrEmpty(receita.CaminhoImagem) && File.Exists(receita.CaminhoImagem))
                {
                    try
                    {
                        pictureBox1.Image?.Dispose();
                        pictureBox1.Image = Image.FromFile(receita.CaminhoImagem);
                        caminhoFoto = receita.CaminhoImagem;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pictureBox1.Image = null;
                        caminhoFoto = null;
                    }
                }
                else
                {
                    pictureBox1.Image = null;
                    caminhoFoto = null;
                }
            }
        }

        private void ExcluirReceita(string codigo)
        {
            try
            {
                // Remove do repositório
                bool removido = RecipeRepository.Remove(codigo);

                if (removido)
                {
                    // Recarrega a lista
                    CarregarReceitas();
                    MessageBox.Show("Receita excluída com sucesso!", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Receita não encontrada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir receita: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCarregarFoto_Click(object? sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Todos os arquivos|*.*";
                openFileDialog.Title = "Selecionar Foto da Receita";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Carrega a imagem no PictureBox
                        pictureBox1.Image?.Dispose(); // Libera a imagem anterior
                        pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                        caminhoFoto = openFileDialog.FileName;

                        MessageBox.Show("Foto carregada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao carregar a foto: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
