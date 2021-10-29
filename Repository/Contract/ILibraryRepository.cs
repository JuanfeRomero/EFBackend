using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFBackEnd.Repository.Contract
{
    public interface ILibraryRepository<T>
    {
        IEnumerable<T> GetAll();
        T Post(T t);
        T Update(T t);
        int Delete(Guid id);
        T Get(Guid id);
    }
}
