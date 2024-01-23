using Homework.Models;

namespace Homework.Services
{
    public interface IPetService
    {
        public decimal GetPrice(IAnimal pet);
    }

    public class PetService : IPetService
    {
        public decimal GetPrice(IAnimal pet)
        {
            return (decimal)(pet.Price * 0.9);
        }
    }
}
