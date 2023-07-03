using Microsoft.AspNetCore.Http.Connections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiorello_AdminPanel.Entities
{
    public class Flower
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public bool SKU { get; set; }
        public List<FlowerImage> flowerImages { get; set; }
        public List<FlowerCategory> flowerCategories { get; set; }
        public List<FlowerTag> flowerTags { get; set; }
        [NotMapped]
        public IFormFile ImageName { get; set; }
    }
}
