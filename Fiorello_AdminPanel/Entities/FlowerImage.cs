using System.ComponentModel.DataAnnotations;

namespace Fiorello_AdminPanel.Entities
{
    public class FlowerImage
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string ImageName { get; set; }
    }
}
