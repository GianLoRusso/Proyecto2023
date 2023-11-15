using System;
using Domain;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Contracts;
using DAL.Contracts;
using DAL.Factory;

namespace BLL.ServicesBLL
{
    public sealed class ClienteBLL : IGenericBusinessRules <Cliente>
    {
        #region Singleton
        private readonly static ClienteBLL _instance = new ClienteBLL();
        private readonly static IGenericRepository<Cliente> dao = FactoryDAL.ClienteRepository;

        public static ClienteBLL Current
        { get 
            { 
                return _instance; 
            } 
        }
        
        private ClienteBLL ()
        {

        }
        #endregion

        public void Add(Cliente obj)
        {
            dao.Insert(obj);
        }

        public void Remove(int id)
        {
            dao.Delete(id);
        }

        public void Update(Cliente obj)
        {
            dao.Update(obj);
        }

        public IEnumerable<Cliente> GetAll(string filterExpression)
        {
            try
            {
                return dao.GetAll(filterExpression);
            }
            catch
            {
                //Services.Exceptions.Service.Handle(new DALException(ex));
                throw;
            }
        }

        public Cliente GetOne(int id)
        {
            try
            {
                return dao.GetOne(id);
            }
            catch 
            {
                //Services.Exceptions.Service.Handle(new BLLException(ex));
                return null;
            }
        }
    }

}
