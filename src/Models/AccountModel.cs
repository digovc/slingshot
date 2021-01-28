using System.ComponentModel.DataAnnotations;

namespace Slingshot.Models
{
    public class AccountModel : ModelBase
    {
        [Required]
        [MaxLength(128)]
        public string CompanyName
        {
            get; set;
        }

        public string Website
        {
            get; set;
        }
    }
}