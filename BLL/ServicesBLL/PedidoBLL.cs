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
    public sealed class PedidoBLL : IGenericBusinessRules<Pedido>
    {
        #region siongleton
        private readonly static PedidoBLL Instance = new PedidoBLL();
        private readonly static IGenericRepository<Pedido> dao = FactoryDAL.PedidoRepository;

        public static PedidoBLL Current
        {
            get
            {
                return Instance;
            }
        }

        private PedidoBLL()
        {

        }
        #endregion

        public void Add(Pedido obj)
        {
            dao.Insert(obj);
        }

        public IEnumerable<Pedido> GetAll(string filterExpression)
        {
            return dao.GetAll(filterExpression);
        }

        public Pedido GetOne(int id)
        {
            return dao.GetOne(id);
        }

        public void Remove(int id)
        {
            dao.Delete(id);
        }

        public void Update(Pedido obj)
        {
            dao.Update(obj);
        }
    }
}
