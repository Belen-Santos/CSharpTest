
using System.ComponentModel.DataAnnotations;

namespace BelenSA.Models.Enums
{
    public enum HowTheyHeardEnum
    {
        Advert = 1,
        [Display(Name = "Word of Mouth")]
        WordOfMouth,
        Other
    }
}
