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
    public sealed class TipoProductoBLL : IGenericBusinessRules<TipoProducto>
    {
        #region singleton
        private readonly static TipoProductoBLL _instance = new TipoProductoBLL();
        private readonly static IGenericRepository<TipoProducto> dao = FactoryDAL.TipoProductoRepository;

        public static TipoProductoBLL Instance 
        { 
            get 
            {  
                return _instance; 
            } 
        }

        private TipoProductoBLL()
        {

        }
        #endregion

        public void Add(TipoProducto obj)
        {
            dao.Insert(obj);
        }

        public IEnumerable<TipoProducto> GetAll(string filterExpression)
        {
            return dao.GetAll(filterExpression);
        }

        public TipoProducto GetOne(int id)
        {
            return dao.GetOne(id);
        }

        public void Remove(int id)
        {
            dao.Delete(id);
        }

        public void Update(TipoProducto obj)
        {
            dao.Update(obj);
        }
    }
}
