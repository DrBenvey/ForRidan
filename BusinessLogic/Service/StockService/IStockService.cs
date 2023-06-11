using BusinessLogic.Service.Base;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.StockService
{
    public interface IStockService: ICRUDService<Stock>
    {
    }
}
