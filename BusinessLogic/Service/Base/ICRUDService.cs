﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Base
{
    public interface ICRUDService<T>: ICRService<T>
    {
        Task Update(T obj);
        Task Delete(int key);
    }
}
