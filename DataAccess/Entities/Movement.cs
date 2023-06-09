using DataAccess.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    [Table("movement")]
    public class Movement : Id
    {
        public int id_stock { get; set; }
        public int id_product { get; set; }
        public DateTime сreated { get; set; }
        /// <summary>
        /// для простоты считаем что 
        /// все в штуках
        /// </summary>
        public Int64 balance { get; set; }
        [ForeignKey("id_stock")]
        public Stock? stock { get; set; }
        [ForeignKey("id_product")]
        public Product? product { get; set; }
    }
}
