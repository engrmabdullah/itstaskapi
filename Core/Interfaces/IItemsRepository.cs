using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IItemsRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
        bool Save();

        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItemByItemId(int itemId);
        Task<IEnumerable<Step>> GetSteps();
        Task<Step> GetStepByStepId(int id);
        Task<IEnumerable<Item>> GetItemsbyStepId(int stepno);
        Task<Step> GetFristStep();
       Task<Step> GetLastStep();

    }
}
