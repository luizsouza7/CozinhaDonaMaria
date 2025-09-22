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
    public partial class FrmConsultaReceita : Form
    {
        public FrmConsultaReceita()
        {
            InitializeComponent();
            btnLocalizar.Click += btnLocalizar_Click;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            this.Load += FrmConsultaReceita_Load;
            if (dataGridView1.Columns["btnAbrir"] is DataGridViewButtonColumn abrirCol)
            {
                abrirCol.Text = "Abrir";
                abrirCol.UseColumnTextForButtonValue = true;
            }
        }

        private void FrmConsultaReceita_Load(object? sender, EventArgs e)
        {
            // Carrega todas as receitas ao abrir o formulário
            CarregarTodasReceitas();
            
            // Configura placeholder no campo de busca
            textBox1.Text = "Digite o nome da receita, tipo de cozinha ou ingrediente...";
            textBox1.ForeColor = Color.Gray;
            textBox1.GotFocus += (s, args) => {
                if (textBox1.Text == "Digite o nome da receita, tipo de cozinha ou ingrediente...")
                {
                    textBox1.Text = "";
                    textBox1.ForeColor = Color.Black;
                }
            };
            textBox1.LostFocus += (s, args) => {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    textBox1.Text = "Digite o nome da receita, tipo de cozinha ou ingrediente...";
                    textBox1.ForeColor = Color.Gray;
                }
            };
        }

        private void CarregarTodasReceitas()
        {
            dataGridView1.Rows.Clear();
            var todasReceitas = RecipeRepository.GetAll();

            if (todasReceitas.Count == 0)
            {
                MessageBox.Show("Nenhuma receita cadastrada. Cadastre uma receita primeiro.", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var receita in todasReceitas)
            {
                dataGridView1.Rows.Add(
                    receita.Codigo,
                    receita.Nome,
                    $"{receita.TipoCozinha} - {receita.TempoPreparoMinutos}min - {receita.Porcoes} porções",
                    "Abrir"
                );
            }
        }

        private void btnLocalizar_Click(object? sender, EventArgs e)
        {
            // Busca receitas reais do repositório
            var termo = textBox1.Text?.Trim() ?? string.Empty;
            
            // Ignora placeholder text
            if (termo == "Digite o nome da receita, tipo de cozinha ou ingrediente...")
            {
                termo = string.Empty;
            }
            
            dataGridView1.Rows.Clear();
            
            var todasReceitas = RecipeRepository.GetAll();
            var receitasFiltradas = todasReceitas.Where(r => 
                string.IsNullOrEmpty(termo) || 
                r.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
                r.TipoCozinha.Contains(termo, StringComparison.OrdinalIgnoreCase) ||
                r.ModoPreparo.Contains(termo, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            if (receitasFiltradas.Count == 0)
            {
                MessageBox.Show($"Nenhuma receita encontrada com o termo '{termo}'.", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var receita in receitasFiltradas)
            {
                dataGridView1.Rows.Add(
                    receita.Codigo,
                    receita.Nome,
                    $"{receita.TipoCozinha} - {receita.TempoPreparoMinutos}min - {receita.Porcoes} porções",
                    "Abrir"
                );
            }
            
            // Mensagem de status
            var mensagem = string.IsNullOrEmpty(termo) 
                ? $"Mostrando todas as {receitasFiltradas.Count} receitas cadastradas."
                : $"Encontradas {receitasFiltradas.Count} receita(s) com o termo '{termo}'.";
            
            MessageBox.Show(mensagem, "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnAbrir")
            {
                var codigo = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Código"].Value) ?? string.Empty;
                var nome = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Nome"].Value) ?? string.Empty;
                
                // Busca a receita completa pelo código
                var todasReceitas = RecipeRepository.GetAll();
                var receita = todasReceitas.FirstOrDefault(r => r.Codigo == codigo);
                
                if (receita == null)
                {
                    MessageBox.Show("Receita não encontrada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var frm = new FrmDetalheConsulta())
                {
                    // Converte ingredientes para o formato esperado
                    var ingredientes = receita.Ingredientes.Select(ing => 
                        (ing.Nome, ing.Quantidade, ing.Observacao)).ToArray();
                    
                    frm.PreencherDetalhes(
                        receita.Nome, 
                        receita.ModoPreparo, 
                        ingredientes
                    );
                    frm.ShowDialog(this);
                }
            }
        }
    }
}
