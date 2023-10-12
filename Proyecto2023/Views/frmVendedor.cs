using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using DAL;


namespace Proyecto2023.Views
{
    public partial class frmVendedor : Form
    {

        VendedorDAL oVendedorDAL;
        public frmVendedor()
        {
            oVendedorDAL = new VendedorDAL();
            InitializeComponent();
            LLenarGrid();
            LimpiarEntradas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Conectado..");

            oVendedorDAL.Agregar(RecuperarInformacion());
            LLenarGrid();
            LimpiarEntradas();
        }
        private Vendedor RecuperarInformacion()
        {
            Vendedor oVendedor = new Vendedor();

            int codigoEmpleado = 1;

            int.TryParse(txtID.Text, out codigoEmpleado);

            oVendedor.ID = codigoEmpleado;

            oVendedor.Nombre = txtNombre.Text;

            oVendedor.Contraseña = txtContraseña.Text;

           return oVendedor;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dgvVendedores.ClearSelection();

            if (indice >= 0)
            {
                txtID.Text = dgvVendedores.Rows[indice].Cells[0].Value.ToString();
                txtContraseña.Text = dgvVendedores.Rows[indice].Cells[1].Value.ToString();
                txtNombre.Text = dgvVendedores.Rows[indice].Cells[2].Value.ToString();

                btnAgregar.Enabled = false;
                btnBorrar.Enabled = true;
                btnModificar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            

        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oVendedorDAL.Eliminar(RecuperarInformacion());
            LLenarGrid();
            LimpiarEntradas();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oVendedorDAL.Modificar(RecuperarInformacion());
            LLenarGrid();
            LimpiarEntradas();
        }
        public void LLenarGrid()
        {
            dgvVendedores.DataSource = oVendedorDAL.MostrarVendedores().Tables[0];
        }
        public void LimpiarEntradas()
        {
            txtID.Text = "";
            txtNombre.Text = "";
            txtContraseña.Text = "";

            btnAgregar.Enabled = true;
            btnBorrar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarEntradas();
        }
    }
}
