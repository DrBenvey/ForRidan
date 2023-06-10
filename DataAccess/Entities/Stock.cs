using DataAccess.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    [Table("stock")]

    public class Stock : NamedId
    {
        public string address { get; set; }
    }
}
