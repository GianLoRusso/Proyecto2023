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
    public sealed class FacturaBLL : IGenericBusinessRules<Factura>
    {

        #region singleton
        private readonly static FacturaBLL instance = new FacturaBLL();
        private readonly static IGenericRepository<Factura> dao = FactoryDAL.FacturaRepository;

        public static FacturaBLL Current
        {
            get
            {
                return instance;
            }
        }
        private FacturaBLL()
        {

        }
        #endregion

        public void Add(Factura obj)
        {
            dao.Insert(obj);
        }

        public IEnumerable<Factura> GetAll(string filterExpression)
        {
           return dao.GetAll(filterExpression);
        }

        public Factura GetOne(int id)
        {
            return dao.GetOne(id);
        }

        public void Remove(int id)
        {
            dao.Delete(id);
        }

        public void Update(Factura obj)
        {
            dao.Update(obj);
        }
    }
}
