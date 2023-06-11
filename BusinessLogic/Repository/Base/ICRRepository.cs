using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository.Base
{
    public interface ICRRepository<T>
    {
        Task<T> Create(T obj);
        Task<List<T>> Read();
        
    }
}
