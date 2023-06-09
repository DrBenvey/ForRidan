using DataAccess.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace DataAccess.Entities
{
    [Table("product")]
    public class Product : NamedId
    {       
        // todo можно при развитии добавлять поля
        // описание продукта
        // единицы измерения
        // поставщик и т.д.
    }
}
