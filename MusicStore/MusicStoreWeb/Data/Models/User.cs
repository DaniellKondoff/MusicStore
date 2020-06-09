using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static MusicStoreWeb.Data.DataConstants;

namespace MusicStoreWeb.Data.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(UserFirstNameMaxLength)]
        [MinLength(UserFirstNameMinLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(UserLastNameMaxLength)]
        [MinLength(UserLastNameMinLength)]
        public string LastName { get; set; }
    }
}
