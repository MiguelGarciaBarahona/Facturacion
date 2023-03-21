using System;
using System.Windows.Forms;

namespace Vista
{
    public partial class ClientesFronm : Form
    {
        public ClientesFronm()
        {
            InitializeComponent();
        }
        string operacion;
        ClientesFronm client;
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            operacion = "Nuevo";
            HabilitarControles();

        }



        private void HabilitarControles()
        {
            NombreTextBox.Enabled = true;
            IdentidadTextBox.Enabled = true;
            TelefonoTextBox.Enabled = true;
            CorreoTextBox.Enabled = true;
            DomicioTextBox.Enabled = true;
            FechaNacimientoTextBox.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            NuevoButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            NombreTextBox.Clear();
            IdentidadTextBox.Clear();
            TelefonoTextBox.Clear();
            CorreoTextBox.Clear();
            DomicioTextBox.Clear();
            FechaNacimientoTextBox.Clear();
            EstaActivoCheckBox.Enabled = false;

        }

        private void DesabilitarControles()
        {
            NombreTextBox.Enabled = false;
            IdentidadTextBox.Enabled = false;
            TelefonoTextBox.Enabled = false;
            CorreoTextBox.Enabled = false;
            DomicioTextBox.Enabled = false;
            FechaNacimientoTextBox.Enabled = false;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
            NuevoButton.Enabled = true;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DesabilitarControles();
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            operacion = "Modificar";


            if (ClienteDataGridView.SelectedRows.Count > 0)
            {



            }

        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            client = new ClientesFronm();
            DesabilitarControles();
            LimpiarControles();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            DesabilitarControles();
        }
    }
}
