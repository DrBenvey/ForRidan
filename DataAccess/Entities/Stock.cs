using DataAccess.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    [Table("stock")]

    public class Stock : NamedId
    {
        // todo можно при развитии добавлять поля
        // адресс склада
        // телефон и т.д.
    }
}
