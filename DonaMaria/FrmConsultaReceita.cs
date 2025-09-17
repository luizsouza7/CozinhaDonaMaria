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
            if (dataGridView1.Columns["btnAbrir"] is DataGridViewButtonColumn abrirCol)
            {
                abrirCol.Text = "Abrir";
                abrirCol.UseColumnTextForButtonValue = true;
            }
        }

        private void btnLocalizar_Click(object? sender, EventArgs e)
        {
            // Preenche com dados simulados com base no termo
            var termo = textBox1.Text?.Trim() ?? string.Empty;
            dataGridView1.Rows.Clear();
            for (int i = 1; i <= 5; i++)
            {
                var nome = $"Receita {i} {termo}".Trim();
                var descricao = $"Descrição da {nome}";
                dataGridView1.Rows.Add(null, nome, descricao, "Abrir");
            }
        }

        private void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnAbrir")
            {
                var nome = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Nome"].Value) ?? string.Empty;
                var descricao = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Receita"].Value) ?? string.Empty;

                using (var frm = new FrmDetalheConsulta())
                {
                    frm.PreencherDetalhes(nome, descricao, new[]
                    {
                        ("Farinha", "2 xícaras", "Peneirada"),
                        ("Ovos", "3 unidades", "Em temperatura ambiente"),
                        ("Leite", "200 ml", "Integral")
                    });
                    frm.ShowDialog(this);
                }
            }
        }
    }
}
