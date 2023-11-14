using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IGenericRepository<T> where T : class, new()
    {
        void Insert(T obj);
        //void Insert(T obj, Guid id); para que el @@identity me traiga el id del que acaba de insertar
        //void Insert(T obj, int id);para que el @@identity me traiga el id del que acaba de insertar

        void Delete(Guid id);
        //void Delete(int id);

        void Update(T obj);

        
        IEnumerable<T> GetAll(string filterExpression);

        T GetOne(Guid id);
        //T GetOne(int id);
    }

}
