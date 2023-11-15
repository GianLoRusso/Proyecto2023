using BLL.Contracts;
using DAL.Contracts;
using DAL.Factory;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServicesBLL
{
    public sealed class Orden_de_pedidoBLL : IGenericBusinessRules<Orden_de_pedido>
    {
        #region singlton
        private readonly static Orden_de_pedidoBLL instance = new Orden_de_pedidoBLL();
        private readonly static IGenericRepository<Orden_de_pedido> dao = FactoryDAL.Orden_de_pedidoRepository;

        public static Orden_de_pedidoBLL Current
        {
            get
            {
                return instance;
            }
        }
        private Orden_de_pedidoBLL()
        {

        }
        #endregion


        public void Add(Orden_de_pedido obj)
        {
            dao.Insert(obj);
        }

        public void Remove(int id)
        {
            dao.Delete(id);
        }

        public void Update(Orden_de_pedido obj)
        {
            dao.Update(obj);
        }

        public IEnumerable<Orden_de_pedido> GetAll(string filterExpression)
        {
            return dao.GetAll(filterExpression);
        }

        public Orden_de_pedido GetOne(int id)
        {
            return dao.GetOne(id);
        }
        

    }
}
