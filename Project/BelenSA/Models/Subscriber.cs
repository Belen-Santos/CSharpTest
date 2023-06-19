using BelenSA.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelenSA.Models
{
    public class Subscriber
    {
        public Subscriber()
        {
            SubscriberReasons = new HashSet<SubscriberReasons>();    
        }

        [Key]
        public int SubscriberId { get; set; }

        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        [Required(ErrorMessage = "Please include your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please include your email address")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Column(TypeName = "nvarchar(MAX)")]
        [Required(ErrorMessage = "Please include how you heard about us")]
        [EnumDataType(typeof(HowTheyHeardEnum))]
        public HowTheyHeardEnum HowTheyHeardAboutUs { get; set; }

        [DataType(DataType.Date)]
        public DateTime SubscriptionDate { get; set; }

        //Relation many to many with ReasonSignUp
        [InverseProperty("Subscriber")]
        public virtual ICollection<SubscriberReasons> SubscriberReasons { get; set; }

    }
}
