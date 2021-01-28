using System.ComponentModel.DataAnnotations;

namespace Slingshot.Models
{
    public class UserModel : ModelBase
    {
        public int AccountId
        {
            get; set;
        }

        [Required]
        [EmailAddress]
        public string Email
        {
            get; set;
        }

        [Required]
        [MaxLength(128)]
        public string FirstName
        {
            get; set;
        }

        [MaxLength(128)]
        public string LastName
        {
            get; set;
        }
    }
}