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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void btnProducto_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            string j = "";
            IEnumerable<Producto> producto = ProductoBLL.Current.GetAll(String.IsNullOrEmpty(j) ? null : j);
            dgvProductos.DataSource = producto.ToList();
        }
    }
}
