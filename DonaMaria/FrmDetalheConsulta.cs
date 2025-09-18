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

        public void PreencherDetalhes(string nome, string receita, (string ingrediente, string quantidade, string observacao)[] ingredientes)
        {
            textBox2.Text = nome;
            textBox3.Text = receita;
            dataGridView1.Rows.Clear();
            foreach (var item in ingredientes)
            {
                dataGridView1.Rows.Add(item.ingrediente, item.quantidade, item.observacao);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
