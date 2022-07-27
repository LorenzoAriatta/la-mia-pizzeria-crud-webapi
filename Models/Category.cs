using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace la_mia_pizzeria_static.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public List<Pizza> Pizze { get; set; }
    }
}
