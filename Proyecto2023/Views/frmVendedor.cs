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
using BLL.ServicesBLL;

namespace Proyecto2023.Views
{
    public partial class frmVendedor : Form
    {
        public frmVendedor()
        {
            InitializeComponent();
        }
        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            string j = "";
            IEnumerable<Vendedor> vendedores = VendedorBLL.Current.GetAll(String.IsNullOrEmpty(j) ? null : j);
            dgvVendedores.DataSource = vendedores.ToList();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int vendedorid = (int)dgvVendedores.SelectedRows[0].Cells["ID_Vendedor"].Value;
            VendedorBLL.Current.Remove(vendedorid);

            string j = "";
            IEnumerable<Vendedor> vendedores = VendedorBLL.Current.GetAll(String.IsNullOrEmpty(j) ? null : j);
            dgvVendedores.DataSource = vendedores.ToList();
            MessageBox.Show("Vendedor eliminado", "Ejecución exitosa", MessageBoxButtons.OK);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Vendedor vendedor = new Vendedor();
            vendedor.Nombre = txtNombre.Text;
            vendedor.Contraseña = txtContraseña.Text;

            VendedorBLL.Current.Add(vendedor);
            MessageBox.Show("Vendedor agregado correctamente", "Ejecución exitosa", MessageBoxButtons.OK);
            string j = "";
            IEnumerable<Vendedor> vendedores = VendedorBLL.Current.GetAll(String.IsNullOrEmpty(j) ? null : j);
            dgvVendedores.DataSource = vendedores.ToList();
        }
        private void dgvVendedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmVendedor_Load(object sender, EventArgs e)
        {

        }

        
    }
}
