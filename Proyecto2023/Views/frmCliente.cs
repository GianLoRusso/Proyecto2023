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
        }
    }
}
