using Microsoft.AspNetCore.Mvc;
using BelenSA.Repositories.Interfaces;
using BelenSA.Models.ViewModels;

namespace BelenSA.Controllers
{
    public class SubscriberController : Controller
    {
        private ISubscriberRepository _subscriberRepository;

        public SubscriberController(ISubscriberRepository iSubscriber)
        {
            _subscriberRepository = iSubscriber; 
        }

        // GET: Subscriber/Create
        public IActionResult Create()
        {
            SubscriberViewModel model = _subscriberRepository.CreateSubscriberVMWithReasons();

            return View(model);
        }

        // POST: Subscriber/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubscriberId, SubscriberName, Email, HowTheyHeardAboutUs, ReasonsIds")] SubscriberViewModel model)
        {
            if (ModelState.IsValid)
            {
                _subscriberRepository.AddSubscriber(model);
            }
            else
            {
                UserMessagesViewModel.ErrorMessage = "The registration was not possible, sorry. Please try again with correct data.";
            }
            //return View(model);
            return RedirectToAction("Index", "Home");
        }
    }
}
