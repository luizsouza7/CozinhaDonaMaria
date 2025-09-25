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
    public partial class FrmDetalheConsulta : Form
    {
        public FrmDetalheConsulta()
        {
            InitializeComponent();
        }

        public void PreencherDetalhes(string nome, string receita, (string ingrediente, string quantidade, string observacao)[] ingredientes, string? caminhoImagem = null)
        {
            // Preenche o nome da receita
            textBox2.Text = nome;

            // Preenche o modo de preparo
            textBox3.Text = receita;

            // Limpa e preenche a lista de ingredientes
            dataGridView1.Rows.Clear();
            foreach (var item in ingredientes)
            {
                dataGridView1.Rows.Add(item.ingrediente, item.quantidade, item.observacao);
            }

            // Carrega a imagem se existir
            if (!string.IsNullOrEmpty(caminhoImagem) && File.Exists(caminhoImagem))
            {
                try
                {
                    pictureBox1.Image?.Dispose();
                    pictureBox1.Image = Image.FromFile(caminhoImagem);
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Botão para fechar o formulário
            this.Close();
        }
    }
}
