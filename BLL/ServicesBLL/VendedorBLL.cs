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
    public sealed class VendedorBLL : IGenericBusinessRules<Vendedor>
    {
        #region singleton
        private readonly static VendedorBLL instance = new VendedorBLL();
        private readonly static IGenericRepository<Vendedor> dao = FactoryDAL.VendedorRepository;

        public static VendedorBLL Curremt
        {
            get 
            {
                return instance;
            }
        }
        
        private VendedorBLL()
        {

        }
        #endregion
        public void Add(Vendedor obj)
        {
            dao.Insert(obj);
        }

        public IEnumerable<Vendedor> GetAll(string filterExpression)
        {
            return dao.GetAll(filterExpression);
        }

        public Vendedor GetOne(Guid id)
        {
            return dao.GetOne(id);
        }

        public void Remove(Guid id)
        {
            dao.Delete(id);
        }

        public void Update(Vendedor obj)
        {
            dao.Update(obj);
        }
    }
}
