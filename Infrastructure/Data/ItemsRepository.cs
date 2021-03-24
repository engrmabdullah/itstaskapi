using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
   public class ItemsRepository : IItemsRepository
    {
        private readonly TaskDbContext _context;

        public ItemsRepository(TaskDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            var list = _context.tbl_Items
                .ToListAsync();
            return await list;
        }

        public async Task<Item> GetItemByItemId(int itemId)
        {
            var row = _context.tbl_Items
                .Where(s => s.id == itemId)
                .FirstOrDefaultAsync();
            return await row;
        }


        public async Task<IEnumerable<Step>> GetSteps()
        {
            var list = _context.Tbl_Steps
                .ToListAsync();
            return await list;
        }

        public async Task<IEnumerable<Item>> GetItemsbyStepId(int stepno)
        {
            var list = _context.tbl_Items.Where(i => i.stepno == stepno)
                .ToListAsync();
            return await list;
        }

        public async Task<Step> GetStepByStepId(int id)
        {
            var row = _context.Tbl_Steps
                .Where(s => s.id == id)
                .FirstOrDefaultAsync();
            return await row;
        }


        public async Task<Step> GetFristStep()
        {
            var row = _context.Tbl_Steps
                .OrderBy(s => s.id)
                .FirstOrDefaultAsync();
            return await row;
        }

        public async Task<Step> GetLastStep()
        {
            var row = _context.Tbl_Steps
                .OrderByDescending(s => s.id)
                .FirstOrDefaultAsync();
            return await row;
        }
    }
}
