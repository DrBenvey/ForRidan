using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository.Base
{
    public interface ICRUDRepository<T>
    {
        Task Create(T obj);
        Task<List<T>> Read();
        Task Update(T obj);
        Task Delete(int key);
    }
}
