﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository.Base
{
    public interface ICRUDRepository<T>: ICRRepository<T>
    {
        Task Update(T obj);
        Task Delete(int key);
    }
}
