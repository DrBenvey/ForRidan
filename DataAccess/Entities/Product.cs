using DataAccess.Base;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    [Table("product")]
    public class Product : NamedId
    {
        public Product()
        {

        }

        public Product(string json)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            id = (int)data.id;
            name = data.name;
            weight = data.weight;
        }
        public double weight { get; set; }
    }
}
