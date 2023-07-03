using System.ComponentModel.DataAnnotations;

namespace Fiorello_AdminPanel.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public List<FlowerTag> flowerTags { get; set; }
    }
}
