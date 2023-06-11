using BusinessLogic.Repository.Base;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repository.StockRepository
{
    public interface IStockRepository : ICRUDRepository<Stock>
    {
    }
}
