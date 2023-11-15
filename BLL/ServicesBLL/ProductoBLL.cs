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
    public sealed class ProductoBLL : IGenericBusinessRules<Producto>
    {
        #region singleton
        private readonly static ProductoBLL instance = new ProductoBLL();
        private readonly static IGenericRepository<Producto> dao = FactoryDAL.ProductoRepository;

        public static ProductoBLL Current
        {
            get
            {
                return instance;
            }
        }

        private ProductoBLL()
        {

        }
        #endregion

        public void Add(Producto obj)
        {
            dao.Insert(obj);
        }

        public IEnumerable<Producto> GetAll(string filterExpression)
        {
            return dao.GetAll(filterExpression);
        }

        public Producto GetOne(int id)
        {
            return dao.GetOne(id);
        }

        public void Remove(int id)
        {
            dao.Delete(id);
        }

        public void Update(Producto obj)
        {
            dao.Update(obj);
        }
    }
}
