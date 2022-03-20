using Business.ViewModels.CardVM;
using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface ICardService
    {
        Task<List<CardGetVM>> GetAllAsync();
        Task<Card> GetAsync(int id);
        Task CreateAsync(CardCreateVM createVM);
        CardUpdateVM Update(int id);
        Task UpdateAsync(int id, CardUpdateVM updateVM);
        Task RemoveAsync(int id);
    }
}
