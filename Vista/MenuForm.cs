using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void UsuariosToolStripButton_Click(object sender, EventArgs e)
        {
            UsuariosForm userform = new UsuariosForm();
            userform.MdiParent = this;
            userform.Show();
        }

        private void ProductosToolStripButton_Click(object sender, EventArgs e)
        {
            ProductosForm producto = new ProductosForm();
            producto.MdiParent = this;
            producto.Show();
        }

        private void ClientesToolStripButton_Click(object sender, EventArgs e)
        {
            ClientesFronm cliente = new ClientesFronm();
            cliente.MdiParent = this;
            cliente.Show();
        }
    }
}
