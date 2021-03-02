using System.ComponentModel.DataAnnotations.Schema;

namespace DapperProject.Entities.Entities
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
