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
    public sealed class DetallePedidoBLL : IGenericBusinessRules<DetallePedido>
    {
        #region singleton
        private readonly static DetallePedidoBLL instance = new DetallePedidoBLL();
        private readonly static IGenericRepository<DetallePedido> dao = FactoryDAL.DetallePedidoRepository;

        public static DetallePedidoBLL Current
        {
            get
            {
                return instance;
            }
        }
        
        private DetallePedidoBLL()
        {

        }
        #endregion

        public void Add(DetallePedido obj)
        {
            dao.Insert(obj);
        }

        public IEnumerable<DetallePedido> GetAll(string filterExpression)
        {
            return dao.GetAll(filterExpression);
        }

        public DetallePedido GetOne(int id)
        {
            return dao.GetOne(id);
        }

        public void Remove(int id)
        {
            dao.Delete(id);
        }

        public void Update(DetallePedido obj)
        {
            dao.Update(obj);
        }
    }
}
