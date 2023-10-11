﻿using System;
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
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           
            MessageBox.Show("Conectado..");

            oVendedorDAL.Agregar(RecuperarInformacion());
            LLenarGrid();
        }
        private Vendedor RecuperarInformacion()
        {
            Vendedor oVendedor = new Vendedor();

            int ID = 0;

            int.TryParse(txtID.Text, out ID);

            oVendedor.ID = ID;

            oVendedor.Nombre = txtNombre.Text;

            oVendedor.Contraseña = txtContraseña.Text;

           return oVendedor;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            txtID.Text= dgvVendedores.Rows[indice].Cells[0].Value.ToString();
            txtContraseña.Text = dgvVendedores.Rows[indice].Cells[1].Value.ToString();
            txtNombre.Text = dgvVendedores.Rows[indice].Cells[2].Value.ToString();
        
        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oVendedorDAL.Eliminar(RecuperarInformacion());
            LLenarGrid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oVendedorDAL.Modificar(RecuperarInformacion());
            LLenarGrid();
        }
        public void LLenarGrid()
        {
            dgvVendedores.DataSource = oVendedorDAL.MostrarVendedores().Tables[0];
        }
    }
}
