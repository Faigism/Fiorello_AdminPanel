using Fiorello_AdminPanel.Attributes.CustomValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiorello_AdminPanel.Entities
{
    public class Slider
    {
        public int Id { get; set; }
        public int Order { get; set; }
        [MaxLength(50)]
        public string? Title1 { get; set; }
        [MaxLength(50)]
        public string? Title2 { get; set; }
        [MaxLength(100)]
        public string? Description { get; set; }
        [MaxLength(100)]
        public string? BtnTxt { get; set; }
        [MaxLength(100)]
        public string? ImageName { get; set; }
        [NotMapped]
        [MaxFileLength(2097152)]
        public IFormFile? ImageFile { get; set; }
    }
}
