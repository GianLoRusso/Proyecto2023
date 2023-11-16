using DAL.Contracts;
using DAL.Repositories.Sql;
using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Factory
{
    public static class FactoryDAL
    {
        readonly static string repository;

        public static IGenericRepository <Cliente> ClienteRepository { get; private set; }
        public static IGenericRepository <Vendedor> VendedorRepository { get; private set; }
        public static IGenericRepository <Producto> ProductoRepository { get; private set; }
        public static IGenericRepository<Pedido> PedidoRepository { get; private set; }
        public static IGenericRepository<DetallePedido> DetallePedidoRepository { get; private set; }
        public static IGenericRepository<Orden_de_pedido> Orden_de_pedidoRepository { get; private set; }
        public static IGenericRepository<Factura> FacturaRepository { get; private set; }
        public static IGenericRepository<FormadePago> FormadePagoRepository { get; private set; }
        public static IGenericRepository<TipoProducto> TipoProductoRepository { get; private set; }


        static FactoryDAL()
        {
            repository = ConfigurationManager.AppSettings["Repository"].ToString();

            ClienteRepository = (IGenericRepository<Cliente>) Activator.CreateInstance
                                (Type.GetType(repository + ".ClienteRepository"));
            VendedorRepository = (IGenericRepository<Vendedor>)Activator.CreateInstance
                                 (Type.GetType(repository + ".VendedorRepository"));
            ProductoRepository = (IGenericRepository<Producto>)Activator.CreateInstance
                                 (Type.GetType(repository + ".ProductoRepository"));
            PedidoRepository = (IGenericRepository<Pedido>)Activator.CreateInstance
                                (Type.GetType(repository + ".PedidoRepository"));
            DetallePedidoRepository = (IGenericRepository<DetallePedido>)Activator.CreateInstance
                                (Type.GetType(repository + ".DetallePedidoRepository"));
            Orden_de_pedidoRepository = (IGenericRepository<Orden_de_pedido>)Activator.CreateInstance
                                (Type.GetType(repository + ".Orden_de_pedidoRepository"));
            FacturaRepository = (IGenericRepository<Factura>)Activator.CreateInstance
                                (Type.GetType(repository + ".FacturaRepository"));
            FormadePagoRepository = (IGenericRepository<FormadePago>)Activator.CreateInstance
                                (Type.GetType(repository + ".FormadePagoRepository"));
            TipoProductoRepository = (IGenericRepository<TipoProducto>)Activator.CreateInstance
                                (Type.GetType(repository + ".TipoProductoRepository"));
        }
    }
}
