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

            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            btnSalvar.Click += btnSalvar_Click;
        }

        private void FrmCadastrarIngredientes_Load(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object? sender, EventArgs e)
        {
            var codigo = textBox1.Text?.Trim();
            var nome = textBox2.Text?.Trim();
            var descricao = textBox3.Text?.Trim();

            if (string.IsNullOrWhiteSpace(nome))
            {
                MessageBox.Show("Informe o nome do ingrediente.");
                return;
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

        private void dataGridView1_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnAlterar")
            {
                textBox1.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Código"].Value);
                textBox2.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Nome"].Value);
                textBox3.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["Descrição"].Value);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "btnExcluir")
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
