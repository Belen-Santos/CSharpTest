using BelenSA.Models.ViewModels;

namespace BelenSA.Repositories.Interfaces
{
    public interface ISubscriberRepository
    {
        SubscriberViewModel CreateSubscriberVMWithReasons();
        void AddSubscriber(SubscriberViewModel model);
    }
}
