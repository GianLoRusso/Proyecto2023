using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contracts
{
    public interface IGenericBusinessRules<T> where T : class, new()
    {
        void Add(T obj);

        void Remove(Guid id);

        void Update(T obj);

        IEnumerable<T> GetAll(string filterExpression);

        T GetOne(Guid id);
    }
}
