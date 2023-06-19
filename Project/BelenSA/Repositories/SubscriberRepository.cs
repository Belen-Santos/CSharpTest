using BelenSA.Data;
using BelenSA.Models;
using BelenSA.Models.ViewModels;
using BelenSA.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BelenSA.Repositories
{
    public class SubscriberRepository : ISubscriberRepository
    {   
        private ApplicationDbContext _dbContext;

        public SubscriberRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public SubscriberViewModel CreateSubscriberVMWithReasons()
        {
            SubscriberViewModel model = new SubscriberViewModel();
           
            //Adding the reasons of the database to the model
            model.listReasons = _dbContext.ReasonsForSigningUp.Select(reason => new SelectListItem { Text = reason.ReasonName, Value = reason.ReasonId.ToString() }).ToList();
         
            return model;
        }

        public void AddSubscriber(SubscriberViewModel model)
        {
            Subscriber subscriber = new Subscriber();   
            List<SubscriberReasons> subscriberReasons = new List<SubscriberReasons>();

            // Check if the email is already in the database
            var checkIfEmailExist = _dbContext.Subscribers.Any(e => e.Email == model.Email);

            // If the user didn't previously regsitered with the same email, we add it into the database
            if (!checkIfEmailExist)
            {
                subscriber.Name = model.SubscriberName;
                subscriber.Email = model.Email; 
                subscriber.HowTheyHeardAboutUs = model.HowTheyHeardAboutUs; 
                subscriber.SubscriptionDate = DateTime.Now;
                if (model.ReasonsIds.Length > 0)
                {
                    foreach (var reasonId in model.ReasonsIds)
                    {
                        subscriberReasons.Add(new SubscriberReasons { ReasonSignUpId = reasonId, SubscriberId = model.SubscriberId});
                    }  
                    subscriber.SubscriberReasons = subscriberReasons;   
                }
                _dbContext.Subscribers.Add(subscriber);
                _dbContext.SaveChanges();
                UserMessagesViewModel.SuccessMessage = "You have subscribed successfully! Thank you.";
           
            }
            else
            {
                UserMessagesViewModel.ErrorMessage = "You have already subscribed with this email. Thank you";
            }
        }
    }
}
