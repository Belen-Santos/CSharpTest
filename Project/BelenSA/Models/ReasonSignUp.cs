using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BelenSA.Models
{
    public class ReasonSignUp
    {
        public ReasonSignUp() {}

        [Key]
        public int ReasonId { get; set; }

        [Required]  
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string ReasonName { get; set; }

        // Relation many to many with Subscriber
        [InverseProperty("ReasonSignUp")]
        //public List<Subscriber> Subscribers { get; } = new();
        public virtual ICollection<SubscriberReasons> SubscriberReasons { get; set; }

    }
}
