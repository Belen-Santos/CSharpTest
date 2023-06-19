using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BelenSA.Models
{
    public class SubscriberReasons
    {
        [Key]
        public int SubscriberReasonId { get; set; }  

        public int SubscriberId { get; set; }   

        public int ReasonSignUpId { get; set; } 

        [ForeignKey(nameof(ReasonSignUpId))]
        [InverseProperty(nameof(Models.ReasonSignUp.SubscriberReasons))]
        public virtual ReasonSignUp ReasonSignUp { get; set; }

        [ForeignKey(nameof(SubscriberId))]
        [InverseProperty("SubscriberReasons")]
        public virtual Subscriber Subscriber { get; set; }   

    }
}
