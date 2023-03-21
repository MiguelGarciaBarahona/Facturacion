using Datos;
using Entidades;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Vista
{
    public partial class ProductosForm : Form
    {
        public ProductosForm()
        {
            InitializeComponent();
        }

        string Operacion;
        Producto Product;
        ProductoDB ProductoDB = new ProductoDB();
        DataTable dable = new DataTable();



        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Operacion = "Nuevo";
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            DescripcionTextBox.Enabled = true;
            ExistenciaTextBox.Enabled = true;
            PrecioTextBox.Enabled = true;
            AdjuntarImagenButton.Enabled = true;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
            NuevoButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            DescripcionTextBox.Clear();
            ExistenciaTextBox.Clear();
            PrecioTextBox.Clear();
            EstaActivoCPheckBox.Enabled = false;
            ImagenPictureBox.Image = null;
            Product = null;

        }


        private void DesabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            DescripcionTextBox.Enabled = false;
            ExistenciaTextBox.Enabled = false;
            PrecioTextBox.Enabled = false;
            AdjuntarImagenButton.Enabled = false;
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
            Operacion = "Modificar";
            if (ProductosDataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                DescripcionTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
                ExistenciaTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Existencia"].ToString();
                PrecioTextBox.Text = ProductosDataGridView.CurrentRow.Cells["Precio"].ToString();
                EstaActivoCPheckBox.Checked = Convert.ToBoolean(ProductosDataGridView.CurrentRow.Cells["EstaActivo"].Value);


                byte[] img = ProductoDB.devolverFoto(ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());

                if (img.Length > 0)
                {
                    MemoryStream ms = new MemoryStream(img);
                    ImagenPictureBox.Image = System.Drawing.Bitmap.FromStream(ms);
                }
                HabilitarControles();
                CodigoTextBox.ReadOnly = true;

            }
            else
            {
                MessageBox.Show("Debe Seleccinar un Registro");
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Product = new Producto();
            Product.Codigo = CodigoTextBox.Text;
            Product.Descripcion = DescripcionTextBox.Text;
            Product.Precio = Convert.ToDecimal(PrecioTextBox.Text);
            Product.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            Product.EstaActivo = EstaActivoCPheckBox.Checked;

            if (ImagenPictureBox.Image != null)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                ImagenPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                Product.Foto = ms.GetBuffer();
            }

            if (Operacion == "Nuevo")
            {
                if (string.IsNullOrEmpty(CodigoTextBox.Text))
                {
                    errorProvider1.SetError(CodigoTextBox, "Ingrese Un Codigo");
                    CodigoTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(DescripcionTextBox.Text))
                {
                    errorProvider1.SetError(DescripcionTextBox, "Ingrese Una Descripcion");
                    DescripcionTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(ExistenciaTextBox.Text))
                {
                    errorProvider1.SetError(ExistenciaTextBox, "Ingrese La Existencia");
                    ExistenciaTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();
                if (string.IsNullOrEmpty(PrecioTextBox.Text))
                {
                    errorProvider1.SetError(PrecioTextBox, "Ingrese El Precio");
                    PrecioTextBox.Focus();
                    return;
                }
                errorProvider1.Clear();

                Product.Codigo = CodigoTextBox.Text;
                Product.Descripcion = DescripcionTextBox.Text;
                Product.Precio = Convert.ToDecimal(PrecioTextBox.Text);
                Product.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
                Product.EstaActivo = EstaActivoCPheckBox.Checked;

                if (ImagenPictureBox.Image != null)
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();

                    ImagenPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    Product.Foto = ms.GetBuffer();
                }

                bool inserto = ProductoDB.Insentar(Product);
                if (inserto)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    TraerProductos();
                    MessageBox.Show("Registro Guardado Con Exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO se Guardo Registro ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (Operacion == "MOdificar")
            {
                bool modifico = ProductoDB.editar(Product);
                if (modifico)
                {
                    DesabilitarControles();
                    LimpiarControles();
                    TraerProductos();
                    MessageBox.Show("Registro Actualizado Con Exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("NO se Actualizo el Registro ", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExistenciaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {

            }
            else
            {
                e.Handled = true;
            }



        }

        private void PrecioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;

            }

        }

        private void AdjuntarImagenButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog diagalofoto = new OpenFileDialog();
            DialogResult resultado = diagalofoto.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                ImagenPictureBox.Image = Image.FromFile(diagalofoto.FileName);
            }
        }

        private void ProductosForm_Load(object sender, EventArgs e)
        {
            TraerProductos();

        }

        private void TraerProductos()
        {
            ProductosDataGridView.DataSource = ProductoDB.DevolverProducto();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ProductosDataGridView.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Confirmar Eliminacio", "advertencia", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes)
                {
                    bool elimino = ProductoDB.Eliminar(ProductosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());

                    if (elimino)
                    {
                        LimpiarControles();
                        DesabilitarControles();
                        TraerProductos();
                        MessageBox.Show("Registro Eliminado");

                    }
                    else
                    {
                        MessageBox.Show("No Se Pudo Eliminar el Registro");
                    }
                }
            }
        }
    }
}
