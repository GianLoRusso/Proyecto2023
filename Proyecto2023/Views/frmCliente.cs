using BLL.ServicesBLL;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2023.Views
{
    public partial class frmCliente : Form
    {
        public frmCliente()
        {
            InitializeComponent();
        }

     
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = txtNombre.Text;
            cliente.Correo = txtCorreo.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Telefono = Convert.ToInt32(txtTelefono.Text);
            

            ClienteBLL.Current.Add(cliente);
            MessageBox.Show("Cliente agregado a la cartera", "Ejecución exitosa", MessageBoxButtons.OK);

            string j = "";
            IEnumerable<Cliente> clientes = ClienteBLL.Current.GetAll(String.IsNullOrEmpty(j) ? null : j);
            dgvClientes.DataSource = clientes.ToList();

            Clean();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            
            string j = "";
            IEnumerable<Cliente> clientes = ClienteBLL.Current.GetAll(String.IsNullOrEmpty(j) ? null : j); 
            dgvClientes.DataSource = clientes.ToList();

            
        }
        private void Clean()
        {
            txtNombre.Text=string.Empty;
            txtCorreo.Text=string.Empty;
            txtDireccion.Text=string.Empty;
            txtTelefono.Text=string.Empty;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            
            int clienteid = (int)dgvClientes.SelectedRows[0].Cells["ID_Cliente"].Value;
            ClienteBLL.Current.Remove(clienteid);

            string j = "";
            IEnumerable<Cliente> clientes = ClienteBLL.Current.GetAll(String.IsNullOrEmpty(j) ? null : j);
            dgvClientes.DataSource = clientes.ToList();
            MessageBox.Show("Cliente eliminado de la cartera", "Ejecución exitosa", MessageBoxButtons.OK);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //string j = "";
            //  int clienteid = (int)dgvClientes.SelectedRows[0].Cells["ID_Cliente"].Value;

            //ClienteBLL.Current.Update(clienteid);

            
            //IEnumerable<Cliente> clientes = ClienteBLL.Current.GetAll(String.IsNullOrEmpty(j) ? null : j);
            //dgvClientes.DataSource = clientes.ToList();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
