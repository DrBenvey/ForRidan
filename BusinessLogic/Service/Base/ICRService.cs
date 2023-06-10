using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Base
{
    public interface ICRService<T>
    {
        Task<T> Create(T obj);
        Task<List<T>> Read();
    }
}
