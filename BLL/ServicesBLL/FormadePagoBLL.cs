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
    public sealed class FormadePagoBLL : IGenericBusinessRules<FormadePago>
    {
        #region singleton
        private readonly static FormadePagoBLL instance = new FormadePagoBLL();
        private readonly static IGenericRepository<FormadePago> dao = FactoryDAL.FormadePagoRepository;

        public static FormadePagoBLL Current
        {
            get
            {
                return instance;
            }
        }

        private FormadePagoBLL()
        {

        }
        #endregion
        public void Add(FormadePago obj)
        {
            dao.Insert(obj);
        }

        public IEnumerable<FormadePago> GetAll(string filterExpression)
        {
            return dao.GetAll(filterExpression);
        }

        public FormadePago GetOne(int id)
        {
            return dao.GetOne(id);
        }

        public void Remove(int id)
        {
            dao.Delete(id);
        }

        public void Update(FormadePago obj)
        {
            dao.Update(obj);
        }
    }
}
