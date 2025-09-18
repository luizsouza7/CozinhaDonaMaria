using System;
using System.Windows.Forms;

namespace DonaMaria
{
	public partial class FrmMenu : Form
	{
		public FrmMenu()
		{
			InitializeComponent();
		}

		private void btnTiposCozinha_Click(object sender, EventArgs e)
		{
			using (var form = new Form1())
			{
				form.ShowDialog(this);
			}
		}

		private void btnIngredientes_Click(object sender, EventArgs e)
		{
			using (var form = new FrmCadastrarIngredientes())
			{
				form.ShowDialog(this);
			}
		}

		private void btnReceitas_Click(object sender, EventArgs e)
		{
			using (var form = new FrmCadastrarReceita())
			{
				form.ShowDialog(this);
			}
		}

		private void btnConsultar_Click(object sender, EventArgs e)
		{
			using (var form = new FrmConsultaReceita())
			{
				form.ShowDialog(this);
			}
		}

		private void menuItemSugestao_Click(object sender, EventArgs e)
		{
			using (var form = new FrmSugestaoReceita())
			{
				form.ShowDialog(this);
			}
		}

		private void menuItemSair_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}

