using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fiorello_AdminPanel.Entities
{
    public class AppUser:IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }
        [NotMapped]
        public List<string> Roles { get; set; }
    }
}
