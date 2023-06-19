using BelenSA.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelenSA.Models.ViewModels
{
    public class SubscriberViewModel
    {
        [Key]
        public int SubscriberId { get; set; }

        [StringLength(100, MinimumLength = 7, ErrorMessage ="Full name must be between 7 and 100 characteres")]
        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Full name")]
        public string SubscriberName { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [EmailAddress(ErrorMessage = "Please introduce a correct email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        [Required(ErrorMessage = "Please select how you heard about us")]
        [EnumDataType(typeof(HowTheyHeardEnum))]
        public HowTheyHeardEnum HowTheyHeardAboutUs { get; set; }

        public List<SelectListItem>? listReasons { get; set; }

        [Required(ErrorMessage = "Please select your reasons for subscribing")]
        [Display(Name = "Reasons for subscribing")]
        public int[] ReasonsIds { get; set; }   
    }
}
