using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DonaMaria
{
    public partial class FrmSugestaoReceita : Form
    {
        public FrmSugestaoReceita()
        {
            InitializeComponent();
            btnGerar.Click += btnGerar_Click;
            Load += FrmSugestaoReceita_Load;
        }

        private void FrmSugestaoReceita_Load(object? sender, EventArgs e)
        {
            GerarSugestao();
        }

        private void btnGerar_Click(object? sender, EventArgs e)
        {
            GerarSugestao();
        }

        private void GerarSugestao()
        {
            var receita = RecipeRepository.GetRandom();
            if (receita == null)
            {
                MessageBox.Show("Não há receitas cadastradas para sugerir. Cadastre uma receita primeiro.");
                LimparCampos();
                return;
            }

            txtNome.Text = receita.Nome;
            txtTipo.Text = receita.TipoCozinha;
            txtModoPreparo.Text = receita.ModoPreparo;
            txtObservacoes.Text = receita.Observacoes ?? string.Empty;
            txtUtensilios.Text = receita.Utensilios ?? string.Empty;

            // Adiciona informações de tempo e porções se os campos existirem
            if (Controls.Find("txtTempo", true).FirstOrDefault() is TextBox txtTempo)
            {
                txtTempo.Text = $"{receita.TempoPreparoMinutos} minutos";
            }
            if (Controls.Find("txtPorcoes", true).FirstOrDefault() is TextBox txtPorcoes)
            {
                txtPorcoes.Text = $"{receita.Porcoes} porções";
            }

            gridIngredientes.Rows.Clear();
            foreach (var ing in receita.Ingredientes)
            {
                gridIngredientes.Rows.Add(ing.Nome, ing.Quantidade, ing.Observacao);
            }

            // Carrega a imagem se existir
            if (!string.IsNullOrEmpty(receita.CaminhoImagem) && File.Exists(receita.CaminhoImagem))
            {
                try
                {
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = Image.FromFile(receita.CaminhoImagem);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar a imagem: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pictureBox1.Image = null;
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtTipo.Clear();
            txtModoPreparo.Clear();
            txtObservacoes.Clear();
            txtUtensilios.Clear();
            gridIngredientes.Rows.Clear();

            // Limpa campos de tempo e porções se existirem
            if (Controls.Find("txtTempo", true).FirstOrDefault() is TextBox txtTempo)
            {
                txtTempo.Clear();
            }
            if (Controls.Find("txtPorcoes", true).FirstOrDefault() is TextBox txtPorcoes)
            {
                txtPorcoes.Clear();
            }

            // Limpa a imagem
            pictureBox1.Image = null;
        }
    }
}


